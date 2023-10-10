//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct Indicator<T> : IIndicator<T>, IIndicator<Indicator<T>,T>
    where T : unmanaged
{
    readonly T Data;

    [MethodImpl(Inline)]
    public Indicator(T data)
    {
        Data = gbits.enable(data, hipos());
    }

    [MethodImpl(Inline)]
    public Indicator(T data, bit enabled)
    {
        Data = gbits.setbit(data, hipos(), enabled);
    }

    [MethodImpl(Inline)]
    static byte hipos()
        => (byte)(sys.width<T>() - 1);

    public bit Enabled
    {
        [MethodImpl(Inline)]
        get => gbits.state(Data, hipos());
    }

    public bit Disabled
    {
        [MethodImpl(Inline)]
        get => !gbits.state(Data, hipos());
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Disabled;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Enabled;
    }

    public T Value
    {
        [MethodImpl(Inline)]
        get => gbits.disable(Data,hipos());
    }

    public string Format()
        => IsEmpty ? EmptyString : Value.ToString();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public int CompareTo(Indicator<T> src)
    {
        var result = Enabled.CompareTo(src.Enabled);
        if(result == 0 && Enabled && src.Enabled)
            result = gmath.cmp(Value, src.Value);
        return result;
    }

    public static Indicator<T> Empty => default;

    [MethodImpl(Inline)]
    public static implicit operator Indicator<T>((T data, bit present) src)
        => new Indicator<T>(src.data,src.present);

    [MethodImpl(Inline)]
    public static implicit operator Indicator<T>(T src)
        => new Indicator<T>(src);

    [MethodImpl(Inline)]
    public static explicit operator T(Indicator<T> src)
        => src.Value;
}
