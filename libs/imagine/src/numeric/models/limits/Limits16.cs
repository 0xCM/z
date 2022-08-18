//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits16u : ushort
    {
        Min = ushort.MinValue,

        Max = (ushort)(((uint)Limits15u.Max << 1) | (uint)Limits1u.Max)
    }
}