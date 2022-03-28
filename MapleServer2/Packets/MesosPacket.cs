﻿using MaplePacketLib2.Tools;
using MapleServer2.Constants;

namespace MapleServer2.Packets;

internal class MesosPacket
{
    public static PacketWriter UpdateMesos(long mesoAmount)
    {
        PacketWriter pWriter = PacketWriter.Of(SendOp.Meso);

        pWriter.WriteLong(mesoAmount); // Total amount of mesos
        pWriter.WriteInt(); // unknown int

        return pWriter;
    }
}
