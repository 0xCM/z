//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static sys;

    public class ApiCaptureEmitter : AppService<ApiCaptureEmitter>
    {
        MsilSvc IlPipe => Wf.MsilSvc();

        ApiCodeSvc ApiCode => Wf.ApiCode();

        HostAsmEmitter HostEmitter => Wf.HostAsmEmitter();

        public ApiCaptureEmitter()
        {
            
        }

        public Index<ApiCodeRow> EmitApiHex(ApiHostUri host, Index<MemberCodeBlock> src, IApiPack dst)
            => ApiCode.EmitApiHex(host, src.View, dst);

        public Count EmitMsilCode(ApiHostUri host, Index<MemberCodeBlock> src, FilePath dst)
        {
            if(src.Count != 0)
                IlPipe.EmitCode(src, dst);
            return src.Count;
        }

        public Index<MsilCapture> EmitMsilData(ApiHostUri host, Index<MemberCodeBlock> src, FilePath dst)
            => IlPipe.EmitData(src, dst);

        public Index<ApiExtractRow> EmitExtracts(ApiHostUri host, Index<ApiMemberExtract> src, FilePath dst)
        {
            var count = src.Length;
            var blocks = src.Map(x => x.Block);
            var flow = Wf.EmittingTable<ApiExtractRow>(dst);
            var emitted = Emit(blocks, dst);
            Wf.EmittedTable(flow, count);
            return emitted;
        }

        AsmHostRoutines DecodeMembers(ApiHostUri host, Index<MemberCodeBlock> src, Index<ApiMemberExtract> extracts, FilePath dst)
        {
            var decoded = HostEmitter.EmitHostRoutines(host, src, dst);
            if(decoded.Count != 0)
                MatchAddresses(extracts, decoded.AsmRoutines);
            return decoded;
       }

        Index<ApiExtractRow> Emit(ReadOnlySpan<ApiExtractBlock> src, FilePath dst)
        {
            var count = src.Length;
            var buffer = alloc<ApiExtractRow>(count);
            var records = span(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                if(code.IsNonEmpty)
                    row(code, ref seek(records,i));
            }
            Tables.emit(@readonly(records), dst);
            return buffer;
        }

        [MethodImpl(Inline), Op]
        static ref ApiExtractRow row(in ApiExtractBlock src, ref ApiExtractRow dst)
        {
            dst.Base = src.BaseAddress;
            dst.Encoded = src.Storage;
            dst.Uri = src.Uri;
            return ref dst;
        }

        void MatchAddresses(ApiMemberExtract[] extracted, AsmRoutine[] decoded)
        {
            try
            {
                var flow = Wf.Running(string.Format("Attempting to match <{0}> routine addresses", extracted.Length));
                var a = extracted.Select(x => x.BaseAddress).ToHashSet();
                if(a.Count != extracted.Length)
                {
                    Wf.Error($"count(Extracted) = {extracted.Length} != {a.Count} = count(set(Extracted))");
                    return;
                }

                var b = decoded.Select(f => f.BaseAddress).ToHashSet();
                if(b.Count != decoded.Length)
                {
                    Wf.Error($"count(Decoded) = {decoded.Length} != {b.Count} = count(set(Decoded))");
                    return;
                }

                b.IntersectWith(a);
                if(b.Count != decoded.Length)
                {
                    Wf.Error($"count(Decoded) = {decoded.Length} != {b.Count} = count(intersect(Decoded,Extracted))");
                    return;
                }

                Wf.Ran(flow, string.Format("Matched <{0}> routine addresses", extracted.Length));
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }
    }
}