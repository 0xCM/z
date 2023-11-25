//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public static partial class XTend
{
    [MethodImpl(Inline)]
    internal static uint Max(this uint[] src)
    {
        var result = 0u;
        for(var i=0; i<src.Length; i++)
        {
            ref readonly var x = ref seek(src,i);
            if(x > result)
                result = x;
        }
        return result;
    }

    public static Address32 Lo(this MemoryAddress src)
        => (uint)src.Location;

    public static Address32 Hi(this MemoryAddress src)
        => (uint)(src.Location >> 32);

    [MethodImpl(Inline)]
    public static Address16 Quadrant(this MemoryAddress src, N0 n)
        => src.Lo().Lo;

    [MethodImpl(Inline)]
    public static Address16 Quadrant(this MemoryAddress src, N1 n)
        => src.Lo().Hi;

    [MethodImpl(Inline)]
    public static Address16 Quadrant(this MemoryAddress src, N2 n)
        => src.Hi().Lo;

    [MethodImpl(Inline)]
    public static Address16 Quadrant(this MemoryAddress src, N3 n)
        => src.Hi().Hi;
}
