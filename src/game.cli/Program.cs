using Game.Engine.EntityComponentSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Game.Engine.Graphics;
using Game.Engine.Gui;

using SharpFont;

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

            var label = new Label(levensloop.UI, "Text", "Arial", 15);

            var fontCollection = new FontCollection();
            fontCollection.AddFontFile("Assets/Fonts/COUR.TTF");

            
            var fontFace = fontCollection.Load("courier new"); ///new FontFace(File.OpenRead("Assets/Fonts/COUR.TTF"));

            var glyph = fontFace.GetGlyph(new CodePoint('A'), 32);

            var test = new SharpFont.Surface();
            glyph.RenderTo(test);



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