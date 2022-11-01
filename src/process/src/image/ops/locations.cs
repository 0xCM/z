//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ImageMemory
    {
        [Op]
        public static ReadOnlySeq<ImageLocation> locations(ProcessAdapter src)
        {
            var dst = bag<ImageLocation>();
            iter(src.Modules, m => dst.Add(location(m)), AppData.get().PllExec());
            return dst.ToArray();
        }
    }
}