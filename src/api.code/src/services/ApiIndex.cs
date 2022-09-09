//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    [ApiHost]
    public readonly struct ApiIndex
    {
        public static ApiMemberIndex create(ApiHostCatalog src)
        {
            var ix = create(src.Members.Select(h => (h.Id, h)));
            return new ApiMemberIndex(ix.HashTable, ix.Duplicates);
        }

        public static ApiOpIndex<ApiCodeBlock> create(ApiCodeBlock[] src)
        {
            try
            {
                var blocks = src.Select(x => (x.OpUri.OpId, x));
                var identities = blocks.Select(x => x.Item1);
                var duplicates = (from g in identities.GroupBy(i => i.IdentityText)
                                where g.Count() > 1
                                select g.Key).ToHashSet();

                var dst = new Dictionary<OpIdentity,ApiCodeBlock>();
                if(duplicates.Count() != 0)
                    dst = blocks.Where(i => !duplicates.Contains(i.OpId.IdentityText)).ToDictionary();
                else
                    dst = blocks.ToDictionary();
                return new ApiOpIndex<ApiCodeBlock>(dst, duplicates.Select(d => ApiIdentity.opid(d)).Array());
            }
            catch(Exception e)
            {
                term.error(e);
                return ApiOpIndex<ApiCodeBlock>.Empty;
            }
        }

        [Op, Closures(UInt64k)]
        public static ApiOpIndex<ApiMember> create(IEnumerable<(OpIdentity,ApiMember)> src)
        {
            var items = src.ToArray();
            var identities = items.Select(x => x.Item1).ToArray();
            var duplicates = (from g in identities.GroupBy(i => i.IdentityText)
                             where g.Count() > 1
                             select g.Key).ToHashSet();

            var dst = new Dictionary<OpIdentity,ApiMember>();
            if(duplicates.Count() != 0)
                dst = items.Where(i => !duplicates.Contains(i.Item1.IdentityText)).ToDictionary();
            else
                dst = src.ToDictionary();

            return new ApiOpIndex<ApiMember>(dst, duplicates.Select(d => ApiIdentity.opid(d)).Array());
        }
    }
}