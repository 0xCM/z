//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static WinMd;

    public sealed class WinMdFlows : WfAppCmd<WinMdFlows>
    {
        static bool IsSymbolic(FilePath src)
            => FS.contains(src.Name, "<IncludeRoot>");

        public static Task<ExecToken> types(IWfChannel channel)
            => types(channel, t => {});

        public static Task<ExecToken> types(IWfChannel channel, Action<EcmaTypeDef> dst)
        {
            ExecToken Run()
            {
                var emitter = text.emitter();
                var src = AppSettings.DevPacks().Scoped("sdks/interop/winmd").Files(FS.ext("winmd"));
                var files = hashset<FileName>(
                    FS.file("Windows.Win32", FS.ext("winmd"))
                    );
                var counter = 0u;
                iter(src, path => {
                    if(files.Contains(path.FileName))
                    {
                        using var file = EcmaFile.open(path);
                        var reader = file.EcmaReader();
                        var types = reader.ReadTypeDefs();
                        iter(types, t =>{
                            emitter.AppendLine(string.Format("{0} {1:D5} {2}", t.Token, t.Token.Row, t.FullName));
                            dst(t);
                        });
                        
                    }
                }, true);

                return channel.FileEmit(emitter.Emit(), EnvDb.Scoped("winmd").Path("sdks.interop.winmd", FileKind.Csv));
            }
            return sys.start(Run);
        }

        public static Task<ExecToken> rsp(IWfChannel channel, CmdArgs args)
            => rsp(channel, args, f => {});

        public static Task<ExecToken> rsp(IWfChannel channel, CmdArgs args, Action<ResponseFile> receiver)
        {
            ExecToken Run()
            {
                var src = FS.dir(args[0]).ToArchive();
                var flow = channel.Running();
                iter(src.Files(true, FS.ext("rsp")), path => {
                    channel.Row(path, FlairKind.StatusData);
                    WinMd.parse(path, out WinMd.ResponseFile response);
                    receiver(response);
                    var options = response.Options.Where(x => x.Kind == OptionKind.Traverse);
                    iter(options, option => {
                        if(IsSymbolic(option.Value.As<FilePath>()))
                        {
                            var path = option.Value.As<FilePath>().Format(PathSeparator.FS);
                            var includes = AppSettings.WinKits().Scoped("10/include/10.0.22000.0");
                            var absolute = FS.path(text.replace(path, "<IncludeRoot>", includes.Root.Format(PathSeparator.BS)));
                            if(absolute.Exists)
                                channel.Row(string.Format("-- {1}", Symbols.format(option.Kind), absolute));
                            else
                                channel.Row($"{path} Not Found", FlairKind.Warning);
                        }
                        else
                        {
                            var path = option.Value.As<FilePath>();
                            if(!path.Exists)
                                channel.Row($"{path} Not Found", FlairKind.Warning);
                        }
                    });
                });;

                return channel.Ran(flow);
            }
            return sys.start(Run);
        }

        [CmdOp("winmd/rsp")]
        void WinMdResponse(CmdArgs args)
            => WinMdFlows.rsp(Channel,args);

        [CmdOp("winmd/types")]
        void WinMdTypes()
            => WinMdFlows.types(Channel);
    }
}