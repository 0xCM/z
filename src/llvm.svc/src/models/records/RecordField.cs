//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct RecordField
    {
        const string TableId = "llvm.fields";

        /// <summary>
        /// The name of the declaring record
        /// </summary>
        [Render(64)]
        public string RecordName;

        /// <summary>
        /// The field data type
        /// </summary>
        [Render(32)]
        public asci32 DataType;

        /// <summary>
        /// The name of the represented member
        /// </summary>
        [Render(32)]
        public string Name;

        /// <summary>
        /// The field value
        /// </summary>
        [Render(1)]
        public string Value;

        [MethodImpl(Inline)]
        public RecordField(string record, asci32 type, string name, string value)
        {
            RecordName = record;
            DataType = type;
            Name = name;
            Value = value;
        }

        public static RecordField Empty => new RecordField(Identifier.Empty, EmptyString, EmptyString, EmptyString);

        public static ReadOnlySpan<byte> RenderWidths => new byte[]{64,32,32,1};
    }
}