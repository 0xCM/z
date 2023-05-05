//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class MemDb : IMemDb
    {
        public static PersistentAllocator allocator(IMemDb db, ByteSize? @default = null)
            => new PersistentAllocator(db, @default);

        [MethodImpl(Inline), Op]
        public static PersistentMemory memory(IMemDb src, asci32 name, ByteSize size)
            => new (name, src.Reserve(size));

        [MethodImpl(Inline), Op]
        public static DbDataType type(Name name, Name primitive, DataSize size, Name refinement = default)
            => new DbDataType(name, primitive, size, refinement.IsNonEmpty, refinement);
 
        public static ReadOnlySeq<MeasuredType> measured(Assembly src, string group)
        {
            var x = src.Enums().NonGeneric().TypeTags<SymSourceAttribute>().Storage.Where(x => x.Right.SymGroup == group).ToIndex();
            return x.Select(x => new MeasuredType(x.Left, Sizes.measure(x.Left))).Sort();
        }

        public static ReadOnlySeq<MeasuredType> measured(Assembly src)
            => src.Enums().NonGeneric().Select(x => new MeasuredType(x, Sizes.measure(x))).Sort();

        public static ReadOnlySeq<DbTypeTable> typetables(Assembly src, ICompositeDispenser dst)
        {
            var types = measured(src);
            Seq<DbTypeTable> tables = sys.alloc<DbTypeTable>(types.Count);
            for(var i=0; i<types.Count; i++)
                tables[i] = typetable(types[i], dst);
            return tables.Sort();
        }

        public static ReadOnlySeq<DbTypeTable> typetables(Assembly src, string group, ICompositeDispenser dst)
        {
            var types = measured(src, group);
            Seq<DbTypeTable> tables = sys.alloc<DbTypeTable>(types.Count);
            for(var i=0; i<types.Count; i++)
                tables[i] = typetable(types[i], dst);
            return tables.Sort();
        }

        public static DbTypeTable typetable(MeasuredType type, ICompositeDispenser dst)
        {
            var symbols = Symbols.syminfo(type.Definition);
            Seq<TypeTableRow> rows = sys.alloc<TypeTableRow>(symbols.Count);
            for(var j=0; j<symbols.Count; j++)
            {
                ref readonly var sym = ref symbols[j];
                ref var row = ref rows[j];
                row.Seq = MemDb.NextSeq(DbObjectKind.TypeTableRow);
                row.TypeName = dst.Label(type.Definition.Name);
                row.LiteralName = dst.Label(sym.Name.Text);
                row.Position = (ushort)sym.Index;
                row.PackedWidth = (byte)type.Size.PackedWidth;
                row.NativeWidth = (byte)type.Size.NativeWidth;
                row.LiteralValue = sym.Value;
                row.Symbol = dst.Label(sym.Expr.Text);
                row.Description = dst.String(sym.Description.Text);
            }

            return new DbTypeTable(
                MemDb.NextSeq(DbObjectKind.TypeTable),
                dst.Label(type.Definition.Name),
                type.Size,
                rows
                );
        }         

        public static DbGrid<T> grid<T>(Dim2<uint> shape)
            => new DbGrid<T>(new DbRowGrid<T>(shape), new DbColGrid<T>(shape));

        public static ReadOnlySeq<TypeTableRow> rows(Index<DbTypeTable> src)
            => src.SelectMany(x => x.Rows).Sort().Resequence();

        [MethodImpl(Inline), Op]
        public static DbCol col(ushort pos, Name name, ReadOnlySpan<byte> widths)
            => new DbCol(pos, name, skip(widths, pos));

        public static MemDb open(FilePath store)
            => open(store,0);

        public static MemDb open(FilePath store, ByteSize capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity));

        public static MemDb open(FilePath store, Gb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static MemDb open(FilePath store, Mb capacity)
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

        readonly MemoryFile DbMap;

        public readonly MemoryFileInfo Description;

        uint Offset;

        public ulong Capacity
        {
            [MethodImpl(Inline)]
            get => DbMap.FileSize;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => DbMap.FileSize;
        }

        public MemoryAddress BaseAddress 
        {
            [MethodImpl(Inline)]
            get => DbMap.BaseAddress;
        }

        public MemDb(FilePath path, ByteSize size)
        {
            var spec = MemoryFileSpec.init(path.CreateParentIfMissing()).WithCapacity(size).WithOpenOrCreateMode().WithReadWriteAccess();
            spec.Stream = true;
            DbMap = new MemoryFile(spec);
            Description = DbMap.Description;
        }

        public void Store<T>(AllocToken token, ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var size = Demand.lteq((ulong)src.Length * size<T>(), token.Size);
            var offset = token.Offset;
            DbMap.Stream.Seek(Offset, System.IO.SeekOrigin.Begin);
            DbMap.Stream.Write(recover<T,byte>(src));
            DbMap.Flush();
        }

        public AllocToken Store(ReadOnlySpan<byte> src)
        {
            var size = (uint)src.Length;
            var offset = Offset;
            var next = (uint)(Offset + src.Length);
            if(next > Size)
                return AllocToken.Empty;
            DbMap.Stream.Seek(Offset, System.IO.SeekOrigin.Begin);
            DbMap.Stream.Write(src);
            Offset = next;
            DbMap.Flush();
            return new AllocToken(DbMap.BaseAddress, offset, size);
        }

        public AllocToken Reserve(ByteSize size)
        {
            var offset = Offset;
            var next = (uint)(Offset + size);
            if(next > Size)
                return AllocToken.Empty;
            Offset = next;
            return new AllocToken(DbMap.BaseAddress, offset, size);
        }

        [MethodImpl(Inline)]
        public AllocToken Token(uint offset, ByteSize size)
            => new (BaseAddress,offset,size);

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

        public static Index<MemoryFileInfo> Allocated()
            => Opened.Values.Map(x => x.Description);

        static readonly ConcurrentDictionary<FilePath,MemDb> Opened = new();

        const byte ObjTypeCount = 24;

        static Index<DbObjectKind,uint> ObjSeqSource = sys.alloc<uint>(ObjTypeCount);
    }
}