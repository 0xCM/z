//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static math;
    using static NasmDebugOptions;

    partial class Nasm
    {
        [Op]
        public static string render(NasmDebugOptions src)
        {
            if((src & g) == 0)
                return EmptyString;

            var b0 = (uint)test(src, Elf32DbgFormat) * 1;
            var b1 = (uint)test(src, Elf64DbgFormat) * 2;
            var b2 = (uint)test(src, Macho32DbgFormat) * 3;
            var b3 = (uint)test(src, Macho64DbgFormat) * 4;
            var b4 = (uint)test(src, Win32DbgFormat) * 5;
            var b5 = (uint)test(src, Win64DbgFormat)* 6;
            var i = coalesce(b0,b1,b2,b3,b4,b5);
            if(i==0)
                return "-g";

            return i switch{
              1 => "-g -F elf32",
              2 => "-g -F elf64",
              3 => "-g -F macho32",
              4 => "-g -F macho64",
              5 => "-g -F win32",
              6 => "-g -F win64",
                _ => EmptyString
            };
        }

        [MethodImpl(Inline), Op]
        public static bit test(NasmDebugOptions src, NasmDebugOptions value)
            => ((src & value) != 0);
    }
}