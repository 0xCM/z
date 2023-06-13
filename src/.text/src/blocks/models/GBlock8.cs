//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines storage for contiguous sequence of 8 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock8<T> : IGBlock<GBlock8<T>>
        where T : unmanaged
    {
        public const uint CellCount = 8;

        GBlock4<T> A;

        GBlock4<T> B;
        public static GBlock8<T> Empty => default;
    }
}