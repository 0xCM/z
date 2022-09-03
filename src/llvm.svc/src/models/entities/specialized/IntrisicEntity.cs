//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class IntrinsicEntity : DefFields
    {
        public const string LlvmName = "Intrinsic";

        public IntrinsicEntity(LineRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        public string TargetPrefix
        {
            get => text.remove(this[nameof(TargetPrefix)], Chars.Quote);
        }

        public string CanonicalName
        {
            get => text.remove(EntityName, "int_x86_");
        }
    }
}
