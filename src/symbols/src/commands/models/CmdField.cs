//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Represents an attribute within a <see cref='CmdDef'/>
    /// </summary>
    public readonly record struct CmdField : IComparable<CmdField>
    {
        public static string format(CmdField src)
            => string.Format($"{src.Name}:{src.Description}");

        /// <summary>
        /// The backing rutime field
        /// </summary>
        public readonly FieldInfo Source;

        /// <summary>
        /// The relative, 0-based position of thef field
        /// </summary>
        public readonly ushort Index;

        /// <summary>
        /// The logical field name
        /// </summary>
        public readonly @string Name;

        /// <summary>
        /// The field's data type
        /// </summary>
        public readonly @string DataType;

        /// <summary>
        /// A human-readable description of the field
        /// </summary>
        public readonly @string Description;

        [MethodImpl(Inline)]
        public CmdField(ushort index, FieldInfo source, @string name, @string type, @string desc)
        {
            Source = source;
            Index = index;
            Name = name;
            DataType = type;
            Description = desc;
        }

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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(hash(Name), hash(Description)) | (Hash32)Index;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public bool Equals(CmdField src)
            => Name == src.Name && Description == src.Description && Index == src.Index;

        public int CompareTo(CmdField src)
           => Index.CompareTo(src.Index);

        public static CmdField Empty => new CmdField(0, EmptyVessels.EmptyField, EmptyString, EmptyString, EmptyString);
    }
}