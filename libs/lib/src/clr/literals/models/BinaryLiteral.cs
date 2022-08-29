//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a base2 literal via text and a boxed value; for the literal to be valid,
    /// the text, when parsed, must yield a value equivalent to the boxed value
    /// </summary>
    public readonly record struct BinaryLiteral : ILiteral<BinaryLiteral>
    {
        [MethodImpl(Inline)]
        public static BinaryLiteral define(Base2 @base2, string name, object value, string text)
            => new BinaryLiteral(name,value,text);

        [MethodImpl(Inline)]
        public static BinaryLiteral<T> define<T>(Base2 @base2, string name, T value, string text)
            where T : unmanaged
                => new BinaryLiteral<T>(name, value, text);

        /// <summary>
        /// The literal name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The literal value
        /// </summary>
        public readonly object Data;

        /// <summary>
        /// Text that represents the boxed value
        /// </summary>
        public readonly string Text;

        [MethodImpl(Inline)]
        public BinaryLiteral(string name, object value, string text)
        {
            Name = name;
            Data = value;
            Text = text;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => blank(Name) && (blank(Text) || (Data == null));
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Name) && nonempty(Text) && Data != null;
        }

        public BinaryLiteral Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Name) | hash(Text);
        }

        [MethodImpl(Inline)]
        public string Format()
             => $"{Name}({Data}:{kind(this).Keyword()}) := " + text.dquote(Text);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(BinaryLiteral src)
            => eq(this,src);

        string ILiteral.Name
            => Name;

        object ILiteral.Data
            => Data;

        string ILiteral.Text
            => Text;

        public static BinaryLiteral Empty
            => new BinaryLiteral(string.Empty, 0, string.Empty);

        /// <summary>
        /// Discerns the numeric kind of a specified binary literal
        /// </summary>
        /// <param name="src">The source literal</param>
        [MethodImpl(Inline), Op]
        static NumericKind kind(BinaryLiteral src)
            => src.Data?.GetType()?.NumericKind() ?? NumericKind.None;

        [MethodImpl(Inline), Op]
        static bool eq(BinaryLiteral x, BinaryLiteral y)
            => string.Equals(x.Text, y.Text)
            && object.Equals(x.Data, y.Data)
            && string.Equals(x.Name, y.Name);
    }
}