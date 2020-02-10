using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Game.Engine.Gui.Fonts.Internal
{
    internal sealed unsafe class DataReader : IDisposable
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly GCHandle _handle;
        private readonly byte* _start;
        private readonly int _maxReadLenght;
        private int _readOffset;
        private int _writeOffset;

        public uint Position => (uint)(_stream.Position - (_writeOffset - _readOffset));

        public DataReader(Stream stream, int maxReadLength = 4096)
        {
            _stream = stream;
            _maxReadLenght = maxReadLength;
            _buffer = new byte[maxReadLength * 2];
            _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            _start = (byte*)_handle.AddrOfPinnedObject();
        }

        public void Dispose()
        {
            if (_handle.IsAllocated)
                _handle.Free();
        }

        public byte ReadByte() => *Read(1);

        public byte[] ReadBytes(int count)
        {
            var result = new byte[count];
            int index = 0;
            while (count > 0)
            {
                var readCount = Math.Min(count, _maxReadLenght);
                Marshal.Copy(new IntPtr(Read(readCount)), result, index, readCount);

                count -= readCount;
                index += readCount;
            }

            return result;
        }

        public void Seek(uint position)
        {
            var current = _stream.Position;
            if (position < current - _writeOffset || position >= current)
            {
                _readOffset = 0;
                _writeOffset = 0;
                _stream.Position = position;
            }
            else
            {
                _readOffset = (int)(position - current + _writeOffset);
                CheckWrapAround(0);
            }
        }

        public void Skip(int count)
        {
            _readOffset += count;
            if (_readOffset < _writeOffset)
            {
                CheckWrapAround(0);
            }
            else
            {
                var seekCount = _readOffset - _writeOffset;
                if (seekCount > 0)
                {
                    _stream.Position += seekCount;
                }

                _readOffset = 0;
                _writeOffset = 0;
            }
        }

        private byte* Read(int count)
        {
            var result = _start + _readOffset;
            _readOffset += count;

            if (_readOffset >= _writeOffset)
            {
                if (count > _maxReadLenght)
                {
                    throw new InvalidOperationException("Tried to read more data than max read lenght.")
                }

                var need = _readOffset - _writeOffset;
                while (need > 0)
                {
                    int read = _stream.Read(_buffer, _writeOffset, Math.Min(_maxReadLenght, _buffer.Length - _writeOffset));
                    if (read <= 0)
                    {
                        throw new EndOfStreamException();
                    }

                    _writeOffset += read;
                    need -= read;
                }

                if (CheckWrapAround(count))
                {
                    result = _start;
                }
            }

            return result;
        }

        private bool CheckWrapAround(int dataCount)
        {
            if (_readOffset >= _maxReadLenght)
            {
                var copyCount = _writeOffset - _readOffset + dataCount;
                if (copyCount > 0)
                {
                    Buffer.BlockCopy(_buffer, _readOffset - dataCount, _buffer, 0, copyCount);
                }

                _readOffset = dataCount;
                _writeOffset = copyCount;
                return true;
            }

            return false;
        }

        private static uint htonl(uint value)
        {
            if (!BitConverter.IsLittleEndian)
                return value;

            var ptr = (byte*)&value;
            return (uint)(ptr[0] << 24 | ptr[1] << 16 | ptr[2] << 8 | ptr[3]);
        }

        private static ushort htons(ushort value)
        {
            if (!BitConverter.IsLittleEndian)
                return value;

            var ptr = (byte*)&value;
            return (ushort)(ptr[0] << 8 | ptr[1]);
        }
    }
}