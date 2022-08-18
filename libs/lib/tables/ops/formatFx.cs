//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        public class FormatFx<T>
            where T : struct         
        {
            static IRecordFormatter<T> Formatter = formatter<T>();

            public static Func<T,string> Fx => (T src) => formatter<T>().Format(src);
        }
        
        
        public static Func<T,string> formatFx<T>(byte? fieldwidth = null, ushort rowpad = 0)
            where T : struct, IRecord<T>
        {
            string fx(T input)
            {
                return formatter<T>(fieldwidth ?? DefaultFieldWidth, rowpad).Format(input);
            }
            return fx;
        }
    }
}