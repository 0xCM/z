//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a numeric literal relative to a specified base
    /// </summary>
    public readonly struct NumericLiteral : INumericLiteral<NumericLiteral>
    {
        public readonly NumericBaseKind Base {get;}

        public readonly string Name {get;}

        public readonly object Data {get;}

        public readonly string Text {get;}

        [MethodImpl(Inline)]
        internal NumericLiteral(NumericBaseKind @base, string name, object data, string text)
        {
            Name = name;
            Data = data;
            Text = text;
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

        public NumericLiteral Zero
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
        {
            if(Base == NumericBaseKind.Base2)
                return BitRender.format(Data, Type.GetTypeCode(Data.GetType()));
            else
                return Data.ToString();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(NumericLiteral src)
            => object.Equals(Data, src.Data);

        string ILiteral.Name
            => Name;

        object ILiteral.Data
            => Data;

        string ILiteral.Text
            => Text;

        public static NumericLiteral Empty
            => new NumericLiteral(0, EmptyString, 0u, EmptyString);
    }
}