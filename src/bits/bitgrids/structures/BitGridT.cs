//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct BitGrid<T>
        where T : unmanaged
    {
        readonly GridDim<ushort> Dim;

        T Storage;

        [MethodImpl(Inline)]
        public BitGrid(GridDim<ushort> dim, T src)
        {
            Dim = dim;
            Storage = src;
        }

        public ushort RowCount
        {
            [MethodImpl(Inline)]
            get => Dim.RowCount;
        }

        public ushort ColCount
        {
            [MethodImpl(Inline)]
            get => Dim.ColCount;
        }
    }
}