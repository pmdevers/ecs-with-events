using System.Collections.Generic;

namespace Game.Engine
{
    public interface ISystemRegistery : IEnumerable<ISystem>
    {
        T GetSystem<T>() where T : ISystem;

        void Register<T>(T system) where T : ISystem;
    }
}