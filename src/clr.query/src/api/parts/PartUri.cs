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
        public PartName Id {get;}

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
        public PartUri(PartName id)
        {
            Id = id;
            UriText = id.Format();
            Hash = sys.hash(UriText);
        }

        [MethodImpl(Inline)]
        public bool Equals(PartUri src)
            => UriText.Equals(src.UriText);

        [MethodImpl(Inline)]
        public int CompareTo(PartUri other)
            => UriText.CompareTo(other.UriText);

        Hash32 IHashed.Hash 
            => Hash;

        public override int GetHashCode()
            => Hash;

        public string Format()
            => UriText;

        public override string ToString()
            => Format();
        public static PartUri Empty
            => new PartUri(PartName.Empty);
    }
}