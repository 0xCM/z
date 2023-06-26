//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class SdmOpCodes
    {
        public static void tokenize(string src, List<string> dst)
        {
            var input = text.trim(text.despace(src));
            if(evex(input) || vex(input))
            {
                var tokens = list<string>();
                var i = text.index(input, Chars.Space);
                var dotted = text.trim(text.split(text.left(input,i), Chars.Dot));
                var spaced = text.trim(text.split(text.right(input, i), Chars.Space));
                for(var m = 0; m<dotted.Length; m++)
                {
                    if(m != 0)
                        dst.Add(AsmOcSymbols.Dot);
                    dst.Add(skip(dotted, m));
                }

                for(var m = 0; m<spaced.Length; m++)
                {
                    dst.Add(AsmOcSymbols.Sep);
                    dst.Add(skip(spaced,m));
                }                
            }
            else
            {
                var comps = text.trim(text.split(input,Chars.Space));
                for(var m=0; m <comps.Length; m++)
                {
                    if(m != 0)
                        dst.Add(AsmOcSymbols.Sep);

                    dst.Add(skip(comps,m));
                }
            }            
        }
    }
}