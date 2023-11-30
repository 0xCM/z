//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    public class ApiCapture : WfSvc<ApiCapture>
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

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
            => RuntimeEvents.observe(AppDb.AppData().Path($"clr.events.{ts}", FileKind.Log));

        void EmitAsm(ICompositeDispenser symbols, PartName part, ReadOnlySeq<ApiEncoded> src, IApiPack dst)
        {
            var buffer = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(buffer,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            Channel.FileEmit(emitter.Emit(), src.Count, dst.AsmExtractPath(part));
        }
    }
}