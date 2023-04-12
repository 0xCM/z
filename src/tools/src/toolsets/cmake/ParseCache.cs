//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools.CMake
{
    using static sys;
    
    [CmdRoute(ParseCacheCmd.CmdName)]
    class ParseCacheHandler : CmdHandler<ParseCacheCmd>
    {
        public override BoundCmd<ParseCacheCmd> Bind(CmdArgs args)
            => new(new ParseCacheCmd{
                Source = FS.path(args[0]),
                //Target = FS.path(args[1])
            }, args);

        public override void Run(ParseCacheCmd cmd)
        {
            var cache = Wf.CMake().ParseCache(cmd.Source);
            iter(cache.Vars, var => {
                Channel.Row(var.Format());
            } );
        }
    }    

    [Cmd(CmdName)]
    public record class ParseCacheCmd : Command<ParseCacheCmd>
    {
        public const string CmdName = "cmake/cache";

        public FilePath Source;

        public FilePath Target;   
    }
}