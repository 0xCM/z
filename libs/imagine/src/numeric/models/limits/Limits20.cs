//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits20u : uint
    {
        Min = 0,

        Max = (uint)(((uint)Limits19u.Max << 1) | (uint)Limits1u.Max)
    }
}