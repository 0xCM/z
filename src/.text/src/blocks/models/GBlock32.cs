//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines storage for contiguous sequence of 32 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock32<T> : IGBlock<GBlock32<T>>
        where T : unmanaged
    {
        public const uint CellCount = 32;

        GBlock16<T> A;

        GBlock16<T> B;

       public static GBlock32<T> Empty => default;

    }
}