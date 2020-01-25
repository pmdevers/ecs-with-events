using Game.Engine.EntityComponentSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Game.Engine
{
    public class EntityLoader
    {
        public class Entity
        {
            public string Id { get; set; }
            public Dictionary<string, JsonElement> Components { get; set; }
        }

        private IDictionary<string, Type> _cachedTypes;
        private readonly IEntityRegistery _registery;

        public EntityLoader(IEntityRegistery registery)
        {
            var type = typeof(IComponent);
            _cachedTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .ToDictionary(x => x.Name.Replace("Component", string.Empty), y => y);
            _registery = registery;
        }

        public void LoadJson(string json)
        {
            var obj = JsonSerializer.Deserialize<Entity>(json);
            var entity = _registery.Create(obj.Id);

            foreach (var c in obj.Components)       
            {
                if (_cachedTypes.ContainsKey(c.Key))
                {
                   var component =  (IComponent)JsonSerializer.Deserialize(c.Value.ToString(), _cachedTypes[c.Key]);
                   entity.AddComponent(component);
                }
            }
            
        }

    }
}
