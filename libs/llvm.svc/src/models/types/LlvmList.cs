//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public readonly struct LlvmList : IIndex<LlvmListItem>
    {
        readonly Index<LlvmListItem> Data;

        public readonly string Name;

        [MethodImpl(Inline)]
        public LlvmList(FS.FilePath path, LlvmListItem[] items)
        {
            Name = path.FileName.WithoutExtension.Format().Remove("llvm.lists.");
            Data = items;
        }

        [MethodImpl(Inline)]
        public LlvmList(string name, LlvmListItem[] items)
        {
            Name = name;
            Data = items;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public LlvmListItem[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<LlvmListItem> Items
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ItemList<string> ToItemList()
        {
            var src = Items;
            var count = src.Length;
            var dst = alloc<ListItem<string>>(count);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (i,skip(src,i).Value);
            return (Name, dst);
        }

        public NameList ToNameList()
            => (Name, this.Map(x => x.Value));

        [MethodImpl(Inline)]
        public static implicit operator LlvmList((FS.FilePath path, LlvmListItem[] items) src)
            => new LlvmList(src.path, src.items);

        [MethodImpl(Inline)]
        public static implicit operator LlvmList((string name, LlvmListItem[] items) src)
            => new LlvmList(src.name, src.items);

        public static LlvmList Empty => new LlvmList(FS.FilePath.Empty, sys.empty<LlvmListItem>());
    }
}