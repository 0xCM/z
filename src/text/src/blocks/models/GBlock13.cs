//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines storage for contiguous sequence of 12 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock13<T> : IGBlock<GBlock13<T>>
        where T : unmanaged
    {
        public const uint CellCount = 13;

        GBlock7<T> A;

        GBlock6<T> B;

        public static GBlock13<T> Empty => default;
    }
}