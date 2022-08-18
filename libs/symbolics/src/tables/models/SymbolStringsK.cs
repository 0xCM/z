//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public class SymbolStrings<K>
        where K : unmanaged
    {
        public string IndexName;

        public string TableName;

        public string IndexNs;

        public string TableNs;

        public ClrIntegerType IndexType;

        public bool Parametric;

        public bool EmitIndex;

        public ItemList<K,string> Entries;

        public Index<StringTableRow> Rows;

    }

    public sealed class SymTable8Spec : SymbolStrings<byte>
    {

    }

    public sealed class SymTable16Spec : SymbolStrings<ushort>
    {

    }

    public sealed class SymTable32Spec : SymbolStrings<uint>
    {

    }
}