using Game.Engine.EntityComponentSystem;

using Xunit;

namespace FinancialPlanner.Engine.Tests
{
    public class Registery_Test
    {
        [Fact]
        public void Created_Entity_IsAdded()
        {
            var registery = new EntityRegistery();

            var entity = registery.Create("Test Entity");

            Assert.True(registery.Contains(entity));
        }

        [Fact]
        public void RemoveEntity()
        {
            var registery = new EntityRegistery();

            var entity = registery.Create("Test Entity");

            Assert.True(registery.Contains(entity));
            Assert.True(registery.Remove(entity));
            Assert.False(registery.Contains(entity));
        }

        [Fact]
        public void Add_Component_To_Entity()
        {
            var registery = new EntityRegistery();

            var entity = registery.Create();
            var testComponent = new TestComponent();

            registery.Add(entity,  testComponent);

            var component = registery.GetComponent<TestComponent>(entity);
                                  

            Assert.Equal(testComponent, component);
        }


    }
}
