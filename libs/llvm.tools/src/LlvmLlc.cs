//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    public class LlvmLlcSvc : ToolService<LlvmLlcSvc>
    {
        public LlvmLlcSvc()
            : base("llc")
        {

        }

        Outcome BuildLlc(IProjectWsObsolete project, Paired<FS.FilePath,Index<string>> spec)
        {
            var isets = spec.Right;
            var path = spec.Left;
            var result = Outcome.Success;
            if(isets.Length == 0)
               return (false, string.Format("No instruction sets specified for {0}", path));

            var id = path.FileName.WithoutExtension.Format();
            for(var j=0; j<isets.Length; j++)
            {
                ref readonly var iset = ref isets[j];
                var script = project.Script(string.Format("llc-build-{0}", iset));
                if(script.Exists)
                {
                    var vars = CmdVars.load(("SrcId",id));
                    result = OmniScript.Run(script, vars, false, out var response);
                    if(result.Fail)
                        break;
                }
                else
                {
                    result = (false,FS.missing(script));
                    break;
                }
            }
            return result;
        }

        FS.Files Sources(IProjectWsObsolete project)
        {
            var result = Outcome.Success;
            var dir = project.Subdir("src");
            var files = FS.Files.Empty;
            if(!dir.Exists)
            {
                Error(string.Format("The project directory '{0}' does not exist", dir));
            }
            else
            {
                files = dir.Files(true, FS.ext("ll"));
            }

            return files;
        }

        public void BuildLlc(IProjectWsObsolete project)
        {
            var result = Outcome.Success;
            var src = Sources(project);
            var specs = isets(src);
            var count = specs.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref specs[i];
                result = BuildLlc(project, spec);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
            }
        }

        static Pairings<FS.FilePath,Index<string>> isets(ReadOnlySpan<FS.FilePath> src)
        {
            var count = src.Length;

            var dst = alloc<Paired<FS.FilePath,Index<string>>>(count);
            var empty = Index<string>.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                seek(dst,i) = (path,empty);
                using var reader = path.Utf8LineReader();
                var counter = 0u;
                while(reader.Next(out var line) && counter <= 3)
                {
                    var content = line.Content.Trim();
                    if(text.index(content, "; iset") >= 0)
                    {
                        var k1 = text.index(content, Chars.Eq);
                        if(k1 >= 0)
                        {
                            var isets= text.right(content,k1).Split(Chars.Plus).Select(x => x.Trim());
                            seek(dst,i) = (path,isets);
                        }
                    }
                }
            }
            return dst;
        }
    }
}