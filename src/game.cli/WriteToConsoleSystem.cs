using System;

using Game.Engine.Systems;

namespace Game.Cli
{
    public class WriteToConsoleSystem : EntitySystem
    {
        public override void Update(TimeSpan gameTime)
        {
            foreach(var e in GetAllEntities())
            {
                Console.WriteLine(e.Name);

                foreach(var c in Registery.GetComponents(e))
                {
                    Console.WriteLine(c.ToString());
                }
            }
        }
    }
}
