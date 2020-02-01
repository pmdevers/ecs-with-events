using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine.Renderer
{
    public enum ShaderDataType : int
    {
        None = 0, 
        Float, 
        Float2, 
        Float3 ,
        Float4 ,
        Mat3,
        Mat4, 
        Int ,
        Int2 , 
        Int3 ,
        Int4 , 
        Bool  

    }
    
    public class BufferElement
    {
        public string Name;
        public ShaderDataType Type;
        public int Size;
        public bool Normalized;
        public int Offset;
        

        public BufferElement(ShaderDataType type, string name, bool normalized = false)
        {
            Name = name;
            Normalized = normalized;
            Type = type;
            Size = GetShaderDataTypeSize(type);
            Offset = 0;
        }

        public int GetComponentCount()
        {
            switch (Type)
            {
                case ShaderDataType.None: return 0;
                case ShaderDataType.Float: return 1;
                case ShaderDataType.Float2: return 2;
                case ShaderDataType.Float3: return 3;
                case ShaderDataType.Float4: return 4;
                case ShaderDataType.Mat3: return 3 * 3;
                case ShaderDataType.Mat4: return 4 * 4;
                case ShaderDataType.Int: return 1;
                case ShaderDataType.Int2: return 2;
                case ShaderDataType.Int3: return 3;
                case ShaderDataType.Int4: return 4;
                case ShaderDataType.Bool: return 1;
            }
            return 0;
        }

        private int GetShaderDataTypeSize(ShaderDataType datatype)
        {
            switch (datatype)
            {
                case ShaderDataType.Float: return 4;
                case ShaderDataType.Float2: return 4 * 2;
                case ShaderDataType.Float3: return 4 * 3;
                case ShaderDataType.Float4: return 4 * 4;
                case ShaderDataType.Mat3: return 4 * 3 * 3;
                case ShaderDataType.Mat4: return 4 * 4 * 4;
                case ShaderDataType.Int: return 4;
                case ShaderDataType.Int2: return 4 * 2;
                case ShaderDataType.Int3: return 4 * 3;
                case ShaderDataType.Int4: return 4 * 4;
                case ShaderDataType.Bool: return 1;
            }
            return 0;
        }
    }

    public class BufferLayout
    {
        private int _stride = 0;
        public BufferLayout(Dictionary<string, ShaderDataType> elements)
        {

            Elements = elements.Select(x => new BufferElement(x.Value, x.Key, false)).ToArray(); 
            CalculateOffsetAndStride();
        }

        private void CalculateOffsetAndStride()
        {
            int offset = 0;
            _stride = 0;
            foreach (var element in Elements)
            {
                element.Offset = offset;
                offset += element.Size;
                _stride += element.Size;
            }
        }

        public int GetStride()
        {
            return _stride;
        }

        public BufferElement[] Elements { get; }

       
    }
}
