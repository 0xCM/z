//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    public class DataList<T> : IEnumerable<T>
    {
        internal readonly List<T> Storage;

        bool Closed;

        public DataList()
        {
            Storage = new List<T>(128);
            Closed = false;
        }

        public DataList(uint capacity)
        {
            Storage = new List<T>((int)capacity);
            Closed = false;
        }

        public DataList(int capacity)
        {
            Storage = new List<T>(capacity);
            Closed = false;
        }

        public DataList(T[] src)
        {
            Storage = new List<T>(src.Length);
            Storage.AddRange(src);
        }

        [MethodImpl(Inline)]
        public void Add(T src)
        {
            if(!Closed)
                Storage.Add(src);
        }

        [MethodImpl(Inline)]
        public void Add(ReadOnlySpan<T> src)
        {
            if(!Closed)
                for(var i=0; i<src.Length; i++)
                    Add(skip(src,i));
        }

        [MethodImpl(Inline)]
        public void Add(T[] src)
        {
            if(!Closed)
                Storage.AddRange(src);
        }

        public void AddRange(ReadOnlySpan<T> src)
            => Add(src);

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Storage.Count;
        }


        public T[] Seal()
        {
            var storage = Lists.storage(Storage);
            Closed = true;
            return storage;
        }

        public ReadOnlySpan<T> View()
            => Storage.ViewDeposited();

        [MethodImpl(Inline)]
        public T[] Emit(bool clear = true)
        {
            var data = Storage.ToArray();
            Clear();
            return data;
        }

        [MethodImpl(Inline)]
        public void Clear()
        {
            Storage.Clear();
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Storage.Count != 0;
        }

        public T this[int index]
        {
            [MethodImpl(Inline)]
            get => Storage[index];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Storage.Count == 0;
        }

        public IReadOnlyList<T> Items
        {
            [MethodImpl(Inline)]
            get => Storage;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)Storage).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => ((IEnumerable<T>)Storage).GetEnumerator();


        [MethodImpl(Inline)]
        public static implicit operator DataList<T>(T[] src)
            => new DataList<T>(src);

        public static DataList<T> Empty
        {
            [MethodImpl(Inline)]
            get => sys.empty<T>();
        }
    }
}