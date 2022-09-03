//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class SpanBlockEmitter
    {
        readonly IBoundSource Source;

        Index<Cell256> _Buffer;

        ByteSize BufferSize {get;}

        public SpanBlockEmitter(IBoundSource source, Pow2x64 bufferSize)
        {
            Source = source;
            BufferSize = (ulong)(bufferSize)/32;
            _Buffer = alloc<Cell256>(BufferSize);
        }

        [MethodImpl(Inline)]
        public SpanBlockEmitter(IBoundSource source, Index<Cell256> buffer)
        {
            Source = source;
            BufferSize = buffer.Length * 32;
            _Buffer = buffer;
        }

        Span<T> Buffer<T>()
            where T : unmanaged
                => recover<Cell256,T>(_Buffer.Edit);

        [MethodImpl(Inline)]
        CellEmitter<T> Cells<T>()
            where T : struct, IDataCell
                => new CellEmitter<T>(Source);

        [MethodImpl(Inline)]
        ulong BufferCellCount<W>(W w)
            where W : unmanaged, ITypeWidth
                => (ulong)BufferSize/((ulong)w.BitWidth /8);

        public void LoadPrimal<T>(SpanBlock8<T> dst)
            where T : unmanaged
        {
            var count = dst.CellCount;
            var src = Source;
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next<T>();
        }

        public void LoadPrimal<T>(SpanBlock16<T> dst)
            where T : unmanaged
        {
            var count = dst.CellCount;
            var src = Source;
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next<T>();
        }

        public void LoadPrimal<T>(SpanBlock32<T> dst)
            where T : unmanaged
        {
            var count = dst.CellCount;
            var src = Source;
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next<T>();
        }

        public void LoadPrimal<T>(SpanBlock64<T> dst)
            where T : unmanaged
        {
            var count = dst.CellCount;
            var src = Source;
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next<T>();
        }

        public void LoadPrimal<T>(SpanBlock128<T> dst)
            where T : unmanaged
        {
            var count = dst.CellCount;
            var src = Source;
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next<T>();
        }

        public void LoadPrimal<T>(SpanBlock256<T> dst)
            where T : unmanaged
        {
            var count = dst.CellCount;
            var src = Source;
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next<T>();
        }

        public void LoadCells<T>(SpanBlock8<T> dst)
            where T : unmanaged, IDataCell
        {
            var count = dst.CellCount;
            var src = Cells<T>();
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next();
        }

        public void LoadCells<T>(SpanBlock16<T> dst)
            where T : unmanaged, IDataCell
        {
            var count = dst.CellCount;
            var src = Cells<T>();
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next();
        }

        public void LoadCells<T>(SpanBlock32<T> dst)
            where T : unmanaged, IDataCell
        {
            var count = dst.CellCount;
            var src = Cells<T>();
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next();
        }

        public void LoadCells<T>(SpanBlock64<T> dst)
            where T : unmanaged, IDataCell
        {
            var count = dst.CellCount;
            var src = Cells<T>();
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next();
        }

        public void LoadCells<T>(SpanBlock128<T> dst)
            where T : unmanaged, IDataCell
        {
            var count = dst.CellCount;
            var src = Cells<T>();
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next();
        }

        public void LoadCells<T>(SpanBlock256<T> dst)
            where T : unmanaged, IDataCell
        {
            var count = dst.CellCount;
            var src = Cells<T>();
            ref var target = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = src.Next();
        }

        public SpanBlock8<T> EmitCells<T>(W8 w)
            where T : unmanaged, IDataCell
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadCells(dst);
            return dst;
        }

        public SpanBlock16<T> EmitCells<T>(W16 w)
            where T : unmanaged, IDataCell
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadCells(dst);
            return dst;
        }

        public SpanBlock32<T> EmitCells<T>(W32 w)
            where T : unmanaged, IDataCell
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadCells(dst);
            return dst;
        }

        public SpanBlock64<T> EmitCells<T>(W64 w)
            where T : unmanaged, IDataCell
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadCells(dst);
            return dst;
        }

        public SpanBlock128<T> EmitCells<T>(W128 w)
            where T : unmanaged, IDataCell
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadCells(dst);
            return dst;
        }

        public SpanBlock256<T> EmitCells<T>(W256 w)
            where T : unmanaged, IDataCell
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadCells(dst);
            return dst;
        }


        public SpanBlock8<T> EmitPrimal<T>(W8 w)
            where T : unmanaged
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadPrimal(dst);
            return dst;
        }

        public SpanBlock16<T> EmitPrimal<T>(W16 w)
            where T : unmanaged
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadPrimal(dst);
            return dst;
        }

        public SpanBlock32<T> EmitPrimal<T>(W32 w)
            where T : unmanaged
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadPrimal(dst);
            return dst;
        }

        public SpanBlock64<T> EmitPrimal<T>(W64 w)
            where T : unmanaged
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadPrimal(dst);
            return dst;
        }

        public SpanBlock128<T> EmitPrimal<T>(W128 w)
            where T : unmanaged
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadPrimal(dst);
            return dst;
        }

        public SpanBlock256<T> EmitPrimal<T>(W256 w)
            where T : unmanaged
        {
            var count = BufferCellCount(w);
            var dst = SpanBlocks.unsafeload(w, Buffer<T>());
            LoadPrimal(dst);
            return dst;
        }
    }
}