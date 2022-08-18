//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITypedIdentity
    {
        Type IdentityType {get;}
    }

    [Free]
    public interface ITypedIdentity<T> : ITypedIdentity
    {
        T Id {get;}

        Type ITypedIdentity.IdentityType
            => typeof(T);
    }

    [Free]
    public interface ITypedIdentity<H,T> : ITypedIdentity<T>, IDataType<H>
        where H : struct, ITypedIdentity<H,T>
    {
        int IComparable<H>.CompareTo(H src)
            => Id.ToString().CompareTo(src.Id.ToString());
    }
}