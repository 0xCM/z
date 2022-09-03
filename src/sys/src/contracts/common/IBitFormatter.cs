//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBitFormatter
    {
        string Format(ReadOnlySpan<byte> src);
    }

    public interface ITargetedBitFormatter : IBitFormatter
    {
        Type TargetType {get;}
    }

    public interface ITargetedBitFormatter<T> : ITargetedBitFormatter
    {
        Type ITargetedBitFormatter.TargetType
            => typeof(T);

    }

    public interface IBitFormatter<T> : ITargetedBitFormatter<T>
        where T : struct
    {
        string Format(T src);
    }

    public interface IFixedBitFormatter : ITargetedBitFormatter
    {
        string Format(dynamic src);

    }

    public interface IFixedBitFormatter<T> : IFixedBitFormatter, IBitFormatter<T>
        where T : struct
    {
        uint FixedWidth {get;}

        string IFixedBitFormatter.Format(dynamic src)
            => Format((T)src);
    }
}