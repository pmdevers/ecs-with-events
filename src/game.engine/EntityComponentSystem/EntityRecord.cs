namespace Game.Engine.EntityComponentSystem
{
    internal struct EntityRecord : IEntityRecord
    {
        internal EntityRecord(string name, IEntityRegistery registry)
        {
            Name = name;
            Registery = registry;
        }

        public string Name { get; }
        public IEntityRegistery Registery { get; }
    }
}