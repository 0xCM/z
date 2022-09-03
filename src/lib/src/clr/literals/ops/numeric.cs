//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = NumericBaseKind;

    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> numeric<T>(string Name, T data, string Text, B @base)
            where T : unmanaged
                => new NumericLiteral<T>(Name,data, Text, @base);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T numeric<T>(FieldInfo f)
            where T : unmanaged
                => sys.constant<T>(f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] numeric<T>(Type src)
            where T : unmanaged
                => map(search<T>(src), numeric<T>);

        [MethodImpl(Inline), Op]
        public static NumericLiteral numeric(B @base, string name, object value, string text)
            => new NumericLiteral(@base, name, value ?? 0u, text ?? EmptyString);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> numeric<T>(B @base, string Name, T data, string Text)
            where T : unmanaged
                => new NumericLiteral<T>(Name,data, Text, @base);
        [Op]
        public static NumericLiteral numeric(Base2 @base, string name, object value, string text)
            => new NumericLiteral(@base, name, value ?? 0u, text ?? EmptyString);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> numeric<T>(Base2 @base, string Name, T Value, string text)
            where T : unmanaged
                => new NumericLiteral<T>(Name, Value, text, @base);

        [MethodImpl(Inline), Op]
        public static NumericLiteral numeric(Base10 @base, string Name, object Value, string text)
            => new NumericLiteral(@base,Name, Value, text);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> numeric<T>(Base10 @base, string Name, T data, string text)
            where T : unmanaged
                => new NumericLiteral<T>(Name, data, text, @base);

        [MethodImpl(Inline), Op]
        public static NumericLiteral numeric(Base16 @base, string name, object value, string text)
            => new NumericLiteral(@base,name, value, text);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> numeric<T>(Base16 b,  string Name, T data, string Text)
            where T : unmanaged
                => new NumericLiteral<T>(Name, data, Text, b);

    }
}