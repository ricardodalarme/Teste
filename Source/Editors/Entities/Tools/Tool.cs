﻿using CryBits.Editors.Logic;
using System.Drawing;

namespace CryBits.Editors.Entities
{
    class Tool
    {
        // Informações gerais de todas as ferramentas
        public string Name { get; set; }
        public Point Position { get; set; }
        public bool Visible { get; set; }
        public Windows Window { get; set; }
    }
}
