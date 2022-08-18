//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a value with known size
    /// </summary>
    [Free]
    public interface ISized
    {
        BitWidth BitWidth {get;}

        ByteSize ByteCount
            => BitWidth.Bytes;
    }

    [Free]
    public interface ISized<T> : ISized
        where T : unmanaged
    {
        ByteSize ISized.ByteCount
            => Sized.size<T>();

        BitWidth ISized.BitWidth
            => Sized.width<T>();
    }
}