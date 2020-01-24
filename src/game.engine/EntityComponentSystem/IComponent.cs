namespace Game.Engine.EntityComponentSystem
{
    public interface IComponent
    {
        IEntityRecord Record { get; set; }
    }
}
