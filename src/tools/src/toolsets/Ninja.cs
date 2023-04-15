//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    public class Ninja : ToolService<Ninja>
    {
        class Flow : ToolFlow<Flow>
        {
            public Flow()
                : base("ninja")
            {}

            protected override void OnStatus(TextLine src)
            {
                var i = src.Index(Chars.Space);
                var name = src.Left(i);
                var rest = src.Right(i);
                //Channel.Row(name, FlairKind.StatusData);
                //Channel.Row(rest);                
            }
        }

        class AppCmd : WfAppCmd<AppCmd>
        {
            Tooling Tooling => Wf.Tooling();

            Ninja Tool => Tooling.Tool<Ninja>();

            [CmdOp("ninja/commands")]
            void NinjaCommands(CmdArgs args)
            {
                var src = FS.archive(args[0]);
                var target = args.Length > 1 ? args[1].Value.Format() : EmptyString;
                Tool.Commands(src, target);
            }

            [CmdOp("ninja/targets")]
            void NinjaTargets(CmdArgs args)
            {
                var src = FS.archive(args[0]);
                Tool.Targets(src);
            }

            [CmdOp("ninja/data")]
            void NinjaData(CmdArgs args)
            {
                var src = FS.archive(args[0]);
                Tool.Data(src);
            }
        }

        static FilePath ToolPath => FS.path("ninja.exe");

        public override IToolFlow ToolFlow()
            => Flow.create(Channel);

        protected override ToolCmdArgs ParseArgs(string src)
        {
            return ToolCmdArgs.Empty;
        }

        static ToolCmdArgs NinjaToolArgs(IDbArchive src, string tool)
        {
            var dst = new ToolCmdArgs(sys.alloc<ToolCmdArg>(2));
            dst[0] = Tooling.option(ArgPrefixKind.Dash,"C", ArgSepKind.Space, src.Root);
            dst[1] = Tooling.option(ArgPrefixKind.Dash,"t", ArgSepKind.Space, tool);
            return dst;
        }

        public void Commands(IDbArchive src, string target = null)
        {
            var command = Tooling.command(ToolPath, NinjaToolArgs(src, "commands"));
            var suffix = EmptyString;
            var name = "ninja.commands";
            if(text.nonempty(target))
            {
                command = Tooling.command(command.ToolPath, command.Args + Tooling.arg(EmptyString, target));
                suffix = text.replace(target, Chars.FSlash, Chars.Dot);
                name = $"{name}.{suffix}";
            }
            var flow = ToolFlow();
            flow.Run(command, src.Path(name, FileKind.Cmd));
        }

        public void Targets(IDbArchive src)
        {
            var command = Tooling.command(ToolPath, NinjaToolArgs(src, "targets"));
            var flow = ToolFlow();
            var dst = src.Path("ninja.targets", FileKind.Txt);        
            flow.Run(command, dst);            
        }

        public void Deps(IDbArchive src)
        {
            var command = Tooling.command(ToolPath, NinjaToolArgs(src, "deps"));
            var flow = ToolFlow();
            var dst = src.Path("ninja.deps", FileKind.Txt);        
            flow.Run(command, dst);            
        }

        public void Rules(IDbArchive src)
        {
            var command = Tooling.command(ToolPath, NinjaToolArgs(src, "rules"));
            var flow = ToolFlow();
            var dst = src.Path("ninja.rules", FileKind.Txt);        
            flow.Run(command, dst);                        
        }

        public void CompDb(IDbArchive src)
        {
            var command = Tooling.command(ToolPath, NinjaToolArgs(src, "compdb"));
            var flow = ToolFlow();
            var dst = src.Path("ninja.compdb", FileKind.Json);        
            flow.Run(command, dst);            
        }

        public void Graph(IDbArchive src)
        {
            var command = Tooling.command(ToolPath, NinjaToolArgs(src, "graph"));
            var flow = ToolFlow();
            var dst = src.Path("ninja.graph", FileKind.Dot);
            flow.Run(command, dst);                        
        }

        public void Data(IDbArchive src)
        {
            Commands(src);
            Targets(src);
            Deps(src);
            Rules(src);
            CompDb(src);
            Graph(src);
        }
    }
}