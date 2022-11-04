//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        public static Index<ApiCatalogEntry> catalog(FilePath src, IWfChannel channel)
        {
            var rows = list<ApiCatalogEntry>();
            using var reader = src.Utf8Reader();
            reader.ReadLine();
            var line = reader.ReadLine();
            while(line != null)
            {
                var outcome = parse(line, out ApiCatalogEntry row);
                if(outcome)
                    rows.Add(row);
                else
                {
                    channel.Error(outcome.Message);
                    return empty<ApiCatalogEntry>();
                }
                line = reader.ReadLine();
            }
            return rows.ToArray();
        }

        static Outcome parse(string src, out ApiCatalogEntry dst)
        {
            const char Delimiter = FieldDelimiter;
            const byte FieldCount = ApiCatalogEntry.FieldCount;
            var fields = text.split(src, Delimiter);
            if(fields.Length != FieldCount)
            {
                dst = default;
                return (false, Msg.FieldCountMismatch.Format(fields.Length, FieldCount, text.delimit(@readonly(fields), Delimiter,0)));
            }

            var i = 0;
            DataParser.parse(skip(fields, i++), out dst.Sequence);
            DataParser.parse(skip(fields, i++), out dst.ProcessBase);
            DataParser.parse(skip(fields, i++), out dst.MemberBase);
            Disp32.parse(skip(fields, i++), out dst.MemberOffset);
            AddressParser.parse(skip(fields, i++), out dst.MemberRebase);
            DataParser.parse(skip(fields, i++), out dst.PartName);
            DataParser.parse(skip(fields, i++), out dst.HostName);
            ApiIdentity.parse(skip(fields, i++), out dst.OpUri);
            return true;
        }
 
        public static ReadOnlySeq<ApiCatalogEntry> catalog(ApiMembers src)
        {
            var dst = sys.alloc<ApiCatalogEntry>(src.Count);
            if(src.IsNonEmpty)
            {
                var @base = src.BaseAddress;
                var rebase = src[0].BaseAddress;
                for(var i=0u; i<src.Count; i++)
                {
                    ref readonly var member = ref src[i];
                    ref var record = ref seek(dst,i);
                    record.Sequence = i;
                    record.ProcessBase = @base;
                    record.MemberBase = member.BaseAddress;
                    record.MemberOffset = AsmRel.disp32(@base, member.BaseAddress);
                    record.MemberRebase = (uint)(member.BaseAddress - rebase);
                    record.HostName = member.Host.HostName;
                    record.PartName = member.Host.Part.Format();
                    record.OpUri = member.OpUri;
                }
            }
            return dst;
        }
    }
}