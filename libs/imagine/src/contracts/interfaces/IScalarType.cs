//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IScalarType : ISizedType
    {
        NativeClass NativeClass {get;}

        ulong IType.Kind
            => 0;
    }

    public interface IScalarType<K> : IType<K>, IScalarType
        where K : unmanaged
    {
        ulong IType.Kind
            => Sized.bw64(Kind);
    }
}