//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdRoute : IDataType<CmdRoute>, IDataString<CmdRoute>
    {
        [Parser]
        public static bool parse(string src, out CmdRoute dst)
        {
            dst = new(src);
            return true;
        }

        const char Sep = Chars.FSlash;

        readonly ReadOnlySeq<string> Data;
    
        public readonly @string Path;

        [MethodImpl(Inline)]
        public CmdRoute(string src)
        {
            Path = src;
            Data = text.split(src, Sep);
        }

        [MethodImpl(Inline)]
        public CmdRoute(params string[] src)
        {
            Path = text.join(Sep,src);
            Data = src;
        }

        public uint PartCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly string this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly string this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Path.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsEmpty;            
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsNonEmpty;            
        }

        public CmdRoute Refine(params string[] src)
        {
            var count = Data.Length + src.Length;
            var dst = sys.alloc<string>(Data.Length + src.Length);
            var j=0u;
            for(var i=0; i< Data.Length; i++)
                sys.seek(dst,j++) = Data[i];
            for(var i=0; i< src.Length; i++)
                sys.seek(dst,j++) = src[i];
            return new CmdRoute(dst);            
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(CmdRoute src)
            => Path == src.Path;

        public int CompareTo(CmdRoute src)
            => Path.CompareTo(src.Path);

        public string Format()
            => Path;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdRoute(string src)
            => new CmdRoute(src);
        
        [MethodImpl(Inline)]
        public static implicit operator @string(CmdRoute src)
            => src.Path;

        public static CmdRoute Empty => new();
    }
}