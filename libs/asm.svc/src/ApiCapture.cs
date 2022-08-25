//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class ApiCapture : WfSvc<ApiCapture>
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        void CheckHex()
        {
            var src = AppDb.ApiTargets().Targets("capture");
            CheckPackedHex(src.Root);
        }

        void CheckPackedHex(FS.FolderPath src)
        {
            var ext = FS.ext(FS.ext("parsed"), FS.XPack);
            var files = src.Files(ext).ToReadOnlySpan();
            var count = files.Length;
            var hex = list<ApiHostHex>();
            for(var i=0; i<count; i++)
            {
                var file = skip(files,i);
                var elements = file.FileName.Format().Split(Chars.Dot).ToReadOnlySpan();
                if(elements.Length < 2)
                    continue;

                var part = skip(elements,0);
                var id = ApiParsers.part(part);
                if(id == 0)
                    continue;

                var uri = ApiIdentity.host(id, skip(elements,1));
                hex.Add(new (uri, ApiCode.memory(file)));
            }
        }

        public static FilePath csv(FS.FolderPath src, ApiHostUri host)
            => src + host.FileName(FS.PCsv);

        void PackHex(FS.FolderPath src, ApiHostUri host)
        {
            var counter = 0u;
            var memory = ApiCode.memory(csv(src, host));
            var blocks = memory.Sort().View;
            var buffer = span<char>(Pow2.T16);
            var dir = AppDb.ApiTargets("capture.test").Targets(string.Format("{0}.{1}", host.Part.Format(), host.HostName)).Root;
            var count = blocks.Length;
            for(var i=0; i<count; i++)
            {
                var dst = dir + FS.file(string.Format("{0:D5}", i), FS.XArray);
                var length = Hex.convert(skip(blocks,i).View, buffer);
                var content = text.format(slice(buffer,0,length));
                using var writer = dst.AsciWriter();
                writer.WriteLine(content);
            }
        }

        void CheckSize(ApiMemberCode src)
        {
            var count = src.MemberCount;
            var rebase = MemoryAddress.Zero;
            var size = 0u;
            for(var i=0; i<count; i++)
            {
                var seg = src.Segment(i);
                rebase = rebase + seg.Size;
                size += seg.Size;
            }

            Require.equal((ByteSize)size, src.CodeSize);
        }

        ClrEventListener OpenEventLog(Timestamp ts)
            => ClrEventListener.create(AppDb.AppData().Path($"clr.events.{ts}", FileKind.Log));

        void EmitAsm(ICompositeDispenser symbols, PartId part, ReadOnlySeq<ApiEncoded> src, IApiPack dst)
        {
            var buffer = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(buffer,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            FileEmit(emitter.Emit(), src.Count, dst.AsmExtractPath(part));
        }
    }
}