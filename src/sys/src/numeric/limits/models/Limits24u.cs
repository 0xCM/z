//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Limits24u : uint
    {
        Min = 0,

        Max = (uint)(((uint)Limits23u.Max << 1) | (uint)Limits1u.Max)
    }
}