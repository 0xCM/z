//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using System.Runtime.Intrinsics.X86;

partial class PolyBits
{
    [MethodImpl(Inline)]
    static ulong extract(ulong src, byte offset, byte width)
        => Bmi1.X64.BitFieldExtract(src, offset, width);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T extract<T>(uint offset, byte width, T src)
        where T : unmanaged
            => generic<T>(extract(bw64(src), (byte)offset, width));

    [MethodImpl(Inline)]
    public static T extract<F,S,T>(BfDataset<F> dataset, F field, S src)
        where F : unmanaged, Enum
        where T : unmanaged
        where S : unmanaged
            => @as<S,T>(extract(dataset.Offset(field), dataset.Width(field), src));

    [MethodImpl(Inline)]
    public static T extract<F,T>(BfDataset<F,T> dataset, F field, T src)
        where F : unmanaged, Enum
        where T : unmanaged
            => extract(dataset.Offset(field), dataset.Width(field), src);
}
