//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedDisasm
    {
        public static Index<XedDisasmFile> datafiles(ProjectContext context, bool pll = true)
        {
            var src = sources(context);
            var dst = sys.bag<XedDisasmFile>();
            iter(src, file => dst.Add(datafile(context,file)), pll);
            return dst.Index().Sort();
        }
    }
}