//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;
using static NativeTypes;
using static NativeTypeMap;
using static NativeClass;
using static NativeSegKind;

using static NativeSigs.ModifierKind;
using W = NativeSizeCode;
using SK = NativeSegKind;
using TW = NativeTypeWidth;
using ID = ScalarKind;

[ApiHost]
public partial class NativeSigs
{
    [MethodImpl(Inline), Op]
    public static Shape shape(int n1 = 0, int n2 = 0, int n4 = 0, int n8 = 0, int n16 = 0, int n32 = 0, int n64 = 0)
    {
        var dst = new Shape();
        dst.N1 = n1;
        dst.N2 = n2;
        dst.N4 = n4;
        dst.N8 = n8;
        dst.N16 = n16;
        dst.N32 = n32;
        dst.N64 = n64;
        return dst;
    }

    public static Shape shape(ReadOnlySpan<byte> src, NativeSizeCode segmax = NativeSizeCode.W512)
    {
        var dst = new Shape();
        return shape(src,segmax, ref dst);
    }

    [Op]
    public static ref Shape shape(ReadOnlySpan<byte> src, NativeSize segmax, ref Shape dst)
    {
        const byte N1  = 1;
        const byte N2  = 2;
        const byte N4  = 4;
        const byte N8  = 8;
        const byte N16 = 16;
        const byte N32 = 32;
        const byte N64 = 64;

        var max = (uint)segmax.ByteCount;

        var count = src.Length;
        if(count == 0)
            return ref dst;

        var mod = -1;
        var div = 0;
        while(mod != 0 && count != 0)
        {
            if(count >= N64 && N64 <= max)
            {
                div = count/N64;
                dst.N64 = div;
                mod = count/N64;
                count -= div*N64;
            }
            else if(count >= N32 && N32 <= max)
            {
                div = count/N32;
                dst.N32 = div;
                mod = count/N32;
                count -= div*N32;
            }
            else if(count >= N16 && N16 <= max)
            {
                div = count/N16;
                dst.N16 = div;
                mod = count/N16;
                count -= div*N16;
            }
            else if(count >= N8 && N8 <= max)
            {
                div = count/N8;
                dst.N8 = div;
                mod = count/N8;
                count -= div*N8;
            }
            else if(count >= N4 && N4 <= max)
            {
                div = count/N4;
                dst.N4 = div;
                mod = count/N4;
                count -= div*N4;
            }
            else if(count >= N2 && N2 <= max)
            {
                div = count/N2;
                dst.N2 = div;
                mod = count/N2;
                count -= div*N2;
            }
            else if(count == N1)
            {
                div = N1;
                dst.N1 = div;
                mod = 0;
                count -= div*N1;
            }
        }

        return ref dst;
    }

    /// <summary>
    /// Determines the block classifier for a blocked type
    /// </summary>
    /// <param name="t">The type to examine</param>
    [Op]
    public static SK segkind(Type t)
        => segkind(Widths.segmented(t), numkind(t).ApiKind());

    public static NumericKind numkind(Type t)
        => t.ContainsGenericParameters ? t.SuppliedTypeArgs().First().NumericKind() : 0;

    [Op]
    public static SK segkind(TW width, ID id)
    {
        var k = width switch
            { TW.W16 =>
                id switch {
                    ID.U8 => Seg16x8u,
                    ID.I8 => Seg16x8i,
                    ID.I16 => Seg16i,
                    ID.U16 => Seg16u,
                    _ => Void
                    },

                TW.W32 =>
                id switch {
                    ID.U8 => Seg32x8u,
                    ID.I8 => Seg32x8i,
                    ID.I16 => Seg32x16i,
                    ID.U16 => Seg32x16u,
                    ID.I32 => Seg32i,
                    ID.U32 => Seg32u,
                    ID.F32 => Seg32f,
                    _ => Void
                    },

                TW.W64 =>
                id switch {
                    ID.U8 => Seg64x8u,
                    ID.I8 => Seg64x8i,
                    ID.U16 => Seg64x16u,
                    ID.I16 => Seg64x16i,
                    ID.U32 => Seg64x32i,
                    ID.I32 => Seg64x32i,
                    ID.U64 => Seg64u,
                    ID.I64 => Seg64i,
                    ID.F32 => Seg64x32f,
                    ID.F64 => Seg64f,
                    _ => Void
                    },

                TW.W128 =>
                id switch {
                    ID.U8 => Seg128x8u,
                    ID.I8 => Seg128x8i,
                    ID.U16 => Seg128x16u,
                    ID.I16 => Seg128x16i,
                    ID.U32 => Seg128x32i,
                    ID.I32 => Seg128x32i,
                    ID.U64 => Seg128x64u,
                    ID.I64 => Seg128x64i,
                    ID.F32 => Seg128x32f,
                    ID.F64 => Seg128x64f,
                    _ => Void
                    },

                TW.W256 =>
                id switch {
                    ID.U8 => Seg256x8u,
                    ID.I8 => Seg256x8i,
                    ID.U16 => Seg256x16u,
                    ID.I16 => Seg256x16i,
                    ID.U32 => Seg256x32i,
                    ID.I32 => Seg256x32i,
                    ID.U64 => Seg256x64u,
                    ID.I64 => Seg256x64i,
                    ID.F32 => Seg256x32f,
                    ID.F64 => Seg256x64f,
                    _ => Void
                    },

                TW.W512 =>
                id switch {
                    ID.U8 => Seg512x8u,
                    ID.I8 => Seg512x8i,
                    ID.U16 => Seg512x16u,
                    ID.I16 => Seg512x16i,
                    ID.U32 => Seg512x32i,
                    ID.I32 => Seg512x32i,
                    ID.U64 => Seg512x64u,
                    ID.I64 => Seg512x64i,
                    ID.F32 => Seg512x32f,
                    ID.F64 => Seg512x64f,
                    _ => Void
                    },

                _ => Void
            };

        return k;
    }

    [MethodImpl(Inline)]
    public static SK segkind<W,T>(W w = default, T t = default)
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
            return Void;
    }

    [MethodImpl(Inline)]
    public static SK segkind<T>(W16 w, T t = default)
        where T : unmanaged
            => segkind_u(w,t);

    [MethodImpl(Inline)]
    public static SK segkind<T>(W32 w, T t = default)
        where T : unmanaged
            => segkind_u(w,t);

    [MethodImpl(Inline)]
    public static SK segkind<T>(W64 w, T t = default)
        where T : unmanaged
            => segkind_u(w,t);

    [MethodImpl(Inline)]
    public static SK segkind<T>(W128 w, T t = default)
        where T : unmanaged
            => segkind_u(w,t);

    [MethodImpl(Inline)]
    public static SK segkind<T>(W256 w, T t = default)
        where T : unmanaged
            => segkind_u(w,t);

    [MethodImpl(Inline)]
    public static SK segkind<T>(W512 w, T t = default)
        where T : unmanaged
            => segkind_u(w,t);

    [MethodImpl(Inline)]
    static SK segkind_u<T>(W16 w, T t = default)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return Seg16x8u;
        else if(typeof(T) == typeof(ushort))
            return Seg16u;
        else
            return segkind_i(w,t);
    }

    [MethodImpl(Inline)]
    static SK segkind_i<T>(W16 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(sbyte))
            return Seg16x8i;
        else if(typeof(T) == typeof(short))
            return Seg16i;
        else
            return Void;
    }

    [MethodImpl(Inline)]
    static SK segkind_u<T>(W32 w, T t = default)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return Seg32x8u;
        else if(typeof(T) == typeof(ushort))
            return Seg32x16u;
        else if(typeof(T) == typeof(uint))
            return Seg32u;
        else
            return segkind_i(w,t);
    }

    [MethodImpl(Inline)]
    static SK segkind_i<T>(W32 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(sbyte))
            return Seg32x8i;
        else if(typeof(T) == typeof(short))
            return Seg32x16i;
        else if(typeof(T) == typeof(int))
            return Seg32i;
        else
            return segkind_f(w, t);
    }

    [MethodImpl(Inline)]
    static SK segkind_f<T>(W32 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(float))
            return Seg32f;
        else
            return Void;
    }

    [MethodImpl(Inline)]
    static SK segkind_u<T>(W64 w, T t = default)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return Seg64x8u;
        else if(typeof(T) == typeof(ushort))
            return Seg64x16u;
        else if(typeof(T) == typeof(uint))
            return Seg64x32u;
        else if(typeof(T) == typeof(ulong))
            return Seg64u;
        else
            return segkind_i(w,t);
    }

    [MethodImpl(Inline)]
    static SK segkind_i<T>(W64 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(sbyte))
            return Seg64x8i;
        else if(typeof(T) == typeof(short))
            return Seg64x16i;
        else if(typeof(T) == typeof(int))
            return Seg64x32i;
        else if(typeof(T) == typeof(long))
            return Seg64i;
        else
            return segkind_f(w, t);
    }

    [MethodImpl(Inline)]
    static SK segkind_f<T>(W64 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(float))
            return Seg64x32f;
        else if(typeof(T) == typeof(double))
            return Seg64f;
        else
            return Void;
    }

    [MethodImpl(Inline)]
    static SK segkind_u<T>(W128 w, T t = default)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return Seg128x8u;
        else if(typeof(T) == typeof(ushort))
            return Seg128x16u;
        else if(typeof(T) == typeof(uint))
            return Seg128x32u;
        else if(typeof(T) == typeof(ulong))
            return Seg128x64u;
        else
            return segkind_i(w,t);
    }

    [MethodImpl(Inline)]
    static SK segkind_i<T>(W128 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(sbyte))
            return Seg128x8i;
        else if(typeof(T) == typeof(short))
            return Seg128x16i;
        else if(typeof(T) == typeof(int))
            return Seg128x32i;
        else if(typeof(T) == typeof(long))
            return Seg128x64i;
        else
            return segkind_f(w, t);
    }

    [MethodImpl(Inline)]
    static SK segkind_f<T>(W128 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(float))
            return Seg128x32f;
        else if(typeof(T) == typeof(double))
            return Seg128x64f;
        else
            return Void;
    }

    [MethodImpl(Inline)]
    static SK segkind_u<T>(W256 w, T t = default)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return Seg256x8u;
        else if(typeof(T) == typeof(ushort))
            return Seg256x16u;
        else if(typeof(T) == typeof(uint))
            return Seg256x32u;
        else if(typeof(T) == typeof(ulong))
            return Seg256x64u;
        else
            return segkind_i(w,t);
    }

    [MethodImpl(Inline)]
    static SK segkind_i<T>(W256 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(sbyte))
            return Seg256x8i;
        else if(typeof(T) == typeof(short))
            return Seg256x16i;
        else if(typeof(T) == typeof(int))
            return Seg256x32i;
        else if(typeof(T) == typeof(long))
            return Seg256x64i;
        else
            return segkind_f(w, t);
    }

    [MethodImpl(Inline)]
    static SK segkind_f<T>(W256 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(float))
            return Seg256x32f;
        else if(typeof(T) == typeof(double))
            return Seg256x64f;
        else
            return Void;
    }

    [MethodImpl(Inline)]
    static SK segkind_u<T>(W512 w, T t = default)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return Seg512x8u;
        else if(typeof(T) == typeof(ushort))
            return Seg512x16u;
        else if(typeof(T) == typeof(uint))
            return Seg512x32u;
        else if(typeof(T) == typeof(ulong))
            return Seg512x64u;
        else
            return segkind_i(w,t);
    }

    [MethodImpl(Inline)]
    static SK segkind_i<T>(W512 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(sbyte))
            return Seg512x8i;
        else if(typeof(T) == typeof(short))
            return Seg512x16i;
        else if(typeof(T) == typeof(int))
            return Seg512x32i;
        else if(typeof(T) == typeof(long))
            return Seg512x64i;
        else
            return segkind_f(w, t);
    }

    [MethodImpl(Inline)]
    static SK segkind_f<T>(W512 w, T t = default)
        where T : struct
    {
        if(typeof(T) == typeof(float))
            return Seg512x32f;
        else if(typeof(T) == typeof(double))
            return Seg512x64f;
        else
            return Void;
    }

    public static byte nonempty(in TypeSeq src)
    {
        var count = z8;
        for(var i=0; i<src.MaxCount; i++)
        {
            ref readonly var type = ref src[i];
            if(type.IsVoid)
                break;
            count++;
        }
        return count;
    }

    [MethodImpl(Inline)]
    public static NativeSegType seg(Scalar type, byte count)
        => new (type,count);

    [MethodImpl(Inline), Op]
    public static NativeSegType seg16(Scalar cell)
        => seg(cell, (byte)(16/cell.Width));

    [MethodImpl(Inline), Op]
    public static NativeSegType seg32(Scalar cell)
        => seg(cell, (byte)(32/cell.Width));

    [MethodImpl(Inline), Op]
    public static NativeSegType seg64(Scalar cell)
        => seg(cell, (byte)(64/cell.Width));

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128(Scalar cell)
        => seg(cell, (byte)(128/cell.Width));

    [MethodImpl(Inline), Op]
    public static NativeSegType seg256(Scalar cell)
        => seg(cell, (byte)(256/cell.Width));

    [MethodImpl(Inline), Op]
    public static NativeSegType seg512(Scalar cell)
        => seg(cell, (byte)(256/cell.Width));

    [MethodImpl(Inline)]
    public static NativeSegType seg(NativeClass @class, NativeSizeCode total, NativeSizeCode cell)
    {
        var a = (uint)total;
        var count = ((uint)Sized.width(total))/((uint)Sized.width(cell));
        var dst =  (ushort)((uint)cell | ((uint)@class << 4) | (count << 8));
        return @as<ushort,NativeSegType>(dst);
    }

    [MethodImpl(Inline)]
    public static NativeSegType seg(NativeClass @class, ushort total, ushort cell)
        => seg(@class, Sized.native(total), Sized.native(cell));

    [MethodImpl(Inline), Op]
    public static NativeSig sig(string scope, string name, NativeType ret, params Operand[] ops)
        => new (scope, name, ret, ops);

    [MethodImpl(Inline), Op]
    public static NativeSig sig(string name, NativeType ret, params Operand[] ops)
        => new (EmptyString, name, ret, ops);

    [MethodImpl(Inline), Op]
    public static NativeSegType seg16x8u()
        => Seg16x8u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg16x8i()
        => Seg16x8i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg32x8u()
        => Seg32x8u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg32x8i()
        => Seg32x8i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg32x16u()
        => Seg32x16u;

    [MethodImpl(Inline), Op]
    public static NativeType seg32x16i()
        => Seg32x16i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg64x8u()
        => Seg64x8u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg64x8i()
        => Seg64x8i;

    [MethodImpl(Inline), Op]
    public static NativeType seg64x16u()
        => Seg64x16u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg64x32u()
        => Seg64x32u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg64x32i()
        => Seg64x32i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x8u()
        => Seg128x8u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x8i()
        => Seg128x8i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x16u()
        => Seg128x16u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x16i()
        => Seg128x16i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x32u()
        => Seg128x32u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x32i()
        => Seg128x32i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x64u()
        => Seg128x64u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x64i()
        => Seg128x64i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x16f()
        => Seg128x16f;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x32f()
        => Seg128x32f;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg128x64f()
        => Seg128x64f;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg256x8u()
        => Seg256x8u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg256x8i()
        => Seg256x8i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg256x16u()
        => Seg256x16u;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg256x16i()
        => Seg256x16i;

    [MethodImpl(Inline), Op]
    public static NativeSegType seg256x32u()
        => Seg256x32u;

    [MethodImpl(Inline), Op]
    public static NativeType seg256x32i()
        => Seg256x32i;

    [MethodImpl(Inline), Op]
    public static NativeType seg256x64u()
        => Seg256x64u;

    [MethodImpl(Inline), Op]
    public static NativeType seg256x64i()
        => Seg256x64i;

    [MethodImpl(Inline), Op]
    public static NativeType seg256x16f()
        => Seg256x16f;

    [MethodImpl(Inline), Op]
    public static NativeType seg256x32f()
        => Seg256x32f;

    [MethodImpl(Inline), Op]
    public static NativeType seg256x64f()
        => Seg256x64f;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x8u()
        => Seg512x8u;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x8i()
        => Seg512x8i;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x16u()
        => Seg512x16u;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x16i()
        => Seg512x16i;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x32u()
        => Seg512x32u;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x32i()
        => Seg512x32i;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x64u()
        => Seg512x64u;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x64i()
        => Seg512x64i;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x16f()
        => Seg512x16f;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x32f()
        => Seg512x32f;

    [MethodImpl(Inline), Op]
    public static NativeType seg512x64f()
        => Seg512x64f;

    [MethodImpl(Inline), Op]
    public static Scalar scalar(NativeSize size, NativeClass @class)
        => new Scalar(size, @class);

    [MethodImpl(Inline), Op]
    public static NativeType @void()
        => NativeType.define(Scalar.Void);

    [MethodImpl(Inline), Op]
    public static NativeType unsigned(NativeSize size)
        => new NativeType(scalar(size, NativeClass.U));

    [MethodImpl(Inline), Op]
    public static NativeType signed(NativeSize size)
        => new (scalar(size, NativeClass.I));

    [MethodImpl(Inline), Op]
    public static NativeType fractional(NativeSize size)
        => new (scalar(size, NativeClass.F));

    [MethodImpl(Inline), Op]
    public static NativeType character(NativeSize size)
        => new (scalar(size, NativeClass.C));

    [MethodImpl(Inline), Op]
    public static NativeType bit()
        => new (scalar(W.W8, NativeClass.B));

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
 
    [MethodImpl(Inline)]
    public static Operand op(Label name, NativeType type)
        => new (name,type, Modifier.Empty);

    [MethodImpl(Inline)]
    public static Operand op(Label name, NativeType type, Modifier mod)
        => new (name,type, mod);

    [MethodImpl(Inline), Op]
    public static Operand ptr(Label name, NativeType type)
        => op(name,type, Pointer);

    [MethodImpl(Inline), Op]
    public static Operand @const(Label name, NativeType type)
        => op(name,type, Const);

    [MethodImpl(Inline), Op]
    public static Operand @constptr(Label name, NativeType type)
        => op(name,type, Const | Pointer);

    [MethodImpl(Inline), Op]
    public static Operand @ref(Label name, NativeType type)
        => op(name,type, Ref);

    [MethodImpl(Inline), Op]
    public static Operand @in(Label name, NativeType type)
        => op(name,type, In);

    [MethodImpl(Inline), Op]
    public static Operand @out(Label name, NativeType type)
        => op(name,type, Out);

    [MethodImpl(Inline), Op]
    public static char indicator(NativeClass @class)
        => @class switch {
            B => Chars.b,
            U => Chars.u,
            I => Chars.i,
            F => Chars.f,
            C => Chars.c,
            _ => ' ',
        };

    public static string format(MapEntry src)
        => string.Format("{0} -> {1}", src.Source, src.Target);

    public static string format(Scalar src)
        => src.IsVoid ? "void" : string.Format("{0}{1}", (ushort)src.Width, indicator(src.Class));

    public static string format(NativeSegType src)
        => src.CellCount <= 1 ? format(src.CellType) : string.Format("{0}x{1}", src.Width, format(src.CellType));

    public static string format(NativeType src)
        => src.IsSegmeted ? format(src.AsSegType()) : format(src.AsCellType());

    public static string format(in NativeSig src, SigFormatStyle style = default)
    {
        switch(style)
        {
            case SigFormatStyle.Functional:
                return functional(src);
            case SigFormatStyle.C:
            case SigFormatStyle.CSharp:
                return cstyle(src);
            default:
                return RP.Error;
        }
    }

    public static string format(in NativeSigRef src, SigFormatStyle style = default)
    {
        switch(style)
        {
            case SigFormatStyle.Functional:
                return functional(src);
            case SigFormatStyle.C:
            case SigFormatStyle.CSharp:
                return cstyle(src);
            default:
                return RP.Error;
        }
    }

    static sbyte patternidx(in Modifier mod)
    {
        sbyte index = -1;
        if(mod.IsEmpty)
            index = 0;
        if(mod.IsConstPointer)
            index = 1;
        else if(mod.IsRefPointer)
            index = 2;
        else if(mod.IsOutPointer)
            index = 3;
        else if(mod.IsPointer)
            index = 4;
        else if(mod.IsOut)
            index = 5;
        else if(mod.IsIn)
            index = 6;
        else if(mod.IsConst)
            index = 7;
        return index;
    }

    public static string format(in Operand src, SigFormatStyle style = default)
    {
        var mod = src.Modifiers;
        var index = patternidx(src.Modifiers);
        if(index < 0)
            return RP.Error;

        var pattern = EmptyString;
        switch(style)
        {
            case SigFormatStyle.Functional:
                pattern = FunctionalFormats[index];
            break;
            case SigFormatStyle.C:
            case SigFormatStyle.CSharp:
                pattern = CFormats[index];
            break;
        }

        if(sys.empty(pattern))
            return RP.Error;

        return string.Format(pattern, src.Type, src.Name);
    }

    static string functional(in NativeSig src)
    {
        var dst = TextFormat.emitter();
        if(empty(src.Scope))
            dst.Append(src.Name);
        else
            dst.AppendFormat("{0}::{1}:", src.Scope, src.Name);

        var operands = src.Operands;
        var opcount = operands.Count;
        for(var i=0; i<opcount; i++)
        {
            ref readonly var op = ref operands[i];
            if(i == 0)
                dst.Append(op.Format(SigFormatStyle.Functional));
            else
                dst.AppendFormat(" -> {0}", op.Format(SigFormatStyle.Functional));
        }

        dst.AppendFormat(" -> {0}", src.ReturnType.Format());
        return dst.Emit();
    }

    static string functional(in NativeSigRef src)
    {
        var dst = TextFormat.emitter();
        dst.AppendFormat("{0}::{1}:", src.Scope, src.Name);

        ref readonly var opcount = ref src.OperandCount;
        for(var i=0; i<opcount; i++)
        {
            ref readonly var op = ref src[i];
            if(i == 0)
                dst.Append(op.Format(SigFormatStyle.Functional));
            else
                dst.AppendFormat(" -> {0}", op.Format(SigFormatStyle.Functional));
        }

        dst.AppendFormat(" -> {0}", src.Return.Type.Format());
        return dst.Emit();
    }

    static string cstyle(in NativeSigRef src)
    {
        var dst = TextFormat.emitter();
        dst.AppendFormat("{0} {1}(", src.Return.Type, src.Name);

        ref readonly var opcount = ref src.OperandCount;
        for(var i=0; i<opcount; i++)
        {
            ref readonly var op = ref src[i];
            if(i==0)
                dst.Append(op.Format(SigFormatStyle.C));
            else
                dst.AppendFormat(", {0}", op.Format(SigFormatStyle.C));
        }

        dst.Append(");");
        return dst.Emit();
    }

    static string cstyle(in NativeSig src)
    {
        var dst = TextFormat.emitter();
        dst.AppendFormat("{0} {1}(", src.ReturnType, src.Name);

        var operands = src.Operands;
        var opcount = operands.Count;
        for(var i=0; i<opcount; i++)
        {
            ref readonly var op = ref operands[i];
            if(i==0)
                dst.Append(op.Format(SigFormatStyle.C));
            else
                dst.AppendFormat(", {0}", op.Format(SigFormatStyle.C));
        }

        dst.Append(");");
        return dst.Emit();
    }

    static Index<string> FunctionalFormats = new string[]{
        "{1}:{0}",          // default
        "{1}:const {0}*",  // const ptr
        "{1}:ref {0}*",     // ref ptr
        "{1}:out {0}*",     // out ptr
        "{1}:{0}*",         // ptr
        "{1}:out {0}",      // out
        "{1}:in {0}",       // in
        "{1}:const {0}",   // const
        };


    static Index<string> CFormats = new string[]{
        "{0} {1}",          // default
        "const {0}* {1}",   // const ptr
        "ref {0}* {1}",     // ref ptr
        "out {0}* {1}",     // out ptr
        "{0}* {1}",         // ptr
        "out {0} {1}",      // out
        "in {0} {1}",       // in
        "const {0} {1}",    // const
        };
}
