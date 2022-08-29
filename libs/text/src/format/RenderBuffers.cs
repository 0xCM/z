//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RenderBuffers
    {
        public readonly Seq<object> Cells;

        public readonly Seq<uint> Widths;

        [MethodImpl(Inline)]
        RenderBuffers(uint count)
        {
            Cells = sys.alloc<object>(count);
            Widths = sys.alloc<uint>(count);
        }

        public object[] CellStorage
        {
            [MethodImpl(Inline)]
            get => Cells;
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => Cells.Count;
        }

        public ref object this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Cells[i];
        }

        public ref object this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Cells[i];
        }

        public static RenderBuffers create(uint count)
            => new (count);
    }
}