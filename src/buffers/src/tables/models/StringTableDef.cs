//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct StringTableDef
    {
        public readonly Identifier TableNs;

        public readonly Identifier TableName;

        public readonly Identifier IndexName;

        public readonly ClrIntegerType IndexType;

        public readonly Identifier IndexNs;

        public readonly bool Parametric;

        public readonly bool EmitIndex;

        public StringTableDef(Identifier tableNs, Identifier table, Identifier index, Identifier indexNs, ClrIntegerType indexType, bool parametric, bool emitIndex)
        {
            TableNs = tableNs;
            TableName = table;
            IndexName = index;
            IndexType = indexType;
            IndexNs = indexNs;
            Parametric = parametric;
            EmitIndex = emitIndex;
        }
    }
}