//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class text
    {

        [Op]
        public static string normalize(string src, params Pair<string>[] repl)
        {
            var dst = src;
            var count = repl.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var r = ref skip(repl,i);
                dst = text.replace(dst, r.Left, r.Right);
            }
            return dst;
        }
    }
}