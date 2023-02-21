//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CsvFormatFx<T>
    {
        static ICsvFormatter<T> Formatter = CsvTables.formatter<T>();

        public static Func<T,string> Fx => (T src) => CsvTables.formatter<T>().Format(src);
    }
}