//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using api = PolyOps;

public struct PolyG<G> : IRngAdapter, IBoundSource
    where G : struct, IRng, IRandomSource<G,ulong>
{
    internal G Source;

    IRng IRngAdapter.Source
        => Source;

    [MethodImpl(Inline)]
    public PolyG(G g)
    {
        Source = g;
    }

    [MethodImpl(Inline)]
    public T Next<T>()
        => Next_u<T>();

    [MethodImpl(Inline)]
    T Next_u<T>()
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(Next(w8));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(Next(w16));
        else if(typeof(T) == typeof(uint))
            return generic<T>(Next(w32));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(Next(w64));
        else
            return Next_i<T>();
    }

    [MethodImpl(Inline)]
    T Next_i<T>()
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(Next(w8i));
        else if(typeof(T) == typeof(short))
            return generic<T>(Next(w16i));
        else if(typeof(T) == typeof(int))
            return generic<T>(Next(w32i));
        else if(typeof(T) == typeof(long))
            return generic<T>(Next(w64i));
        else
            return Next_f<T>();
    }

    [MethodImpl(Inline)]
    T Next_f<T>()
    {
        if(typeof(T) == typeof(float))
            return generic<T>(NextFloat(w32));
        else if(typeof(T) == typeof(double))
            return generic<T>(NextFloat(w64));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    public T Next<T>(T max)
        where T : unmanaged
            => Next_u<T>(max);

    [MethodImpl(Inline)]
    T Next_u<T>(T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(Next(uint8(max)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(Next(uint16(max)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(Next(uint32(max)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(Next(uint64(max)));
        else
            return Next_i<T>(max);
    }

    [MethodImpl(Inline)]
    T Next_i<T>(T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(Next(int8(max)));
        else if(typeof(T) == typeof(short))
            return generic<T>(Next(int16(max)));
        else if(typeof(T) == typeof(int))
            return generic<T>(Next(int32(max)));
        else if(typeof(T) == typeof(long))
            return generic<T>(Next(int64(max)));
        else
            return Next_f<T>(max);
    }

    [MethodImpl(Inline)]
    T Next_f<T>(T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(Next(float32(max)));
        else if(typeof(T) == typeof(double))
            return generic<T>(Next(float64(max)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    public T Next<T>(T min, T max)
        where T : unmanaged
            => Next_u<T>(min, max);

    [MethodImpl(Inline)]
    T Next_u<T>(T min, T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(Next(uint8(min), uint8(max)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(Next(uint16(min), uint16(max)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(Next(uint32(min), uint32(max)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(Next(uint64(min), uint64(max)));
        else
            return Next_i<T>(min, max);
    }

    [MethodImpl(Inline)]
    T Next_i<T>(T min, T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(Next(int8(min), int8(max)));
        else if(typeof(T) == typeof(short))
            return generic<T>(Next(int16(min), int16(max)));
        else if(typeof(T) == typeof(int))
            return generic<T>(Next(int32(min), int32(max)));
        else if(typeof(T) == typeof(long))
            return generic<T>(Next(int64(min), int64(max)));
        else
            return Next_f<T>(min, max);
    }

    [MethodImpl(Inline)]
    T Next_f<T>(T min, T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(Next(float32(min), float32(max)));
        else if(typeof(T) == typeof(double))
            return generic<T>(Next(float64(min), float64(max)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    public byte Next(W8 w)
        => api.next(ref Source, w);

    [MethodImpl(Inline)]
    public byte Next(byte max)
        => api.next(ref Source, max);

    [MethodImpl(Inline)]
    public byte Next(byte min, byte max)
        => api.next(ref Source, min, max);

    [MethodImpl(Inline)]
    public sbyte Next(W8i w)
        => api.next(ref Source, w);

    [MethodImpl(Inline)]
    public sbyte Next(sbyte max)
        => api.next(ref Source, max);

    [MethodImpl(Inline)]
    public sbyte Next(sbyte min, sbyte max)
        => api.next(ref Source, min, max);

    [MethodImpl(Inline)]
    public short Next(W16i w)
        => api.next(ref Source, w);

    [MethodImpl(Inline)]
    public short Next(short max)
    {
        var amax = (ulong)math.abs(max);
        return (short) (Source.Next(amax * 2) - amax);
    }

    [MethodImpl(Inline)]
    public short Next(short min, short max)
    {
        var delta = math.sub(max, min);
        return delta > 0
            ? math.add(min, (short)Source.Next((ulong)delta))
            : math.add(min, (short)Source.Next((ulong)math.negate(delta)));
    }

    [MethodImpl(Inline)]
    public ushort Next(W16 w)
        => api.next(ref Source, w);

    [MethodImpl(Inline)]
    public ushort Next(ushort max)
        => api.next(ref Source, max);

    [MethodImpl(Inline)]
    public ushort Next(ushort min, ushort max)
        => api.next(ref Source, min, max);

    [MethodImpl(Inline)]
    public int Next(W32i w)
        => api.next(ref Source, w);

    [MethodImpl(Inline)]
    public int Next(int max)
    {
        var amax = (ulong)math.abs(max);
        return (int) (Source.Next(amax * 2) - amax);
    }

    [MethodImpl(Inline)]
    public int Next(int min, int max)
    {
        var delta = math.sub(max, min);
        return delta > 0
            ? min + (int)Source.Next((ulong)delta)
            : min + (int)Source.Next((ulong)math.negate(delta));
    }

    [MethodImpl(Inline)]
    public uint Next(W32 w)
        => api.next(ref Source, w);

    [MethodImpl(Inline)]
    public uint Next(uint max)
        => api.next(ref Source, max);

    [MethodImpl(Inline)]
    public uint Next(uint min, uint max)
        => api.next(ref Source, min, max);

    [MethodImpl(Inline)]
    public long Next(W64i w)
        => api.next(ref Source, w);

    [MethodImpl(Inline)]
    public long Next(long max)
    {
        var amax = (ulong)math.abs(max);
        return (long) (Source.Next(amax * 2) - amax);
    }

    [MethodImpl(Inline)]
    public long Next(long min, long max)
    {
        var delta = math.sub(max, min);
        return delta > 0
            ? min + (long)Source.Next((ulong)delta)
            : min + (long)Source.Next((ulong)math.negate(delta));
    }

    [MethodImpl(Inline)]
    public ulong Next(W64 w)
        => api.next(ref Source, w);

    [MethodImpl(Inline)]
    public ulong Next(ulong max)
        => api.next(ref Source, max);

    [MethodImpl(Inline)]
    public ulong Next(ulong min, ulong max)
        => api.next(ref Source, min, max);

    [MethodImpl(Inline)]
    public float NextFloat(W32 w)
        => ((float)Source.Next())/float.MaxValue;

    [MethodImpl(Inline)]
    public float Next(float max)
    {
        var whole = (float)Next((int)max);
        return whole + NextFloat(w32);
    }

    [MethodImpl(Inline)]
    public float Next(float min, float max)
    {
        var whole = (float)Next((int)min, (int)max);
        return whole + NextFloat(w32);
    }

    [MethodImpl(Inline)]
    public double NextFloat(W64 w)
        => ((double)Source.Next())/double.MaxValue;

    [MethodImpl(Inline)]
    public double Next(double min, double max)
    {
        var whole = (double)Next((long)min, (long)max);
        return whole + NextFloat(w64);
    }

    [MethodImpl(Inline)]
    public double Next(double max)
    {
        var whole = (double)Next((long)max);
        return whole + NextFloat(w64);
    }

    [MethodImpl(Inline)]
    public static implicit operator PolyG<G>(G src)
        => new PolyG<G>(src);
}
