using System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Engine
{
    public class SystemRegistery : ISystemRegistery
    {
        private readonly IDictionary<Type, ISystem> _systems = new Dictionary<Type, ISystem>();

        public void Register<T>(T system) where T : ISystem
        {
            var systemType = typeof(T);
            if (_systems.ContainsKey(systemType))
                throw new InvalidOperationException($"System '{systemType.Name}' already added to the registery.");

            _systems.Add(systemType, system);
        }

        public T GetSystem<T>() where T : ISystem
        {
            var systemType = typeof(T);
            if (!_systems.TryGetValue(systemType, out ISystem system))
                throw new InvalidOperationException($"System '{systemType.Name}' not found in the registery.");

            return (T)system;
        }

        public IEnumerator<ISystem> GetEnumerator()
        {
            return _systems.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _systems.Values.GetEnumerator();
        }
    }
}
