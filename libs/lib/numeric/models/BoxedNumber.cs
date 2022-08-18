//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Returns 0 in a box
        /// </summary>
        /// <param name="kind">The numeric kind of 0 to be put into the box</param>
        [MethodImpl(Inline), Op]
        public static BoxedNumber ZBox(this NumericKind kind)
            => BoxedNumber.define(NumericBox.rebox(byte.MinValue, kind), kind);
   }

    /// <summary>
    /// A numbered box
    /// </summary>
    [IdentityProvider(typeof(BoxedNumber))]
    public readonly struct BoxedNumber : IEquatable<BoxedNumber>, ITypeIdentityProvider<BoxedNumber>, IComparable, IConvertible, IFormattable
    {
        public static BoxedNumberConverter Converter => default;

        [MethodImpl(Inline), Op]
        public static BoxedNumber define(object src, NumericKind kind)
            => new BoxedNumber(src ?? new object(), kind);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static BoxedNumber define<T>(T src)
            where T : unmanaged
                => new BoxedNumber(src, NumericKinds.kind<T>());
        [Op]
        public static BoxedNumber convert(BoxedNumber src, NumericKind dst)
            => define(NumericBox.rebox(src,dst), dst);

        [Op, Closures(AllNumeric)]
        public static T convert<T>(BoxedNumber src)
            where T : unmanaged
                => (T)typeof(T).NumericKind().Rebox(src.Boxed);

        /// <summary>
        /// Puts an enum value into a (numeric) box
        /// </summary>
        /// <param name="e">The enumeration value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static BoxedNumber from<E>(E e)
            where E : unmanaged, Enum
                => define(System.Convert.ChangeType(e, Enums.ecode<E>().TypeCode()), Enums.ecode<E>().NumericKind());

        [Op]
        public static BoxedNumber from(Enum e)
        {
            var tc = Type.GetTypeCode(e.GetType().GetEnumUnderlyingType());
            var nk = tc.ToNumericKind();
            var box = System.Convert.ChangeType(e,tc);
            return define(box,nk);
        }

        [Op]
        public static BoxedNumber from(object src)
        {
            if(src is null)
                return BoxedNumber.Empty;
            else if(src is Enum e)
                return from(e);

            var nk = src.GetType().NumericKind();
            if(nk != 0)
                return define(src,nk);

            return BoxedNumber.Empty;
        }

        /// <summary>
        /// In the box
        /// </summary>
        public readonly object Boxed;

        /// <summary>
        /// Box discriminator for runtime efficiency
        /// </summary>
        public readonly NumericKind Kind;

        [MethodImpl(Inline)]
        internal BoxedNumber(object src, NumericKind kind)
        {
            Boxed = src;
            Kind = kind;
        }

        public bool IsSignedInt
            => NumericKinds.signed(Boxed);

        public bool IsUnsignedInt
            => NumericKinds.unsigned(Boxed);

        public bool IsFloat
            => NumericKinds.fractional(Boxed);

        [MethodImpl(Inline)]
        public T Unbox<T>()
            where T : unmanaged
                => (T)Boxed;

        public T Convert<T>()
            where T : unmanaged
                => convert<T>(this);

        public BoxedNumber Convert(NumericKind dst)
            => convert(this, dst);

        public BoxedNumber Convert(Type target)
            => Convert(target.NumericKind());

        IComparable Comparable
        {
            [MethodImpl(Inline)]
            get => Boxed as IComparable;
        }

        IFormattable Formattable
        {
            [MethodImpl(Inline)]
            get => Boxed as IFormattable;
        }

        IConvertible Convertible
        {
            [MethodImpl(Inline)]
            get => Boxed as IConvertible;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Boxed is null || Boxed is DBNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public static bool operator==(BoxedNumber a, BoxedNumber b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(BoxedNumber a, BoxedNumber b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(sbyte src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(byte src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(short src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(ushort src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(int src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(uint src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(long src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(ulong src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(float src)
            => define(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedNumber(double src)
            => define(src);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(BoxedNumber src)
            => src.Convert<sbyte>();

        [MethodImpl(Inline)]
        public static explicit operator short(BoxedNumber src)
            => src.Convert<short>();

        [MethodImpl(Inline)]
        public static explicit operator int(BoxedNumber src)
            => src.Convert<int>();

        [MethodImpl(Inline)]
        public static explicit operator long(BoxedNumber src)
            => src.Convert<long>();

        [MethodImpl(Inline)]
        public static explicit operator byte(BoxedNumber src)
            => src.Convert<byte>();

        [MethodImpl(Inline)]
        public static explicit operator ushort(BoxedNumber src)
            => src.Convert<ushort>();

        [MethodImpl(Inline)]
        public static explicit operator uint(BoxedNumber src)
            => src.Convert<uint>();

        [MethodImpl(Inline)]
        public static explicit operator ulong(BoxedNumber src)
            => src.Convert<ulong>();

        [MethodImpl(Inline)]
        public static explicit operator float(BoxedNumber src)
            => src.Convert<float>();

        [MethodImpl(Inline)]
        public static explicit operator double(BoxedNumber src)
            => src.Convert<double>();

        [MethodImpl(Inline)]
        public bool Equals(BoxedNumber other)
            => Boxed.Equals(other.Boxed);

        public string Format(Base10 @base)
            => Boxed.ToString();

        public string Format(Base16 @base)
            => Convert<ulong>().FormatHex(false,true);

        public string Format(Base2 @base)
            => BitRender.format(Boxed, Kind.ToTypeCode());

        public override string ToString()
            => Boxed.ToString();

        public override int GetHashCode()
            => Boxed.GetHashCode();

        public override bool Equals(object other)
            => other is BoxedNumber n && Equals(n);

        [MethodImpl(Inline)]
        TypeCode IConvertible.GetTypeCode()
            => Convertible.GetTypeCode();

        [MethodImpl(Inline)]
        bool IConvertible.ToBoolean(IFormatProvider provider)
            => Convertible.ToBoolean(provider);

        [MethodImpl(Inline)]
        byte IConvertible.ToByte(IFormatProvider provider)
            => Convertible.ToByte(provider);

        [MethodImpl(Inline)]
        char IConvertible.ToChar(IFormatProvider provider)
            => Convertible.ToChar(provider);

        [MethodImpl(Inline)]
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
            => Convertible.ToDateTime(provider);

        [MethodImpl(Inline)]
        decimal IConvertible.ToDecimal(IFormatProvider provider)
            => Convertible.ToDecimal(provider);

        [MethodImpl(Inline)]
        double IConvertible.ToDouble(IFormatProvider provider)
            => Convertible.ToDouble(provider);

        [MethodImpl(Inline)]
        short IConvertible.ToInt16(IFormatProvider provider)
            => Convertible.ToInt16(provider);

        [MethodImpl(Inline)]
        int IConvertible.ToInt32(IFormatProvider provider)
            => Convertible.ToInt32(provider);

        [MethodImpl(Inline)]
        long IConvertible.ToInt64(IFormatProvider provider)
            => Convertible.ToInt64(provider);

        [MethodImpl(Inline)]
        sbyte IConvertible.ToSByte(IFormatProvider provider)
            => Convertible.ToSByte(provider);

        [MethodImpl(Inline)]
        float IConvertible.ToSingle(IFormatProvider provider)
            => Convertible.ToSingle(provider);

        [MethodImpl(Inline)]
        string IConvertible.ToString(IFormatProvider provider)
            => Convertible.ToString(provider);

        [MethodImpl(Inline)]
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
            => Convertible.ToType(conversionType, provider);

        [MethodImpl(Inline)]
        ushort IConvertible.ToUInt16(IFormatProvider provider)
            => Convertible.ToUInt16(provider);

        [MethodImpl(Inline)]
        uint IConvertible.ToUInt32(IFormatProvider provider)
            => Convertible.ToUInt32(provider);

        [MethodImpl(Inline)]
        ulong IConvertible.ToUInt64(IFormatProvider provider)
            => Convertible.ToUInt64(provider);

        [MethodImpl(Inline)]
        int IComparable.CompareTo(object obj)
            => Comparable.CompareTo(obj);

        [MethodImpl(Inline)]
        string IFormattable.ToString(string format, IFormatProvider formatProvider)
            => Formattable.ToString(format, formatProvider);

        public TypeIdentity Identity()
            => TypeIdentity.define("nbox");

        public static BoxedNumber Empty
            => new BoxedNumber(DBNull.Value, NumericKind.None);
    }
}