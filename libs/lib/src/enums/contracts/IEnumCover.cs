//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEnumCover<E> : ILiteralCover<E>
        where E : unmanaged, Enum
    {
        string Expr {get;}

        string Name {get;}

        ulong Scalar {get;}
    }

    public interface IEnumCover<E,T> : IEnumCover<E>
        where E : unmanaged, Enum
        where T : unmanaged
    {

        new T Scalar {get;}

        ulong IEnumCover<E>.Scalar
            => core.bw64(Scalar);
    }
}