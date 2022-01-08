﻿namespace MapleServer2.Enums;

public enum UGCMarketListingStatus : byte
{
    Unknown = 0,
    Hold = 1,
    Active = 2,
    Expired = 3
}

public enum UGCMarketItemHomeCategory : byte
{
    None = 0,
    Promoted = 1,
    New = 2
}