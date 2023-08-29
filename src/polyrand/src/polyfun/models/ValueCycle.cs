//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public struct ValueCycle<T> : ISource<ValueCycle<T>,T>
    where T : struct
{
    readonly Index<T> Data;

    uint Position;

    [MethodImpl(Inline)]
    public ValueCycle(Index<T> src)
    {
        Data = src;
        Position = 0;
    }

    [MethodImpl(Inline)]
    public ref readonly T NextRef()
    {
        if(Position >= Data.Count)
            Position = 0;

        return ref Data[Position++];
    }

    [MethodImpl(Inline)]
    public T Next()
        => NextRef();
}
