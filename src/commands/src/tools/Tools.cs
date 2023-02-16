//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    [ApiHost]
    public class Tools
    {
        [MethodImpl(Inline), Op]
        public static ToolFlagSpec flag(string name, string desc)
            => new ToolFlagSpec(name, desc);

        public static ReadOnlySeq<ToolFlagSpec> flags(FilePath src)
        {
            var k = z16;
            var dst = list<ToolFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.Eq);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.FS);
                
                if(i == NotFound)
                    continue;


                var name = text.trim(Asci.format(SQ.left(content,i)));
                var desc = text.trim(Asci.format(SQ.right(content,i)));
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }

        public static Task<ExecToken> start(IWfChannel channel, CmdArgs args)
        {
            var tool = FS.path(args[0]);
            var toolname = tool.FileName.WithoutExtension.Format();
            var running = channel.Running($"Executing '{args}'");
            var dst = AppDb.Service.DbTargets($"tools/{toolname}").Path(tool.FileName.ChangeExtension(FileKind.Help));
            return ProcessLauncher.redirect(channel, args, dst);
        }
        
        public static Task<ExecToken> vscode<T>(IWfChannel channel, T target, ToolContext? context = null)
            => ProcessLauncher.launch(channel, FS.path("code.exe"), Cmd.args(target), context);

        public static Task<ExecToken> devenv<T>(IWfChannel channel, T target, ToolContext? context = null)
            => ProcessLauncher.launch(channel, FS.path("devenv.exe"), Cmd.args(target), context);
    }
}