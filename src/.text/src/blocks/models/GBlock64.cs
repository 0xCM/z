//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines storage for contiguous sequence of 64 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock64<T> : IGBlock<GBlock64<T>>
        where T : unmanaged
    {
        public const uint CellCount = 32;

        GBlock32<T> A;

        GBlock32<T> B;

        public static GBlock32<T> Empty => default;
    }
}