//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NBI = NumericBaseIndicator;
    using NBK = NumericBaseKind;

    [ApiHost]
    public readonly struct NumericBases
    {
        [MethodImpl(Inline), Op]
        public static NBI indicator(char src)
        {
            if(src == (char)NBI.Base2)
                return NBI.Base2;
            else if(src == (char)NBI.Base16)
                return NBI.Base16;
            else if(src == (char)NBI.Base10)
                return NBI.Base10;
            else if(src == (char)NBI.Base8)
                return NBI.Base8;
            else if(src == (char)NBI.Base3)
                return NBI.Base3;
            else
                return NBI.None;
        }

        [MethodImpl(Inline), Op]
        public static NBI indicator(NBK src)
        {
            if(src == NBK.Base2)
                return NBI.Base2;
            else if(src == NBK.Base16)
                return NBI.Base16;
            else if(src == NBK.Base10)
                return NBI.Base10;
            else if(src == NBK.Base8)
                return NBI.Base8;
            else if(src == NBK.Base3)
                return NBI.Base3;
            else
                return NBI.None;
        }

        [MethodImpl(Inline), Op]
        public static NBK kind(NBI src)
        {
            if(src == NBI.Base2)
                return NBK.Base2;
            else if(src == NBI.Base16)
                return NBK.Base16;
            else if(src == NBI.Base10)
                return NBK.Base10;
            else if(src == NBI.Base8)
                return NBK.Base8;
            else if(src == NBI.Base3)
                return NBK.Base3;
            else
                return NBK.None;
        }

        [MethodImpl(Inline)]
        public static NBI indicator<B>(B b = default)
            where B : unmanaged, INumericBase
        {
            if(typeof(B) == typeof(Base2))
                return NBI.Base2;
            else if(typeof(B) == typeof(Base3))
                return NBI.Base3;
            else if(typeof(B) == typeof(Base8))
                return NBI.Base8;
            else if(typeof(B) == typeof(Base10))
                return NBI.Base10;
            else if(typeof(B) == typeof(Base16))
                return NBI.Base16;
            else
                return NBI.None;
        }

        [MethodImpl(Inline)]
        public static NBK nbk<B>(B b = default)
            where B : unmanaged, INumericBase
        {
            if(typeof(B) == typeof(Base2))
                return NBK.Base2;
            else if(typeof(B) == typeof(Base3))
                return NBK.Base3;
            else if(typeof(B) == typeof(Base8))
                return NBK.Base8;
            else if(typeof(B) == typeof(Base10))
                return NBK.Base10;
            else if(typeof(B) == typeof(Base16))
                return NBK.Base16;
            else
                return NBK.None;
        }
    }
}