﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
namespace UOProxy.Packets.FromServer
{
    public class _0x8CConnectToGameServer : Packet
    {
        private byte[] _ip = new byte[4];
        public short Port;
        public int Key;

        public _0x8CConnectToGameServer(UOStream Data)
            : base(Data)
        {
            if (UOProxy.ProxyMode)
            {
                // If we are in proxy mode, overwrite servers IP with local IP
                IP = IPAddress.Loopback;
                Data.Write(_ip,0, 4);
                UOProxy.UseHuffman = true;
                Data.Position = 1;
                //ToDo Add Port override
            }
            _ip[0] = Data.ReadBit();
            _ip[1] = Data.ReadBit();
            _ip[2] = Data.ReadBit();
            _ip[3] = Data.ReadBit();
            Port = Data.ReadShort();
            Key = Data.ReadInt();
            
            
        }
        public IPAddress IP { get { return new IPAddress(_ip); } private set { _ip = value.GetAddressBytes(); } }
    }
}
