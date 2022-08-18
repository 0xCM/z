//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    using NBK = NumericBaseKind;

    /// <summary>
    /// Defines a numeric literal relative to a specified base
    /// </summary>
    public readonly struct NumericLiteral<T> : INumericLiteral<NumericLiteral<T>,T>
        where T : unmanaged
    {
        public readonly string Name {get;}

        public readonly T Data {get;}

        public readonly string Text {get;}

        public readonly NBK Base {get;}

        [MethodImpl(Inline)]
        public NumericLiteral(string name, T data, string text, NBK @base)
        {
            Name = name;
            Data = data;
            Text = text ?? data.ToString();
            Base = @base;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => blank(Text);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasValue
        {
            [MethodImpl(Inline)]
            get => !Data.Equals(default);
        }

        public Type SystemType
        {
            [MethodImpl(Inline)]
            get => Data.GetType();
        }

        public TypeCode TypeCode
        {
            [MethodImpl(Inline)]
            get => Type.GetTypeCode(SystemType);
        }

        public NumericLiteral<T> Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public bool IsEnum
        {
            [MethodImpl(Inline)]
            get => SystemType.IsEnum;
        }
        public string Format()
            => Text;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(NumericLiteral<T> src)
            => object.Equals(Data, src.Data);

        public static NumericLiteral<T> Empty
            => new NumericLiteral<T>(EmptyString, default, EmptyString, 0);
    }
}