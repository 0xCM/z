//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct TextFile : IFsEntry<TextFile>
    {
        public static TextFileStats stats(FilePath src)
        {
            var dst = new TextFileStats();
            using var reader = src.Utf8Reader();
            var line = reader.ReadLine();
            while(line != null)
            {
                var length = (uint)line.Length;
                if(length > dst.MaxLineLength)
                    dst.MaxLineLength = length;
                dst.CharCount += length;
                dst.LineCount++;
                line = reader.ReadLine();
            }
            return dst;
        }

        public readonly FilePath Path;

        public PathPart Name
        {
            [MethodImpl(Inline)]
            get => Path.Name;
        }

        [MethodImpl(Inline)]
        public TextFile(FilePath src)
            => Path = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public int CompareTo(TextFile src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(TextFile src)
            => Name == src.Name;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator TextFile(FilePath src)
            => new TextFile(src);

        [MethodImpl(Inline)]
        public static implicit operator FilePath(TextFile src)
            => src.Path;
    }

    partial class XTend
    {
        public static TextFileStats FileStats(this FilePath src)
            => TextFile.stats(src);
    }
}