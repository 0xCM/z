//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 7 9-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock9<T> : IGBlock<GBlock9<T>>
        where T : unmanaged
    {
        public const uint CellCount = 9;

        GBlock8<T> A;

        GBlock<T> B;

        public static GBlock9<T> Empty => default;

    }
}