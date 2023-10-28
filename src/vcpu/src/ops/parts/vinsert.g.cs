//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial class vgcpu
{
    /// <summary>
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively designating low or hi</param>
    [MethodImpl(Inline), Closures(AllNumeric)]
    public static Vector256<T> vinsert<T>(Vector128<T> src, Vector256<T> dst, [Imm] byte lane)
        where T : unmanaged
            => vinsert_u(src,dst,(LaneIndex)lane);

    /// <summary>
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifing low or hi</param>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static Vector256<T> vinsert<T>(Vector128<T> src, Vector256<T> dst, [Imm] LaneIndex lane)
        where T : unmanaged
            => vinsert_u(src, dst, lane);

    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static Vector512<T> vinsert<T>(Vector128<T> src, Vector512<T> dst, [Imm] VectorLane lane)
        where T : unmanaged
            => vinsert_u(src, dst, lane);

    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static Vector512<T> vinsert<T>(Vector256<T> src, Vector512<T> dst, [Imm] VectorLane lane)
        where T : unmanaged
            => vinsert_u(src, dst, lane);

    [MethodImpl(Inline)]
    static Vector256<T> vinsert_u<T>(Vector128<T> src, Vector256<T> dst, LaneIndex lane)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vinsert(v8u(src), v8u(dst), lane));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vinsert(v16u(src), v16u(dst), lane));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vinsert(v64i(src), v64i(dst), lane));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vinsert(v64u(src), v64u(dst), lane));
        else
            return vinsert_i(src, dst, lane);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vinsert_i<T>(Vector128<T> src, Vector256<T> dst, LaneIndex lane)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vinsert(v8i(src), v8i(dst), lane));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vinsert(v16i(src), v16i(dst), lane));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vinsert(v32i(src), v32i(dst), lane));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vinsert(v64i(src), v64i(dst), lane));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static Vector512<T> vinsert_u<T>(Vector128<T> src, Vector512<T> dst, VectorLane lane)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vinsert(v8u(src), v8u(dst), lane));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vinsert(v16u(src), v16u(dst), lane));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vinsert(v64i(src), v64i(dst), lane));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vinsert(v64u(src), v64u(dst), lane));
        else
            return vinsert_i(src, dst, lane);
    }

    [MethodImpl(Inline)]
    static Vector512<T> vinsert_i<T>(Vector128<T> src, Vector512<T> dst, VectorLane lane)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vinsert(v8i(src), v8i(dst), lane));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vinsert(v16i(src), v16i(dst), lane));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vinsert(v32i(src), v32i(dst), lane));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vinsert(v64i(src), v64i(dst), lane));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static Vector512<T> vinsert_u<T>(Vector256<T> src, Vector512<T> dst, VectorLane lane)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vinsert(v8u(src), v8u(dst), lane));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vinsert(v16u(src), v16u(dst), lane));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vinsert(v64i(src), v64i(dst), lane));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vinsert(v64u(src), v64u(dst), lane));
        else
            return vinsert_i(src, dst, lane);
    }

    [MethodImpl(Inline)]
    static Vector512<T> vinsert_i<T>(Vector256<T> src, Vector512<T> dst, VectorLane lane)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vinsert(v8i(src), v8i(dst), lane));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vinsert(v16i(src), v16i(dst), lane));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vinsert(v32i(src), v32i(dst), lane));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vinsert(v64i(src), v64i(dst), lane));
        else
            throw no<T>();
    }

}
