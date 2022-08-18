//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = NativeSizeCode;

    using api = Sized;

    public readonly struct NativeSize
    {
        public static NativeSize W8 => N.W8;

        public static NativeSize W16 => N.W16;

        public static NativeSize W32 => N.W32;

        public static NativeSize W64 => N.W64;

        public static NativeSize W128 => N.W128;

        public static NativeSize W256 => N.W256;

        public static NativeSize W512 => N.W512;

        public static NativeSize W80 => N.W80;

        public readonly NativeSizeCode Code;

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => api.width(Code);
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => api.bytes(Code);
        }

        [MethodImpl(Inline)]
        public NativeSize(NativeSizeCode kind)
        {
            Code = kind;
        }

        public string Format()
            => Width.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeSize(NativeSizeCode src)
            => new NativeSize(src);

        [MethodImpl(Inline)]
        public static implicit operator NativeSize(NativeTypeWidth src)
            => Sized.native((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator NativeSizeCode(NativeSize src)
            => (NativeSizeCode)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(NativeSize src)
            => src.Width;

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(NativeSize src)
            => src.ByteCount;

        [MethodImpl(Inline)]
        public static explicit operator ushort(NativeSize src)
            => (ushort)src.Code;
    }
}