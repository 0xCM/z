//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static CpuBytes;

partial class vcpu
{


    [MethodImpl(Inline)]
    static Vector256<byte> blendspec(W256 w, W8 n, bool odd)
        => vcpu.vload<byte>(w,odd ? BlendSpec_Odd_256x8 : BlendSpec_Even_256x8);

    [MethodImpl(Inline)]
    static Vector256<byte> blendspec(W256 w, W16 n, bool odd)
        => vcpu.vload<byte>(w,odd ? BlendSpec_Odd_256x16 : BlendSpec_Even_256x16);

    [MethodImpl(Inline)]
    static Vector256<byte> blendspec(W256 w, W32 n, bool odd)
        => vcpu.vload<byte>(w,odd ? BlendSpec_Odd_256x32 : BlendSpec_Even_256x32);

    [MethodImpl(Inline)]
    static Vector256<byte> blendspec(N256 w, N64 n, bool odd)
        => vcpu.vload<byte>(w, odd ? BlendSpec_Odd_256x64 : BlendSpec_Even_256x64);
}
partial struct cpu
{
    /// <summary>
    /// Defines a blend specification for combining 2 256-bit vectors that selects the odd components from each vector
    /// cpu::vblend2x64[T]:w256->bool->v256x8u
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <param name="odd">Whether to select odd or even components</param>
    /// <typeparam name="T">The component type</typeparam>
    [MethodImpl(Inline)]
    public static Vector256<byte> vblendspec<T>(W256 w, bool odd)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
            return blendspec(w, w8, odd);
        else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
            return blendspec(w, w16, odd);
        else if(typeof(T) == typeof(uint) ||typeof(T) == typeof(int))
            return blendspec(w, w32, odd);
        else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
            return blendspec(w, w64, odd);
        else
            throw no<T>();
    }

    /// <summary>
    /// Retrieves a blend specification for combining 2 256-bit vectors that selects the even components from each vector
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <param name="odd">Whether to select odd or even components</param>
    /// <typeparam name="N">The component width type</typeparam>
    [MethodImpl(Inline)]
    public static Vector256<byte> vblendspec<N>(W256 w, bool odd, N n = default)
        where N : unmanaged, ITypeNat
    {
        if(typeof(N) == typeof(N8))
            return blendspec(w, w8, odd);
        else if(typeof(N) == typeof(N16))
            return blendspec(w, w16, odd);
        else if(typeof(N) == typeof(N32))
            return blendspec(w, w32, odd);
        else if(typeof(N) == typeof(N64))
            return blendspec(w, w64, odd);
        else
            throw no<N>();
    }

    [MethodImpl(Inline)]
    static Vector256<byte> blendspec(W256 w, W8 n, bool odd)
        => vcpu.vload<byte>(w,odd ? BlendSpec_Odd_256x8 : BlendSpec_Even_256x8);

    [MethodImpl(Inline)]
    static Vector256<byte> blendspec(W256 w, W16 n, bool odd)
        => vcpu.vload<byte>(w,odd ? BlendSpec_Odd_256x16 : BlendSpec_Even_256x16);

    [MethodImpl(Inline)]
    static Vector256<byte> blendspec(W256 w, W32 n, bool odd)
        => vcpu.vload<byte>(w,odd ? BlendSpec_Odd_256x32 : BlendSpec_Even_256x32);

    [MethodImpl(Inline)]
    static Vector256<byte> blendspec(N256 w, N64 n, bool odd)
        => vcpu.vload<byte>(w, odd ? BlendSpec_Odd_256x64 : BlendSpec_Even_256x64);
}
