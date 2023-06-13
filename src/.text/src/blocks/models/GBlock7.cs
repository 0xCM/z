//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 7 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock7<T> : IGBlock<GBlock7<T>>
        where T : unmanaged
    {
        public const uint CellCount = 7;

        GBlock6<T> A;

        GBlock<T> B;

        public static GBlock7<T> Empty => default;
    }
}