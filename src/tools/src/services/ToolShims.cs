//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ToolShims 
    {
        public static Task<int> start(ShimDef shim, WfEmit channel, params string[] args)
            => start(shim, args, channel);

        static Task<int> start(ShimDef spec, ReadOnlySeq<string> args, WfEmit channel)
        {
            void status(in string src)
            {
                channel.Write(src);
            }

            void error(in string src)
            {
                channel.Error(src);
            }

            int run()
            {
                var result = 0;
                try
                {
                    var psi = ProcessStartSpec.define(spec.ShimSource, args.Storage);
                    var process = Cmd.process(psi);
                    var seq = enlist(spec,process);
                    var running = channel.Running($"{process.Id}:{spec.ShimSource}");
                    process.WaitForExit();
                    result = process.ExitCode;
                    var ran = channel.Ran(running);
                }
                catch(Exception e)
                {
                    result = -1;
                    channel.Error(e);
                }

                return result;
            }
            return sys.start(run);
        }

        public static ShimDef parse(string[] src)
        {
            var count = src.Length;
            if(count != 3)
                throw new ArgumentException(ShimDef.Grammar);

            var path = FS.path(skip(src,0));
            var target = FS.dir(skip(src,2));
            return new ShimDef(path,skip(src,1),target);
        }

        public static ShimDef validate(ShimDef src)
        {
            var dst = src;
            if(!src.ShimSource.Exists)
                @throw($"Shim target '{src.ShimSource}' does not exist");

            if(!src.TargetFolder.Exists)
                @throw($"Target directory '{src.TargetFolder}' does not exist");

            return dst;
        }

        static uint Seq;

        static uint enlist(ShimDef def, ProcessAdapter process)
        {
            var seq = inc(ref Seq);
            Shims.TryAdd(seq, new ShimmedProcess(seq, def, process));
            return seq;
        }

        static ConcurrentDictionary<uint, ShimmedProcess> Shims = new();
    }
}