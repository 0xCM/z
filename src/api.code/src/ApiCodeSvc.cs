//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class ApiCodeSvc : AppService<ApiCodeSvc>
    {
        public Index<ApiCodeRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<MemberCodeBlock> src, IApiPack dst)
            => EmitApiCode(uri, src, dst.HexExtractPath(uri));

        [Op]
        public Index<ApiCodeRow> EmitApiCode(ApiHostUri uri, ReadOnlySpan<MemberCodeBlock> src, FilePath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiCodeRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = ApiCodeRows.apicode(skip(src, i), i);

                Channel.TableEmit(buffer, dst);
                return buffer;
            }
            else
                return array<ApiCodeRow>();
        }

        public void Emit(ReadOnlySpan<CollectedHost> src, IDbArchive dst, bool pll)
            => iter(src, code => EmitHex(code, dst), pll);

        void EmitHex(CollectedHost src, IDbArchive dst)
        {
            var extracts = dst.Scoped("extracts");
            var path = extracts.Path(ApiFiles.file(src.Host, FileKind.HexDat));
            EmitHex(src.Blocks, path);
        }

        ByteSize EmitHex(ReadOnlySeq<ApiEncoded> src, FilePath dst)
        {
            var count = src.Count;
            var emitting = Channel.EmittingFile(dst);
            var size = ApiCodeRows.hexdat(src, dst);
            Channel.EmittedFile(emitting,count);
            return size;
        }
    }
}