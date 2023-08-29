//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// Produces pseudorandom numeric points and streams predicated on a supplied generator
/// </summary>
public class Polyrand : IPolyrand
{
    readonly IRandomSource<ulong> Points;

    public Option<IRandomNav> Navigator {get;}

    [MethodImpl(Inline)]
    internal Polyrand(IRandomSource<ulong> points)
    {
        Points = points;
        Navigator = default;
    }

    [MethodImpl(Inline)]
    internal Polyrand(IRandomNav<ulong> points)
    {
        Points = points;
        Navigator = Option.some(points as IRandomNav);
    }

    [MethodImpl(Inline)]
    public T Next<T>()
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(UInt8Source.Next());
        else if(typeof(T) == typeof(ushort))
            return generic<T>(UInt16Source.Next());
        else if(typeof(T) == typeof(uint))
            return generic<T>(UInt32Source.Next());
        else if(typeof(T) == typeof(ulong))
            return generic<T>(UInt64Source.Next());
        else
            return Next_i<T>();
    }

    T Next_i<T>()
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(Int8Source.Next());
        else if(typeof(T) == typeof(short))
            return generic<T>(Int16Source.Next());
        else if(typeof(T) == typeof(int))
            return generic<T>(Int32Source.Next());
        else if(typeof(T) == typeof(long))
            return generic<T>(Int64Source.Next());
        else
            return Next_f<T>();
    }

    T Next_f<T>()
    {
        if(typeof(T) == typeof(float))
            return generic<T>(Float32Source.Next());
        else if(typeof(T) == typeof(double))
            return generic<T>(Float64Source.Next());
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    public T Next<T>(T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(UInt8Source.Next(uint8(max)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(UInt16Source.Next(uint16(max)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(UInt32Source.Next(uint32(max)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(UInt64Source.Next(uint64(max)));
        else
            return Next_i(max);
    }

    [MethodImpl(Inline)]
    T Next_i<T>(T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(Int8Source.Next(int8(max)));
        else if(typeof(T) == typeof(short))
            return generic<T>(Int16Source.Next(int16(max)));
        else if(typeof(T) == typeof(int))
            return generic<T>(Int32Source.Next(int32(max)));
        else if(typeof(T) == typeof(long))
            return generic<T>(Int64Source.Next(int64(max)));
        else
            return Next_f(max);
    }

    [MethodImpl(Inline)]
    T Next_f<T>(T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(Float32Source.Next(float32(max)));
        else if(typeof(T) == typeof(double))
            return generic<T>(Float64Source.Next(float64(max)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    public T Next<T>(T min, T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(UInt8Source.Next(uint8(min), uint8(max)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(UInt16Source.Next(uint16(min), uint16(max)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(UInt32Source.Next(uint32(min), uint32(max)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(UInt64Source.Next(uint64(min), uint64(max)));
        else
            return Next_i(min,max);
    }

    [MethodImpl(Inline)]
    T Next_i<T>(T min, T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(Int8Source.Next(int8(min), int8(max)));
        else if(typeof(T) == typeof(short))
            return generic<T>(UInt16Source.Next(uint16(min), uint16(max)));
        else if(typeof(T) == typeof(int))
            return generic<T>(UInt32Source.Next(uint32(min), uint32(max)));
        else if(typeof(T) == typeof(long))
            return generic<T>(UInt64Source.Next(uint64(min), uint64(max)));
        else
            return Next_f(min,max);
    }

    [MethodImpl(Inline)]
    T Next_f<T>(T min, T max)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(Float32Source.Next(float32(min), float32(max)));
        else if(typeof(T) == typeof(double))
            return generic<T>(Float64Source.Next(float64(min), float64(max)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    public T Next<T>(Interval<T> domain)
        where T : unmanaged
            => domain.IsEmpty ? Next<T>() : Next(domain.Left, domain.Right);

    public IEnumerable<T> Take<T>(int count)
        where T : unmanaged
    {
        var counter = 0;
        while(counter++ < count)
            yield return Next<T>();
    }

    IBoundSource<sbyte> Int8Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<byte> UInt8Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<short> Int16Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<ushort> UInt16Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<int> Int32Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<uint> UInt32Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<long> Int64Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<ulong> UInt64Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<float> Float32Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    IBoundSource<double> Float64Source
    {
        [MethodImpl(Inline)]
        get => this;
    }

    [MethodImpl(Inline)]
    sbyte ISource<sbyte>.Next()
            => (sbyte) (Points.Next((ulong)sbyte.MaxValue*2) - (ulong)SByte.MaxValue);

    [MethodImpl(Inline)]
    sbyte IBoundSource<sbyte>.Next(sbyte max)
    {
        var amax = (ulong)math.abs(max);
        return (sbyte) (Points.Next(amax * 2) - amax);
    }

    [MethodImpl(Inline)]
    sbyte IBoundSource<sbyte>.Next(sbyte min, sbyte max)
    {
        var delta = math.sub(max, min);
        return delta > 0
            ? math.add(min, (sbyte)Points.Next((ulong)delta))
            : math.add(min, (sbyte)Points.Next((ulong)math.negate(delta)));
    }

    [MethodImpl(Inline)]
    byte IBoundSource<byte>.Next(byte min, byte max)
        => (byte)Points.Next((ulong)min, (ulong)max);

    [MethodImpl(Inline)]
    byte IBoundSource<byte>.Next(byte max)
        => (byte)Points.Next((ulong)max);

    [MethodImpl(Inline)]
    byte ISource<byte>.Next()
        => (byte)Points.Next((ulong)byte.MaxValue);

    [MethodImpl(Inline)]
    short ISource<short>.Next()
        => (short) (Points.Next((ulong)short.MaxValue*2) - (ulong)Int16.MaxValue);

    [MethodImpl(Inline)]
    short IBoundSource<short>.Next(short max)
    {
        var amax = (ulong)math.abs(max);
        return (short) (Points.Next(amax * 2) - amax);
    }

    [MethodImpl(Inline)]
    short IBoundSource<short>.Next(short min, short max)
    {
        var delta = math.sub(max, min);
        return delta > 0
            ? math.add(min, (short)Points.Next((ulong)delta))
            : math.add(min, (short)Points.Next((ulong)math.negate(delta)));
    }

    [MethodImpl(Inline)]
    short NextI16()
        => (short)Points.Next(((ulong)short.MaxValue*2) - (ulong)short.MaxValue);

    [MethodImpl(Inline)]
    ushort ISource<ushort>.Next()
        => (ushort)Points.Next((ushort)ushort.MaxValue);

    [MethodImpl(Inline)]
    ushort IBoundSource<ushort>.Next(ushort max)
        => (ushort)Points.Next((ulong)max);

    [MethodImpl(Inline)]
    ushort IBoundSource<ushort>.Next(ushort min, ushort max)
        => (ushort)Points.Next((ulong)min, (ulong)max);

    [MethodImpl(Inline)]
    int ISource<int>.Next()
        => (int) (Points.Next((ulong)int.MaxValue*2) - Int32.MaxValue);

    [MethodImpl(Inline)]
    int IBoundSource<int>.Next(int max)
    {
        var amax = (ulong)math.abs(max);
        return (int) (Points.Next(amax * 2) - amax);
    }

    [MethodImpl(Inline)]
    int IBoundSource<int>.Next(int min, int max)
    {
        var delta = math.sub(max, min);
        return delta > 0
            ? min + (int)Points.Next((ulong)delta)
            : min + (int)Points.Next((ulong)math.negate(delta));
    }

    [MethodImpl(Inline)]
    int NextI32()
        => (int) (Points.Next((ulong)int.MaxValue*2) - Int32.MaxValue);

    [MethodImpl(Inline)]
    uint ISource<uint>.Next()
        =>(uint)Points.Next((ulong)uint.MaxValue);

    [MethodImpl(Inline)]
    uint IBoundSource<uint>.Next(uint max)
        => (uint)Points.Next((ulong)max);

    [MethodImpl(Inline)]
    uint IBoundSource<uint>.Next(uint min, uint max)
        => (uint)Points.Next((ulong)min, (ulong)max);

    [MethodImpl(Inline)]
    uint NextU32(uint min, uint max)
        => math.add(min, (uint)Points.Next((ulong)(max - min)));

    /// <summary>
    /// Enables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to enable</param>
    [MethodImpl(Inline)]
    static long enable(long src, int pos)
        =>  src |= (1L << pos);

    [MethodImpl(Inline)]
    long ISource<long>.Next()
    {
        var next = (long)Points.Next(long.MaxValue);
        var negative = Bit32.test(next, 7);
        var result = Bit32.test(next, 7) ? enable(next, 63) : next;
        return result;
    }

    [MethodImpl(Inline)]
    long IBoundSource<long>.Next(long max)
    {
        var amax = (ulong)math.abs(max);
        return (long) (Points.Next(amax * 2) - amax);
    }

    [MethodImpl(Inline)]
    long IBoundSource<long>.Next(long min, long max)
    {
        var delta = math.sub(max, min);
        return delta > 0
            ? min + (long)Points.Next((ulong)delta)
            : min + (long)Points.Next((ulong)math.negate(delta));
    }

    [MethodImpl(Inline)]
    ulong ISource<ulong>.Next()
        => Points.Next();

    [MethodImpl(Inline)]
    ulong IBoundSource<ulong>.Next(ulong max)
        => Points.Next(max);

    [MethodImpl(Inline)]
    ulong IBoundSource<ulong>.Next(ulong min, ulong max)
        => Points.Next(min, max);

    [MethodImpl(Inline)]
    float ISource<float>.Next()
        => NextF32();

    [MethodImpl(Inline)]
    float IBoundSource<float>.Next(float max)
    {
        var whole = (float)Int32Source.Next((int)max);
        return whole + NextF32();
    }

    [MethodImpl(Inline)]
    float IBoundSource<float>.Next(float min, float max)
    {
        var whole = (float)Int32Source.Next((int)min, (int)max);
        return whole + NextF32();
    }

    [MethodImpl(Inline)]
    double ISource<double>.Next()
        => NextF64();

    [MethodImpl(Inline)]
    double IBoundSource<double>.Next(double min, double max)
    {
        var whole = (double)Int64Source.Next((long)min, (long)max);
        return whole + NextF64();
    }

    [MethodImpl(Inline)]
    double IBoundSource<double>.Next(double max)
    {
        var whole = (double)Int64Source.Next((long)max);
        return whole + NextF64();
    }

    [MethodImpl(Inline)]
    float NextF32()
        => ((float)Points.Next())/float.MaxValue;

    [MethodImpl(Inline)]
    double NextF64()
        => ((double)Points.Next())/double.MaxValue;
}
