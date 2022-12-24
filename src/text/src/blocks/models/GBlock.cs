//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for a T-cell
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock<T> : IGBlock<GBlock<T>>
        where T : unmanaged
    {
        public const uint CellCount = 1;

        T Data;

        public static GBlock<T> Empty => default;

    }
}