//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a field
    /// </summary>
    public readonly struct MemberFieldSpec
    {
        /// <summary>
        /// The field's name
        /// </summary>
        public Identifier FieldName {get;}

        /// <summary>
        /// The name of the field data type
        /// </summary>
        public Identifier DataType {get;}

        /// <summary>
        /// The field's relative position
        /// </summary>
        public uint Position {get;}

        /// <summary>
        /// The 0-based offset address of the field in the context of a type with explicit layout; otherwise ignored
        /// </summary>
        public uint Offset {get;}

        [MethodImpl(Inline)]
        public MemberFieldSpec(Identifier field, Identifier type, uint pos, uint offset = default)
        {
            FieldName = field;
            DataType = type;
            Position = pos;
            Offset = offset;
        }

        public string Format()
            =>  string.Format(RP.PSx4, FieldName, Position, Offset, DataType);


        public override string ToString()
            => Format();
    }
}