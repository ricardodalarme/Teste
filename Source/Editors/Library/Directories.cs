﻿using System.IO;
using System.Windows.Forms;
using CryBits.Editors.Media;
using CryBits.Editors.Media.Audio;

namespace CryBits.Editors.Library
{
    internal static class Directories
    {
        // Formato de todos os arquivos de dados
        public const string Format = ".dat";

        // Editor
        public static readonly FileInfo Options = new FileInfo(Application.StartupPath + @"\Options" + Format);

        // Cliente
        public static readonly DirectoryInfo Fonts = new DirectoryInfo(Application.StartupPath + @"\Graphics\Fonts\");
        public static readonly DirectoryInfo Sounds = new DirectoryInfo(Application.StartupPath + @"\Audio\Sounds\");
        public static readonly DirectoryInfo Musics = new DirectoryInfo(Application.StartupPath + @"\Audio\Musics\");
        public static readonly DirectoryInfo Tiles = new DirectoryInfo(Application.StartupPath + @"\Data\Tiles\");
        public static readonly FileInfo Tools = new FileInfo(Application.StartupPath + @"\Data\Tools" + Format);
        public static readonly DirectoryInfo Tex_Panels = new DirectoryInfo(Application.StartupPath + @"\Graphics\Interface\Panels\");
        public static readonly FileInfo Tex_CheckBox = new FileInfo(Application.StartupPath + @"\Graphics\Interface\CheckBox");
        public static readonly FileInfo Tex_TextBox = new FileInfo(Application.StartupPath + @"\Graphics\Interface\TextBox");
        public static readonly DirectoryInfo Tex_Buttons = new DirectoryInfo(Application.StartupPath + @"\Graphics\Interface\Buttons\");
        public static readonly DirectoryInfo Tex_Characters = new DirectoryInfo(Application.StartupPath + @"\Graphics\Characters\");
        public static readonly DirectoryInfo Tex_Faces = new DirectoryInfo(Application.StartupPath + @"\Graphics\Faces\");
        public static readonly DirectoryInfo Tex_Panoramas = new DirectoryInfo(Application.StartupPath + @"\Graphics\Panoramas\");
        public static readonly DirectoryInfo Tex_Fogs = new DirectoryInfo(Application.StartupPath + @"\Graphics\Fogs\");
        public static readonly DirectoryInfo Tex_Tiles = new DirectoryInfo(Application.StartupPath + @"\Graphics\Tiles\");
        public static readonly DirectoryInfo Tex_Items = new DirectoryInfo(Application.StartupPath + @"\Graphics\Items\");
        public static readonly FileInfo Tex_Grid = new FileInfo(Application.StartupPath + @"\Graphics\Misc\Grid");
        public static readonly FileInfo Tex_Weather = new FileInfo(Application.StartupPath + @"\Graphics\Misc\Weather");
        public static readonly FileInfo Tex_Blanc = new FileInfo(Application.StartupPath + @"\Graphics\Misc\Blank");
        public static readonly FileInfo Tex_Directions = new FileInfo(Application.StartupPath + @"\Graphics\Misc\Directions");
        public static readonly FileInfo Tex_Transparent = new FileInfo(Application.StartupPath + @"\Graphics\Misc\Transparent");
        public static readonly FileInfo Tex_Lighting = new FileInfo(Application.StartupPath + @"\Graphics\Misc\Lighting");

        public static void Create()
        {
            // Cria os diretórios
            Fonts.Create();
            Sounds.Create();
            Musics.Create();
            Tiles.Create();
            Tools.Directory.Create();
            Tex_Panoramas.Create();
            Tex_Fogs.Create();
            Tex_Characters.Create();
            Tex_Faces.Create();
            Tex_Panels.Create();
            Tex_Buttons.Create();
            Tex_CheckBox.Directory.Create();
            Tex_TextBox.Directory.Create();
            Tex_Tiles.Create();
            Tex_Grid.Directory.Create();
            Tex_Weather.Directory.Create();
            Tex_Blanc.Directory.Create();
            Tex_Directions.Directory.Create();
            Tex_Transparent.Directory.Create();
            Tex_Lighting.Directory.Create();
            Tex_Items.Create();

            // Lê os dados do lado do cliente
            Graphics.Init();
            Sound.Load();
            Read.Tiles();
            Read.Tools();
        }
    }
}