//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CsvFormatFx<T>
        where T : struct         
    {
        static ICsvFormatter<T> Formatter = Tables.formatter<T>();

        public static Func<T,string> Fx => (T src) => Tables.formatter<T>().Format(src);
    }
}