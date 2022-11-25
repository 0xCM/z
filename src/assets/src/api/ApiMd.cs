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
        static uint CountFields(Index<Type> tables)
        {
            var counter = 0u;
            for(var i=0; i<tables.Count; i++)
                counter += tables[i].DeclaredInstanceFields().Ignore().Index().Count;
            return counter;
        }

        public static ReadOnlySeq<DataFlowSpec> CalcDataFlows(ReadOnlySeq<Assembly> src)
        {
            var flows = DataFlow.discover(src.Storage);
            var count = flows.Length;
            var buffer = alloc<DataFlowSpec>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var flow = ref flows[i];
                dst.Actor = flow.Actor;
                dst.Source = flow.Source?.ToString() ?? EmptyString;
                dst.Target = flow.Target?.ToString() ?? EmptyString;
                dst.Description = flow.Format();
            }
            return buffer.Sort();
        }

        public static ReadOnlySeq<ApiTableField> CalcTableFields(ReadOnlySeq<Assembly> src)
        {
            var tables = src.Storage.Types().Tagged<RecordAttribute>().Index();
            var count = CountFields(tables);
            var buffer = alloc<ApiTableField>(count);
            var k=0u;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var type = ref tables[i];
                var fields = Tables.fields(type);
                var total = 0u;
                var id = TableId.identify(type).Format();
                var typename = type.DisplayName();
                for(var j=z16; j<fields.Length; j++, k++)
                {
                    ref readonly var tf = ref skip(fields,j);
                    ref readonly var fd = ref tf.Definition;
                    ref var dst = ref seek(buffer,k);
                    var size = (ushort)(Sizes.bits(fd.FieldType)/8);
                    total += size;
                    dst.Seq = j;
                    dst.TableId = id;
                    dst.TableType = typename;
                    dst.Col = j;
                    dst.FieldSize = size;
                    dst.TableSize = total;
                    dst.RenderWidth = tf.FieldWidth;
                    dst.FieldName = fd.Name;
                    dst.FieldType = fd.FieldType.DisplayName();
                }
            }
            return buffer;
        }

        public static TypeList types(FileUri src)
        {
            var lines = src.ReadLines(skipBlank:true);
            var count = lines.Count;
            var dst = sys.alloc<TypeListEntry>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var type = Type.GetType(line) ?? typeof(void);
                seek(dst,i) = type;
            }
            return new (dst);
        }

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


        ReadOnlySeq<IApiHost> CalcApiHosts()
        {
            var dst = sys.bag<IApiHost>();
            iter(Parts, a => iter(ApiRuntime.hosts(a), h => dst.Add(h)), PllExec);
            return dst.Array();
        }

        public ReadOnlySeq<IApiHost> ApiHosts
            => data(K.ApiHosts, CalcApiHosts);

        public new ApiMdEmitter Emitter(IDbArchive dst)
            => ApiMdEmitter.init(Wf, dst);
    }
}