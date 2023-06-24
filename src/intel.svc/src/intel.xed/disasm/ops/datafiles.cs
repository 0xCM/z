//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedDisasm
    {
        public static Index<XedDisasmFile> datafiles(IDbArchive context, bool pll = true)
        {
            var src = sources(context);
            var dst = sys.bag<XedDisasmFile>();
            iter(src, file => dst.Add(datafile(file)), pll);
            return dst.Index().Sort();
        }
    }
}