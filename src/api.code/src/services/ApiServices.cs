//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using Asm;

    public class ApiServices : AppService<ApiServices>
    {        
        public void Emit(ApiMembers src, IApiPack dst)
        {
            Emit(src, dst.Table<ApiCatalogEntry>());
        }

        public Index<ApiCatalogEntry> Emit(ApiMembers src, FilePath dst)
        {
            var records = rebase(src.BaseAddress, src.View);
            Channel.TableEmit(records, dst);
            return records;
        }

        public static Index<ApiCatalogEntry> rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> src)
        {
            var dst = alloc<ApiCatalogEntry>(src.Length);
            rebase(@base, src, dst);
            return dst;
        }

        public static uint rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> members, Span<ApiCatalogEntry> dst)
        {
            var count = members.Length;
            var rebase = first(members).BaseAddress;
            for(uint seq=0; seq<count; seq++)
            {
                ref var record = ref seek(dst,seq);
                ref readonly var member = ref skip(members, seq);
                record.Sequence = seq;
                record.ProcessBase = @base;
                record.MemberBase = member.BaseAddress;
                record.MemberOffset = AsmRel.disp32(@base, member.BaseAddress);
                record.MemberRebase = (uint)(member.BaseAddress - rebase);
                record.HostName = member.Host.HostName;
                record.PartName = member.Host.Part.Format();
                record.OpUri = member.OpUri;
            }
            return (uint)count;
        }
    }
}