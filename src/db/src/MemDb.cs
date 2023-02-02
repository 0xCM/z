//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Numbers;
    using static math;

    [ApiHost]
    public class MemDb : IMemDb
    {
        public static DbGrid<T> grid<T>(Dim2<uint> shape)
            => new DbGrid<T>(new DbRowGrid<T>(shape), new DbColGrid<T>(shape));

        public static Index<TypeTableRow> rows(Index<DbTypeTable> src)
            => src.SelectMany(x => x.Rows).Sort().Resequence();

        [MethodImpl(Inline), Op]
        public static DbCol col(ushort pos, Name name, ReadOnlySpan<byte> widths)
            => new DbCol(pos, name, skip(widths, pos));

        [MethodImpl(Inline), Op]
        public static Index<DbCol> cols(params DbCol[] cols)
            => cols;

        public static IMemDb open(FilePath store)
            => open(store,0);

        public static IMemDb open(FilePath store, ByteSize capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity));

        public static IMemDb open(FilePath store, Gb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static IMemDb open(FilePath store, Mb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static Index<DbCol> resequence(Index<DbCol> left, Index<DbCol> right)
        {
            var count = left.Count + right.Count;
            var dst = sys.alloc<DbCol>(count);
            var k=z8;
            for(var i=0; i<left.Count; i++, k++)
                seek(dst,k) = (left[i].Reposition(k));

            for(var i=0; i<right.Count; i++, k++)
                seek(dst,k) = (right[i].Reposition(k));

            return dst;
        }

        [MethodImpl(Inline), Op]
        public static void split(uint src, out ushort a, out ushort b)
        {
            a = (ushort)(src & 0x0000_FFFF);
            b = (ushort)((src & 0xFFFF_0000) >> 16);
        }

        public static void check(IWfChannel channel)
        {
            check(channel, (32,32));
            check(channel, (12,12));
            check(channel, (8,8));
            check(channel, (256,256));
        }

        public static void check(IWfChannel channel, Dim2<uint> shape)
        {
            var r = shape.I;
            var c = shape.J;
            var m = (uint)(r*c);
            var grid = MemDb.grid<byte>(shape);
            ref readonly var rows = ref grid.Rows;
            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                    rows[i,j] = (byte)math.mod((i*c + j), r) ;
            }

            var cols = rows.Columns();
            var rDst = text.emitter();
            var cDst = text.emitter();

            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                {
                    rDst.AppendFormat("{0:X2} | ", rows[i,j]);
                    cDst.AppendFormat("{0:X2} | ", cols[i,j]);
                }

                rDst.AppendLine();
                cDst.AppendLine();
            }

            var linear = Points.multilinear(shape);
            var lDst = text.emitter();
            Points.render(linear, lDst);

            var scope = "memdb";
            var suffix = $"{r}x{c}";
            channel.FileEmit(lDst.Emit(), linear.Count, AppDb.Service.Logs().Targets(scope).Path($"{scope}.linear.{suffix}", FileKind.Csv));
            channel.FileEmit(rDst.Emit(), m, AppDb.Service.Logs().Targets(scope).Path($"{scope}.rows.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
            channel.FileEmit(cDst.Emit(), m, AppDb.Service.Logs().Targets(scope).Path($"{scope}.cols.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
        }

        [MethodImpl(Inline)]
        public static num4 read(ReadOnlySpan<byte> src, uint index, out num4 dst)
        {
            var cell = MemoryScales.index(4, -2, index);
            ref readonly var b = ref skip(src, cell.Offset);
            dst = cell.Aligned ? num(n4,b) : num(n4, srl(b , (byte)cell.CellWidth));
            return dst;
        }

        [MethodImpl(Inline)]
        public static void write(num4 src, uint index, Span<byte> dst)
        {
            const byte UpperMask = 0xF0;
            const byte LowerMask = 0x0F;
            var cell = MemoryScales.index(4, -2, index);
            ref var c = ref seek(dst, cell.Offset);
            if(cell.Aligned)
                c = or(and(c, UpperMask), src);
            else
                c = or(sll(src, (byte)cell.CellWidth), and(c, LowerMask));
        }

        readonly MemoryFile DbMap;

        public readonly MemoryFileInfo Description;

        uint Offset;

        public ulong Capacity
        {
            [MethodImpl(Inline)]
            get => DbMap.FileSize;
        }

        public MemDb(FilePath path)
        {
            var spec = MemoryFileSpec.init(path.CreateParentIfMissing());
            spec.EnableAccessReadWrite();
            spec.EnableModeOpenOrCreate();
            spec.Stream = true;
            DbMap = new MemoryFile(spec);
            Description = DbMap.Description;
        }

        public MemDb(FilePath path, ByteSize size)
        {
            var spec = MemoryFileSpec.init(path.CreateParentIfMissing());
            spec.Capacity = size;
            spec.EnableAccessReadWrite();
            spec.EnableModeOpenOrCreate();
            spec.Stream = true;
            DbMap = new MemoryFile(spec);
            Description = DbMap.Description;
        }

        public AllocToken Store(ReadOnlySpan<byte> src)
        {
            var size = (uint)src.Length;
            var offset = Offset;
            var next = (uint)(Offset + src.Length);
            if(next > Capacity)
                return AllocToken.Empty;
            DbMap.Stream.Seek(Offset, System.IO.SeekOrigin.Begin);
            DbMap.Stream.Write(src);
            Offset = next;
            return token(DbMap.BaseAddress, offset, size);
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Load(AllocToken token)
            => DbMap.View(token.Offset, token.Size);

        [MethodImpl(Inline)]
        public Span<byte> Edit(AllocToken token)
            => DbMap.Edit(token.Offset, token.Size);

        MemoryFileInfo IMemDb.Description
            => Description;

        [MethodImpl(Inline)]
        public static uint NextSeq(DbObjectKind kind)
            => sys.inc(ref ObjSeqSource[kind]);

        [MethodImpl(Inline), Op]
        public static DbDataType type(uint seq, Name name, Name primitive, DataSize size, Name refinement = default)
            => new DbDataType(seq, name, primitive, size, refinement.IsNonEmpty, refinement);

        // public static Index<DbTypeTable> typetables(Assembly src, string group, ICompositeDispenser dst)
        // {
        //     var types = MeasuredType.symbolic(src, group);
        //     Index<DbTypeTable> tables = sys.alloc<DbTypeTable>(types.Count);
        //     for(var i=0; i<types.Count; i++)
        //         tables[i] = MemDb.typetable(types[i], dst);
        //     return tables.Sort();
        // }

        // public static DbTypeTable typetable(MeasuredType type, ICompositeDispenser dst)
        // {
        //     var symbols = Symbols.syminfo(type.Definition);
        //     Index<TypeTableRow> rows = sys.alloc<TypeTableRow>(symbols.Count);
        //     for(var j=0; j<symbols.Count; j++)
        //     {
        //         ref readonly var sym = ref symbols[j];
        //         ref var row = ref rows[j];
        //         row.Seq = NextSeq(DbObjectKind.TypeTableRow);
        //         row.TypeName = dst.Label(type.Definition.Name);
        //         row.LiteralName = dst.Label(sym.Name.Text);
        //         row.Position = (ushort)sym.Index;
        //         row.PackedWidth = (byte)type.Size.PackedWidth;
        //         row.NativeWidth = (byte)type.Size.NativeWidth;
        //         row.LiteralValue = sym.Value;
        //         row.Symbol = dst.Label(sym.Expr.Text);
        //         row.Description = dst.String(sym.Description.Text);
        //     }

        //     return new DbTypeTable(
        //         MemDb.NextSeq(DbObjectKind.TypeTable),
        //         dst.Label(type.Definition.Name),
        //         type.Size,
        //         rows
        //         );
        // }
 
        [MethodImpl(Inline)]
        static AllocToken token(MemoryAddress @base, uint offset, uint size)
            => new AllocToken(@base,offset, size);

        public static Index<MemoryFileInfo> Allocated()
            => Opened.Values.Map(x => x.Description);

        static readonly ConcurrentDictionary<FilePath,MemDb> Opened = new();

        const byte ObjTypeCount = 24;

        static Index<DbObjectKind,uint> ObjSeqSource = sys.alloc<uint>(ObjTypeCount);
    }
}