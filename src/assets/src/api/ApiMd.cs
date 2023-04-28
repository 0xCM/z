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
        public static void emit(IWfChannel channel, ApiCmdCatalog src, IDbArchive dst)
        {
            var data = src.Commands;
            iter(data, x => channel.Row(x.Uri.Name));
            channel.TableEmit(data, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
        }

        [Parser]
        public static Outcome parse(string src, out SymInfo dst)
        {
            const byte FieldCount = 9;
            var outcome = Outcome.Success;
            var j=0;
            var cells = text.split(src,Chars.Pipe);
            if(cells.Length != FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(FieldCount, cells.Length));
            }

            dst.Group = skip(cells,j++);
            dst.Type = skip(cells,j++);
            Sizes.parse(skip(cells,j++), out dst.Size);
            uint.TryParse(skip(cells,j++), out dst.Index);
            dst.Name = skip(cells,j++);
            SymVal.parse(skip(cells,j++), out dst.Value);
            SymExpr.parse(skip(cells,j++), out dst.Expr);
            dst.Description = skip(cells,j++);

            return outcome;
        }

        [Parser]
        public static Outcome parse(string src, out SymLiteralRow dst)
        {
            var outcome = Outcome.Success;
            var j=0;
            var cells = text.split(src,Chars.Pipe);
            if(cells.Length != SymLiteralRow.FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, cells.Length));
            }

            DataParser.parse(skip(cells,j++), out dst.Component);
            DataParser.parse(skip(cells,j++), out dst.Type);
            DataParser.parse(skip(cells,j++), out dst.Group);
            DataParser.parse(skip(cells,j++), out dst.Size);
            DataParser.parse(skip(cells,j++), out dst.Index);
            DataParser.parse(skip(cells,j++), out dst.Name);
            DataParser.parse(skip(cells,j++), out dst.Symbol);
            Enums.parse(skip(cells,j++), out dst.DataType);
            DataParser.parse(skip(cells,j++), out dst.Value);
            Enums.parse(skip(cells,j++), out dst.Base);
            DataParser.parse(skip(cells,j++), out dst.Hidden);
            DataParser.parse(skip(cells,j++), out dst.Description);
            DataParser.parse(skip(cells,j++), out dst.Identity);
            return outcome;
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
            using var reader = CsvTables.reader<SymLiteralRow>(src, parse);
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
            using var reader = CsvTables.reader<SymInfo>(src, parse);
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

        ReadOnlySeq<IApiHost> CalcApiHosts()
        {
            var dst = sys.bag<IApiHost>();
            iter(ApiAssemblies.Components, a => iter(ApiCatalog.hosts(a), h => dst.Add(h)), PllExec);
            return dst.Array();
        }

        public ReadOnlySeq<IApiHost> ApiHosts
            => data(K.ApiHosts, CalcApiHosts);

        public new ApiMdEmitter Emitter(IDbArchive dst)
            => ApiMdEmitter.init(Wf, dst);
    }
}