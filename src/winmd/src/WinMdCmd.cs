//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static WinMd;

    class WinMdCmd : WfAppCmd<WinMdCmd>
    {
        static bool IsSymbolic(FilePath src)
            => FS.contains(src.Name, "<IncludeRoot>");

        [CmdOp("winmd/rsp")]
        void WinMdResponse(CmdArgs args)
        {
            var src = FS.dir(args[0]).ToArchive();
            iter(src.Files(true, FS.ext("rsp")), path => {
                Channel.Row(path, FlairKind.StatusData);
                WinMd.parse(path, out WinMd.ResponseFile response);
                var options = response.Options.Where(x => x.Kind == OptionKind.Traverse);
                iter(options, option => {
                    if(IsSymbolic(option.Value.As<FilePath>()))
                    {
                        var path = option.Value.As<FilePath>().Format(PathSeparator.FS);
                        var includes = AppSettings.WinKits().Scoped("10/include/10.0.22000.0");
                        var absolute = FS.path(text.replace(path, "<IncludeRoot>", includes.Root.Format(PathSeparator.BS)));
                        if(absolute.Exists)
                            Channel.Row(string.Format("-- {1}", Symbols.format(option.Kind), absolute));
                        else
                            Channel.Row($"{path} Not Found", FlairKind.Warning);
                    }
                    else
                    {
                        var path = option.Value.As<FilePath>();
                        if(!path.Exists)
                            Channel.Row($"{path} Not Found", FlairKind.Warning);
                    }
                });
            });;
        }

        [CmdOp("winmd/types")]
        void WinMdTypes()
        {
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
                    iter(types, t => {
                        Channel.Row(string.Format("{0} {1:D5} {2}", t.Token, t.Token.Row, t.FullName));
                    });
                }

            });
        }
    }
}