//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;
using static XedFields;
using static sys;

using FK = XedRules.FieldKind;
using DK = XedRules.FieldDataKind;
using R = XedRules;

[ApiHost]
public partial class XedOps : AppService<XedOps>
{
    static readonly Index<XedRegId> Regs;

    static XedOps()
    {
        Regs = Symbols.index<XedRegId>().Kinds.ToArray();
    }
    
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
                result = XedParsers.parse(name, out FK kind);
                result.Require();
                dst.Update(pack(value, kind));
                counter++;
            }
            return counter;
        }

        public static Index<FK> parse(IReadOnlyDictionary<string,string> src, Fields fields, out XedOperandState state)
        {
            state = parse(src, out Index<FK> parsed);
            for(var i=0; i<parsed.Count; i++)
            {
                var field = Xed.extract(state, parsed[i]);
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

        public static uint parse(IReadOnlyDictionary<string,string> src, Span<FieldValue> fields, out XedOperandState state)
        {
            state = parse(src, out Index<FK> _);
            var names = src.Keys.Array();
            var count = names.Length;
            for(var i=0; i<count; i++)
            {
                var name = skip(names,i);
                if(XedParsers.parse(name, out FK kind))
                    seek(fields,i) = parse(src[name], kind, ref state);
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), name));
            }

            XedOps.update(fields, ref state);
            return (uint)count;
        }

        public static Index<FieldValue> parse(IReadOnlyDictionary<string,string> src, out XedOperandState dst)
        {
            var count = (uint)src.Count;
            var fields = alloc<FieldValue>(count);
            parse(src,fields, out dst);
            return fields;
        }

        public static FK kind(string src)
        {
            var i = text.index(src, Chars.Eq);
            var j = text.index(src, Chars.LBracket);
            var k = text.index(src, "!=");
            var result = FK.INVALID;

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
                result = XedParsers.parse(name, out FK kind);
                result.Require();
                dst.Update(pack(value, kind));
                counter++;
            }
            return counter;
        }

        public static XedOperandState parse(IReadOnlyDictionary<string,string> src, out Index<FK> fields)
        {
            var parsed = list<FK>();
            var failed = dict<FK,string>();
            var count = src.Count;
            var dst = XedOperandState.Empty;
            var names = src.Keys.Index();
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref names[i];
                var kind = FK.INVALID;
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
        static FieldValue value<T>(FK kind, T value)
            where T : unmanaged
                => new (kind, bw64(value));

        [Op]
        public static FieldValue parse(string src, FK kind, ref XedOperandState dst)
        {
            var result = true;
            var fieldval = R.FieldValue.Empty;
            switch(kind)
            {
                case FK.AMD3DNOW:
                    dst.AMD3DNOW = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.ASZ:
                    dst.ASZ = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.BASE0:
                    result = XedParsers.parse(src, out dst.BASE0);
                    fieldval = value(kind, dst.BASE0);
                break;

                case FK.BASE1:
                    result = XedParsers.parse(src, out dst.BASE1);
                    fieldval = value(kind, dst.BASE1);
                break;

                case FK.BCAST:
                    result = XedParsers.parse(src, out dst.BCAST);
                    fieldval = value(kind, dst.BCAST);
                break;

                case FK.BCRC:
                    dst.BCRC = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.RELBR:
                    dst.RELBR = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.BRDISP_WIDTH:
                    result = XedParsers.parse(src, out dst.BRDISP_WIDTH);
                    fieldval = value(kind, dst.BRDISP_WIDTH);
                break;

                case FK.CET:
                    dst.CET = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.CHIP:
                    result = XedParsers.parse(src, out dst.CHIP);
                    fieldval = value(kind, dst.CHIP);
                break;

                case FK.CLDEMOTE:
                    dst.CLDEMOTE = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.DEFAULT_SEG:
                    result = DataParser.parse(src, out dst.DEFAULT_SEG);
                    fieldval = value(kind, dst.DEFAULT_SEG);
                break;

                case FK.DF32:
                    dst.DF32 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.DF64:
                    dst.DF64 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.DISP_WIDTH:
                    result = DataParser.parse(src, out dst.DISP_WIDTH);
                    fieldval = value(kind, dst.DISP_WIDTH);
                break;

                case FK.DUMMY:
                    dst.DUMMY = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.EASZ:
                    result = DataParser.parse(src, out dst.EASZ);
                    fieldval = value(kind, dst.EASZ);
                break;

                case FK.ELEMENT_SIZE:
                    result = DataParser.parse(src, out dst.ELEMENT_SIZE);
                    fieldval = value(kind, dst.ELEMENT_SIZE);
                break;

                case FK.ENCODER_PREFERRED:
                    dst.ENCODER_PREFERRED = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.ENCODE_FORCE:
                    dst.ENCODE_FORCE = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.EOSZ:
                    result = DataParser.parse(src, out dst.EOSZ);
                    fieldval = value(kind, dst.EOSZ);
                break;

                case FK.ESRC:
                    result = DataParser.parse(src, out dst.ESRC);
                    fieldval = value(kind, dst.ESRC);
                break;

                case FK.FIRST_F2F3:
                    result = DataParser.parse(src, out dst.FIRST_F2F3);
                    fieldval = value(kind, dst.FIRST_F2F3);
                break;

                case FK.HAS_MODRM:
                    dst.HAS_MODRM = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.HAS_SIB:
                    dst.HAS_SIB = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.HINT:
                    result = DataParser.parse(src, out dst.HINT);
                    fieldval = value(kind, dst.HINT);
                break;

                case FK.ICLASS:
                    result = DataParser.eparse(src, out dst.ICLASS);
                    fieldval = value(kind, dst.ICLASS);
                break;

                case FK.ILD_F2:
                    dst.ILD_F2 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.ILD_F3:
                    dst.ILD_F3 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.ILD_SEG:
                    result = DataParser.parse(src, out dst.ILD_SEG);
                    fieldval = value(kind, dst.ILD_SEG);
                break;

                case FK.IMM0:
                    dst.IMM0 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.IMM0SIGNED:
                    dst.IMM0SIGNED = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.IMM1:
                    dst.IMM1 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.IMM1_BYTES:
                    result = DataParser.parse(src, out dst.IMM1_BYTES);
                    fieldval = value(kind, dst.IMM1_BYTES);
                break;

                case FK.IMM_WIDTH:
                    result = DataParser.parse(src, out dst.IMM_WIDTH);
                    fieldval = value(kind, dst.IMM_WIDTH);
                break;

                case FK.INDEX:
                    result = XedParsers.parse(src, out dst.INDEX);
                    fieldval = value(kind, dst.INDEX);
                break;

                case FK.LAST_F2F3:
                    result = DataParser.parse(src, out dst.LAST_F2F3);
                    fieldval = value(kind, dst.LAST_F2F3);
                break;

                case FK.LLRC:
                    result = DataParser.parse(src, out dst.LLRC);
                    fieldval = value(kind, dst.LLRC);
                break;

                case FK.LOCK:
                    dst.LOCK = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.LZCNT:
                    dst.LZCNT = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.MAP:
                    result = DataParser.parse(src, out dst.MAP);
                    fieldval = value(kind, dst.MAP);
                break;

                case FK.MASK:
                    result = DataParser.parse(src, out dst.MASK);
                    fieldval = value(kind, dst.MASK);
                break;

                case FK.MAX_BYTES:
                    result = DataParser.parse(src, out dst.MAX_BYTES);
                    fieldval = value(kind, dst.MAX_BYTES);
                break;

                case FK.MEM_WIDTH:
                    result = DataParser.parse(src, out dst.MEM_WIDTH);
                    fieldval = value(kind, dst.MEM_WIDTH);
                break;

                case FK.MEM0:
                    dst.MEM0 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.MEM1:
                    dst.MEM1 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.MOD:
                    result = DataParser.parse(src, out dst.MOD);
                    fieldval = value(kind, dst.MOD);
                break;

                case FK.REG:
                    result = DataParser.parse(src, out dst.REG);
                    fieldval = value(kind, dst.REG);
                break;

                case FK.MODRM_BYTE:
                    result = DataParser.parse(src, out byte modrm);
                    dst.MODRM_BYTE = modrm;
                    fieldval = value(kind, dst.MODRM_BYTE);
                break;

                case FK.MODE:
                    result = DataParser.parse(src, out dst.MODE);
                    fieldval = value(kind, dst.MODE);
                break;

                case FK.MODEP5:
                    dst.MODEP5 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.MODEP55C:
                    dst.MODEP55C = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.MODE_FIRST_PREFIX:
                    dst.MODE_FIRST_PREFIX = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.MPXMODE:
                    dst.MPXMODE = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.MUST_USE_EVEX:
                    dst.MUST_USE_EVEX = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.NEEDREX:
                    dst.NEEDREX = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.NEED_MEMDISP:
                    result = XedParsers.parse(src, out dst.NEED_MEMDISP);
                    fieldval = value(kind, dst.NEED_MEMDISP);
                break;

                case FK.NEED_SIB:
                    dst.NEED_SIB = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.NELEM:
                    result = XedParsers.parse(src, out dst.NELEM);
                    fieldval = value(kind, dst.NELEM);
                break;

                case FK.NOMINAL_OPCODE:
                    result = XedParsers.parse(src, out dst.NOMINAL_OPCODE);
                    fieldval = value(kind, dst.NOMINAL_OPCODE);
                break;

                case FK.NOREX:
                    dst.NOREX = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.NO_SCALE_DISP8:
                    dst.NO_SCALE_DISP8 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.NPREFIXES:
                    result = DataParser.parse(src, out dst.NPREFIXES);
                    fieldval = value(kind, dst.NPREFIXES);
                break;

                case FK.NREXES:
                    result = DataParser.parse(src, out dst.NREXES);
                    fieldval = value(kind, dst.NREXES);
                break;

                case FK.NSEG_PREFIXES:
                    result = DataParser.parse(src, out dst.NSEG_PREFIXES);
                    fieldval = value(kind, dst.NSEG_PREFIXES);
                break;

                case FK.OSZ:
                    dst.OSZ = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.OUT_OF_BYTES:
                    dst.OUT_OF_BYTES = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.P4:
                    dst.P4 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.POS_DISP:
                    result = DataParser.parse(src, out dst.POS_DISP);
                    fieldval = value(kind, dst.POS_DISP);
                break;

                case FK.POS_IMM:
                    result = DataParser.parse(src, out dst.POS_IMM);
                    fieldval = value(kind, dst.POS_IMM);
                break;

                case FK.POS_IMM1:
                    result = DataParser.parse(src, out dst.POS_IMM1);
                    fieldval = value(kind, dst.POS_IMM1);
                break;

                case FK.POS_MODRM:
                    result = DataParser.parse(src, out dst.POS_MODRM);
                    fieldval = value(kind, dst.POS_MODRM);
                break;

                case FK.POS_NOMINAL_OPCODE:
                    result = DataParser.parse(src, out dst.POS_NOMINAL_OPCODE);
                    fieldval = value(kind, dst.POS_NOMINAL_OPCODE);
                break;

                case FK.POS_SIB:
                    result = DataParser.parse(src, out dst.POS_SIB);
                    fieldval = value(kind, dst.POS_SIB);
                break;

                case FK.PREFIX66:
                    dst.PREFIX66 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.PTR:
                    dst.PTR = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.REALMODE:
                    dst.REALMODE = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.OUTREG:
                    result = XedParsers.parse(src, out dst.OUTREG);
                    fieldval = value(kind, dst.OUTREG);
                break;

                case FK.REG0:
                    result = XedParsers.parse(src, out dst.REG0);
                    fieldval = value(kind, dst.REG0);
                break;

                case FK.REG1:
                    result = XedParsers.parse(src, out dst.REG1);
                    fieldval = value(kind, dst.REG1);
                break;

                case FK.REG2:
                    result = XedParsers.parse(src, out dst.REG2);
                    fieldval = value(kind, dst.REG2);
                break;

                case FK.REG3:
                    result = XedParsers.parse(src, out dst.REG3);
                    fieldval = value(kind, dst.REG3);
                break;

                case FK.REG4:
                    result = XedParsers.parse(src, out dst.REG4);
                    fieldval = value(kind, dst.REG4);
                break;

                case FK.REG5:
                    result = XedParsers.parse(src, out dst.REG5);
                    fieldval = value(kind, dst.REG5);
                break;

                case FK.REG6:
                    result = XedParsers.parse(src, out dst.REG6);
                    fieldval = value(kind, dst.REG6);
                break;

                case FK.REG7:
                    result = XedParsers.parse(src, out dst.REG7);
                    fieldval = value(kind, dst.REG7);
                break;

                case FK.REG8:
                    result = XedParsers.parse(src, out dst.REG8);
                    fieldval = value(kind, dst.REG8);
                break;

                case FK.REG9:
                    result = XedParsers.parse(src, out dst.REG9);
                    fieldval = value(kind, dst.REG9);
                break;

                case FK.REP:
                    result = DataParser.parse(src, out dst.REP);
                    fieldval = value(kind, dst.REP);
                break;

                case FK.REX:
                    dst.REX = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.REXB:
                    dst.REX = bit.On;
                    dst.REXB = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.REXR:
                    dst.REX = bit.On;
                    dst.REXR = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.REXRR:
                    dst.REXRR = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.REXW:
                    dst.REX = bit.On;
                    dst.REXW = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.REXX:
                    dst.REX = bit.On;
                    dst.REXX = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.RM:
                    result = DataParser.parse(src, out dst.RM);
                    fieldval = value(kind, dst.RM);
                break;

                case FK.ROUNDC:
                    result = DataParser.parse(src, out dst.ROUNDC);
                    fieldval = value(kind, dst.ROUNDC);
                break;

                case FK.SAE:
                    dst.SAE = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.SCALE:
                    result = DataParser.parse(src, out dst.SCALE);
                    fieldval = value(kind, dst.SCALE);
                break;

                case FK.SEG0:
                    result = XedParsers.parse(src, out dst.SEG0);
                    fieldval = value(kind, dst.SEG0);
                break;

                case FK.SEG1:
                    result = XedParsers.parse(src, out dst.SEG1);
                    fieldval = value(kind, dst.SEG1);
                break;

                case FK.SEG_OVD:
                    result = DataParser.parse(src, out dst.SEG_OVD);
                    fieldval = value(kind, dst.SEG_OVD);
                break;

                case FK.SIBBASE:
                    result = DataParser.parse(src, out dst.SIBBASE);
                    fieldval = value(kind, dst.SIBBASE);
                break;

                case FK.SIBINDEX:
                    result = DataParser.parse(src, out dst.SIBINDEX);
                    fieldval = value(kind, dst.SIBINDEX);
                break;

                case FK.SIBSCALE:
                    result = DataParser.parse(src, out dst.SIBSCALE);
                    fieldval = value(kind, dst.SIBSCALE);
                break;

                case FK.SMODE:
                    result = DataParser.parse(src, out dst.SMODE);
                    fieldval = value(kind, dst.SMODE);
                    break;

                case FK.SRM:
                    result = DataParser.parse(src, out dst.SRM);
                    fieldval = value(kind, dst.SRM);
                break;

                case FK.TZCNT:
                    dst.TZCNT = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.UBIT:
                    dst.UBIT = bit.On;
                    fieldval = value(kind, bit.On);
                break;


                case FK.USING_DEFAULT_SEGMENT0:
                    dst.USING_DEFAULT_SEGMENT0 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.USING_DEFAULT_SEGMENT1:
                    dst.USING_DEFAULT_SEGMENT1 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.VEXDEST210:
                    result = DataParser.parse(src, out dst.VEXDEST210);
                    fieldval = value(kind, dst.VEXDEST210);
                break;

                case FK.VEXDEST3:
                    dst.VEXDEST3 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.VEXDEST4:
                    dst.VEXDEST4 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.VEXVALID:
                    result = DataParser.parse(src, out dst.VEXVALID);
                    fieldval = value(kind, dst.VEXVALID);
                break;

                case FK.VEX_C4:
                    dst.VEX_C4 = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.VEX_PREFIX:
                    result = DataParser.parse(src, out dst.VEX_PREFIX);
                    fieldval = value(kind, dst.VEX_PREFIX);
                break;

                case FK.VL:
                    result = DataParser.parse(src, out dst.VL);
                    fieldval = value(kind, dst.VL);
                break;

                case FK.WBNOINVD:
                    dst.WBNOINVD = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case FK.ZEROING:
                    dst.ZEROING = bit.On;
                    fieldval = value(kind, bit.On);
                break;
            }

            return fieldval;
        }

        [Op]
        public static XedFieldPack pack(string src, FK kind)
        {
            var result = true;
            var dst = XedFieldPack.Empty;
            dst.Field = kind;
            switch(kind)
            {
                case FK.AMD3DNOW:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.ASZ:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.BASE0:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.BASE1:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.BCAST:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.BCRC:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.RELBR:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.BRDISP_WIDTH:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.CET:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.CHIP:
                    result = XedParsers.parse(src, out dst.Chip);
                break;

                case FK.CLDEMOTE:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.DEFAULT_SEG:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.DF32:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.DF64:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.DISP_WIDTH:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.DUMMY:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.EASZ:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.ELEMENT_SIZE:
                    result = DataParser.parse(src, out dst.Word);
                break;

                case FK.ENCODER_PREFERRED:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.ENCODE_FORCE:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.EOSZ:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.ESRC:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.FIRST_F2F3:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.HAS_MODRM:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.HAS_SIB:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.HINT:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.ICLASS:
                    result = XedParsers.parse(src, out dst.Class);
                break;

                case FK.ILD_F2:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.ILD_F3:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.ILD_SEG:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.IMM0:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.IMM0SIGNED:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.IMM1:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.IMM1_BYTES:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.IMM_WIDTH:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.INDEX:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.LAST_F2F3:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.LLRC:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.LOCK:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.LZCNT:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.MAP:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.MASK:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.MAX_BYTES:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.MEM_WIDTH:
                    result = DataParser.parse(src, out dst.Word);
                break;

                case FK.MEM0:
                    dst.Bit = 1;
                    result = true;
                break;

                case FK.MEM1:
                    dst.Bit = 1;
                    result = true;
                break;

                case FK.MOD:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.REG:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.MODRM_BYTE:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.MODE:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.MODEP5:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.MODEP55C:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.MODE_FIRST_PREFIX:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.MPXMODE:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.MUST_USE_EVEX:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.NEEDREX:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.NEED_MEMDISP:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.NEED_SIB:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.NELEM:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.NOMINAL_OPCODE:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.NOREX:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.NO_SCALE_DISP8:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.NPREFIXES:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.NREXES:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.NSEG_PREFIXES:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.OSZ:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.OUT_OF_BYTES:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.P4:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.POS_DISP:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.POS_IMM:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.POS_IMM1:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.POS_MODRM:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.POS_NOMINAL_OPCODE:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.POS_SIB:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.PREFIX66:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.PTR:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.REALMODE:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.OUTREG:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG0:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG1:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG2:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG3:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG4:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG5:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG6:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG7:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG8:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REG9:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.REP:
                    result = DataParser.parse(src, out dst.Byte);
                break;

                case FK.REX:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.REXB:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.REXR:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.REXRR:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.REXW:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.REXX:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.RM:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.ROUNDC:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.SAE:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.SCALE:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.SEG0:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.SEG1:
                    result = XedParsers.parse(src, out dst.Reg);
                break;

                case FK.SEG_OVD:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.SIBBASE:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.SIBINDEX:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.SIBSCALE:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.SMODE:
                    result = XedParsers.parse(src, out dst.Byte);
                    break;

                case FK.SRM:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.TZCNT:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.UBIT:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.USING_DEFAULT_SEGMENT0:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.USING_DEFAULT_SEGMENT1:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.VEXDEST210:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.VEXDEST3:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.VEXDEST4:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.VEXVALID:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.VEX_C4:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.VEX_PREFIX:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.VL:
                    result = XedParsers.parse(src, out dst.Byte);
                break;

                case FK.WBNOINVD:
                    result = XedParsers.parse(src, out dst.Bit);
                break;

                case FK.ZEROING:
                    result = XedParsers.parse(src, out dst.Bit);
                break;
            }

            if(!result)
                Errors.Throw(AppMsg.ParseFailure.Format(kind.ToString(), src));

            return dst;
        }
    }
        public static ref XedOperandState update(in Fields src, ReadOnlySpan<FieldKind> fields, ref XedOperandState dst)
        {
            var count = fields.Length;
            for(var i=0; i<count; i++)
                update(src[skip(fields,i)], ref dst);
            return ref dst;
        }

        public static Dictionary<FieldKind,FieldValue> update(Index<FieldValue> src, ref XedOperandState state)
        {
            update(src.View, ref state);
            return src.Map(x => (x.Field, x)).ToDictionary();
        }

        static ref XedOperandState update(ReadOnlySpan<FieldValue> src, ref XedOperandState dst)
        {
            for(var i=0; i<src.Length; i++)
                update(skip(src,i), ref dst);
            return ref dst;
        }

        static ref XedOperandState update(in FieldValue src, ref XedOperandState dst)
        {
            var result = Outcome.Success;
            switch(src.Field)
            {
                case FK.AMD3DNOW:
                    dst.AMD3DNOW = src;
                break;

                case FK.ASZ:
                    dst.ASZ = src;
                break;

                case FK.BASE0:
                    dst.BASE0 = src.ToReg();
                break;

                case FK.BASE1:
                    dst.BASE1 = src.ToReg();
                break;

                case FK.BCAST:
                    dst.BCAST = src.ToByte();
                break;

                case FK.BCRC:
                    dst.BCRC = src;
                break;

                case FK.RELBR:
                    dst.RELBR = src;
                break;

                case FK.BRDISP_WIDTH:
                    dst.BRDISP_WIDTH = src.ToByte();
                break;

                case FK.CET:
                    dst.CET = src;
                break;

                case FK.CHIP:
                    dst.CHIP = src;
                break;

                case FK.CLDEMOTE:
                    dst.CLDEMOTE = src;
                break;

                case FK.DEFAULT_SEG:
                    dst.DEFAULT_SEG = src.ToByte();
                break;

                case FK.DF32:
                    dst.DF32 = src;
                break;

                case FK.DF64:
                    dst.DF64 = src;
                break;

                case FK.DISP:
                    dst.DISP = src;
                break;

                case FK.DISP_WIDTH:
                    dst.DISP_WIDTH = src.ToByte();
                break;

                case FK.DUMMY:
                    dst.DUMMY = src;
                break;

                case FK.EASZ:
                    dst.EASZ = src.ToByte();
                break;

                case FK.ELEMENT_SIZE:
                    dst.ELEMENT_SIZE = src.ToByte();
                break;

                case FK.ENCODER_PREFERRED:
                    dst.ENCODER_PREFERRED = src;
                break;

                case FK.ENCODE_FORCE:
                    dst.ENCODE_FORCE = src;
                break;

                case FK.EOSZ:
                    dst.EOSZ = src.ToByte();
                break;

                case FK.ESRC:
                    dst.ESRC = src.ToByte();
                break;

                case FK.FIRST_F2F3:
                    dst.FIRST_F2F3 = src.ToByte();
                break;

                case FK.HAS_MODRM:
                    dst.HAS_MODRM = src;
                break;

                case FK.HAS_SIB:
                    dst.HAS_SIB = src;
                break;

                case FK.HINT:
                    dst.HINT  = src.ToByte();
                break;

                case FK.ICLASS:
                    dst.ICLASS = src;
                break;

                case FK.ILD_F2:
                    dst.ILD_F2 = src;
                break;

                case FK.ILD_F3:
                    dst.ILD_F3 = src;
                break;

                case FK.ILD_SEG:
                    dst.ILD_SEG = src.ToByte();
                break;

                case FK.IMM0:
                    dst.IMM0 = src;
                break;

                case FK.IMM0SIGNED:
                    dst.IMM0SIGNED = src;
                break;

                case FK.IMM1:
                    dst.IMM1 = src;
                break;

                case FK.IMM1_BYTES:
                    dst.IMM1_BYTES = src.ToByte();
                break;

                case FK.IMM_WIDTH:
                    dst.IMM_WIDTH = src.ToByte();
                break;

                case FK.INDEX:
                    dst.INDEX = src.ToReg();
                break;

                case FK.LAST_F2F3:
                    dst.LAST_F2F3 = src.ToByte();
                break;

                case FK.LLRC:
                    dst.LLRC = src.ToByte();
                break;

                case FK.LOCK:
                    dst.LOCK = src;
                break;

                case FK.LZCNT:
                    dst.LZCNT = src;
                break;

                case FK.MAP:
                    dst.MAP = src.ToByte();
                break;

                case FK.MASK:
                    dst.MASK = src.ToBit();
                break;

                case FK.MAX_BYTES:
                    dst.MAX_BYTES = src.ToByte();
                break;

                case FK.MEM_WIDTH:
                    dst.MEM_WIDTH = src.ToByte();
                break;

                case FK.MOD:
                    dst.MOD = src.ToByte();
                break;

                case FK.REG:
                    dst.REG = src.ToByte();
                break;

                case FK.MODRM_BYTE:
                    dst.MODRM_BYTE = src.ToHex8();
                break;

                case FK.MODE:
                    dst.MODE = src.ToByte();
                break;

                case FK.MODEP5:
                    dst.MODEP5 = src;
                break;

                case FK.MODEP55C:
                    dst.MODEP55C = src;
                break;

                case FK.MODE_FIRST_PREFIX:
                    dst.MODE_FIRST_PREFIX = src;
                break;

                case FK.MPXMODE:
                    dst.MPXMODE = src;
                break;

                case FK.MUST_USE_EVEX:
                    dst.MUST_USE_EVEX = src;
                break;

                case FK.NEEDREX:
                    dst.NEEDREX = src;
                break;

                case FK.NEED_MEMDISP:
                    dst.NEED_MEMDISP = src.ToByte();
                break;

                case FK.NEED_SIB:
                    dst.NEED_SIB = src;
                break;

                case FK.NELEM:
                    dst.NELEM = src.ToWord();
                break;

                case FK.NOMINAL_OPCODE:
                    dst.NOMINAL_OPCODE = src.ToByte();
                break;

                case FK.NOREX:
                    dst.NOREX = src;
                break;

                case FK.NO_SCALE_DISP8:
                    dst.NO_SCALE_DISP8 = src;
                break;

                case FK.NPREFIXES:
                    dst.NPREFIXES = src.ToByte();
                break;

                case FK.NREXES:
                    dst.NREXES = src.ToByte();
                break;

                case FK.NSEG_PREFIXES:
                    dst.NSEG_PREFIXES = src.ToByte();
                break;

                case FK.OSZ:
                    dst.OSZ = src;
                break;

                case FK.OUT_OF_BYTES:
                    dst.OUT_OF_BYTES = src;
                break;

                case FK.P4:
                    dst.P4 = src;
                break;

                case FK.POS_DISP:
                    dst.POS_DISP = src.ToByte();
                break;

                case FK.POS_IMM:
                    dst.POS_IMM = src.ToByte();
                break;

                case FK.POS_IMM1:
                    dst.POS_IMM1 = src.ToByte();
                break;

                case FK.POS_MODRM:
                    dst.POS_MODRM = src.ToByte();
                break;

                case FK.POS_NOMINAL_OPCODE:
                    dst.POS_NOMINAL_OPCODE = src.ToByte();
                break;

                case FK.POS_SIB:
                    dst.POS_SIB = src.ToByte();
                break;

                case FK.PREFIX66:
                    dst.PREFIX66 = 1;
                break;

                case FK.PTR:
                    dst.PTR = 1;
                break;

                case FK.REALMODE:
                    dst.REALMODE = 1;
                break;

                case FK.OUTREG:
                    dst.OUTREG = src.ToReg();
                break;

                case FK.REG0:
                    dst.REG0 = src.ToReg();
                break;

                case FK.REG1:
                    dst.REG1 = src.ToReg();
                break;

                case FK.REG2:
                    dst.REG2 = src.ToReg();
                break;

                case FK.REG3:
                    dst.REG3 = src.ToReg();
                break;

                case FK.REG4:
                    dst.REG4  = src.ToReg();
                break;

                case FK.REG5:
                    dst.REG5 = src.ToReg();
                break;

                case FK.REG6:
                    dst.REG6 = src.ToReg();
                break;

                case FK.REG7:
                    dst.REG7 = src.ToReg();
                break;

                case FK.REG8:
                    dst.REG8 = src.ToReg();
                break;

                case FK.REG9:
                    dst.REG9 = src.ToReg();
                break;

                case FK.REP:
                    dst.REP = src.ToByte();
                break;

                case FK.REX:
                    dst.REX = src;
                break;

                case FK.REXB:
                    dst.REXB = src;
                break;

                case FK.REXR:
                    dst.REXR = src;
                break;

                case FK.REXRR:
                    dst.REXRR = src;
                break;

                case FK.REXW:
                    dst.REXW = src;
                break;

                case FK.REXX:
                    dst.REXX = src;
                break;

                case FK.RM:
                    dst.RM = src.ToByte();
                break;

                case FK.ROUNDC:
                    dst.ROUNDC = src.ToByte();
                break;

                case FK.SAE:
                    dst.SAE = src;
                break;

                case FK.SCALE:
                    dst.SCALE = src.ToByte();
                break;

                case FK.SEG0:
                    dst.SEG0 = src.ToReg();
                break;

                case FK.SEG1:
                    dst.SEG1 = src.ToReg();
                break;

                case FK.SEG_OVD:
                    dst.SEG_OVD = src.ToByte();
                break;

                case FK.SIBBASE:
                    dst.SIBBASE = src.ToByte();
                break;

                case FK.SIBINDEX:
                    dst.SIBINDEX = src.ToByte();
                break;

                case FK.SIBSCALE:
                    dst.SIBSCALE = src.ToByte();
                break;

                case FK.SMODE:
                    dst.SMODE = src.ToByte();
                    break;

                case FK.SRM:
                    dst.SRM = src.ToByte();
                break;

                case FK.TZCNT:
                    dst.TZCNT = src;
                break;

                case FK.UBIT:
                    dst.UBIT = src;
                break;

                case FK.UIMM0:
                    dst.UIMM0 = src;
                break;

                case FK.UIMM1:
                    dst.UIMM1 = src;
                break;

                case FK.USING_DEFAULT_SEGMENT0:
                    dst.USING_DEFAULT_SEGMENT0 = src;
                break;

                case FK.USING_DEFAULT_SEGMENT1:
                    dst.USING_DEFAULT_SEGMENT1 = src;
                break;

                case FK.VEXDEST210:
                    dst.VEXDEST210 = src.ToByte();
                break;

                case FK.VEXDEST3:
                    dst.VEXDEST3 = src;
                break;

                case FK.VEXDEST4:
                    dst.VEXDEST4 = src;
                break;

                case FK.VEXVALID:
                    dst.VEXVALID = src.ToByte();
                break;

                case FK.VEX_C4:
                    dst.VEX_C4 = src;
                break;

                case FK.VEX_PREFIX:
                    dst.VEX_PREFIX = src.ToByte();
                break;

                case FK.VL:
                    dst.VL = src.ToByte();
                break;

                case FK.WBNOINVD:
                    dst.WBNOINVD = src;
                break;

                case FK.ZEROING:
                    dst.ZEROING = src;
                break;

                case FK.MEM0:
                    dst.MEM0 = src;
                break;

                case FK.MEM1:
                    dst.MEM1 = src;
                break;

                case FK.AGEN:
                    dst.AGEN = src;
                break;
            }

            return ref dst;
        }

        static ref XedOperandState update(in Field src, ref XedOperandState dst)
        {
            switch(src.Kind)
            {
                case FK.AMD3DNOW:
                    dst.AMD3DNOW = src;
                break;

                case FK.ASZ:
                    dst.ASZ = src;
                break;

                case FK.BASE0:
                    dst.BASE0 = src;
                break;

                case FK.BASE1:
                    dst.BASE1 = src;
                break;

                case FK.BCAST:
                    dst.BCAST = src;
                break;

                case FK.BCRC:
                    dst.BCRC = src;
                break;

                case FK.RELBR:
                    dst.RELBR = src;
                break;

                case FK.BRDISP_WIDTH:
                    dst.BRDISP_WIDTH = src;
                break;

                case FK.CET:
                    dst.CET = src;
                break;

                case FK.CHIP:
                    dst.CHIP = src;
                break;

                case FK.CLDEMOTE:
                    dst.CLDEMOTE = src;
                break;

                case FK.DEFAULT_SEG:
                    dst.DEFAULT_SEG = src;
                break;

                case FK.DF32:
                    dst.DF32 = src;
                break;

                case FK.DF64:
                    dst.DF64 = src;
                break;

                case FK.DISP:
                    dst.DISP = src;
                break;

                case FK.DISP_WIDTH:
                    dst.DISP_WIDTH = src;
                break;

                case FK.DUMMY:
                    dst.DUMMY = src;
                break;

                case FK.EASZ:
                    dst.EASZ = src;
                break;

                case FK.ELEMENT_SIZE:
                    dst.ELEMENT_SIZE = src;
                break;

                case FK.ENCODER_PREFERRED:
                    dst.ENCODER_PREFERRED = src;
                break;

                case FK.ENCODE_FORCE:
                    dst.ENCODE_FORCE = src;
                break;

                case FK.EOSZ:
                    dst.EOSZ = src;
                break;

                case FK.ESRC:
                    dst.ESRC = src;
                break;

                case FK.FIRST_F2F3:
                    dst.FIRST_F2F3 = src;
                break;

                case FK.HAS_MODRM:
                    dst.HAS_MODRM = src;
                break;

                case FK.HAS_SIB:
                    dst.HAS_SIB = src;
                break;

                case FK.HINT:
                    dst.HINT = src;
                break;

                case FK.ICLASS:
                    dst.ICLASS = src;
                break;

                case FK.ILD_F2:
                    dst.ILD_F2 = src;
                break;

                case FK.ILD_F3:
                    dst.ILD_F3 = src;
                break;

                case FK.ILD_SEG:
                    dst.ILD_SEG = src;
                break;

                case FK.IMM0:
                    dst.IMM0 = src;
                break;

                case FK.IMM0SIGNED:
                    dst.IMM0SIGNED = src;
                break;

                case FK.IMM1:
                    dst.IMM1 = src;
                break;

                case FK.IMM1_BYTES:
                    dst.IMM1_BYTES = src;
                break;

                case FK.IMM_WIDTH:
                    dst.IMM_WIDTH = src;
                break;

                case FK.INDEX:
                    dst.INDEX = src;
                break;

                case FK.LAST_F2F3:
                    dst.LAST_F2F3 = src;
                break;

                case FK.LLRC:
                    dst.LLRC = src;
                break;

                case FK.LOCK:
                    dst.LOCK = src;
                break;

                case FK.LZCNT:
                    dst.LZCNT = src;
                break;

                case FK.MAP:
                    dst.MAP = src;
                break;

                case FK.MASK:
                    dst.MASK = src;
                break;

                case FK.MAX_BYTES:
                    dst.MAX_BYTES = src;
                break;

                case FK.MEM_WIDTH:
                    dst.MEM_WIDTH = src;
                break;

                case FK.MOD:
                    dst.MOD = src;
                break;

                case FK.REG:
                    dst.REG = src;
                break;

                case FK.MODRM_BYTE:
                    dst.MODRM_BYTE = src;
                break;

                case FK.MODE:
                    dst.MODE = src;
                break;

                case FK.MODEP5:
                    dst.MODEP5 = src;
                break;

                case FK.MODEP55C:
                    dst.MODEP55C = src;
                break;

                case FK.MODE_FIRST_PREFIX:
                    dst.MODE_FIRST_PREFIX = src;
                break;

                case FK.MPXMODE:
                    dst.MPXMODE = src;
                break;

                case FK.MUST_USE_EVEX:
                    dst.MUST_USE_EVEX = src;
                break;

                case FK.NEEDREX:
                    dst.NEEDREX = src;
                break;

                case FK.NEED_MEMDISP:
                    dst.NEED_MEMDISP = src;
                break;

                case FK.NEED_SIB:
                    dst.NEED_SIB = src;
                break;

                case FK.NELEM:
                    dst.NELEM = src;
                break;

                case FK.NOMINAL_OPCODE:
                    dst.NOMINAL_OPCODE = src;
                break;

                case FK.NOREX:
                    dst.NOREX = src;
                break;

                case FK.NO_SCALE_DISP8:
                    dst.NO_SCALE_DISP8 = src;
                break;

                case FK.NPREFIXES:
                    dst.NPREFIXES = src;
                break;

                case FK.NREXES:
                    dst.NREXES = src;
                break;

                case FK.NSEG_PREFIXES:
                    dst.NSEG_PREFIXES = src;
                break;

                case FK.OSZ:
                    dst.OSZ = src;
                break;

                case FK.OUT_OF_BYTES:
                    dst.OUT_OF_BYTES = src;
                break;

                case FK.P4:
                    dst.P4 = src;
                break;

                case FK.POS_DISP:
                    dst.POS_DISP = src;;
                break;

                case FK.POS_IMM:
                    dst.POS_IMM = src;
                break;

                case FK.POS_IMM1:
                    dst.POS_IMM1 = src;
                break;

                case FK.POS_MODRM:
                    dst.POS_MODRM = src;
                break;

                case FK.POS_NOMINAL_OPCODE:
                    dst.POS_NOMINAL_OPCODE = src;
                break;

                case FK.POS_SIB:
                    dst.POS_SIB = src;
                break;

                case FK.PREFIX66:
                    dst.PREFIX66 = 1;
                break;

                case FK.PTR:
                    dst.PTR = 1;
                break;

                case FK.REALMODE:
                    dst.REALMODE = 1;
                break;

                case FK.OUTREG:
                    dst.OUTREG = src;
                break;

                case FK.REG0:
                    dst.REG0 = src;
                break;

                case FK.REG1:
                    dst.REG1 = src;
                break;

                case FK.REG2:
                    dst.REG2 = src;
                break;

                case FK.REG3:
                    dst.REG3 = src;
                break;

                case FK.REG4:
                    dst.REG4 = src;
                break;

                case FK.REG5:
                    dst.REG5 = src;
                break;

                case FK.REG6:
                    dst.REG6 = src;
                break;

                case FK.REG7:
                    dst.REG7 = src;
                break;

                case FK.REG8:
                    dst.REG8 = src;
                break;

                case FK.REG9:
                    dst.REG9 = src;
                break;

                case FK.REP:
                    dst.REP = src;
                break;

                case FK.REX:
                    dst.REX = src;
                break;

                case FK.REXB:
                    dst.REXB = src;
                break;

                case FK.REXR:
                    dst.REXR = src;
                break;

                case FK.REXRR:
                    dst.REXRR = src;
                break;

                case FK.REXW:
                    dst.REXW = src;
                break;

                case FK.REXX:
                    dst.REXX = src;
                break;

                case FK.RM:
                    dst.RM = src;
                break;

                case FK.ROUNDC:
                    dst.ROUNDC = src;
                break;

                case FK.SAE:
                    dst.SAE = src;
                break;

                case FK.SCALE:
                    dst.SCALE = src;
                break;

                case FK.SEG0:
                    dst.SEG0 = src;
                break;

                case FK.SEG1:
                    dst.SEG1 = src;
                break;

                case FK.SEG_OVD:
                    dst.SEG_OVD = src;
                break;

                case FK.SIBBASE:
                    dst.SIBBASE = src;
                break;

                case FK.SIBINDEX:
                    dst.SIBINDEX = src;
                break;

                case FK.SIBSCALE:
                    dst.SIBSCALE = src;
                break;

                case FK.SMODE:
                    dst.SMODE = src;
                    break;

                case FK.SRM:
                    dst.SRM = src;
                break;

                case FK.TZCNT:
                    dst.TZCNT = src;
                break;

                case FK.UBIT:
                    dst.UBIT = src;
                break;

                case FK.UIMM0:
                    dst.UIMM0 = src;
                break;

                case FK.UIMM1:
                    dst.UIMM1 = src;
                break;

                case FK.USING_DEFAULT_SEGMENT0:
                    dst.USING_DEFAULT_SEGMENT0 = src;
                break;

                case FK.USING_DEFAULT_SEGMENT1:
                    dst.USING_DEFAULT_SEGMENT1 = src;
                break;

                case FK.VEXDEST210:
                    dst.VEXDEST210 = src;
                break;

                case FK.VEXDEST3:
                    dst.VEXDEST3 = src;
                break;

                case FK.VEXDEST4:
                    dst.VEXDEST4 = src;
                break;

                case FK.VEXVALID:
                    dst.VEXVALID = src;
                break;

                case FK.VEX_C4:
                    dst.VEX_C4 = src;
                break;

                case FK.VEX_PREFIX:
                    dst.VEX_PREFIX = src;
                break;

                case FK.VL:
                    dst.VL = src;
                break;

                case FK.WBNOINVD:
                    dst.WBNOINVD = src;
                break;

                case FK.ZEROING:
                    dst.ZEROING = src;
                break;

                case FK.MEM0:
                    dst.MEM0 = src;
                break;

                case FK.MEM1:
                    dst.MEM1 = src;
                break;

                case FK.AGEN:
                    dst.AGEN = src;
                break;

            }
            return ref dst;
        } 
}