//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class _OpUri : IApiUri<_OpUri>
    {
        /// <summary>
        /// The full uri in the form {scheme}://{hostpath}/{opid}
        /// </summary>
        public readonly string UriText;

        /// <summary>
        /// The host fragment, of the form {assembly_short_name}/{hostname}
        /// </summary>
        public readonly _ApiHostUri Host;

        /// <summary>
        /// Defines host-relative identity in the form, for example, {opname}_{typewidth}X{segwidth}{u | i | f}
        /// </summary>
        public readonly _OpIdentity OpId;

        public readonly Hash32 Hash;

        _OpUri()
        {
            UriText = EmptyString;
            Host = _ApiHostUri.Empty;
            OpId = _OpIdentity.Empty;
        }

        public _OpUri(in _ApiHostUri host, in _OpIdentity opid, string uritext)
        {
            Host = host;
            OpId = opid;
            UriText = _OpIdentity.safe(Require.notnull(uritext));
            Hash = Algs.hash(UriText);
        }

        Hash32 IHashed.Hash 
            => Hash;

        public override int GetHashCode()
            => Hash;
            
        /// <summary>
        /// The defining part
        /// </summary>
        public PartId Part
            => Host.Part;

        public string Content
        {
            [MethodImpl(Inline)]
            get => UriText ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.Length != 0;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public int CompareTo(_OpUri src)
            => Content.CompareTo(src.Content);

        public bool Equals(_OpUri src)
            => Content.Equals(src.Content, NoCase);

 
        public override string ToString()
            => Format();

        /// <summary>
        /// Emptiness of nothing
        /// </summary>
        public static _OpUri Empty
            => new _OpUri();

        string IApiUri.UriText
            => UriText;
    }
}