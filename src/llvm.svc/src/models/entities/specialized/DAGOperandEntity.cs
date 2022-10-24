//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class DAGOperandEntity : LlvmTableDef
    {
        public const string LlvmName = "DAGOperand";

        public DAGOperandEntity(LineRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        public string OperandNamespace
            => this[nameof(OperandNamespace)];

        /// <summary>
        /// Specifies the name of the operand's value type
        /// </summary>
        public string Type
            => this[nameof(Type)];

        public string PrintMethod
            => this[nameof(PrintMethod)];

        public string OperandType
            => Value(nameof(OperandType), field => text.remove(field.Value,Chars.Quote), EmptyString);

        public string MIOperandInfo
            => this[nameof(MIOperandInfo)];

        public string MCOperandPredicate
            => this[nameof(MCOperandPredicate)];

        public string ParserMatchClass
            => this[nameof(ParserMatchClass)];
    }
}