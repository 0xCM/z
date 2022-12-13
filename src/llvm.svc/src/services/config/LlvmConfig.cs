//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using K = LlvmConfigKind;

    public sealed class LlvmConfigSvc : ToolService<LlvmConfigSvc>
    {
        public LlvmConfigSvc()
            : base("llvm-config")
        {

        }

        OmniScript OmniScript => Wf.OmniScript();
        
        public LlvmConfigSet CollectSettings()
        {
            const string Pattern = "llvm-config --{0}";
            var result = Outcome.Success;
            var options = Symbols.index<K>().View;
            var count = options.Length;
            var dst = new LlvmConfigSet(Channel);
            var response = ReadOnlySpan<TextLine>.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var option = ref skip(options,i);
                result = OmniScript.Run(string.Format(Pattern, option.Expr), out response);
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
                    dst.Set(kind, content);
                break;
                case K.IncludeDir:
                    dst.Set(kind, FS.dir(content));
                break;
                case K.LibDir:
                    dst.Set(kind, FS.dir(content));
                break;
                case K.TargetsBuilt:
                    dst.Set(kind, content.Split(Chars.Space).ToSeq());
                break;
                case K.AssertionMode:
                    dst.Set(kind, content);
                break;
                case K.SrcRoot:
                    dst.Set(kind, FS.dir(content));
                break;
                case K.ObjRoot:
                    dst.Set(kind, FS.dir(content));
                break;
                case K.BinDir:
                    dst.Set(kind, FS.dir(content));
                break;
                case K.HostTarget:
                    dst.Set(kind, content);
                break;
                case K.CFlags:
                    dst.Set(kind, content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty));
                break;
                case K.CxxFlags:
                    dst.Set(kind, content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty));
                break;
                case K.SystemLibs:
                    dst.Set(kind, content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty).Select(FS.file));
                break;
                case K.LibNames:
                    dst.Set(kind, content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty).Select(FS.file));
                break;
                case K.CppFlags:
                    dst.Set(kind, content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty));
                break;
                case K.LinkerFlags:
                {
                    dst.Set(kind, content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty));
                }
                break;
                case K.LinkStatic:
                {
                    var data = content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty);
                    dst.Set(kind, data);
                }
                break;
                case K.Components:
                    dst.Set(kind, content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty));
                break;
                case K.LibFiles:
                    dst.Set(kind, content.Split(Chars.Space).ToSeq().Select(x => x.Trim()).Where(nonempty).Select(FS.path));
                break;
            }
        }
    }
}