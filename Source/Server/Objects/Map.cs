﻿using System;
using System.Collections.Generic;

namespace Objects
{
    [Serializable]
    class Map : Lists.Structures.Data
    {
        public short Revision;
        public List<Map_Layer> Layer = new List<Map_Layer>();
        public Map_Tile[,] Tile ;
        public string Name = string.Empty;
        public byte Width = Game.Min_Map_Width;
        public byte Height = Game.Min_Map_Height;
        public byte Moral;
        public byte Panorama;
        public byte Music;
        public int Color = -1;
        public Map_Weather Weather = new Map_Weather();
        public Map_Fog Fog = new Map_Fog();
        public Map[] Link = new Map[(byte)Game.Directions.Count];
        public byte Light_Global;
        public byte Lighting = 100;
        public Map_Light[] Light = Array.Empty<Map_Light>();
        public Map_NPC[] NPC = Array.Empty<Map_NPC>();

        public Map(Guid ID) : base(ID) { }

        public bool OutLimit(short X, short Y)
        {
            // Verifica se as coordenas estão no limite do mapa
            return X > Width || Y > Height || X < 0 || Y < 0;
        }

        public bool Tile_Blocked(short X, short Y)
        {
            // Verifica se o azulejo está bloqueado
            if (OutLimit(X, Y)) return true;
            if (Tile[X, Y].Attribute == (byte)global::Map.Attributes.Block) return true;
            return false;
        }
    }


    [Serializable]
    class Map_Tile
    {
        public byte Attribute;
        public short Data_1;
        public short Data_2;
        public short Data_3;
        public short Data_4;
        public string Data_5;
        public byte Zone;
        public bool[] Block = new bool[(byte)Game.Directions.Count];
    }

    [Serializable]
    class Map_Layer
    {
        public string Name;
        public byte Type;
        public Map_Tile_Data[,] Tile ;

        public Map_Layer(byte Width, byte Height)
        {
            Tile = new Map_Tile_Data[Width + 1, Height + 1];
        }
    }

    [Serializable]
    class Map_NPC
    {
        public NPC NPC;
        public byte Zone;
        public bool Spawn;
        public byte X;
        public byte Y;
    }

    [Serializable]
    class Map_Tile_Data
    {
        public byte X;
        public byte Y;
        public byte Tile;
        public bool Auto;
    }

    [Serializable]
    class Map_Light
    {
        public byte X;
        public byte Y;
        public byte Width;
        public byte Height;
    }

    [Serializable]
    class Map_Weather
    {
        public byte Type;
        public byte Intensity;
    }

    [Serializable]
    class Map_Fog
    {
        public byte Texture;
        public sbyte Speed_X;
        public sbyte Speed_Y;
        public byte Alpha = 255;
    }
}