//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmHexProvider
    {
        ref readonly AsmHexCode AsmHex(out AsmHexCode hex);
    }

    public interface IAsmHexProvider<T> : IAsmHexProvider
        where T : struct, IAsmHexProvider<T>
    {

    }
}