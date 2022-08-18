//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILexical : ITextual
    {
        int CompareTo(ILexical src)
            => Format().CompareTo(src.Format());
    }

    public interface ILexical<T> : ILexical, IComparable<T>
        where T : ILexical<T>, ITextual
    {
        int IComparable<T>.CompareTo(T src)
            => Format().CompareTo(src.Format());
    }
}