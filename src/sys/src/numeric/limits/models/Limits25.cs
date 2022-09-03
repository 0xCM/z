//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits25u : uint
    {
        Min = 0,

        Max = (uint)(((uint)Limits24u.Max << 1) | (uint)Limits1u.Max)
    }
}