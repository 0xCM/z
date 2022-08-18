//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Uri for .net clr assembly
    /// </summary>
    public readonly record struct PartUri : IApiUri<PartUri>
    {
        /// <summary>
        /// The assembly identifier, constrained to the defining enumeration
        /// </summary>
        public PartId Id {get;}

        /// <summary>
        /// The uri content
        /// </summary>
        public string UriText {get;}

        public readonly Hash32 Hash;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Id == PartId.None || string.IsNullOrWhiteSpace(UriText);
        }

        [MethodImpl(Inline)]
        internal PartUri(PartId id)
        {
            Id = id;
            UriText = id != 0 ? id.Format() : EmptyString;
            Hash = Algs.hash(UriText);
        }

        [MethodImpl(Inline)]
        public bool Equals(PartUri src)
            => Identified.equals(this, src);

        [MethodImpl(Inline)]
        public int CompareTo(PartUri other)
            => Identified.compare(this, other);

        Hash32 IHashed.Hash 
            => Hash;

        public override int GetHashCode()
            => Hash;

        public string Format()
            => UriText;

        public override string ToString()
            => Format();
        public static PartUri Empty
            => new PartUri(0);
    }
}