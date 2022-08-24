//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public class CoffObjects : WfSvc<CoffObjects>
    {
        public static Index<ObjDumpRow> rows(FS.FilePath src)
        {
            var result = TextGrids.load(src, TextEncodingKind.Asci, out var grid);
            if(result.Fail)
                Errors.Throw(result.Message);

            var count = grid.RowCount;
            var buffer = alloc<ObjDumpRow>(count);
            ref var target = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var data = ref grid[(int)i];
                ref var dst = ref seek(target,i);
                var j=0;
                result = DataParser.parse(data[j++], out dst.Seq);
                result = DataParser.parse(data[j++], out dst.DocSeq);
                result = DataParser.parse(data[j++], out dst.OriginId);
                result = EncodingId.parse(data[j++].Text, out dst.EncodingId);
                result = InstructionId.parse(data[j++].Text, out dst.InstructionId);
                result = DataParser.parse(data[j++], out dst.Section);
                result = DataParser.parse(data[j++], out dst.BlockAddress);
                result = DataParser.parse(data[j++], out dst.BlockName);
                result = DataParser.parse(data[j++], out dst.IP);
                result = DataParser.parse(data[j++], out dst.Size);
                result = ApiNative.parse(data[j++].View, out dst.Encoded);
                dst.Asm = text.trim(data[j++].Text);
                result = AsmInlineComment.parse(data[j++].View, out dst.Comment);
                result = DataParser.parse(data[j++], out dst.Source);
            }

            return buffer;
        }


        public static Outcome parse(ProjectContext context, in FileRef src, out Index<ObjDumpRow> dst)
            => new ObjDumpParser().Parse(context, src, out dst);

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
                        DataParser.parse(digits, out hex);
                    dst.DocSeq = seq++;
                    dst.Offset = hex;
                    var pos = k + 1 + 8 + 2;
                    SymCodes.ExprKind(content[pos].ToString(), out dst.Code);
                    dst.Name = text.right(content, pos + 1).Trim();
                    if(dst.Code == ObjSymCode.t && dst.Name != ".text")
                        dst.Code = ObjSymCode.T;
                    else if(dst.Code == ObjSymCode.r && dst.Name != ".rdata")
                        dst.Code = ObjSymCode.R;
                    dst.Kind = ObjSymCalcs.kind(dst.Code);
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
        public static SymAddress address(in CoffSymRecord row)
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

        public static Outcome<CoffHex> hex(CoffObject coff, HexDataRow[] rows)
        {
            var result = validate(coff, rows, out var hex);
            if(result)
                return new CoffHex(coff, rows, hex);
            else
                return result;
        }

        public static Outcome validate(CoffObject coff, HexDataRow[] src, out BinaryCode hex)
        {
            hex = ApiCodeBlocks.pack(src);
            var hexsize = hex.Size;
            var objsize = coff.Size;
            if(hexsize != objsize)
                return (false,string.Format("Size mismatch: {0} != {1}", objsize, hexsize));

            var objData = coff.Data;
            var hexData = hex;
            var size = (uint)objsize;
            for(var j=0u; j<size; j++)
            {
                MemoryAddress offset = j;
                ref readonly var a = ref coff[j];
                ref readonly var b = ref hex[j];
                if(a != b)
                    return (false, string.Format("{0} != {1} at offset {2}", a.FormatHex(), b.FormatHex(), offset));
            }

            return true;
        }

        [MethodImpl(Inline), Op]
        public static uint size(in CoffStringTable src)
            => first(recover<uint>(slice(src.Data,0,4)));

        public static string format(in CoffStringTable src, in CoffSymbol sym)
        {
            ref readonly var name = ref sym.Name;
            var value = sym.Value;
            var kind = name.NameKind;
            var address = kind == CoffNameKind.String ? Address32.Zero : name.Address;
            var dst = EmptyString;
            if(value < Hex16.Max)
            {
                if(address.IsNonZero)
                    dst = entry(src, name.Address).Format();
                else
                {
                    if(kind == CoffNameKind.String)
                    {
                        var len = length(src,sym.Name);
                        dst = recover<AsciCode>(slice(sym.Name.Bytes,0,len)).Format();
                    }
                }
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint length(in CoffStringTable strings, Address32 offset)
        {
            var data = slice(strings.Data, (uint)offset);
            var max = strings.Data.Length;
            var len = 0u;
            var i=0u;
            while(i < max && (sbyte)skip(data,i++) > 0)
                len++;
            return len;
        }

        [MethodImpl(Inline), Op]
        public static uint length(in CoffStringTable strings, CoffSymbolName name)
        {
            var kind = name.NameKind;
            var len  = 0u;
            if(kind == CoffNameKind.String)
                len = AQ.length(recover<AsciCode>(name.Bytes));
            else if(kind == CoffNameKind.Address)
                len = length(strings, name.Address);
            return len;
        }

        public static string format(in CoffStringTable strings, CoffSymbolName name)
        {
            var len = length(strings, name);
            var dst = EmptyString;
            if(len <= 8)
                dst = recover<AsciCode>(slice(name.Bytes,0,len)).Format();
            else if(name.Address.IsNonZero)
                dst = entry(strings, name.Address).Format();
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciCode> entry(in CoffStringTable strings, Address32 offset)
        {
            var data = slice(strings.Data, (uint)offset);
            return recover<AsciCode>(slice(data,0, length(strings,offset)));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<CoffSymbol> symbols(ReadOnlySpan<byte> src, uint offset, uint count)
            => slice(recover<CoffSymbol>(slice(src,offset)), 0, count);

        [MethodImpl(Inline), Op]
        public static CoffObject load(in FileRef fref)
            => new CoffObject(fref.Path, fref.Path.ReadBytes());

        [MethodImpl(Inline), Op]
        public static CoffObject load(FS.FilePath path)
            => new CoffObject(path, path.ReadBytes());

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