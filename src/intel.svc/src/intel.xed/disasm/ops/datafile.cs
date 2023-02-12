//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static DisasmDataFile datafile(ProjectContext context, in FileRef src)
        {
            var dst = list<DisasmBlock>();
            var lines = src.Path.ReadNumberedLines();
            var count = lines.Length;
            var blocklines = list<TextLine>();
            var imax = count-1;
            for(var i=0; i<imax; i++)
            {
                blocklines.Clear();
                ref readonly var l0 = ref lines[i];
                ref readonly var l1 = ref lines[i+1];
                if(l0.IsNonEmpty && l1.IsNonEmpty)
                {
                    ref readonly var c0 = ref l0.Content;
                    ref readonly var c1 = ref l1.Content;
                    if(c1[0] == '0')
                    {
                        blocklines.Add(l0);
                        blocklines.Add(l1);
                        i++;
                        while(i++ < imax)
                        {
                            ref readonly var l = ref lines[i];
                            blocklines.Add(l);
                            if(l.StartsWith(DisasmParse.XDIS))
                                break;
                        }
                        dst.Add(block(blocklines.ToArray()));
                    }
                }
            }
            return new DisasmDataFile(context.Root(src), src,dst.ToArray());
        }
    }
}