//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits11u : ushort
    {
        Min = 0,

        Max = (ushort)(((uint)Limits10u.Max << 1) | (uint)Limits1u.Max)
    }
}