//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CsLang
    {
        void EmitTableData(StringTable src, FS.FilePath dst)
            => TableEmit(src.Rows, dst);

        void EmitTableData<K>(SymbolStrings<K> src, FS.FilePath dst)
            where K : unmanaged
                => TableEmit(src.Rows, dst);
    }
}