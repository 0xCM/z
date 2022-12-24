//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 5 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock5<T> : IGBlock<GBlock5<T>>
        where T : unmanaged
    {
        public const uint CellCount = 5;

        GBlock4<T> A;

        GBlock<T> B;

       public static GBlock5<T> Empty => default;

    }
}