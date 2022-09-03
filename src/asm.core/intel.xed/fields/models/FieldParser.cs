//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedFields;
    using static core;

    using K = XedRules.FieldKind;
    using R = XedRules;

    partial class XedOps
    {
        public class FieldParser
        {
            public static uint parse(InstFieldValues src, Fields dst, bool clear = true)
            {
                if(clear)
                    dst.Clear();

                var result = Outcome.Success;
                var counter = 0u;
                var count = src.Count;
                var keys = src.Keys.Array();
                for(var i=0; i<count; i++)
                {
                    var name = skip(keys,i);
                    var value = src[name];
                    result = XedParsers.parse(name, out FieldKind kind);
                    result.Require();
                    dst.Update(FieldParser.pack(value, kind));
                    counter++;
                }
                return counter;
            }

            public static Index<FieldKind> parse(IReadOnlyDictionary<string,string> src, Fields fields, out OperandState state)
            {
                state = parse(src, out Index<FieldKind> parsed);
                for(var i=0; i<parsed.Count; i++)
                {
                    var field = extract(state, parsed[i]);
                    convert(field, out fields[field.Field]);
                }
                return parsed;
            }

            public static void convert(in FieldValue src, out Field dst)
            {
                dst = Field.Empty;
                var kind = src.Field;
                var size = XedFields.size(kind, src.CellKind);
                if(size.PackedWidth == 1)
                    dst = Field.init(kind, (bit)src.Data);
                else if(size.NativeWidth == 1)
                    dst = Field.init(kind, (byte)src.Data);
                else if(size.NativeWidth == 2)
                    dst = Field.init(kind, (ushort)src.Data);
                else
                    Errors.Throw($"Unsupported size {size}");
            }

            public static uint parse(IReadOnlyDictionary<string,string> src, Span<FieldValue> fields, out OperandState state)
            {
                state = FieldParser.parse(src, out Index<FieldKind> _);
                var names = src.Keys.Array();
                var count = names.Length;
                for(var i=0; i<count; i++)
                {
                    var name = skip(names,i);
                    if(XedParsers.parse(name, out FieldKind kind))
                        seek(fields,i) = FieldParser.parse(src[name], kind, ref state);
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), name));
                }

                update(fields, ref state);
                return (uint)count;
            }

            public static Index<FieldValue> parse(IReadOnlyDictionary<string,string> src, out OperandState dst)
            {
                var count = (uint)src.Count;
                var fields = alloc<FieldValue>(count);
                parse(src,fields, out dst);
                return fields;
            }

            public static FieldKind kind(string src)
            {
                var i = text.index(src, Chars.Eq);
                var j = text.index(src, Chars.LBracket);
                var k = text.index(src, "!=");
                var result = FieldKind.INVALID;

                if(j>0)
                {
                    var field = text.left(src, j);
                    if(XedParsers.parse(field, out result))
                        return result;
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));
                }
                else if(k>0)
                {
                    var field = text.left(src,k);
                    if(XedParsers.parse(field, out result))
                        return result;
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));
                }
                else if(i > 0)
                {
                    var field = text.left(src,i);
                    if(XedParsers.parse(field, out result))
                        return result;
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));

                }
                if(XedParsers.parse(src, out result))
                    return result;

                return result;
            }

            public static uint parse(IReadOnlyDictionary<string,string> src, Fields dst, bool clear)
            {
                if(clear)
                    dst.Clear();

                var result = Outcome.Success;
                var counter = 0u;
                var count = src.Count;
                var keys = src.Keys.Array();
                for(var i=0; i<count; i++)
                {
                    var name = skip(keys,i);
                    var value = src[name];
                    result = XedParsers.parse(name, out FieldKind kind);
                    result.Require();
                    dst.Update(pack(value, kind));
                    counter++;
                }
                return counter;
            }

            public static OperandState parse(IReadOnlyDictionary<string,string> src, out Index<FieldKind> fields)
            {
                var parsed = list<FieldKind>();
                var failed = dict<FieldKind,string>();
                var count = src.Count;
                var dst = OperandState.Empty;
                var names = src.Keys.Index();
                for(var i=0; i<count; i++)
                {
                    ref readonly var name = ref names[i];
                    var kind = FieldKind.INVALID;
                    if(XedParsers.parse(name, out kind))
                    {
                        var value = parse(src[name], kind,  ref dst);
                        if(value.IsNonEmpty)
                            parsed.Add(kind);
                        else
                            failed.Add(kind, src[name]);
                    }
                }
                fields = parsed.ToArray();
                return dst;
            }

            [MethodImpl(Inline)]
            static FieldValue value<T>(FieldKind kind, T value)
                where T : unmanaged
                    => new FieldValue(kind, core.bw64(value));

            [Op]
            public static FieldValue parse(string src, FieldKind kind, ref OperandState dst)
            {
                var result = true;
                var fieldval = R.FieldValue.Empty;
                switch(kind)
                {
                    case K.AMD3DNOW:
                        dst.AMD3DNOW = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ASZ:
                        dst.ASZ = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.BASE0:
                        result = XedParsers.parse(src, out dst.BASE0);
                        fieldval = value(kind, dst.BASE0);
                    break;

                    case K.BASE1:
                        result = XedParsers.parse(src, out dst.BASE1);
                        fieldval = value(kind, dst.BASE1);
                    break;

                    case K.BCAST:
                        result = XedParsers.parse(src, out dst.BCAST);
                        fieldval = value(kind, dst.BCAST);
                    break;

                    case K.BCRC:
                        dst.BCRC = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.RELBR:
                        dst.RELBR = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.BRDISP_WIDTH:
                        result = XedParsers.parse(src, out dst.BRDISP_WIDTH);
                        fieldval = value(kind, dst.BRDISP_WIDTH);
                    break;

                    case K.CET:
                        dst.CET = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.CHIP:
                        result = XedParsers.parse(src, out dst.CHIP);
                        fieldval = value(kind, dst.CHIP);
                    break;

                    case K.CLDEMOTE:
                        dst.CLDEMOTE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.DEFAULT_SEG:
                        result = DataParser.parse(src, out dst.DEFAULT_SEG);
                        fieldval = value(kind, dst.DEFAULT_SEG);
                    break;

                    case K.DF32:
                        dst.DF32 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.DF64:
                        dst.DF64 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.DISP_WIDTH:
                        result = DataParser.parse(src, out dst.DISP_WIDTH);
                        fieldval = value(kind, dst.DISP_WIDTH);
                    break;

                    case K.DUMMY:
                        dst.DUMMY = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.EASZ:
                        result = DataParser.parse(src, out dst.EASZ);
                        fieldval = value(kind, dst.EASZ);
                    break;

                    case K.ELEMENT_SIZE:
                        result = DataParser.parse(src, out dst.ELEMENT_SIZE);
                        fieldval = value(kind, dst.ELEMENT_SIZE);
                    break;

                    case K.ENCODER_PREFERRED:
                        dst.ENCODER_PREFERRED = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ENCODE_FORCE:
                        dst.ENCODE_FORCE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.EOSZ:
                        result = DataParser.parse(src, out dst.EOSZ);
                        fieldval = value(kind, dst.EOSZ);
                    break;

                    case K.ESRC:
                        result = DataParser.parse(src, out dst.ESRC);
                        fieldval = value(kind, dst.ESRC);
                    break;

                    case K.FIRST_F2F3:
                        result = DataParser.parse(src, out dst.FIRST_F2F3);
                        fieldval = value(kind, dst.FIRST_F2F3);
                    break;

                    case K.HAS_MODRM:
                        dst.HAS_MODRM = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.HAS_SIB:
                        dst.HAS_SIB = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.HINT:
                        result = DataParser.parse(src, out dst.HINT);
                        fieldval = value(kind, dst.HINT);
                    break;

                    case K.ICLASS:
                        result = DataParser.eparse(src, out dst.ICLASS);
                        fieldval = value(kind, dst.ICLASS);
                    break;

                    case K.ILD_F2:
                        dst.ILD_F2 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ILD_F3:
                        dst.ILD_F3 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ILD_SEG:
                        result = DataParser.parse(src, out dst.ILD_SEG);
                        fieldval = value(kind, dst.ILD_SEG);
                    break;

                    case K.IMM0:
                        dst.IMM0 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.IMM0SIGNED:
                        dst.IMM0SIGNED = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.IMM1:
                        dst.IMM1 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.IMM1_BYTES:
                        result = DataParser.parse(src, out dst.IMM1_BYTES);
                        fieldval = value(kind, dst.IMM1_BYTES);
                    break;

                    case K.IMM_WIDTH:
                        result = DataParser.parse(src, out dst.IMM_WIDTH);
                        fieldval = value(kind, dst.IMM_WIDTH);
                    break;

                    case K.INDEX:
                        result = XedParsers.parse(src, out dst.INDEX);
                        fieldval = value(kind, dst.INDEX);
                    break;

                    case K.LAST_F2F3:
                        result = DataParser.parse(src, out dst.LAST_F2F3);
                        fieldval = value(kind, dst.LAST_F2F3);
                    break;

                    case K.LLRC:
                        result = DataParser.parse(src, out dst.LLRC);
                        fieldval = value(kind, dst.LLRC);
                    break;

                    case K.LOCK:
                        dst.LOCK = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.LZCNT:
                        dst.LZCNT = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MAP:
                        result = DataParser.parse(src, out dst.MAP);
                        fieldval = value(kind, dst.MAP);
                    break;

                    case K.MASK:
                        result = DataParser.parse(src, out dst.MASK);
                        fieldval = value(kind, dst.MASK);
                    break;

                    case K.MAX_BYTES:
                        result = DataParser.parse(src, out dst.MAX_BYTES);
                        fieldval = value(kind, dst.MAX_BYTES);
                    break;

                    case K.MEM_WIDTH:
                        result = DataParser.parse(src, out dst.MEM_WIDTH);
                        fieldval = value(kind, dst.MEM_WIDTH);
                    break;

                    case K.MEM0:
                        dst.MEM0 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MEM1:
                        dst.MEM1 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MOD:
                        result = DataParser.parse(src, out dst.MOD);
                        fieldval = value(kind, dst.MOD);
                    break;

                    case K.REG:
                        result = DataParser.parse(src, out dst.REG);
                        fieldval = value(kind, dst.REG);
                    break;

                    case K.MODRM_BYTE:
                        result = DataParser.parse(src, out byte modrm);
                        dst.MODRM_BYTE = modrm;
                        fieldval = value(kind, dst.MODRM_BYTE);
                    break;

                    case K.MODE:
                        result = DataParser.parse(src, out dst.MODE);
                        fieldval = value(kind, dst.MODE);
                    break;

                    case K.MODEP5:
                        dst.MODEP5 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MODEP55C:
                        dst.MODEP55C = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MODE_FIRST_PREFIX:
                        dst.MODE_FIRST_PREFIX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MPXMODE:
                        dst.MPXMODE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MUST_USE_EVEX:
                        dst.MUST_USE_EVEX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NEEDREX:
                        dst.NEEDREX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NEED_MEMDISP:
                        result = XedParsers.parse(src, out dst.NEED_MEMDISP);
                        fieldval = value(kind, dst.NEED_MEMDISP);
                    break;

                    case K.NEED_SIB:
                        dst.NEED_SIB = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NELEM:
                        result = XedParsers.parse(src, out dst.NELEM);
                        fieldval = value(kind, dst.NELEM);
                    break;

                    case K.NOMINAL_OPCODE:
                        result = XedParsers.parse(src, out dst.NOMINAL_OPCODE);
                        fieldval = value(kind, dst.NOMINAL_OPCODE);
                    break;

                    case K.NOREX:
                        dst.NOREX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NO_SCALE_DISP8:
                        dst.NO_SCALE_DISP8 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NPREFIXES:
                        result = DataParser.parse(src, out dst.NPREFIXES);
                        fieldval = value(kind, dst.NPREFIXES);
                    break;

                    case K.NREXES:
                        result = DataParser.parse(src, out dst.NREXES);
                        fieldval = value(kind, dst.NREXES);
                    break;

                    case K.NSEG_PREFIXES:
                        result = DataParser.parse(src, out dst.NSEG_PREFIXES);
                        fieldval = value(kind, dst.NSEG_PREFIXES);
                    break;

                    case K.OSZ:
                        dst.OSZ = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.OUT_OF_BYTES:
                        dst.OUT_OF_BYTES = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.P4:
                        dst.P4 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.POS_DISP:
                        result = DataParser.parse(src, out dst.POS_DISP);
                        fieldval = value(kind, dst.POS_DISP);
                    break;

                    case K.POS_IMM:
                        result = DataParser.parse(src, out dst.POS_IMM);
                        fieldval = value(kind, dst.POS_IMM);
                    break;

                    case K.POS_IMM1:
                        result = DataParser.parse(src, out dst.POS_IMM1);
                        fieldval = value(kind, dst.POS_IMM1);
                    break;

                    case K.POS_MODRM:
                        result = DataParser.parse(src, out dst.POS_MODRM);
                        fieldval = value(kind, dst.POS_MODRM);
                    break;

                    case K.POS_NOMINAL_OPCODE:
                        result = DataParser.parse(src, out dst.POS_NOMINAL_OPCODE);
                        fieldval = value(kind, dst.POS_NOMINAL_OPCODE);
                    break;

                    case K.POS_SIB:
                        result = DataParser.parse(src, out dst.POS_SIB);
                        fieldval = value(kind, dst.POS_SIB);
                    break;

                    case K.PREFIX66:
                        dst.PREFIX66 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.PTR:
                        dst.PTR = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REALMODE:
                        dst.REALMODE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.OUTREG:
                        result = XedParsers.parse(src, out dst.OUTREG);
                        fieldval = value(kind, dst.OUTREG);
                    break;

                    case K.REG0:
                        result = XedParsers.parse(src, out dst.REG0);
                        fieldval = value(kind, dst.REG0);
                    break;

                    case K.REG1:
                        result = XedParsers.parse(src, out dst.REG1);
                        fieldval = value(kind, dst.REG1);
                    break;

                    case K.REG2:
                        result = XedParsers.parse(src, out dst.REG2);
                        fieldval = value(kind, dst.REG2);
                    break;

                    case K.REG3:
                        result = XedParsers.parse(src, out dst.REG3);
                        fieldval = value(kind, dst.REG3);
                    break;

                    case K.REG4:
                        result = XedParsers.parse(src, out dst.REG4);
                        fieldval = value(kind, dst.REG4);
                    break;

                    case K.REG5:
                        result = XedParsers.parse(src, out dst.REG5);
                        fieldval = value(kind, dst.REG5);
                    break;

                    case K.REG6:
                        result = XedParsers.parse(src, out dst.REG6);
                        fieldval = value(kind, dst.REG6);
                    break;

                    case K.REG7:
                        result = XedParsers.parse(src, out dst.REG7);
                        fieldval = value(kind, dst.REG7);
                    break;

                    case K.REG8:
                        result = XedParsers.parse(src, out dst.REG8);
                        fieldval = value(kind, dst.REG8);
                    break;

                    case K.REG9:
                        result = XedParsers.parse(src, out dst.REG9);
                        fieldval = value(kind, dst.REG9);
                    break;

                    case K.REP:
                        result = DataParser.parse(src, out dst.REP);
                        fieldval = value(kind, dst.REP);
                    break;

                    case K.REX:
                        dst.REX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXB:
                        dst.REX = bit.On;
                        dst.REXB = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXR:
                        dst.REX = bit.On;
                        dst.REXR = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXRR:
                        dst.REXRR = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXW:
                        dst.REX = bit.On;
                        dst.REXW = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXX:
                        dst.REX = bit.On;
                        dst.REXX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.RM:
                        result = DataParser.parse(src, out dst.RM);
                        fieldval = value(kind, dst.RM);
                    break;

                    case K.ROUNDC:
                        result = DataParser.parse(src, out dst.ROUNDC);
                        fieldval = value(kind, dst.ROUNDC);
                    break;

                    case K.SAE:
                        dst.SAE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.SCALE:
                        result = DataParser.parse(src, out dst.SCALE);
                        fieldval = value(kind, dst.SCALE);
                    break;

                    case K.SEG0:
                        result = XedParsers.parse(src, out dst.SEG0);
                        fieldval = value(kind, dst.SEG0);
                    break;

                    case K.SEG1:
                        result = XedParsers.parse(src, out dst.SEG1);
                        fieldval = value(kind, dst.SEG1);
                    break;

                    case K.SEG_OVD:
                        result = DataParser.parse(src, out dst.SEG_OVD);
                        fieldval = value(kind, dst.SEG_OVD);
                    break;

                    case K.SIBBASE:
                        result = DataParser.parse(src, out dst.SIBBASE);
                        fieldval = value(kind, dst.SIBBASE);
                    break;

                    case K.SIBINDEX:
                        result = DataParser.parse(src, out dst.SIBINDEX);
                        fieldval = value(kind, dst.SIBINDEX);
                    break;

                    case K.SIBSCALE:
                        result = DataParser.parse(src, out dst.SIBSCALE);
                        fieldval = value(kind, dst.SIBSCALE);
                    break;

                    case K.SMODE:
                        result = DataParser.parse(src, out dst.SMODE);
                        fieldval = value(kind, dst.SMODE);
                        break;

                    case K.SRM:
                        result = DataParser.parse(src, out dst.SRM);
                        fieldval = value(kind, dst.SRM);
                    break;

                    case K.TZCNT:
                        dst.TZCNT = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.UBIT:
                        dst.UBIT = bit.On;
                        fieldval = value(kind, bit.On);
                    break;


                    case K.USING_DEFAULT_SEGMENT0:
                        dst.USING_DEFAULT_SEGMENT0 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.USING_DEFAULT_SEGMENT1:
                        dst.USING_DEFAULT_SEGMENT1 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.VEXDEST210:
                        result = DataParser.parse(src, out dst.VEXDEST210);
                        fieldval = value(kind, dst.VEXDEST210);
                    break;

                    case K.VEXDEST3:
                        dst.VEXDEST3 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.VEXDEST4:
                        dst.VEXDEST4 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.VEXVALID:
                        result = DataParser.parse(src, out dst.VEXVALID);
                        fieldval = value(kind, dst.VEXVALID);
                    break;

                    case K.VEX_C4:
                        dst.VEX_C4 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.VEX_PREFIX:
                        result = DataParser.parse(src, out dst.VEX_PREFIX);
                        fieldval = value(kind, dst.VEX_PREFIX);
                    break;

                    case K.VL:
                        result = DataParser.parse(src, out dst.VL);
                        fieldval = value(kind, dst.VL);
                    break;

                    case K.WBNOINVD:
                        dst.WBNOINVD = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ZEROING:
                        dst.ZEROING = bit.On;
                        fieldval = value(kind, bit.On);
                    break;
                }

                return fieldval;
            }

            [Op]
            public static FieldPack pack(string src, FieldKind kind)
            {
                var result = true;
                var dst = FieldPack.Empty;
                dst.Field = kind;
                switch(kind)
                {
                    case K.AMD3DNOW:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.ASZ:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.BASE0:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.BASE1:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.BCAST:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.BCRC:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.RELBR:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.BRDISP_WIDTH:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.CET:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.CHIP:
                        result = XedParsers.parse(src, out dst.Chip);
                    break;

                    case K.CLDEMOTE:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.DEFAULT_SEG:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.DF32:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.DF64:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.DISP_WIDTH:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.DUMMY:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.EASZ:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.ELEMENT_SIZE:
                        result = DataParser.parse(src, out dst.Word);
                    break;

                    case K.ENCODER_PREFERRED:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.ENCODE_FORCE:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.EOSZ:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.ESRC:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.FIRST_F2F3:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.HAS_MODRM:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.HAS_SIB:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.HINT:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.ICLASS:
                        result = XedParsers.parse(src, out dst.Class);
                    break;

                    case K.ILD_F2:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.ILD_F3:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.ILD_SEG:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.IMM0:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.IMM0SIGNED:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.IMM1:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.IMM1_BYTES:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.IMM_WIDTH:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.INDEX:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.LAST_F2F3:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.LLRC:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.LOCK:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.LZCNT:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.MAP:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.MASK:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.MAX_BYTES:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.MEM_WIDTH:
                        result = DataParser.parse(src, out dst.Word);
                    break;

                    case K.MEM0:
                        dst.Bit = 1;
                        result = true;
                    break;

                    case K.MEM1:
                        dst.Bit = 1;
                        result = true;
                    break;

                    case K.MOD:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.REG:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.MODRM_BYTE:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.MODE:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.MODEP5:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.MODEP55C:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.MODE_FIRST_PREFIX:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.MPXMODE:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.MUST_USE_EVEX:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.NEEDREX:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.NEED_MEMDISP:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.NEED_SIB:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.NELEM:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.NOMINAL_OPCODE:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.NOREX:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.NO_SCALE_DISP8:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.NPREFIXES:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.NREXES:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.NSEG_PREFIXES:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.OSZ:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.OUT_OF_BYTES:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.P4:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.POS_DISP:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.POS_IMM:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.POS_IMM1:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.POS_MODRM:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.POS_NOMINAL_OPCODE:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.POS_SIB:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.PREFIX66:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.PTR:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.REALMODE:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.OUTREG:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG0:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG1:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG2:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG3:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG4:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG5:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG6:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG7:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG8:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REG9:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.REP:
                        result = DataParser.parse(src, out dst.Byte);
                    break;

                    case K.REX:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.REXB:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.REXR:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.REXRR:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.REXW:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.REXX:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.RM:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.ROUNDC:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.SAE:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.SCALE:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.SEG0:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.SEG1:
                        result = XedParsers.parse(src, out dst.Reg);
                    break;

                    case K.SEG_OVD:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.SIBBASE:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.SIBINDEX:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.SIBSCALE:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.SMODE:
                        result = XedParsers.parse(src, out dst.Byte);
                        break;

                    case K.SRM:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.TZCNT:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.UBIT:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.USING_DEFAULT_SEGMENT0:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.USING_DEFAULT_SEGMENT1:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.VEXDEST210:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.VEXDEST3:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.VEXDEST4:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.VEXVALID:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.VEX_C4:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.VEX_PREFIX:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.VL:
                        result = XedParsers.parse(src, out dst.Byte);
                    break;

                    case K.WBNOINVD:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;

                    case K.ZEROING:
                        result = XedParsers.parse(src, out dst.Bit);
                    break;
                }

                if(!result)
                    Errors.Throw(AppMsg.ParseFailure.Format(kind.ToString(), src));

                return dst;
            }
       }
    }
}