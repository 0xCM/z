//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IText : ITextual, INullity
    {
        string Text {get;}

        ReadOnlySpan<char> Data
            => Text ?? string.Empty;

        int Length
            => Data.Length;

        bool INullity.IsEmpty
            => Length == 0;

        bool INullity.IsNonEmpty
            => Length != 0;

        string ITextual.Format()
            => Text;
    }

    public interface IText<T> : IText, IEquatable<T>, IComparable<T>
        where T : IText<T>
    {
        bool IEquatable<T>.Equals(T src)
            => string.Equals(Text, src.Text);

        int IComparable<T>.CompareTo(T src)
            => Text?.CompareTo(src.Text) ?? 0;
    }
}