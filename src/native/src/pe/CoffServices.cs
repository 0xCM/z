//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ApiAtomic;

    public class CoffServices : AppService<CoffServices>
    {
        AppDb AppDb => AppDb.Service;

        Symbols<CoffSectionKind> SectionKinds;

        public CoffServices()
        {
            SectionKinds = Symbols.index<CoffSectionKind>();
        }

        public CoffSymIndex Collect(ProjectContext context)
        {
            CollectObjHex(context);
            return CollectSymIndex(context);
        }

        public CoffSymIndex CollectSymIndex(ProjectContext context)
            => new CoffSymIndex(EmitSectionRows(context), EmitSymbolRows(context));

        public DbArchive ObjHex(string name)
            => AppDb.EtlTargets(name).Targets(objhex);

        public Outcome CollectObjHex(ProjectContext context)
        {
            var targets = ObjHex(context.Project.Name);
            targets.Clear();
            var result = Outcome.Success;
            var files = context.Files.Docs(FileKind.Obj, FileKind.O);
            var count = files.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref files[i].Path;
                var srcid = text.ifempty(path.SrcId(FileKind.Obj, FileKind.O), path.FileName.WithoutExtension.Format());
                var dst = targets.Path(FS.file(srcid, FileKind.HexDat.Ext()));
                var running = Channel.Running(string.Format("Emitting {0}", dst));
                using var writer = dst.AsciWriter();
                var obj = CoffObjects.load(path);
                writer.WriteLine(obj.Format());
                Channel.Ran(running, string.Format("objhex:{0} -> {1}", path.ToUri(), dst.ToUri()));
            }

            return result;
        }

        public HexFileData LoadObjHex(ProjectContext context)
        {
            var src = ObjHex(context.Project.Name).Files(FileKind.HexDat).Array();
            var count = src.Length;
            var dst = dict<FilePath,Index<HexDataRow>>(count);
            for(var i=0; i<count; i++)
                dst[src[i]] = HexDataReader.rows(Channel, src[i]);

            return dst;
        }

        public CoffObjectIndex LoadObjData(ProjectContext context)
        {
            var files = context.Files.Docs(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var dst = dict<FilePath,CoffObjectData>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                dst[file.Path] = CoffObjects.load(file.Path);
            }
            return dst;
        }

        public CoffSectionKind CalcSectionKind(string name)
        {
            var kind = CoffSectionKind.Unknown;
            if(SectionKinds.MapExpr(name, out var sym))
                kind = sym.Kind;
            return kind;
        }

        public Index<CoffSectionRow> CalcSectionRows(ProjectContext context, in FileRef src)
        {
            var buffer = list<CoffSectionRow>();
            var seq = 0u;
            CalcSectionRows(context, src,buffer);
            var records = buffer.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            return records;
        }

        void CalcSectionRows(ProjectContext context, in FileRef src, List<CoffSectionRow> records)
        {
            var obj = CoffObjects.load(src.Path);
            var view = CoffObjectView.cover(obj.Data);
            ref readonly var header = ref view.Header;
            var strings = view.StringTable;
            var sections = view.SectionHeaders;
            var origin = context.Root(src.Path);
            for(var j=0u; j<sections.Length; j++)
            {
                ref readonly var section = ref skip(sections,j);
                var number = j+1 ;
                var name = CoffStrings.format(strings, section.Name);
                var record = default(CoffSectionRow);
                record.OriginId = origin.DocId;
                record.SectionNumber = (ushort)number;
                record.SectionName = name;
                record.SectionKind = CoffObjects.SectionKind(name);
                record.RawDataAddress = section.PointerToRawData;
                record.RawDataSize = section.SizeOfRawData;
                record.RelocAddress = section.PointerToRelocations;
                record.RelocCount = section.NumberOfRelocations;
                record.Flags = section.Characteristics;
                record.Source = src.Path;
                records.Add(record);
            }
        }

        public Index<CoffSectionRow> CalcSectionRows(ProjectContext context)
        {
            var project = context.Project;
            var src = LoadObjData(context);
            var entries = src.Entries;
            var count = entries.Count;
            var buffer = list<CoffSectionRow>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref entries[i];
                ref readonly var path = ref entry.Left;
                ref readonly var obj = ref entry.Right;
                var view = CoffObjectView.cover(obj.Data);
                ref readonly var header = ref view.Header;
                var strings = view.StringTable;
                var sections = view.SectionHeaders;
                CalcSectionRows(context, context.Doc(path), buffer);
            }

            var records = buffer.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            return records;
        }

        public Index<CoffSectionRow> EmitSectionRows(ProjectContext context)
        {
            var records = CalcSectionRows(context);
            Channel.TableEmit(records, EtlContext.table<CoffSectionRow>(context.Project.Name));
            return records;
        }

        public CoffSymIndex LoadSymIndex(ProjectId project)
            => new CoffSymIndex(LoadSectionRows(project), LoadSymbols(project));

        public Index<CoffSymRow> LoadSymbols(ProjectId project)
        {
            var src = EtlContext.table<CoffSymRow>(project);
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            Index<CoffSymRow> dst = alloc<CoffSymRow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i+1];
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length, CoffSymRow.FieldCount);
                var reader = cells.Reader();
                ref var row = ref dst[i];
                DataParser.parse(reader.Next(), out row.Seq).Require();
                DataParser.parse(reader.Next(), out row.Section).Require();
                HexParser.parse(reader.Next(), out row.OriginId).Require();
                AddressParser.parse(reader.Next(), out row.Address).Require();
                DataParser.parse(reader.Next(), out row.SymSize).Require();
                HexParser.parse(reader.Next(), out row.Value).Require();
                DataParser.eparse(reader.Next(), out row.SymClass).Require();
                DataParser.parse(reader.Next(), out row.AuxCount).Require();
                DataParser.parse(reader.Next(), out row.Name).Require();
                DataParser.parse(reader.Next(), out row.Source).Require();
            }
            return dst;
        }

        public Index<CoffSectionRow> LoadSectionRows(ProjectId project)
        {
            var src = EtlContext.table<CoffSectionRow>(project);
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            var buffer = alloc<CoffSectionRow>(count);
            var docreader = lines.Storage.Reader();
            docreader.Next();
            var i=0u;
            while(docreader.Next(out var line))
            {
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length, CoffSectionRow.FieldCount);

                var reader = cells.Reader();
                ref var row = ref seek(buffer,i++);
                DataParser.parse(reader.Next(), out row.Seq).Require();
                HexParser.parse(reader.Next(), out row.OriginId).Require();
                DataParser.parse(reader.Next(), out row.SectionNumber).Require();
                DataParser.parse(reader.Next(), out row.SectionName).Require();
                SectionKinds.ExprKind(reader.Next(), out row.SectionKind);
                DataParser.parse(reader.Next(), out row.RawDataSize).Require();
                DataParser.parse(reader.Next(), out row.RawDataAddress).Require();
                DataParser.parse(reader.Next(), out row.RelocCount).Require();
                DataParser.parse(reader.Next(), out row.RelocAddress).Require();
                DataParser.eparse(reader.Next(), out row.Flags).Require();
                DataParser.parse(reader.Next(), out row.Source).Require();
            }
            return buffer;
        }

        public Outcome CheckObjHex(ProjectContext context)
        {
            var result = Outcome.Success;
            var hexDat = LoadObjHex(context);
            var objDat = LoadObjData(context);
            var count = Require.equal(hexDat.Count, objDat.Count);
            var hexPaths = hexDat.Paths.Array().Index().Sort();
            var objPaths = objDat.Paths.Array().Index().Sort();
            for(var i=0; i<count; i++)
            {
                ref readonly var hexpath = ref hexPaths[i];
                ref readonly var objpath = ref objPaths[i];
            }

            return result;
        }

        void CalcSymbolRows(ProjectContext context, in FileRef file, ref uint seq, List<CoffSymRow> buffer)
        {
            var obj = CoffObjects.load(file.Path);
            var objData = obj.Data.View;
            var offset = 0u;
            var view = CoffObjectView.cover(obj.Data, offset);
            var symcount = view.SymbolCount;
            if(symcount != 0)
            {
                var origin = context.Root(file.Path);
                var syms = view.Symbols;
                var strings = view.StringTable;
                var size = 0u;
                for(var j=0; j<symcount; j++)
                {
                    ref readonly var sym = ref skip(syms,j);
                    var symtext = strings.Text(sym);
                    if(nonempty(symtext))
                    {
                        var record = default(CoffSymRow);
                        var name = sym.Name;
                        record.Seq = seq++;
                        record.OriginId = origin.DocId;
                        record.Address = name.NameKind == CoffNameKind.String ? Address32.Zero : name.Address;
                        record.SymSize = CoffStrings.length(strings, name);
                        record.Section = sym.Section;
                        record.Value = sym.Value;
                        record.SymClass = sym.Class;
                        record.AuxCount = sym.NumberOfAuxSymbols;
                        record.Name = symtext;
                        record.Source = file.Path;
                        buffer.Add(record);
                        size += record.SymSize;
                    }
                }
            }
        }

        public Index<CoffSymRow> CalcSymbolRows(ProjectContext context)
        {
            var buffer = list<CoffSymRow>();
            var files = context.Files.Docs(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var seq = 0u;
            for(var i=0; i<count; i++)
                CalcSymbolRows(context,files[i], ref seq, buffer);
            return buffer.ToArray();
        }

        public Index<CoffSymRow> EmitSymbolRows(ProjectContext context)
        {
            var buffer = list<CoffSymRow>();
            var src = LoadObjData(context);
            var files = context.Files;
            var paths = src.Paths.Array();
            var objCount = paths.Length;
            for(var i=0; i<objCount; i++)
            {
                ref readonly var objPath = ref skip(paths,i);
                var origin = context.Root(objPath);
                var obj = src[objPath];
                var file = files.Doc(objPath);
                var objData = obj.Data.View;
                var offset = 0u;
                var view = CoffObjectView.cover(obj.Data, offset);
                var symcount = view.SymbolCount;
                if(symcount == 0)
                    continue;

                var syms = view.Symbols;
                var strings = view.StringTable;
                for(var j=0; j<symcount; j++)
                {
                    ref readonly var sym = ref skip(syms,j);
                    var symtext = strings.Text(sym);
                    if(nonempty(symtext))
                    {
                        var record = default(CoffSymRow);
                        var name = sym.Name;
                        record.OriginId = origin.DocId;
                        record.Address = name.NameKind == CoffNameKind.String ? Address32.Zero : name.Address;
                        record.SymSize = CoffStrings.length(strings, name);
                        record.Section = sym.Section;
                        record.Value = sym.Value;
                        record.SymClass = sym.Class;
                        record.AuxCount = sym.NumberOfAuxSymbols;
                        record.Name = symtext;
                        record.Source = file.Path;
                        buffer.Add(record);
                    }
                }
            }

            var records = buffer.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            Channel.TableEmit(records, EtlContext.table<CoffSymRow>(context.Project.Name));
            return records;
        }
    }
}