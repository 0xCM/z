//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        [MethodImpl(Inline), Op]
        public static MsgPattern<FileUri> processing(FilePath src)
            => "Processing records from {0}";

        [MethodImpl(Inline), Op]
        public static MsgPattern<TableId,FileUri> processing(TableId table, FilePath src)
            => "Processing {0} records from {1}";

        [MethodImpl(Inline), Op]
        public static MsgPattern<Count,FileUri> imported(Count count, FilePath src)
            => "Imported {0} records from {1}";

        [MethodImpl(Inline), Op]
        public static MsgPattern<Count,FileUri> emitted(Count count, FilePath dst)
            => "Emitted {0} records to {1}";
    }
}