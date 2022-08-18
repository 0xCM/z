//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ActionName : IComparable<ActionName>, IEquatable<ActionName>, INullity
    {
        readonly @string Data;

        [MethodImpl(Inline)]
        public ActionName(string data)
        {
            Data = data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ActionName src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public bool Equals(ActionName src)
            => Data.Equals(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is ActionName x && Equals(x);

        public string Format()
            => Data;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ActionName(string src)
            => new ActionName(src);
    }
}