//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ClrEnumRecord
    {
        public const byte FieldCount = 8;

        public const string TableId = "clr.enums";

        /// <summary>
        /// The part in which the enum is defined
        /// </summary>
        [Render(12)]
        public PartId PartId;

        /// <summary>
        /// The name of the defining type
        /// </summary>
        [Render(24)]
        public string TypeName;

        /// <summary>
        /// The metadata token of the defining type
        /// </summary>
        [Render(8)]
        public CliToken TypeId;

        /// <summary>
        /// The name of the literal identifier
        /// </summary>
        [Render(24)]
        public string FieldName;

        /// <summary>
        /// The metadata token of the defining field
        /// </summary>
        [Render(8)]
        public CliToken FieldId;

        /// <summary>
        /// The kind of primitive specialized by the enum
        /// </summary>
        [Render(12)]
        public ClrEnumKind EnumKind;

        /// <summary>
        /// The literal declaration order within the defining enum
        /// </summary>
        [Render(12)]
        public uint Position;

        /// <summary>
        /// The primitive value
        /// </summary>
        [Render(16)]
        public ulong LiteralValue;
    }
}