using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Gui.Fonts.Internal
{
    internal class CharacterMap
    {
        private Dictionary<CodePoint, int> _table;

        public CharacterMap(Dictionary<CodePoint, int> table)
        {
            _table = table;
        }

        public int Lookup(CodePoint codePoint)
        {
            int index;
            if (_table.TryGetValue(codePoint, out index))
            {
                return index;
            }
            return -1;
        }

        public static CharacterMap ReadMap(DataReader reader, TableRecord[] tables)
        {
        }
    }
}