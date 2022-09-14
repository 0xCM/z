//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypeKind : ITextual
    {
        ulong Key {get;}

        Identifier Class {get;}

        Identifier Name {get;}

        byte Arity {get;}
    }

    public interface ITypeKind<K> : ITypeKind
        where K : unmanaged
    {
        new K Key {get;}

        ulong ITypeKind.Key
            => sys.bw64(Key);
    }
}