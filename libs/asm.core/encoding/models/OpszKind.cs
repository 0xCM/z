//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [Flags, SymSource]
    public enum OpszKind : byte
    {
        [Symbol("w16")]
        W16 = (byte)DataWidth.W16,

        [Symbol("w32")]
        W32 = (byte)DataWidth.W32,

        [Symbol("w64")]
        W64 = (byte)DataWidth.W64
    }
}