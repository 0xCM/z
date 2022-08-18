//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits3u : byte
    {
        Min = 0,

        Max = (byte)((uint)Limits2u.Max << 1 | (uint)Limits1u.Max),
    }
}