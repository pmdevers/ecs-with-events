using Game.Engine.EntityComponentSystem;

namespace Game.Engine
{
    public abstract class Component : IComponent
    {
        public IEntityRecord Record { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} - {Record.Name}";
        }
    }
}