//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmPrefix
    {
        byte Encoded {get;}

        bit IsEmtpy
            => Encoded == 0;

        bit IsNonEmpty
            => Encoded != 0;
    }

    public interface IAsmPrefix<P> : IAsmPrefix
        where P : unmanaged
    {

    }
}