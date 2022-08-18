//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static CodeGenerator;
    using static core;

    public sealed class ApiResPackEmitter : WfSvc<ApiResPackEmitter>
    {
        const string ProjId = "codegen.respack";

        protected override void OnInit()
        {
        }

        static FS.FileName BuildRespack => FS.file("build-respack", FS.Cmd);

        static FS.FileName PackRespack => FS.file("deploy-respack", FS.Cmd);

        void RunScripts()
        {
            // var build = ScriptRunner.RunControlScript(BuildRespack);
            // iter(build, line => Write(line));
            // var pack = ScriptRunner.RunControlScript(PackRespack);
            // iter(pack, line => Write(line));
        }

        ReadOnlySpan<ApiHostRes> Emit(ReadOnlySpan<ApiHostBlocks> src, FS.FolderPath dst, bool build = true)
        {
            var running = Running();
            var count = src.Length;
            var counter = 0u;
            var buffer = alloc<ApiHostRes>(count);
            dst.Clear();

            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                seek(target,i) = Emit(skip(src,i), dst);
                counter += seek(target,i).Count;
            }

            if(build)
                RunScripts();

            Ran(running);

            return buffer;
        }

        ApiHostRes Emit(in ApiHostBlocks src, FS.FolderPath dst)
        {
            var target = dst + ApiFiles.filename(src.Host, FS.Cs);
            var flow = EmittingFile(target);
            var emission = Emit(src, target);
            EmittedFile(flow, emission.Count);
            return emission;
        }

        ApiHostRes Emit(in ApiHostBlocks src, FS.FilePath target)
        {
            if(empty(src.Host.HostName))
            {
                Warn(string.Format("Cannot emit {0} because host name is undefined", target.ToUri()));
                return ApiHostRes.Empty;
            }

            var resources = ByteSpans.hostres(src);
            var hostname = src.Host.HostName.ReplaceAny(array('.'), '_');
            var typename = string.Concat(src.Host.Part.Format(), Chars.Underscore, hostname);
            var members = hashset<string>();
            using var writer = target.Writer();
            EmitFileHeader(writer);
            OpenFileNamespace(writer, "Z0.ByteCode");
            EmitUsingStatements(writer);
            DeclareStaticClass(writer, typename);
            for(var i=0; i<resources.Count; i++)
            {
                ref readonly var res = ref resources[i];
                if(!members.Contains(res.Identifier))
                {
                    EmitMember(writer, ByteSpans.bytespan(res));
                    members.Add(res.Identifier);
                }
            }
            CloseTypeDeclaration(writer);
            CloseFileNamespace(writer);
            return resources;
        }
    }
}