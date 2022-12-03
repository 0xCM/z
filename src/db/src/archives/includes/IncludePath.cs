//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Includes;

    public readonly struct IncludePath : IIndex<FolderPath>
    {
        internal readonly Index<FolderPath> Data;

        [MethodImpl(Inline)]
        public IncludePath(params FolderPath[] src)
            => Data = src;

        public ReadOnlySpan<FolderPath> Entries
        {
            [MethodImpl(Inline)]
            get =>  Data;
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public FolderPath[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }
        public string Format()
            => api.format(this, PathSeparator.BS, true);

        public string Format(PathSeparator sep, bool quote)
            => api.format(this, sep,quote);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static IncludePath operator +(IncludePath a, IncludePath b)
            => api.concat(a,b);

        [MethodImpl(Inline)]
        public static IncludePath operator +(IncludePath a, FolderPath b)
            => api.concat(a,b);

        [MethodImpl(Inline)]
        public static IncludePath operator +(FolderPath a, IncludePath b)
            => api.concat(a,b);

        [MethodImpl(Inline)]
        public static implicit operator IncludePath(FolderPath[] src)
            => new IncludePath(src);
    }
}