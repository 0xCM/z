//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        [MethodImpl(Inline)]
        public static BinaryLiteral define(Base2 @base2, string name, object value, string text)
            => new BinaryLiteral(name,value,text);

        [MethodImpl(Inline)]
        public static BinaryLiteral<T> define<T>(Base2 @base2, string name, T value, string text)
            where T : unmanaged
                => new BinaryLiteral<T>(name, value, text);
    }
}