//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines storage for contiguous sequence of 11 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock11<T> : IGBlock<GBlock11<T>>
        where T : unmanaged
    {
        public const uint CellCount = 11;

        GBlock10<T> A;

        GBlock<T> B;

        public static GBlock11<T> Empty => default;
    }
}