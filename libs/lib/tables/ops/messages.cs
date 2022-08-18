//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial struct Tables
    {
        [MethodImpl(Inline), Op]
        public static MsgPattern<FS.FileUri> processing(FS.FilePath src)
            => "Processing records from {0}";

        [MethodImpl(Inline), Op]
        public static MsgPattern<TableId,FS.FileUri> processing(TableId table, FS.FilePath src)
            => "Processing {0} records from {1}";

        [MethodImpl(Inline), Op]
        public static MsgPattern<Count,FS.FileUri> imported(Count count, FS.FilePath src)
            => "Imported {0} records from {1}";

        [MethodImpl(Inline), Op]
        public static MsgPattern<Count,FS.FileUri> emitted(Count count, FS.FilePath dst)
            => "Emitted {0} records to {1}";
    }
}