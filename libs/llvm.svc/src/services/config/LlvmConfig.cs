//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    using K = llvm.LlvmConfigKind;

    public sealed class LlvmConfigSvc : ToolService<LlvmConfigSvc>
    {
        public LlvmConfigSvc()
            : base(ToolNames.llvm_config)
        {

        }

        public LlvmConfigSet CollectSettings()
        {
            const string Pattern = "llvm-config --{0}";
            var result = Outcome.Success;
            var options = Symbols.index<K>().View;
            var count = options.Length;
            var dst = new LlvmConfigSet();
            for(var i=0; i<count; i++)
            {
                ref readonly var option = ref skip(options,i);
                result = OmniScript.Run(string.Format(Pattern, option.Expr), out var response);
                if(result.Fail)
                    Write(result.Message);

                if(response.Length != 0)
                    store(option, first(response), dst);
            }

            return dst;
        }

        static void store(Sym<LlvmConfigKind> sym, TextLine src, LlvmConfigSet dst)
        {
            var content = text.trim(src.Content);
            if(empty(content))
                return;

            var kind = sym.Kind;
            switch(kind)
            {
                case K.Version:
                {
                    dst.Set(kind, content);
                }
                break;
                case K.IncludeDir:
                {
                    var data = FS.dir(content);
                    dst.Set(kind, data);
                }
                break;
                case K.LibDir:
                {
                    var data = FS.dir(content);
                    dst.Set(kind,data);
                }
                break;
                case K.TargetsBuilt:
                {
                    var data = content.Split(Chars.Space).Delimit(Chars.Semicolon);
                    dst.Set(kind, data);
                }
                break;
                case K.SrcRoot:
                {
                    dst.Set(kind, FS.dir(content));
                }
                break;
                case K.ObjRoot:
                {
                    dst.Set(kind, FS.dir(content));
                }
                break;
                case K.BinDir:
                {
                    dst.Set(kind, FS.dir(content));
                }
                break;
                case K.HostTarget:
                {
                    dst.Set(kind, content);
                }
                break;
                case K.CFlags:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Delimit(Chars.Semicolon);
                    dst.Set(kind, data);
                }
                break;
                case K.CxxFlags:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Delimit(Chars.Semicolon);;
                    dst.Set(kind, data);
                }
                break;
                case K.SystemLibs:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Select(FS.file).Delimit(Chars.Semicolon);;
                    dst.Set(kind,data);
                }
                break;
                case K.LibNames:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Select(FS.file).Delimit(Chars.Semicolon);;
                    dst.Set(kind, data);
                }
                break;
                case K.CppFlags:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Delimit(Chars.Semicolon);;
                    dst.Set(kind,data);
                }
                break;
                case K.LinkerFlags:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Delimit(Chars.Semicolon);;
                    dst.Set(kind, data);
                }
                break;
                case K.LinkStatic:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Delimit(Chars.Semicolon);;
                    dst.Set(kind, data);
                }
                break;
                case K.Components:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Delimit(Chars.Semicolon);;
                    dst.Set(kind,data);
                }
                break;
                case K.Libs:
                {
                    FS.Files data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Select(FS.path);
                    dst.Set(kind, data);
                }
                break;
                case K.LibFiles:
                {
                    FS.Files data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Select(FS.path);
                    dst.Set(kind, data);
                }
                break;
            }
        }
    }
}