//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TableDoc<T>
    {
        protected readonly Index<T> Data;

        public FS.FilePath Location {get;}

        protected TableDoc(FS.FilePath path, T[] rows)
        {
            Location = path;
            Data = rows;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }
    }

    public abstract class TableDoc<D,T> : TableDoc<T>
        where D : TableDoc<D,T>
    {
        protected TableDoc(FS.FilePath path, T[] rows)
            : base(path,rows)
        {

        }
    }
}