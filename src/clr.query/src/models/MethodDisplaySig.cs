//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct MethodDisplaySig : IDataType<MethodDisplaySig>
    {
        readonly string Content;

        [MethodImpl(Inline)]
        public MethodDisplaySig(string src)
            => Content = src ?? EmptyString;

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Text);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Text);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Text);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public bool Equals(MethodDisplaySig src)
            => Text == src.Text;

        public override int GetHashCode()
            => Hash;

        public int CompareTo(MethodDisplaySig src)
            => Text.CompareTo(src.Text);

        public static MethodDisplaySig Empty
        {
            [MethodImpl(Inline)]
            get => new MethodDisplaySig(EmptyString);
        }
    }
}