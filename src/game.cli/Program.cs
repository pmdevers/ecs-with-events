using Game.Engine.EntityComponentSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Game.Engine.Graphics;
using Game.Engine.Gui;

namespace Game.Cli
{
    internal class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private static int Main(string[] args)
        {
            var returnValue = new Program().Run();
            return returnValue;
        }

        private int Run()
        {
            var levensloop = new Engine.Game();

            var label = new Label(levensloop.UIContext, "Text", "Arial", 15);

            
            levensloop.Registery.Register(new WriteToConsoleSystem());
            levensloop.EntityLoader.LoadLevel(File.ReadAllText("Level1.json"));

            //levensloop.EntityLoader.LoadJson(File.ReadAllText("camera.json"));
            //levensloop.EntityLoader.LoadJson(File.ReadAllText("square.json"));
            //levensloop.EntityLoader.LoadJson(File.ReadAllText("triangle.json"));

            levensloop.Run();

            return 0;
        }
    }
}