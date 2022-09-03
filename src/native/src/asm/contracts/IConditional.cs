//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public interface IConditional
    {
        string Format(bit alt);

        ReadOnlySpan<char> Bitstring {get;}

        BitWidth RelWidth {get;}

        byte Encoding {get;}

        bit Identical {get;}
    }
}