//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using K = ApiMdKind;

    public sealed class ApiMd : WfSvc<ApiMd>
    {
        IDbArchive ApiTargets()
            => AppDb.ApiTargets();

        public Assembly[] Parts
            => ModuleArchives.parts();

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
            using var reader = src.TableReader<SymLiteralRow>(Symbolic.parse);
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

        public Index<SymInfo> LoadTokens(string name)
        {
            var src = ApiTargets().PrefixedTable<SymInfo>(tokens + "." +  name.ToLower());
            using var reader = src.TableReader<SymInfo>(SymInfo.parse);
            var header = reader.Header.Split(Chars.Pipe);
            if(header.Length != SymInfo.FieldCount)
            {
                Error(AppMsg.FieldCountMismatch.Format(SymInfo.FieldCount, header.Length));
                return Index<SymInfo>.Empty;
            }
            var dst = list<SymInfo>();
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