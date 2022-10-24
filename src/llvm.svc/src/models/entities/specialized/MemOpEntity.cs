//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class MemOpEntity : LlvmTableDef
    {
        public MemOpEntity(LineRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }
    }
}