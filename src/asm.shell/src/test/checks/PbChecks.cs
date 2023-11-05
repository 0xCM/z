//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static PbChecks.Field32;

using FK = PbChecks.Field32.FieldName;
using FW = PbChecks.Field32.FieldWidth;

public class PbChecks : Checker<PbChecks>
{
    new ITextEmitter Emitter;


    public PbChecks()
    {
        Emitter = text.emitter();
    }

    static BfDataset<FieldName,Field32> dataset(N1 n)
        => Bitfields.dataset<FieldName,FieldWidth,Field32>("field32", NativeSizeCode.W32);

    public static Index<Field32> pack(BfDataset<FieldName,Field32> spec, ReadOnlySpan<Field32Source> src, bool pll = true)
    {
        var dst = sys.bag<Field32>();
        iter(src,opcode => dst.Add(pack(spec,opcode)), pll);
        return dst.Index().Sort();
    }

    [MethodImpl(Inline)]
    public static Field32 pack(BfDataset<FieldName,Field32> spec, Field32Source src)
        => math.or(
            (uint)src.InstClass << (int)spec.Offset(FK.Class),
            (uint)src.OpCode << (int)spec.Offset(FK.Hex8),
            (uint)src.Mod << (int)spec.Offset(FK.Mod),
            (uint)src.Lock << (int)spec.Offset(FK.Lock),
            (uint)src.RexW << (int)spec.Offset(FK.Rex),
            (uint)src.Rep << (int)spec.Offset(FK.Rep)
            );

    public static Func<Field32,string> formatter(BfDataset<FieldName,Field32> spec)
        => src => string.Format("{0,-18} | 0x{1} | {2,-6} | {3,-6} | {4,-6}",
                spec.Extract<num16>(FK.Class, src),
                spec.Extract<Hex8>(FK.Hex8, src),
                spec.Extract<BitIndicator>(FK.Lock, src),
                spec.Extract<BitIndicator>(FK.Rex, src),
                spec.Extract<BitIndicator>(FK.Mod, src)
                );

    enum Fields3
    {
        Field0,

        Field1,

        Field2
    }

    static string[] DsHeaders = new string[]{"Name",  "Packed", "Native", "Fields", "SegPattern", "Intervals"};

    static string DsPattern = "{0,-16} | {1,-6} | {2,-6} | {3,-6} | {4,-32} | {5}";

    [Ignore]
    static ReadOnlySpan<byte> Widths0 => new byte[3]{4,3,5};

    void EmitHeader(IEventTarget dst)
        => dst.Deposit(Events.row(string.Format(DsPattern, DsHeaders)));

    void Render(IBfDataset src)
    {
        Emitter.AppendLineFormat(DsPattern, src.Name, src.Size.Packed, src.Size.Native, src.FieldCount, src.BitstringPattern, src.Intervals);
    }

    void Check(N0 n)
    {
        Render(Bitfields.dataset<Fields3>($"Bf{n}", NativeSizeCode.W32, Widths0));
    }

    void Check(N1 n)
    {
        var bf = dataset(n);
        var formatter = CsvTables.formatter<BfSegDef>();
        var segs = Bitfields.segdefs(bf);
        Channel.TableEmit(segs, AppDb.DbTargets("pb").PrefixedTable<BfSegDef>($"{bf.Name}"));
        var intervals = bf.Intervals;
        Write(formatter.FormatHeader());
        iter(segs, seg => Write(formatter.Format(seg)));
        for(var i=0; i<intervals.Count; i++)
        {
            Write(intervals[i]);
        }

    }

    protected override void Execute(IEventTarget dst)
    {
        EmitHeader(dst);
        Check(n0);
        Check(n1);
        dst.Deposit(Events.row(Emitter.Emit()));
    }

    public struct Field32Source
    {
        [Render(6)]
        public uint Seq;

        [Render(12)]
        public ushort PatternId;

        [Render(12)]
        public ushort InstClass;

        [Render(6)]
        public byte Index;

        [Render(6)]
        public num2 Mode;

        [Render(6)]
        public Hex8 OpCode;

        [Render(6)]
        public BitIndicator Lock;

        [Render(6)]
        public BitIndicator Mod;

        [Render(6)]
        public BitIndicator RexW;

        [Render(6)]
        public BitIndicator Rep;
    }

    [StructLayout(StructLayout,Size=4)]
    public readonly record struct Field32 : IComparable<Field32>
    {
        public uint Data
        {
            [MethodImpl(Inline)]
            get => u32(this);
        }

        public int CompareTo(Field32 src)
            => Data.CompareTo(src.Data);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(Field32 src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public static implicit operator uint(Field32 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Field32(uint src)
            => @as<uint,Field32>(src);

        public static Field32 Empty => default;

        public enum FieldName : byte
        {
            Rep = 0,

            Rex = 1,

            Lock = 2,

            Mod = 3,

            Hex8 = 4,

            Class = 5,
        }

        public enum FieldWidth : byte
        {
            Rep = num2.Width,

            Rex = num2.Width,

            Lock = num2.Width,

            Mod = num2.Width,

            Hex8 = num8.Width,

            Class = num11.Width,
        }

        public enum FieldOffset : byte
        {
            Rep = 0,

            Rex = FW.Rep + Rep,

            Lock = FW.Rex + Rex,

            Mod = FW.Lock + Lock,

            Byte = FW.Mod + Mod,

            Hex8 = FW.Hex8 + Byte,
        }
    }
}
