//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using SK = NativeSegKind;
    using TW = NativeTypeWidth;
    using ID = ScalarKind;

    partial class NativeTypes
    {
        /// <summary>
        /// Determines the block classifier for a blocked type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static SK segkind(Type t)
            => segkind(Widths.segmented(t), NativeTypes.numkind(t).ApiKind());

        [Op]
        public static SK segkind(TW width, ID id)
        {
            var k = width switch
                    { TW.W16 =>
                        id switch {
                            ID.U8 => SK.Seg16x8u,
                            ID.I8 => SK.Seg16x8i,
                            ID.I16 => SK.Seg16i,
                            ID.U16 => SK.Seg16u,
                            _ => SK.Void
                            },

                        TW.W32 =>
                        id switch {
                            ID.U8 => SK.Seg32x8u,
                            ID.I8 => SK.Seg32x8i,
                            ID.I16 => SK.Seg32x16i,
                            ID.U16 => SK.Seg32x16u,
                            ID.I32 => SK.Seg32i,
                            ID.U32 => SK.Seg32u,
                            ID.F32 => SK.Seg32f,
                            _ => SK.Void
                            },

                        TW.W64 =>
                        id switch {
                            ID.U8 => SK.Seg64x8u,
                            ID.I8 => SK.Seg64x8i,
                            ID.U16 => SK.Seg64x16u,
                            ID.I16 => SK.Seg64x16i,
                            ID.U32 => SK.Seg64x32i,
                            ID.I32 => SK.Seg64x32i,
                            ID.U64 => SK.Seg64u,
                            ID.I64 => SK.Seg64i,
                            ID.F32 => SK.Seg64x32f,
                            ID.F64 => SK.Seg64f,
                            _ => SK.Void
                            },

                        TW.W128 =>
                        id switch {
                            ID.U8 => SK.Seg128x8u,
                            ID.I8 => SK.Seg128x8i,
                            ID.U16 => SK.Seg128x16u,
                            ID.I16 => SK.Seg128x16i,
                            ID.U32 => SK.Seg128x32i,
                            ID.I32 => SK.Seg128x32i,
                            ID.U64 => SK.Seg128x64u,
                            ID.I64 => SK.Seg128x64i,
                            ID.F32 => SK.Seg128x32f,
                            ID.F64 => SK.Seg128x64f,
                            _ => SK.Void
                            },

                        TW.W256 =>
                        id switch {
                            ID.U8 => SK.Seg256x8u,
                            ID.I8 => SK.Seg256x8i,
                            ID.U16 => SK.Seg256x16u,
                            ID.I16 => SK.Seg256x16i,
                            ID.U32 => SK.Seg256x32i,
                            ID.I32 => SK.Seg256x32i,
                            ID.U64 => SK.Seg256x64u,
                            ID.I64 => SK.Seg256x64i,
                            ID.F32 => SK.Seg256x32f,
                            ID.F64 => SK.Seg256x64f,
                            _ => SK.Void
                            },

                        TW.W512 =>
                        id switch {
                            ID.U8 => SK.Seg512x8u,
                            ID.I8 => SK.Seg512x8i,
                            ID.U16 => SK.Seg512x16u,
                            ID.I16 => SK.Seg512x16i,
                            ID.U32 => SK.Seg512x32i,
                            ID.I32 => SK.Seg512x32i,
                            ID.U64 => SK.Seg512x64u,
                            ID.I64 => SK.Seg512x64i,
                            ID.F32 => SK.Seg512x32f,
                            ID.F64 => SK.Seg512x64f,
                            _ => SK.Void
                            },

                        _ => SK.Void
                    };

            return k;
        }

        [MethodImpl(Inline)]
        public static NativeSegKind segkind<W,T>(W w = default, T t = default)
            where W : unmanaged, ITypeWidth
            where T : unmanaged
        {
            if(typeof(W) == typeof(W16))
                return segkind<T>(default(W16));
            else if(typeof(W) == typeof(W32))
                return segkind<T>(default(W32));
            else if(typeof(W) == typeof(W64))
                return segkind<T>(default(W64));
            else if(typeof(W) == typeof(W128))
                return segkind<T>(default(W128));
            else if(typeof(W) == typeof(W256))
                return segkind<T>(default(W256));
            else if(typeof(W) == typeof(W512))
                return segkind<T>(default(W512));
            else
                return NativeSegKind.Void;
        }

        [MethodImpl(Inline)]
        public static NativeSegKind segkind<T>(W16 w, T t = default)
            where T : unmanaged
                => segkind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind segkind<T>(W32 w, T t = default)
            where T : unmanaged
                => segkind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind segkind<T>(W64 w, T t = default)
            where T : unmanaged
                => segkind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind segkind<T>(W128 w, T t = default)
            where T : unmanaged
                => segkind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind segkind<T>(W256 w, T t = default)
            where T : unmanaged
                => segkind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind segkind<T>(W512 w, T t = default)
            where T : unmanaged
                => segkind_u(w,t);

        [MethodImpl(Inline)]
        static NativeSegKind segkind_u<T>(W16 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg16x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg16u;
            else
                return segkind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_i<T>(W16 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg16x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg16i;
            else
                return NativeSegKind.Void;
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_u<T>(W32 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg32x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg32x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg32u;
            else
                return segkind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_i<T>(W32 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg32x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg32x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg32i;
            else
                return segkind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_f<T>(W32 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg32f;
            else
                return NativeSegKind.Void;
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_u<T>(W64 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg64x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg64x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg64x32u;
            else if(typeof(T) == typeof(ulong))
                return NativeSegKind.Seg64u;
            else
                return segkind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_i<T>(W64 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg64x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg64x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg64x32i;
            else if(typeof(T) == typeof(long))
                return NativeSegKind.Seg64i;
            else
                return segkind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_f<T>(W64 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg64x32f;
            else if(typeof(T) == typeof(double))
                return NativeSegKind.Seg64f;
            else
                return NativeSegKind.Void;
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_u<T>(W128 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg128x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg128x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg128x32u;
            else if(typeof(T) == typeof(ulong))
                return NativeSegKind.Seg128x64u;
            else
                return segkind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_i<T>(W128 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg128x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg128x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg128x32i;
            else if(typeof(T) == typeof(long))
                return NativeSegKind.Seg128x64i;
            else
                return segkind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_f<T>(W128 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg128x32f;
            else if(typeof(T) == typeof(double))
                return NativeSegKind.Seg128x64f;
            else
                return NativeSegKind.Void;
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_u<T>(W256 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg256x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg256x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg256x32u;
            else if(typeof(T) == typeof(ulong))
                return NativeSegKind.Seg256x64u;
            else
                return segkind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_i<T>(W256 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg256x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg256x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg256x32i;
            else if(typeof(T) == typeof(long))
                return NativeSegKind.Seg256x64i;
            else
                return segkind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_f<T>(W256 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg256x32f;
            else if(typeof(T) == typeof(double))
                return NativeSegKind.Seg256x64f;
            else
                return NativeSegKind.Void;
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_u<T>(W512 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg512x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg512x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg512x32u;
            else if(typeof(T) == typeof(ulong))
                return NativeSegKind.Seg512x64u;
            else
                return segkind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_i<T>(W512 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg512x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg512x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg512x32i;
            else if(typeof(T) == typeof(long))
                return NativeSegKind.Seg512x64i;
            else
                return segkind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind segkind_f<T>(W512 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg512x32f;
            else if(typeof(T) == typeof(double))
                return NativeSegKind.Seg512x64f;
            else
                return NativeSegKind.Void;
        }
    }
}