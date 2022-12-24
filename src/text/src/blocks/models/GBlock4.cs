//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines storage for contiguous sequence of 4 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock4<T> : IGBlock<GBlock4<T>>
        where T : unmanaged
    {
        public const uint CellCount = 4;

        GBlock2<T> A;

        GBlock2<T> B;

        public static GBlock4<T> Empty => default;
    }
}