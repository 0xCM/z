//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 3 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock3<T> : IGBlock<GBlock3<T>>
        where T : unmanaged
    {
        public const uint CellCount = 3;

        GBlock<T> A;

        GBlock2<T> B;

        public static GBlock3<T> Empty => default;

    }
}