//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class Permute
{
    /// <summary>
    /// Distills a natural permutation on 4 symbols to its canonical literal specification
    /// </summary>
    /// <param name="src">The source permutation</param>
    [MethodImpl(Inline), Op]
    public static Perm4L pack(NatPerm<N4> src)
    {
        const int segwidth = 2;
        const int length = 4;
        var dst = 0u;
        for(int i=0, offset = 0; i< length; i++, offset +=segwidth)
            dst |= (uint)src[i] << offset;
        return (Perm4L)dst;
    }

    /// <summary>
    /// Distills a natural permutation on 8 symbols to its canonical literal specification
    /// </summary>
    /// <param name="src">The source permutation</param>
    [MethodImpl(Inline), Op]
    public static Perm8L pack(NatPerm<N8> src)
    {
        const int segwidth = 3;
        const int length = 8;
        var dst = 0u;
        for(int i=0, offset = 0; i< length; i++, offset +=segwidth)
            dst |= (uint)src[i] << offset;
        return (Perm8L)dst;
    }

    /// <summary>
    /// Distills a natural permutation on 16 symbols to its canonical literal specification
    /// </summary>
    /// <param name="src">The source permutation</param>
    [MethodImpl(Inline), Op]
    public static Perm16L pack(NatPerm<N16> src)
    {
        const int segwidth = 4;
        const int length = 16;
        var dst = 0ul;
        for(int i=0, offset = 0; i< length; i++, offset +=segwidth)
            dst |= (ulong)src[i] << offset;
        return (Perm16L)dst;
    }
}