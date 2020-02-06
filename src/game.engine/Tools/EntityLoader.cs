using Game.Engine.EntityComponentSystem;
using Game.Engine.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Game.Engine
{
    public class EntityLoader
    {
        public class Entity
        {
            public string Id { get; set; }
            public Dictionary<string, JsonElement> Components { get; set; }
        }

        private readonly IDictionary<string, Type> _cachedTypes;
        private readonly IEntityRegistery _registery;
        private readonly JsonSerializerOptions _options;

        public EntityLoader(IEntityRegistery registery)
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new JsonStringEnumConverter());
            _options.Converters.Add(new VectorConverter());

            var type = typeof(IComponent);
            _cachedTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .ToDictionary(x => x.Name.Replace("Component", string.Empty), y => y);
            _registery = registery;
        }

        public void LoadLevel(string json)
        {
            var obj = JsonSerializer.Deserialize<Entity[]>(json, _options);
            foreach (var obj1 in obj)
            {
                var entity = _registery.Create(obj1.Id);

                foreach (var c in obj1.Components)
                {
                    if (_cachedTypes.ContainsKey(c.Key))
                    {
                        var component = (IComponent)JsonSerializer.Deserialize(c.Value.ToString(), _cachedTypes[c.Key], _options);
                        entity.AddComponent(component);
                    }
                }
            }
        }

        public void LoadEntityJson(string json)
        {
            var obj = JsonSerializer.Deserialize<Entity>(json, _options);
            var entity = _registery.Create(obj.Id);

            foreach (var c in obj.Components)
            {
                if (_cachedTypes.ContainsKey(c.Key))
                {
                    var component = (IComponent)JsonSerializer.Deserialize(c.Value.ToString(), _cachedTypes[c.Key], _options);
                    entity.AddComponent(component);
                }
            }
        }
    }
}