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

        public static ReadOnlySeq<ApiTableField> CalcTableFields(IWfChannel channel, ReadOnlySeq<Assembly> src)
        {
            var tables = src.Storage.Types().Tagged<RecordAttribute>().Index();
            var count = CountFields(tables);
            var buffer = alloc<ApiTableField>(count);
            var k=0u;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var type = ref tables[i];
                try
                {
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
                        dst.RenderWidth = tf.CellWidth;
                        dst.FieldName = fd.Name;
                        dst.FieldType = fd.FieldType.DisplayName();
                    }
                }
                catch(Exception e)
                {
                    channel.Warn($"{type}:${e.Message}");
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

            
            return new (src.FileName().WithoutExtension.Name, dst);
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

        // static IModuleArchive archive()
        //     => Archives.modules(FS.path(ExecutingPart.Assembly.Location).FolderPath);

        public static Assembly[] parts()        
        {
            Assembly[] get()
            {
                var root = FS.path(controller().Location).FolderPath;                    
                var modules = Archives.modules(root,false).Members().Where(x => FS.managed(x.Path) && !x.Path.FileName().Contains("System.Private.CoreLib"));
                return modules.Where(m => m.Path.FileName().StartsWith("z0.")).Map(x => Assembly.LoadFile(x.Path.ToFilePath().Format()));
            }
            return data("parts",get);
        }
            //=> data("parts",() => archive().Assemblies().Where(x => x.Path.FileName().StartsWith("z0")).Map(x => x.Load()).Distinct().Array());

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