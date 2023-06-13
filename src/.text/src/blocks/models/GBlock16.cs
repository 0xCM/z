//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines storage for contiguous sequence of 16 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock16<T> : IGBlock<GBlock16<T>>
        where T : unmanaged
    {
        public const uint CellCount = 16;

        GBlock8<T> A;

        GBlock8<T> B;

        public static GBlock16<T> Empty => default;
    }
}