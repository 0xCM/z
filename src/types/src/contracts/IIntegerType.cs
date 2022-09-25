//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IIntegerType : IScalarType
    {
        TypeSignKind Sign {get;}
    }

    public interface IIntegerType<K> : IScalarType<K>
        where K : unmanaged
    {

    }
}