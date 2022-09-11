//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class OpUri : IApiUri<OpUri>
    {
        /// <summary>
        /// The full uri in the form {scheme}://{hostpath}/{opid}
        /// </summary>
        public readonly string UriText;

        /// <summary>
        /// The host fragment, of the form {assembly_short_name}/{hostname}
        /// </summary>
        public readonly ApiHostUri Host;

        /// <summary>
        /// Defines host-relative identity in the form, for example, {opname}_{typewidth}X{segwidth}{u | i | f}
        /// </summary>
        public readonly OpIdentity OpId;

        public readonly Hash32 Hash;

        OpUri()
        {
            UriText = EmptyString;
            Host = ApiHostUri.Empty;
            OpId = OpIdentity.Empty;
        }

        public OpUri(in ApiHostUri host, in OpIdentity opid, string uritext)
        {
            Host = host;
            OpId = opid;
            UriText = OpIdentity.safe(Require.notnull(uritext));
            Hash = sys.hash(UriText);
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

        public int CompareTo(OpUri src)
            => Content.CompareTo(src.Content);

        public bool Equals(OpUri src)
            => Content.Equals(src.Content, NoCase);

 
        public override string ToString()
            => Format();

        /// <summary>
        /// Emptiness of nothing
        /// </summary>
        public static OpUri Empty
            => new OpUri();

        string IApiUri.UriText
            => UriText;
    }
}