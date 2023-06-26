//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public interface IHexBlock
{
    static abstract ReadOnlySpan<byte> String {get;}

    static abstract ReadOnlySpan<AsciSymbol> Symbols {get;}
}

public interface IHexBlock<T> : IHexBlock
    where T : unmanaged
{
    static abstract ReadOnlySpan<T> Values {get;}

    static abstract ref readonly T Value(uint index);
}

public interface IHexBlock<H,T> : IHexBlock<T>
    where H : unmanaged, IHexBlock<H,T>
    where T : unmanaged
{    

    static ref readonly T IHexBlock<T>.Value(uint index)
        => ref skip(H.Values,index);                        
}    
