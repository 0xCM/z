//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IHexType
    {
        Hex8Kind Value {get;}
    }

    public interface IHexType<H> : IHexType
        where H : unmanaged, IHexType<H>
    {
        Type Reified
            => typeof(H);
    }
}