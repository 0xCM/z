//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Covers a value that can be interpreted as a compile-time literal constant
    /// </summary>
    public readonly struct LiteralInfo : ILiteral<LiteralInfo>
    {
        public readonly string Name {get;}

        public readonly object Data {get;}

        public readonly string Text {get;}

        public readonly TypeCode TypeCode {get;}

        public readonly bool IsEnum {get;}

        public readonly bool Polymorphic {get;}

        [MethodImpl(Inline)]
        public LiteralInfo(string name, object data, string text, TypeCode tc, bool isEnum, bool polymorphic)
        {
            Name = name;
            Data = data;
            Text = text;
            TypeCode = tc;
            IsEnum = isEnum;
            Polymorphic = polymorphic;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == null || empty(Text);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public LiteralInfo Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public bool IsAnonymous
        {
            [MethodImpl(Inline)]
            get => blank(Name);
        }

        public Type SystemType
        {
            [MethodImpl(Inline)]
            get => Data?.GetType() ?? typeof(void);
        }

        [MethodImpl(Inline)]
        public bool Equals(LiteralInfo src)
            => object.Equals(Data, src.Data);

        [MethodImpl(Inline)]
        public string Format()
            => Data?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data?.GetHashCode() ?? 0;

        public override bool Equals(object src)
            => src is LiteralInfo v && Equals(v);

        public static LiteralInfo Empty
            => new LiteralInfo(EmptyString, EmptyString, EmptyString, 0, false, false);
    }
}