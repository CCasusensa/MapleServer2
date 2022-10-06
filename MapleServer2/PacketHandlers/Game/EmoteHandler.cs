﻿using MaplePacketLib2.Tools;
using MapleServer2.Constants;
using MapleServer2.Packets;
using MapleServer2.Servers.Game;
using MapleServer2.Types;

namespace MapleServer2.PacketHandlers.Game;

public class EmoteHandler : GamePacketHandler<EmoteHandler>
{
    public override RecvOp OpCode => RecvOp.Emotion;

    private enum Mode : byte
    {
        LearnEmote = 0x1,
        UseEmote = 0x2
    }

    public override void Handle(GameSession session, PacketReader packet)
    {
        Mode mode = (Mode) packet.ReadByte();

        switch (mode)
        {
            case Mode.LearnEmote:
                HandleLearnEmote(session, packet);
                break;
            case Mode.UseEmote:
                HandleUseEmote(packet);
                break;
            default:
                LogUnknownMode(mode);
                break;
        }
    }

    private static void HandleLearnEmote(GameSession session, PacketReader packet)
    {
        long itemUid = packet.ReadLong();

        if (!session.Player.Inventory.HasItem(itemUid))
        {
            return;
        }

        Item item = session.Player.Inventory.GetByUid(itemUid);

        if (session.Player.Emotes.Contains(item.SkillId))
        {
            return;
        }

        session.Player.Emotes.Add(item.SkillId);

        session.Send(EmotePacket.LearnEmote(item.SkillId));

        session.Player.Inventory.ConsumeItem(session, item.Uid, 1);
    }

    private static void HandleUseEmote(PacketReader packet)
    {
        int emoteId = packet.ReadInt();
        string animationName = packet.ReadUnicodeString();
        // animationName is the name in /Xml/anikeytext.xml
    }
}
