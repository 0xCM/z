//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public readonly struct AsmImmWriter : IAsmImmWriter
    {
        public IWfRuntime Wf {get;}

        public ApiHostUri Uri {get;}

        readonly IImmArchive Target;

        readonly AsmFormatConfig Config;

        static IImmArchive ImmArchive(FolderPath root)
            => new ImmArchive(root + FS.folder("imm"));

        [MethodImpl(Inline)]
        public AsmImmWriter(IWfRuntime wf, in ApiHostUri host, IApiPack dst)
        {
            Wf = wf;
            Uri = host;
            Target = ImmArchive(dst.Root);
            Config = AsmFormatConfig.@default(out var _);
        }

        public Option<FilePath> SaveAsmImm(OpIdentity id, AsmRoutine[] src, bool append, bool refined)
        {
            var dst = Target.AsmImmPath(Uri.Part, Uri, id, refined);
            using var writer = dst.Writer(append);
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var f = ref src[i];
                if(f.IsNonEmpty)
                    writer.Write(AsmFormatter.format(f,Config));
            }
            return dst;
        }

        public ApiCodeset SaveHexImm(OpIdentity id, AsmRoutine[] src, bool append, bool refined)
        {
            if(src.Length == 0)
                return ApiCodeset.Empty;

            var path = Target.HexImmPath(Uri.Part, Uri, id, refined);
            var count = src.Length;
            var view = @readonly(src);
            var blocks = alloc<ApiCodeBlock>(count);
            ref var block = ref first(blocks);
            using var writer = path.Writer(append);
            for(var i=0; i<count; i++)
            {
                var code = skip(view,i).Code;
                seek(block,i) = skip(view,i).Code;
                writer.WriteLine(string.Format("{0,-16} | {1,-80} | {2}", code.BaseAddress, code.OpUri, code.Encoded.Format()));
            }
            return ApiCodeset.create(path, blocks);
        }
    }
}