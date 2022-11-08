//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TableReaders
    {
        public static TableReader<T> reader<T>(FilePath src, RowParser<T> parser, bool header = true)
            where T : struct
                => new TableReader<T>(src, parser, header);
    }
}