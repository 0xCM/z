//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolProcess<P> : ToolProcess
        where P : ToolProcess<P>,new()
    {
        public static P init(IWfChannel channel, FilePath src, FilePath dst)
        {
            var process = new P();
            process.Channel = channel;
            process.SourcePath = src;
            process.TargetPath = dst;
            return process;
        }
    }
}