//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits9u : ushort
    {
        Min = 0,

        Max = (ushort)(((uint)Limits8u.Max << 1) | (uint)Limits1u.Max)
    }
}