//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static sys;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static Index<string> lines(string src, bool keepblank = false, bool trim = true)
        {
            var k=0u;
            var dst = list<string>();
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null)
                {
                    if(text.blank(next))
                        if(keepblank)
                            dst.Add(next);
                    else
                        dst.Add(trim ? text.trim(next) : next);
                    next = reader.ReadLine();
                }
            }
            return dst.ToArray();
        }
    }
}