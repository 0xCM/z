//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits4u : byte
    {
        Min = 0,

        Max = (byte)((uint)Limits3u.Max << 1 | (uint)Limits1u.Max),
    }
}