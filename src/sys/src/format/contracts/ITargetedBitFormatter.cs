//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITargetedBitFormatter : IBitFormatter
    {
        Type TargetType {get;}
    }

    public interface ITargetedBitFormatter<T> : ITargetedBitFormatter
    {
        Type ITargetedBitFormatter.TargetType
            => typeof(T);
    }
}