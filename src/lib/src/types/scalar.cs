//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = NativeSizeCode;

    partial class NativeTypes
    {
        [MethodImpl(Inline), Op]
        public static NativeScalar scalar(NativeSize size, NativeClass @class)
            => new NativeScalar(size, @class);

        [MethodImpl(Inline), Op]
        public static NativeType @void()
            => NativeType.define(NativeScalar.Void);

        [MethodImpl(Inline), Op]
        public static NativeType unsigned(NativeSize size)
            => new NativeType(scalar(size, NativeClass.U));

        [MethodImpl(Inline), Op]
        public static NativeType signed(NativeSize size)
            => new NativeType(scalar(size, NativeClass.I));

        [MethodImpl(Inline), Op]
        public static NativeType fractional(NativeSize size)
            => new NativeType(scalar(size, NativeClass.F));

        [MethodImpl(Inline), Op]
        public static NativeType character(NativeSize size)
            => new NativeType(scalar(size, NativeClass.C));

        [MethodImpl(Inline), Op]
        public static NativeType bit()
            => new NativeType(scalar(W.W8, NativeClass.B));

        [MethodImpl(Inline), Op]
        public static NativeType u8()
            => unsigned(W.W8);

        [MethodImpl(Inline), Op]
        public static NativeType i8()
            => signed(W.W8);

        [MethodImpl(Inline), Op]
        public static NativeType u16()
            => unsigned(W.W16);

        [MethodImpl(Inline), Op]
        public static NativeType i16()
            => signed(W.W16);

        [MethodImpl(Inline), Op]
        public static NativeType u32()
            => unsigned(W.W32);

        [MethodImpl(Inline), Op]
        public static NativeType i32()
            => signed(W.W32);

        [MethodImpl(Inline), Op]
        public static NativeType u64()
            => unsigned(W.W64);

        [MethodImpl(Inline), Op]
        public static NativeType i64()
            => signed(W.W64);

        [MethodImpl(Inline), Op]
        public static NativeType c8()
            => character(W.W8);

        [MethodImpl(Inline), Op]
        public static NativeType c16()
            => character(W.W16);

        [MethodImpl(Inline), Op]
        public static NativeType f32()
            => fractional(W.W32);

        [MethodImpl(Inline), Op]
        public static NativeType f64()
            => fractional(W.W64);

        [MethodImpl(Inline), Op]
        public static NativeType u128()
            => unsigned(W.W128);

        [MethodImpl(Inline), Op]
        public static NativeType i128()
            => signed(W.W128);

        [MethodImpl(Inline), Op]
        public static NativeType f128()
            => fractional(W.W128);

        [MethodImpl(Inline), Op]
        public static NativeType u256()
            => unsigned(W.W256);

        [MethodImpl(Inline), Op]
        public static NativeType i256()
            => signed(W.W256);

        [MethodImpl(Inline), Op]
        public static NativeType f256()
            => fractional(W.W256);

        [MethodImpl(Inline), Op]
        public static NativeType u512()
            => unsigned(W.W512);

        [MethodImpl(Inline), Op]
        public static NativeType i512()
            => signed(W.W512);

        [MethodImpl(Inline), Op]
        public static NativeType f512()
            => fractional(W.W512);
    }
}