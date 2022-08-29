//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct BinaryLiteral<T> : ILiteral<BinaryLiteral<T>,T>
        where T : unmanaged
    {
        public readonly string Name;

        public readonly T Data;

        public readonly string Text;

        [MethodImpl(Inline)]
        public BinaryLiteral(string name, T value, string text)
        {
            Name = name;
            Data = value;
            Text = text;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Name) && (empty(Text) || Data.Equals(default));
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Name) && nonempty(Text) && !Data.Equals(default);
        }

        public BinaryLiteral<T> Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Name) | hash(Data);
        }

        string ILiteral.Name
            => Name;

        object ILiteral.Data
            => Data;

        string ILiteral.Text
            => Text;

        T ILiteral<BinaryLiteral<T>, T>.Data
            => Data;

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Name}({Data}:{NumericKinds.kind<T>().Keyword()}) := " + text.dquote(Text);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(BinaryLiteral<T> src)
            => eq(this, src);

        public static BinaryLiteral<T> Empty
            => new BinaryLiteral<T>(EmptyString, default, EmptyString);

        [MethodImpl(Inline)]
        static bool eq(BinaryLiteral<T> x, BinaryLiteral<T> y)
            => string.Equals(x.Text, y.Text)
            && object.Equals(x.Data, y.Data)
            && string.Equals(x.Name, y.Name);
    }
}