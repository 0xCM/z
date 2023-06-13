//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 10 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock10<T> : IGBlock<GBlock10<T>>
        where T : unmanaged
    {
        public const uint CellCount = 10;

        GBlock8<T> A;

        GBlock2<T> B;

       public static GBlock10<T> Empty => default;

    }
}