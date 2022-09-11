//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextLine
    {
        LineNumber LineNumber {get;}
    }

    public interface ITextLine<T> : ITextLine
    {
        T Content {get;}
    }

    public interface ITextLine<L,T> : ITextLine<T>, IEquatable<L>, IComparable<L>
        where L : ITextLine<L,T>
    {

    }
}