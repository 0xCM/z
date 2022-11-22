//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.Linq;

    using K = ApiMdKind;

    public sealed class ApiMd : AppService<ApiMd>
    {
        public Index<SymLiteralRow> literals(IWfChannel channel, FilePath src)
        {
            using var reader = CsvTables.reader<SymLiteralRow>(src, Symbolic.parse);
            var header = reader.Header.Split(Chars.Tab);
            if(header.Length != SymLiteralRow.FieldCount)
            {
                channel.Error(AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, header.Length));
                return sys.empty<SymLiteralRow>();
            }

            var dst = list<SymLiteralRow>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    channel.Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }

        public static Index<SymInfo> symbols(IWfChannel channel, FilePath src)
        {
            using var reader = CsvTables.reader<SymInfo>(src, Symbolic.parse);
            var header = reader.Header.Split(Chars.Pipe);
            if(header.Length != SymInfo.FieldCount)
            {
                channel.Error(AppMsg.FieldCountMismatch.Format(SymInfo.FieldCount, header.Length));
                return sys.empty<SymInfo>();
            }
            var dst = list<SymInfo>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    channel.Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }


        static IModuleArchive archive(FolderPath root)
            => new ModuleArchive(root);

        static IModuleArchive archive()
            => archive(FS.path(ExecutingPart.Assembly.Location).FolderPath);

        public static Assembly[] parts()
            => data("parts",() => archive().ManagedDll().Where(x => x.FileName.StartsWith("z0")).Map(x => x.Load()).Distinct().Array());

        public Assembly[] Parts
            => parts();

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
    }
}