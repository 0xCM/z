//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.IO;

    partial class Lines
    {
        // [MethodImpl(Inline), Op]
        // public static uint lines(ReadOnlySpan<char> src, Span<string> dst, bool keepblank = false, bool trim = true)
        // {
        //     var k=0u;
        //     var m=0u;
        //     for(var i=0u; i<src.Length - 1; i++)
        //     {
        //         ref readonly var c0 = ref skip(src,i);
        //         ref readonly var c1 = ref skip(src, i+1);
        //         if(SQ.nl(c0))
        //         {
        //             if(k < dst.Length)
        //             {
        //                 seek(dst,k++) = sys.@string(slice(src,m, i-m));
        //                 m = i+1;
        //             }
        //             else
        //                 break;
        //         }
        //         else if(SQ.cr(c0) && SQ.nl(c1))
        //         {
        //             if(k < dst.Length)
        //             {
        //                 seek(dst,k++) = sys.@string(slice(src,m, i-m));
        //                 m = i+2;
        //             }
        //             else
        //                 break;
        //         }
        //     }
        //     return k;
        //     // var capacity = (uint)dst.Length;
        //     // using(var reader = new StringReader(src))
        //     // {
        //     //     var next = reader.ReadLine();
        //     //     while(next != null && k<capacity)
        //     //     {
        //     //         if(text.blank(next))
        //     //             if(keepblank)
        //     //                 seek(dst,k++) = next;
        //     //         else
        //     //             seek(dst, k++) = trim ? text.trim(next) : next;
        //     //         next = reader.ReadLine();
        //     //     }
        //     // }
        // }

        public static ReadOnlySpan<string> lines(MemoryFile src)
        {
            using var reader = new StreamReader(src.Stream, leaveOpen:true);
            return lines(reader.ReadToEnd());
        }

        [Op]
        public static ReadOnlySpan<string> lines(string src, bool keepblank = false, bool trim = true)
        {
            var lines = list<string>();
            var lineNumber = 0u;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null)
                {
                    if(text.blank(next))
                    {
                        if(keepblank)
                        {
                            lines.Add(next);
                            ++lineNumber;
                        }
                    }
                    else
                    {
                        lines.Add(trim ? text.trim(next) : next);
                        ++lineNumber;
                    }

                    next = reader.ReadLine();
                }
            }
            return lines.ViewDeposited();
        }
    }
}