using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Game.Engine.Tools
{
    public static class AddressHelper
    {
        private static readonly object mutualObject;
        private static readonly ObjectReinterpreter reinterpreter;

        static AddressHelper()
        {
            mutualObject = new object();
            reinterpreter = new ObjectReinterpreter { AsObject = new ObjectWrapper() };
        }

        public static IntPtr GetAddress(object obj)
        {
            lock (mutualObject)
            {
                reinterpreter.AsObject.Object = obj;
                IntPtr address = reinterpreter.AsIntPtr.Value;
                reinterpreter.AsObject.Object = null;
                return address;
            }
        }

        public static T GetInstance<T>(IntPtr address)
        {
            lock (mutualObject)
            {
                reinterpreter.AsIntPtr.Value = address;
                return (T)reinterpreter.AsObject.Object;
            }
        }

        // I bet you thought C# was type-safe.
        [StructLayout(LayoutKind.Explicit)]
        private struct ObjectReinterpreter
        {
            [FieldOffset(0)] public ObjectWrapper AsObject;
            [FieldOffset(0)] public IntPtrWrapper AsIntPtr;
        }

        private class ObjectWrapper
        {
            public object Object;
        }

        private class IntPtrWrapper
        {
            public IntPtr Value;
        }
    }
}
