using Game.Engine.EntityComponentSystem;

namespace FinancialPlanner.Engine.Tests
{
    public class TestComponent : IComponent
    {
        public IEntityRecord Record { get; set; }
    }
}
