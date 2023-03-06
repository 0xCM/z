//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class FileChangeTriggers
    {
        static void discover(Assembly src, ConcurrentBag<IFileChangeTrigger> dst)
        {
            var attributions = src.Types().Concrete().Attributions<FileChangeTriggerAttribute>();
            iter(attributions, a => dst.Add((IFileChangeTrigger)Activator.CreateInstance(a.Type)));
        }

        public static ReadOnlySeq<IFileChangeTrigger> discover(params Assembly[] src)
        {
            var dst = bag<IFileChangeTrigger>();
            iter(src, a => discover(a,dst), true);
            return dst.Array();
        }
    }
}