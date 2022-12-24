//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 2 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock2<T> : IGBlock<GBlock2<T>>
        where T : unmanaged
    {
        public const uint CellCount = 2;

        GBlock<T> A;

        GBlock<T> B;

        public static GBlock2<T> Empty => default;
    }
}