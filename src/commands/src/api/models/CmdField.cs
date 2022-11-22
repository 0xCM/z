//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Represents an attribute within a <see cref='CmdTypeInfo'/>
    /// </summary>
    public readonly record struct CmdField : IComparable<CmdField>
    {
        /// <summary>
        /// The relative, 0-based position of thef field
        /// </summary>
        public readonly byte Index;

        /// <summary>
        /// The fields' runtime type
        /// </summary>
        public readonly FieldInfo Source;

        public readonly string Expr;

        [MethodImpl(Inline)]
        public CmdField(byte index, FieldInfo src, string expr)
        {
            Index = index;
            Source = src;
            Expr = expr;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(hash(FieldName), hash(Expr)) | (Hash32)Index;
        }

        public override int GetHashCode()
            => Hash;

        public string FieldName
        {
            [MethodImpl(Inline)]
            get => Source.Name;
        }

        public string Format()
            => ApiCmdTypes.format(this);

        public override string ToString()
            => Format();

        public bool Equals(CmdField src)
            => FieldName == src.FieldName && Expr == src.Expr && Index == src.Index;

        public int CompareTo(CmdField src)
           => Index.CompareTo(src.Index);
    }
}