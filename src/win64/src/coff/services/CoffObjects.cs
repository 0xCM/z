//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using static sys;
    using static ObjSymCode;
    using static ObjSymKind;

    [ApiHost,Free]
    public class CoffObjects : AppService<CoffObjects>
    {
        static Symbols<CoffSectionKind> SectionKinds = Symbols.index<CoffSectionKind>();

        public static IEnumerable<CoffSectionHeaders> sections(IWfChannel channel, IEnumerable<CoffObject> objects)
        {
            foreach(var obj in objects.AsParallel())
                yield return new CoffSectionHeaders(obj.Path, obj.SectionHeaders.ToArray());
        }

        public static CoffSectionKind SectionKind(string name)
        {
            var kind = CoffSectionKind.Unknown;
            if(SectionKinds.MapExpr(name, out var sym))
                kind = sym.Kind;
            return kind;
        }


        public static Outcome<CoffHex> hex(CoffObjectData src, HexDataRow[] rows)
        {
            var result = validate(src, rows, out var hex);
            if(result)
                return new CoffHex(src, rows, hex);
            else
                return result;
        }

        public static Outcome validate(CoffObjectData src, HexDataRow[] rows, out BinaryCode hex)
        {
            hex = BinaryRows.pack(rows);
            var hexsize = hex.Size;
            var objsize = src.Size;
            if(hexsize != objsize)
                return (false,string.Format("Size mismatch: {0} != {1}", objsize, hexsize));

            var objData = src.Data;
            var hexData = hex;
            var size = (uint)objsize;
            for(var j=0u; j<size; j++)
            {
                MemoryAddress offset = j;
                ref readonly var a = ref src[j];
                ref readonly var b = ref hex[j];
                if(a != b)
                    return (false, string.Format("{0} != {1} at offset {2}", a.FormatHex(), b.FormatHex(), offset));
            }

            return true;
        }

        [Op]
        public static ObjSymKind kind(ObjSymCode code)
        {
            var kind = ObjSymKind.None;
            switch(code)
            {
                case a:
                case A:
                    kind = AbsoluteSymbol;
                break;
                case b:
                    kind = BssSection;
                break;
                case B:
                    kind = BssObject;
                break;
                case C:
                    kind = Common;
                break;
                case d:
                    kind = DataSection;
                break;
                case D:
                    kind = DataObject;
                break;
                case i:
                case l:
                case n:
                    kind = CoffDebugSymbol;
                break;

                case s:
                case S:
                    kind = DebugSymbol;
                break;
                case r:
                    kind = ReadOnlyDataSection;
                break;
                case R:
                    kind = ReadOnlyDataObject;
                break;
                case t:
                    kind = CodeSection;
                break;
                case T:
                    kind = CodeObject;
                break;
                case U:
                    kind = UndefinedSymbol;
                break;
                case V:
                case v:
                case w:
                case W:
                case N_STAB:
                    kind = Other;
                break;
            }
            return kind;
        }

        public static CoffObject @object(FilePath path)
            => new CoffObject(load(path));

        [Op]
        public static CoffObjectData load(FilePath path)
            => new CoffObjectData(path, path.ReadBytes());

        public static Outcome parse(string src, ref uint seq, out ObjSymRow dst)
        {
            var result = Outcome.Success;
            var content = src;
            dst = default;
            var j = text.index(content, Chars.Colon);
            if(j > 0)
            {
                var k = text.index(content, j + 1, Chars.Colon);
                if(k > 0)
                {
                    dst.Source = FS.path(text.left(content,k));
                    var digits = text.slice(text.right(content,k),1,8).Trim();
                    var hex = Hex32.Max;
                    if(nonempty(digits))
                        HexParser.parse(digits, out hex);
                    dst.DocSeq = seq++;
                    dst.Offset = hex;
                    var pos = k + 1 + 8 + 2;
                    SymCodes.ExprKind(content[pos].ToString(), out dst.Code);
                    dst.Name = text.right(content, pos + 1).Trim();
                    if(dst.Code == ObjSymCode.t && dst.Name != ".text")
                        dst.Code = ObjSymCode.T;
                    else if(dst.Code == ObjSymCode.r && dst.Name != ".rdata")
                        dst.Code = ObjSymCode.R;
                    dst.Kind = kind(dst.Code);
                }
            }
            return result;
        }        

        [MethodImpl(Inline), Op]
        public static SymAddress address(in ObjSymRow src)
        {
            ObjSymClass @class = src.Code;
            var selector = math.or((ushort)src.OriginId, (uint)(@class.Pack() << 16));
            return SymAddress.define(selector, src.Offset);
        }

        [MethodImpl(Inline), Op]
        public static SymAddress address(in CoffSymRow row)
        {
            var lo = (ushort)row.OriginId;
            var section = row.Section > Pow2.T15 ? (ushort) ((ushort.MaxValue - row.Section) + byte.MaxValue) : row.Section;
            var hi = math.or((ushort)(byte)row.SymSize, (ushort)(section<<8));
            return SymAddress.define(math.or((uint)lo, (uint)hi << 16), row.Value);
        }

        public static LocatedSymbols symbolize(ReadOnlySpan<ObjSymRow> src, SymbolDispenser dispenser)
        {
            var count = src.Length;
            var dst = new LocatedSymbols();
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(src,i);
                if(row.Kind != ObjSymKind.CodeObject)
                    continue;

                var location = address(row);
                if(!dst.TryAdd(location, dispenser.Symbol(location, row.Name)))
                    Errors.Throw(string.Format("The address {0} is duplicated at sequence {1} for symbol '{2}'", location, row.Seq, row.Name));
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Timestamp timestamp(Hex32 src)
            => Time.epoch(TimeSpan.FromSeconds(src));

        [MethodImpl(Inline), Op]
        public static ref readonly CoffHeader header(ReadOnlySpan<byte> src, uint offset)
            => ref skip(recover<CoffHeader>(src), offset);

        public static readonly Symbols<ObjSymCode> SymCodes = Symbols.index<ObjSymCode>();

        public static readonly Symbols<ObjSymKind> SymKinds = Symbols.index<ObjSymKind>();             
    }
}