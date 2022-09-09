//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFixedBitFormatter : ITargetedBitFormatter
    {
        uint FixedWidth {get;}

        string Format(dynamic src);
    }

    public interface IFixedBitFormatter<T> : IFixedBitFormatter, IBitFormatter<T>
        where T : struct
    {
        string IFixedBitFormatter.Format(dynamic src)
            => Format((T)src);
    }    
}