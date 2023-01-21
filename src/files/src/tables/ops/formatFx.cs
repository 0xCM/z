//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        public static Func<T,string> formatFx<T>(byte? fieldwidth = null, ushort rowpad = 0)
        {
            string fx(T input)
            {
                return Tables.formatter<T>(fieldwidth ?? DefaultFieldWidth, rowpad).Format(input);
            }
            return fx;
        }
    }
}