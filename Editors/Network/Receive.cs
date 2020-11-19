﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CryBits.Editors.Forms;
using CryBits.Entities;
using CryBits.Packets;
using Lidgren.Network;
using static CryBits.Defaults;
using static CryBits.Utils;

namespace CryBits.Editors.Network
{
    internal static class Receive
    {
        public static void Handle(NetIncomingMessage data)
        {
            // Manuseia os dados recebidos
            switch ((ServerPackets)data.ReadByte())
            {
                case ServerPackets.Alert: Alert(data); break;
                case ServerPackets.Connect: Connect(); break;
                case ServerPackets.ServerData: ServerData(data); break;
                case ServerPackets.Classes: Classes(data); break;
                case ServerPackets.Map: Map(data); break;
                case ServerPackets.NPCs: NPCs(data); break;
                case ServerPackets.Items: Items(data); break;
                case ServerPackets.Shops: Shops(data); break;
            }
        }

        private static void Alert(NetIncomingMessage data)
        {
            // Mostra a mensagem
            MessageBox.Show(data.ReadString());
        }

        private static void Connect()
        {
            // Abre a janela principal
            Login.Form.Visible = false;
            EditorMaps.Form = new EditorMaps();
        }

        private static void ServerData(NetIncomingMessage data)
        {
            // Lê os dados
            GameName = data.ReadString();
            WelcomeMessage = data.ReadString();
            Port = data.ReadInt16();
            MaxPlayers = data.ReadByte();
            MaxCharacters = data.ReadByte();
            MaxPartyMembers = data.ReadByte();
            MaxMapItems = data.ReadByte();
            NumPoints = data.ReadByte();
            MinNameLength = data.ReadByte();
            MaxNameLength = data.ReadByte();
            MinPasswordLength = data.ReadByte();
            MaxPasswordLength = data.ReadByte();
        }

        private static void Classes(NetIncomingMessage data)
        {
            // Recebe os dados
            Class.List = (Dictionary<Guid, Class>)ByteArrayToObject(data);
        }

        private static void Map(NetIncomingMessage data)
        {
            Map map = (Map)ByteArrayToObject(data);
            Guid id = map.ID;

            // Obtém o dado
            if (CryBits.Entities.Map.List.ContainsKey(id)) CryBits.Entities.Map.List[id] = map;
            else
                CryBits.Entities.Map.List.Add(id, map);
        }

        private static void NPCs(NetIncomingMessage data)
        {
            // Recebe os dados
            NPC.List = (Dictionary<Guid, NPC>)ByteArrayToObject(data);
        }

        private static void Items(NetIncomingMessage data)
        {
            // Recebe os dados
            Item.List = (Dictionary<Guid, Item>)ByteArrayToObject(data);
        }

        private static void Shops(NetIncomingMessage data)
        {
            // Recebe os dados
            Shop.List = (Dictionary<Guid, Shop>)ByteArrayToObject(data);
        }
    }
}