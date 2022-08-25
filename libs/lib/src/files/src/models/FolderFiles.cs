//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FolderFiles : IIndex<FS.FilePath>
    {
        public readonly FS.FolderPath Location;

        public readonly FS.Files Files;

        public FolderFiles(FS.FolderPath dir, FS.FilePath[] files)
        {
            Location = dir;
            Files = files;
        }

        public Index<FS.FilePath> Data
        {
            [MethodImpl(Inline)]
            get => Files.Storage;
        }

        public FS.FilePath[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
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

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly FS.FilePath this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly FS.FilePath this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public FolderFiles Filter(FileExt ext)
            => new FolderFiles(Location, Data.Where(x => x.Ext == ext));

        public FolderFiles Filter(string pattern)
            => new FolderFiles(Location, Data.Where(x => x.Contains(pattern)));

        public void Render(ITextEmitter dst)
        {
            for(var i=0; i<Count; i++)
                dst.AppendLine(this[i].ToUri());
        }

        public string Format()
        {
            var dst = text.emitter();
            Render(dst);
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FS.Files(FolderFiles src)
            => src.Files;

        [MethodImpl(Inline)]
        public static implicit operator FS.FilePath[](FolderFiles src)
            => src.Storage;
    }
}