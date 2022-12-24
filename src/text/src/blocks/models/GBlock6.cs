//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 6 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock6<T> : IGBlock<GBlock6<T>>
        where T : unmanaged
    {
        public const uint CellCount = 6;

        GBlock3<T> A;

        GBlock3<T> B;

       public static GBlock6<T> Empty => default;

    }
}