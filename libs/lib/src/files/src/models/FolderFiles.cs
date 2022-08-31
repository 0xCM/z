//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FolderFiles : IIndex<FilePath>
    {
        public readonly FolderPath Location;

        public readonly Files Files;

        public FolderFiles(FolderPath dir, FilePath[] files)
        {
            Location = dir;
            Files = files;
        }

        public Index<FilePath> Data
        {
            [MethodImpl(Inline)]
            get => Files.Storage;
        }

        public FilePath[] Storage
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

        public ref readonly FilePath this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly FilePath this[int index]
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
        public static implicit operator Files(FolderFiles src)
            => src.Files;

        [MethodImpl(Inline)]
        public static implicit operator FilePath[](FolderFiles src)
            => src.Storage;
    }
}