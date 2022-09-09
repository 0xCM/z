//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct ApiHostUri : IApiUri<ApiHostUri>
    {
        public readonly PartName Part {get;}

        public readonly string HostName {get;}

        public readonly string UriText {get;}

        public readonly Hash32 Hash;

        [MethodImpl(Inline)]
        public ApiHostUri(PartName owner, string name)
        {
            Part = owner;
            HostName = text.ifempty(OpIdentity.safe(name),  "__empty__");
            UriText = owner.IsNonEmpty ? string.Format("{0}{1}{2}", Part.Format(), IDI.UriPathSep, HostName) : HostName;
            Hash = hash(UriText);
        }

        public Identifier Id
            => IsEmpty ? "__empty__" : string.Format("{0}.{1}", Part.Format(), HostName);

        [MethodImpl(Inline)]
        ApiHostUri(string name)
        {
            Part = PartId.None;
            HostName = EmptyString;
            UriText = EmptyString;
            Hash = 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(HostName);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(HostName);
        }

        Hash32 IHashed.Hash 
            => Hash;
        // public FileName FileName(FileExt ext)
        //     => FS.file(string.Format("{0}.{1}", Part.Format(), HostName), ext);

        // public FileName FileName(FileKind kind)
        //     => FS.file(string.Format("{0}.{1}", Part.Format(), HostName), kind.Ext());

        [MethodImpl(Inline)]
        public string Format()
            => UriText ?? EmptyString;

        [MethodImpl(Inline)]
        public bool Equals(ApiHostUri src)
            => string.Equals(UriText, src.UriText, NoCase);

        [MethodImpl(Inline)]
        public int CompareTo(ApiHostUri src)
            => UriText?.CompareTo(src.UriText) ?? int.MaxValue;

        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();

        public static ApiHostUri Empty
            => new ApiHostUri(EmptyString);
    }
}