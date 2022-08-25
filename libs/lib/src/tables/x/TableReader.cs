//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Tables;

    partial class XTend
    {
        public static TableReader<T> TableReader<T>(this FilePath src, bool header = true)
            where T : struct
                => new TableReader<T>(src, header);

        public static TableReader<T> TableReader<T>(this FilePath src, RowParser<T> parser, bool header = true)
            where T : struct
                => new TableReader<T>(src, parser, header);
    }
}