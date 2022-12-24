//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 12 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock12<T> : IGBlock<GBlock12<T>>
        where T : unmanaged
    {
        public const uint CellCount = 12;

        GBlock6<T> A;

        GBlock6<T> B;

       public static GBlock12<T> Empty => default;

    }
}