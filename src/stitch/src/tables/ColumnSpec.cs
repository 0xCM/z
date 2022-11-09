//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a field
    /// </summary>
    public readonly struct ColumnSpec
    {
        /// <summary>
        /// The field's name
        /// </summary>
        public readonly Identifier Name;

        /// <summary>
        /// The name of the field data type
        /// </summary>
        public readonly Identifier DataType;

        /// <summary>
        /// The field's relative position
        /// </summary>
        public readonly uint Position;

        /// <summary>
        /// The 0-based offset address of the field in the context of a type with explicit layout; otherwise ignored
        /// </summary>
        public readonly uint Offset;

        [MethodImpl(Inline)]
        public ColumnSpec(Identifier field, Identifier type, uint pos, uint offset = default)
        {
            Name = field;
            DataType = type;
            Position = pos;
            Offset = offset;
        }

        public string Format()
            =>  string.Format(RP.PSx4, Name, Position, Offset, DataType);


        public override string ToString()
            => Format();
    }
}