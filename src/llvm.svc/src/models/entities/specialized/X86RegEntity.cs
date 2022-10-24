//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class X86RegEntity : LlvmTableDef
    {
        public const string LlvmName = "X86Reg";

        public X86RegEntity(LineRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }
    }
}