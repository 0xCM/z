//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using K = ApiMdKind;

    public sealed class ApiMd : AppService<ApiMd>
    {
        IDbArchive ApiTargets()
            => AppDb.Service.ApiTargets();

        public Assembly[] Parts
            => ApiModules.parts();

        public Index<Type> ApiTableTypes
            => data(K.ApiTables, () => Parts.Types().Tagged<RecordAttribute>().Index());

        ReadOnlySeq<IApiHost> CalcApiHosts()
        {
            var dst = sys.bag<IApiHost>();
            iter(Parts, a => iter(ApiRuntime.hosts(a), h => dst.Add(h)), PllExec);
            return dst.Array();
        }

        public ReadOnlySeq<IApiHost> ApiHosts
            => data(K.ApiHosts, CalcApiHosts);

        public new ApiMdEmitter Emitter()
            => ApiMdEmitter.init(Wf);

        public Index<SymLiteralRow> LoadSymLits(FilePath src)
        {
            using var reader = TableConvention.reader<SymLiteralRow>(src, Symbolic.parse);
            var header = reader.Header.Split(Chars.Tab);
            if(header.Length != SymLiteralRow.FieldCount)
            {
                Error(AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, header.Length));
                return Index<SymLiteralRow>.Empty;
            }

            var dst = list<SymLiteralRow>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }

    }
}