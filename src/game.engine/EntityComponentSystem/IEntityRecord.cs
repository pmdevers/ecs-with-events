namespace Game.Engine.EntityComponentSystem
{
    public interface IEntityRecord
    {
        string Name { get; }
        IEntityRegistery Registery { get; }
    }
}