//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits13u : ushort
    {
        Min = 0,

        Max = (ushort)(((uint)Limits12u.Max << 1) | (uint)Limits1u.Max)
    }
}