//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedRules;
using static XedModels;
using static sys;

using K = XedRules.FieldKind;
using R = XedRules;

public class XedFieldParser
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
            result = XedParsers.parse(name, out K kind);
            result.Require();
            dst.Update(pack(value, kind));
            counter++;
        }
        return counter;
    }

    public static void convert(in FieldValue src, out Field dst)
    {
        dst = Field.Empty;
        var kind = src.Field;
        var size = FieldDefs.size(kind, src.CellKind);
        if(size.PackedWidth == 1)
            dst = Field.init(kind, (bit)src.Data);
        else if(size.NativeWidth == 1)
            dst = Field.init(kind, (byte)src.Data);
        else if(size.NativeWidth == 2)
            dst = Field.init(kind, (ushort)src.Data);
        else
            Errors.Throw($"Unsupported size {size}");
    }

    public static uint parse(IReadOnlyDictionary<string,string> src, Span<FieldValue> fields, out XedFieldState state)
    {
        state = parse(src, out Index<K> _);
        var names = src.Keys.Array();
        var count = names.Length;
        for(var i=0; i<count; i++)
        {
            var name = skip(names,i);
            if(XedParsers.parse(name, out K kind))
                seek(fields,i) = parse(src[name], kind, ref state);
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), name));
        }

        update(fields, ref state);
        return (uint)count;
    }

    public static Index<FieldValue> parse(IReadOnlyDictionary<string,string> src, out XedFieldState dst)
    {
        var count = (uint)src.Count;
        var fields = alloc<FieldValue>(count);
        parse(src,fields, out dst);
        return fields;
    }

    public static K kind(string src)
    {
        var i = text.index(src, Chars.Eq);
        var j = text.index(src, Chars.LBracket);
        var k = text.index(src, "!=");
        var result = K.INVALID;

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

    public static XedFieldState parse(IReadOnlyDictionary<string,string> src, out Index<K> fields)
    {
        var parsed = list<K>();
        var failed = dict<K,string>();
        var count = src.Count;
        var dst = XedFieldState.Empty;
        var names = src.Keys.Index();
        for(var i=0; i<count; i++)
        {
            ref readonly var name = ref names[i];
            var kind = K.INVALID;
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
    static FieldValue value(K kind, bit value)
        => new (kind, value);

    [MethodImpl(Inline)]
    static FieldValue value(K kind, byte value)
        => new (kind, value);

    [MethodImpl(Inline)]
    static FieldValue value(K kind, XedRegId value)            
        => new (kind, value);

    [Op]
    public static FieldValue parse(string src, K kind, ref XedFieldState dst)
    {
        var result = true;
        var fieldval = R.FieldValue.Empty;
        switch(kind)
        {
            case K.AMD3DNOW:
                dst.AMD3DNOW = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.ASZ:
                dst.ASZ = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.BASE0:
                result = XedParsers.parse(src, out dst.BASE0);
                fieldval = new(kind, dst.BASE0);
            break;

            case K.BASE1:
                result = XedParsers.parse(src, out dst.BASE1);
                fieldval = new(kind, dst.BASE1);
            break;

            case K.BCAST:
                result = XedParsers.parse(src, out dst.BCAST);
                fieldval = new(kind, (byte)dst.BCAST);
            break;

            case K.BCRC:
                dst.BCRC = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.RELBR:
                dst.RELBR = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.BRDISP_WIDTH:
                result = XedParsers.parse(src, out dst.BRDISP_WIDTH);
                fieldval = new(kind, dst.BRDISP_WIDTH);
            break;

            case K.CET:
                dst.CET = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.CHIP:
                result = XedParsers.parse(src, out dst.CHIP);
                fieldval = new(kind, dst.CHIP);
            break;

            case K.CLDEMOTE:
                dst.CLDEMOTE = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.DEFAULT_SEG:
                result = DataParser.parse(src, out dst.DEFAULT_SEG);
                fieldval = new(kind, dst.DEFAULT_SEG);
            break;

            case K.DF32:
                dst.DF32 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.DF64:
                dst.DF64 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.DISP_WIDTH:
                result = DataParser.parse(src, out dst.DISP_WIDTH);
                fieldval = new(kind, dst.DISP_WIDTH);
            break;

            case K.DUMMY:
                dst.DUMMY = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.EASZ:
                result = DataParser.parse(src, out dst.EASZ);
                fieldval = new(kind, dst.EASZ);
            break;

            case K.ELEMENT_SIZE:
                result = DataParser.parse(src, out dst.ELEMENT_SIZE);
                fieldval = new(kind, dst.ELEMENT_SIZE);
            break;

            case K.ENCODER_PREFERRED:
                dst.ENCODER_PREFERRED = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.ENCODE_FORCE:
                dst.ENCODE_FORCE = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.EOSZ:
                result = DataParser.parse(src, out dst.EOSZ);
                fieldval = new(kind, dst.EOSZ);
            break;

            case K.ESRC:
                result = DataParser.parse(src, out dst.ESRC);
                fieldval = new(kind, dst.ESRC);
            break;

            case K.FIRST_F2F3:
                result = DataParser.parse(src, out dst.FIRST_F2F3);
                fieldval = new(kind, dst.FIRST_F2F3);
            break;

            case K.HAS_MODRM:
                dst.HAS_MODRM = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.HAS_SIB:
                dst.HAS_SIB = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.HINT:
                result = DataParser.parse(src, out dst.HINT);
                fieldval = new(kind, dst.HINT);
            break;

            case K.ICLASS:
                result = DataParser.eparse(src, out dst.ICLASS);
                fieldval = new(kind, dst.ICLASS);
            break;

            case K.ILD_F2:
                dst.ILD_F2 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.ILD_F3:
                dst.ILD_F3 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.ILD_SEG:
                result = DataParser.parse(src, out dst.ILD_SEG);
                fieldval = new(kind, dst.ILD_SEG);
            break;

            case K.IMM0:
                dst.IMM0 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.IMM0SIGNED:
                dst.IMM0SIGNED = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.IMM1:
                dst.IMM1 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.IMM1_BYTES:
                result = DataParser.parse(src, out dst.IMM1_BYTES);
                fieldval = new(kind, dst.IMM1_BYTES);
            break;

            case K.IMM_WIDTH:
                result = DataParser.parse(src, out dst.IMM_WIDTH);
                fieldval = new(kind, dst.IMM_WIDTH);
            break;

            case K.INDEX:
                result = XedParsers.parse(src, out dst.INDEX);
                fieldval = new(kind, dst.INDEX);
            break;

            case K.LAST_F2F3:
                result = DataParser.parse(src, out dst.LAST_F2F3);
                fieldval = new(kind, dst.LAST_F2F3);
            break;

            case K.LLRC:
                result = XedParsers.parse(src, out dst.LLRC);
                fieldval = new(kind, dst.LLRC);
            break;

            case K.LOCK:
                dst.LOCK = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.LZCNT:
                dst.LZCNT = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.MAP:
                result = DataParser.parse(src, out dst.MAP);
                fieldval = new(kind, dst.MAP);
            break;

            case K.MASK:
                result = DataParser.parse(src, out dst.MASK);
                fieldval = new(kind, dst.MASK);
            break;

            case K.MAX_BYTES:
                result = DataParser.parse(src, out dst.MAX_BYTES);
                fieldval = new(kind, dst.MAX_BYTES);
            break;

            case K.MEM_WIDTH:
                result = DataParser.parse(src, out dst.MEM_WIDTH);
                fieldval = new(kind, dst.MEM_WIDTH);
            break;

            case K.MEM0:
                dst.MEM0 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.MEM1:
                dst.MEM1 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.MOD:
                result = XedParsers.parse(src, out dst.MOD);
                fieldval = new(kind, dst.MOD);
            break;

            case K.REG:
                result = XedParsers.parse(src, out dst.REG);
                fieldval = new(kind, dst.REG);
            break;

            case K.MODRM_BYTE:
                result = DataParser.parse(src, out byte modrm);
                dst.MODRM_BYTE = modrm;
                fieldval = new(kind, dst.MODRM_BYTE);
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
                fieldval = new(kind, bit.On);
            break;

            case K.MODE_FIRST_PREFIX:
                dst.MODE_FIRST_PREFIX = bit.On;
                fieldval = new(kind, bit.On);
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
                fieldval = new(kind, bit.On);
            break;

            case K.NEED_MEMDISP:
                result = XedParsers.parse(src, out dst.NEED_MEMDISP);
                fieldval = new(kind, dst.NEED_MEMDISP);
            break;

            case K.NEED_SIB:
                dst.NEED_SIB = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.NELEM:
                result = XedParsers.parse(src, out dst.NELEM);
                fieldval = new(kind, dst.NELEM);
            break;

            case K.NOMINAL_OPCODE:
                result = XedParsers.parse(src, out dst.NOMINAL_OPCODE);
                fieldval = new(kind, dst.NOMINAL_OPCODE);
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
                fieldval = new(kind, dst.POS_DISP);
            break;

            case K.POS_IMM:
                result = DataParser.parse(src, out dst.POS_IMM);
                fieldval = new(kind, dst.POS_IMM);
            break;

            case K.POS_IMM1:
                result = DataParser.parse(src, out dst.POS_IMM1);
                fieldval = new(kind, dst.POS_IMM1);
            break;

            case K.POS_MODRM:
                result = DataParser.parse(src, out dst.POS_MODRM);
                fieldval = new(kind, dst.POS_MODRM);
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
                fieldval = new(kind, dst.REG3);
            break;

            case K.REG4:
                result = XedParsers.parse(src, out dst.REG4);
                fieldval = new(kind, dst.REG4);
            break;

            case K.REG5:
                result = XedParsers.parse(src, out dst.REG5);
                fieldval = new(kind, dst.REG5);
            break;

            case K.REG6:
                result = XedParsers.parse(src, out dst.REG6);
                fieldval = new(kind, dst.REG6);
            break;

            case K.REG7:
                result = XedParsers.parse(src, out dst.REG7);
                fieldval = new(kind, dst.REG7);
            break;

            case K.REG8:
                result = XedParsers.parse(src, out dst.REG8);
                fieldval = new(kind, dst.REG8);
            break;

            case K.REG9:
                result = XedParsers.parse(src, out dst.REG9);
                fieldval = new(kind, dst.REG9);
            break;

            case K.REP:
                result = DataParser.parse(src, out dst.REP);
                fieldval = new(kind, dst.REP);
            break;

            case K.REX:
                dst.REX = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.REXW:
                dst.REXW = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.REXR:
                dst.REXR = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.REXX:
                dst.REXX = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.REXRR:
                dst.REXRR = bit.On;
                fieldval = value(kind, bit.On);
            break;

            case K.REXB:
                dst.REXB = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.RM:
                result = XedParsers.parse(src, out dst.RM);
                fieldval = new(kind, dst.RM);
            break;

            case K.ROUNDC:
                result = DataParser.parse(src, out dst.ROUNDC);
                fieldval = new(kind, dst.ROUNDC);
            break;

            case K.SAE:
                dst.SAE = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.SCALE:
                result = DataParser.parse(src, out dst.SCALE);
                fieldval = new(kind, dst.SCALE);
            break;

            case K.SEG0:
                result = XedParsers.parse(src, out dst.SEG0);
                fieldval = new(kind, dst.SEG0);
            break;

            case K.SEG1:
                result = XedParsers.parse(src, out dst.SEG1);
                fieldval = value(kind, dst.SEG1);
            break;

            case K.SEG_OVD:
                result = DataParser.parse(src, out dst.SEG_OVD);
                fieldval = new(kind, dst.SEG_OVD);
            break;

            case K.SIBBASE:
                result = XedParsers.parse(src, out dst.SIBBASE);
                fieldval = new(kind, dst.SIBBASE);
            break;

            case K.SIBINDEX:
                result = XedParsers.parse(src, out dst.SIBINDEX);
                fieldval = new(kind, dst.SIBINDEX);
            break;

            case K.SIBSCALE:
                result = XedParsers.parse(src, out dst.SIBSCALE);
                fieldval = new(kind, dst.SIBSCALE);
            break;

            case K.SMODE:
                result = DataParser.parse(src, out dst.SMODE);
                fieldval = new(kind, dst.SMODE);
                break;

            case K.SRM:
                result = XedParsers.parse(src, out dst.SRM);
                fieldval = value(kind, dst.SRM);
            break;

            case K.TZCNT:
                dst.TZCNT = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.UBIT:
                dst.UBIT = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.USING_DEFAULT_SEGMENT0:
                dst.USING_DEFAULT_SEGMENT0 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.USING_DEFAULT_SEGMENT1:
                dst.USING_DEFAULT_SEGMENT1 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.VEXDEST210:
                result = XedParsers.parse(src, out dst.VEXDEST210);
                fieldval = new(kind, dst.VEXDEST210);
            break;

            case K.VEXDEST3:
                dst.VEXDEST3 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.VEXDEST4:
                dst.VEXDEST4 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.VEXVALID:
                result = DataParser.parse(src, out dst.VEXVALID);
                fieldval = new(kind, dst.VEXVALID);
            break;

            case K.VEX_C4:
                dst.VEX_C4 = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.VEX_PREFIX:
                result = DataParser.parse(src, out dst.VEX_PREFIX);
                fieldval = new(kind, dst.VEX_PREFIX);
            break;

            case K.VL:
                result = XedParsers.parse(src, out dst.VL);
                fieldval = new(kind, dst.VL);
            break;

            case K.WBNOINVD:
                dst.WBNOINVD = bit.On;
                fieldval = new(kind, bit.On);
            break;

            case K.ZEROING:
                dst.ZEROING = bit.On;
                fieldval = new(kind, bit.On);
            break;
        }

        return fieldval;
    }

    [Op]
    public static XedFieldPack pack(string src, K kind)
    {
        var result = true;
        var dst = XedFieldPack.Empty;
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

    public static ref XedFieldState update(in Fields src, ReadOnlySpan<FieldKind> fields, ref XedFieldState dst)
    {
        var count = fields.Length;
        for(var i=0; i<count; i++)
            update(src[skip(fields,i)], ref dst);
        return ref dst;
    }

    public static ref XedFieldState update(ReadOnlySpan<FieldValue> src, ref XedFieldState dst)
    {
        for(var i=0; i<src.Length; i++)
            update(skip(src,i), ref dst);
        return ref dst;
    }

    public static ref XedFieldState update(in FieldValue src, ref XedFieldState dst)
    {
        var result = Outcome.Success;
        switch(src.Field)
        {
            case K.AMD3DNOW:
                dst.AMD3DNOW = src;
            break;

            case K.ASZ:
                dst.ASZ = src;
            break;

            case K.BASE0:
                dst.BASE0 = src.ToReg();
            break;

            case K.BASE1:
                dst.BASE1 = src.ToReg();
            break;

            case K.BCAST:
                dst.BCAST = (BroadcastKind)src.ToByte();
            break;

            case K.BCRC:
                dst.BCRC = src;
            break;

            case K.RELBR:
                dst.RELBR = src;
            break;

            case K.BRDISP_WIDTH:
                dst.BRDISP_WIDTH = src.ToByte();
            break;

            case K.CET:
                dst.CET = src;
            break;

            case K.CHIP:
                dst.CHIP = src;
            break;

            case K.CLDEMOTE:
                dst.CLDEMOTE = src;
            break;

            case K.DEFAULT_SEG:
                dst.DEFAULT_SEG = src.ToByte();
            break;

            case K.DF32:
                dst.DF32 = src;
            break;

            case K.DF64:
                dst.DF64 = src;
            break;

            case K.DISP:
                dst.DISP = src;
            break;

            case K.DISP_WIDTH:
                dst.DISP_WIDTH = src.ToByte();
            break;

            case K.DUMMY:
                dst.DUMMY = src;
            break;

            case K.EASZ:
                dst.EASZ = src.ToByte();
            break;

            case K.ELEMENT_SIZE:
                dst.ELEMENT_SIZE = src.ToByte();
            break;

            case K.ENCODER_PREFERRED:
                dst.ENCODER_PREFERRED = src;
            break;

            case K.ENCODE_FORCE:
                dst.ENCODE_FORCE = src;
            break;

            case K.EOSZ:
                dst.EOSZ = src.ToByte();
            break;

            case K.ESRC:
                dst.ESRC = src.ToByte();
            break;

            case K.FIRST_F2F3:
                dst.FIRST_F2F3 = src.ToByte();
            break;

            case K.HAS_MODRM:
                dst.HAS_MODRM = src;
            break;

            case K.HAS_SIB:
                dst.HAS_SIB = src;
            break;

            case K.HINT:
                dst.HINT  = src.ToByte();
            break;

            case K.ICLASS:
                dst.ICLASS = src;
            break;

            case K.ILD_F2:
                dst.ILD_F2 = src;
            break;

            case K.ILD_F3:
                dst.ILD_F3 = src;
            break;

            case K.ILD_SEG:
                dst.ILD_SEG = src.ToByte();
            break;

            case K.IMM0:
                dst.IMM0 = src;
            break;

            case K.IMM0SIGNED:
                dst.IMM0SIGNED = src;
            break;

            case K.IMM1:
                dst.IMM1 = src;
            break;

            case K.IMM1_BYTES:
                dst.IMM1_BYTES = src.ToByte();
            break;

            case K.IMM_WIDTH:
                dst.IMM_WIDTH = src.ToByte();
            break;

            case K.INDEX:
                dst.INDEX = src.ToReg();
            break;

            case K.LAST_F2F3:
                dst.LAST_F2F3 = src.ToByte();
            break;

            case K.LLRC:
                dst.LLRC = (LLRC)src.ToByte();
            break;

            case K.LOCK:
                dst.LOCK = src;
            break;

            case K.LZCNT:
                dst.LZCNT = src;
            break;

            case K.MAP:
                dst.MAP = src.ToByte();
            break;

            case K.MASK:
                dst.MASK = src.ToBit();
            break;

            case K.MAX_BYTES:
                dst.MAX_BYTES = src.ToByte();
            break;

            case K.MEM_WIDTH:
                dst.MEM_WIDTH = src.ToByte();
            break;

            case K.MOD:
                dst.MOD = src.ToByte();
            break;

            case K.REG:
                dst.REG = src.ToByte();
            break;

            case K.MODRM_BYTE:
                dst.MODRM_BYTE = src.ToHex8();
            break;

            case K.MODE:
                dst.MODE = src.ToByte();
            break;

            case K.MODEP5:
                dst.MODEP5 = src;
            break;

            case K.MODEP55C:
                dst.MODEP55C = src;
            break;

            case K.MODE_FIRST_PREFIX:
                dst.MODE_FIRST_PREFIX = src;
            break;

            case K.MPXMODE:
                dst.MPXMODE = src;
            break;

            case K.MUST_USE_EVEX:
                dst.MUST_USE_EVEX = src;
            break;

            case K.NEEDREX:
                dst.NEEDREX = src;
            break;

            case K.NEED_MEMDISP:
                dst.NEED_MEMDISP = src.ToByte();
            break;

            case K.NEED_SIB:
                dst.NEED_SIB = src;
            break;

            case K.NELEM:
                dst.NELEM = src.ToWord();
            break;

            case K.NOMINAL_OPCODE:
                dst.NOMINAL_OPCODE = src.ToByte();
            break;

            case K.NOREX:
                dst.NOREX = src;
            break;

            case K.NO_SCALE_DISP8:
                dst.NO_SCALE_DISP8 = src;
            break;

            case K.NPREFIXES:
                dst.NPREFIXES = src.ToByte();
            break;

            case K.NREXES:
                dst.NREXES = src.ToByte();
            break;

            case K.NSEG_PREFIXES:
                dst.NSEG_PREFIXES = src.ToByte();
            break;

            case K.OSZ:
                dst.OSZ = src;
            break;

            case K.OUT_OF_BYTES:
                dst.OUT_OF_BYTES = src;
            break;

            case K.P4:
                dst.P4 = src;
            break;

            case K.POS_DISP:
                dst.POS_DISP = src.ToByte();
            break;

            case K.POS_IMM:
                dst.POS_IMM = src.ToByte();
            break;

            case K.POS_IMM1:
                dst.POS_IMM1 = src.ToByte();
            break;

            case K.POS_MODRM:
                dst.POS_MODRM = src.ToByte();
            break;

            case K.POS_NOMINAL_OPCODE:
                dst.POS_NOMINAL_OPCODE = src.ToByte();
            break;

            case K.POS_SIB:
                dst.POS_SIB = src.ToByte();
            break;

            case K.PREFIX66:
                dst.PREFIX66 = 1;
            break;

            case K.PTR:
                dst.PTR = 1;
            break;

            case K.REALMODE:
                dst.REALMODE = 1;
            break;

            case K.OUTREG:
                dst.OUTREG = src.ToReg();
            break;

            case K.REG0:
                dst.REG0 = src.ToReg();
            break;

            case K.REG1:
                dst.REG1 = src.ToReg();
            break;

            case K.REG2:
                dst.REG2 = src.ToReg();
            break;

            case K.REG3:
                dst.REG3 = src.ToReg();
            break;

            case K.REG4:
                dst.REG4  = src.ToReg();
            break;

            case K.REG5:
                dst.REG5 = src.ToReg();
            break;

            case K.REG6:
                dst.REG6 = src.ToReg();
            break;

            case K.REG7:
                dst.REG7 = src.ToReg();
            break;

            case K.REG8:
                dst.REG8 = src.ToReg();
            break;

            case K.REG9:
                dst.REG9 = src.ToReg();
            break;

            case K.REP:
                dst.REP = src.ToByte();
            break;

            case K.REX:
                dst.REX = src;
            break;

            case K.REXB:
                dst.REXB = src;
            break;

            case K.REXR:
                dst.REXR = src;
            break;

            case K.REXRR:
                dst.REXRR = src;
            break;

            case K.REXW:
                dst.REXW = src;
            break;

            case K.REXX:
                dst.REXX = src;
            break;

            case K.RM:
                dst.RM = src.ToByte();
            break;

            case K.ROUNDC:
                dst.ROUNDC = src.ToByte();
            break;

            case K.SAE:
                dst.SAE = src;
            break;

            case K.SCALE:
                dst.SCALE = src.ToByte();
            break;

            case K.SEG0:
                dst.SEG0 = src.ToReg();
            break;

            case K.SEG1:
                dst.SEG1 = src.ToReg();
            break;

            case K.SEG_OVD:
                dst.SEG_OVD = src.ToByte();
            break;

            case K.SIBBASE:
                dst.SIBBASE = src.ToByte();
            break;

            case K.SIBINDEX:
                dst.SIBINDEX = src.ToByte();
            break;

            case K.SIBSCALE:
                dst.SIBSCALE = src.ToByte();
            break;

            case K.SMODE:
                dst.SMODE = src.ToByte();
                break;

            case K.SRM:
                dst.SRM = src.ToByte();
            break;

            case K.TZCNT:
                dst.TZCNT = src;
            break;

            case K.UBIT:
                dst.UBIT = src;
            break;

            case K.UIMM0:
                dst.UIMM0 = src;
            break;

            case K.UIMM1:
                dst.UIMM1 = src;
            break;

            case K.USING_DEFAULT_SEGMENT0:
                dst.USING_DEFAULT_SEGMENT0 = src;
            break;

            case K.USING_DEFAULT_SEGMENT1:
                dst.USING_DEFAULT_SEGMENT1 = src;
            break;

            case K.VEXDEST210:
                dst.VEXDEST210 = src.ToByte();
            break;

            case K.VEXDEST3:
                dst.VEXDEST3 = src;
            break;

            case K.VEXDEST4:
                dst.VEXDEST4 = src;
            break;

            case K.VEXVALID:
                dst.VEXVALID = src.ToByte();
            break;

            case K.VEX_C4:
                dst.VEX_C4 = src;
            break;

            case K.VEX_PREFIX:
                dst.VEX_PREFIX = src.ToByte();
            break;

            case K.VL:
                dst.VL = src.ToByte();
            break;

            case K.WBNOINVD:
                dst.WBNOINVD = src;
            break;

            case K.ZEROING:
                dst.ZEROING = src;
            break;

            case K.MEM0:
                dst.MEM0 = src;
            break;

            case K.MEM1:
                dst.MEM1 = src;
            break;

            case K.AGEN:
                dst.AGEN = src;
            break;
        }

        return ref dst;
    }

    public static ref XedFieldState update(in Field src, ref XedFieldState dst)
    {
        switch(src.Kind)
        {
            case K.AMD3DNOW:
                dst.AMD3DNOW = src;
            break;

            case K.ASZ:
                dst.ASZ = src;
            break;

            case K.BASE0:
                dst.BASE0 = src;
            break;

            case K.BASE1:
                dst.BASE1 = src;
            break;

            case K.BCAST:
                dst.BCAST = src;
            break;

            case K.BCRC:
                dst.BCRC = src;
            break;

            case K.RELBR:
                dst.RELBR = src;
            break;

            case K.BRDISP_WIDTH:
                dst.BRDISP_WIDTH = src;
            break;

            case K.CET:
                dst.CET = src;
            break;

            case K.CHIP:
                dst.CHIP = src;
            break;

            case K.CLDEMOTE:
                dst.CLDEMOTE = src;
            break;

            case K.DEFAULT_SEG:
                dst.DEFAULT_SEG = src;
            break;

            case K.DF32:
                dst.DF32 = src;
            break;

            case K.DF64:
                dst.DF64 = src;
            break;

            case K.DISP:
                dst.DISP = src;
            break;

            case K.DISP_WIDTH:
                dst.DISP_WIDTH = src;
            break;

            case K.DUMMY:
                dst.DUMMY = src;
            break;

            case K.EASZ:
                dst.EASZ = src;
            break;

            case K.ELEMENT_SIZE:
                dst.ELEMENT_SIZE = src;
            break;

            case K.ENCODER_PREFERRED:
                dst.ENCODER_PREFERRED = src;
            break;

            case K.ENCODE_FORCE:
                dst.ENCODE_FORCE = src;
            break;

            case K.EOSZ:
                dst.EOSZ = src;
            break;

            case K.ESRC:
                dst.ESRC = src;
            break;

            case K.FIRST_F2F3:
                dst.FIRST_F2F3 = src;
            break;

            case K.HAS_MODRM:
                dst.HAS_MODRM = src;
            break;

            case K.HAS_SIB:
                dst.HAS_SIB = src;
            break;

            case K.HINT:
                dst.HINT = src;
            break;

            case K.ICLASS:
                dst.ICLASS = src;
            break;

            case K.ILD_F2:
                dst.ILD_F2 = src;
            break;

            case K.ILD_F3:
                dst.ILD_F3 = src;
            break;

            case K.ILD_SEG:
                dst.ILD_SEG = src;
            break;

            case K.IMM0:
                dst.IMM0 = src;
            break;

            case K.IMM0SIGNED:
                dst.IMM0SIGNED = src;
            break;

            case K.IMM1:
                dst.IMM1 = src;
            break;

            case K.IMM1_BYTES:
                dst.IMM1_BYTES = src;
            break;

            case K.IMM_WIDTH:
                dst.IMM_WIDTH = src;
            break;

            case K.INDEX:
                dst.INDEX = src;
            break;

            case K.LAST_F2F3:
                dst.LAST_F2F3 = src;
            break;

            case K.LLRC:
                dst.LLRC = src;
            break;

            case K.LOCK:
                dst.LOCK = src;
            break;

            case K.LZCNT:
                dst.LZCNT = src;
            break;

            case K.MAP:
                dst.MAP = src;
            break;

            case K.MASK:
                dst.MASK = src;
            break;

            case K.MAX_BYTES:
                dst.MAX_BYTES = src;
            break;

            case K.MEM_WIDTH:
                dst.MEM_WIDTH = src;
            break;

            case K.MOD:
                dst.MOD = src;
            break;

            case K.REG:
                dst.REG = src;
            break;

            case K.MODRM_BYTE:
                dst.MODRM_BYTE = src;
            break;

            case K.MODE:
                dst.MODE = src;
            break;

            case K.MODEP5:
                dst.MODEP5 = src;
            break;

            case K.MODEP55C:
                dst.MODEP55C = src;
            break;

            case K.MODE_FIRST_PREFIX:
                dst.MODE_FIRST_PREFIX = src;
            break;

            case K.MPXMODE:
                dst.MPXMODE = src;
            break;

            case K.MUST_USE_EVEX:
                dst.MUST_USE_EVEX = src;
            break;

            case K.NEEDREX:
                dst.NEEDREX = src;
            break;

            case K.NEED_MEMDISP:
                dst.NEED_MEMDISP = src;
            break;

            case K.NEED_SIB:
                dst.NEED_SIB = src;
            break;

            case K.NELEM:
                dst.NELEM = src;
            break;

            case K.NOMINAL_OPCODE:
                dst.NOMINAL_OPCODE = src;
            break;

            case K.NOREX:
                dst.NOREX = src;
            break;

            case K.NO_SCALE_DISP8:
                dst.NO_SCALE_DISP8 = src;
            break;

            case K.NPREFIXES:
                dst.NPREFIXES = src;
            break;

            case K.NREXES:
                dst.NREXES = src;
            break;

            case K.NSEG_PREFIXES:
                dst.NSEG_PREFIXES = src;
            break;

            case K.OSZ:
                dst.OSZ = src;
            break;

            case K.OUT_OF_BYTES:
                dst.OUT_OF_BYTES = src;
            break;

            case K.P4:
                dst.P4 = src;
            break;

            case K.POS_DISP:
                dst.POS_DISP = src;;
            break;

            case K.POS_IMM:
                dst.POS_IMM = src;
            break;

            case K.POS_IMM1:
                dst.POS_IMM1 = src;
            break;

            case K.POS_MODRM:
                dst.POS_MODRM = src;
            break;

            case K.POS_NOMINAL_OPCODE:
                dst.POS_NOMINAL_OPCODE = src;
            break;

            case K.POS_SIB:
                dst.POS_SIB = src;
            break;

            case K.PREFIX66:
                dst.PREFIX66 = 1;
            break;

            case K.PTR:
                dst.PTR = 1;
            break;

            case K.REALMODE:
                dst.REALMODE = 1;
            break;

            case K.OUTREG:
                dst.OUTREG = src;
            break;

            case K.REG0:
                dst.REG0 = src;
            break;

            case K.REG1:
                dst.REG1 = src;
            break;

            case K.REG2:
                dst.REG2 = src;
            break;

            case K.REG3:
                dst.REG3 = src;
            break;

            case K.REG4:
                dst.REG4 = src;
            break;

            case K.REG5:
                dst.REG5 = src;
            break;

            case K.REG6:
                dst.REG6 = src;
            break;

            case K.REG7:
                dst.REG7 = src;
            break;

            case K.REG8:
                dst.REG8 = src;
            break;

            case K.REG9:
                dst.REG9 = src;
            break;

            case K.REP:
                dst.REP = src;
            break;

            case K.REX:
                dst.REX = src;
            break;

            case K.REXW:
                dst.REXW = src;
            break;

            case K.REXR:
                dst.REXR = src;
            break;

            case K.REXX:
                dst.REXX = src;
            break;

            case K.REXB:
                dst.REXB = src;
            break;

            case K.REXRR:
                dst.REXRR = src;
            break;

            case K.RM:
                dst.RM = src;
            break;

            case K.ROUNDC:
                dst.ROUNDC = src;
            break;

            case K.SAE:
                dst.SAE = src;
            break;

            case K.SCALE:
                dst.SCALE = src;
            break;

            case K.SEG0:
                dst.SEG0 = src;
            break;

            case K.SEG1:
                dst.SEG1 = src;
            break;

            case K.SEG_OVD:
                dst.SEG_OVD = src;
            break;

            case K.SIBBASE:
                dst.SIBBASE = src;
            break;

            case K.SIBINDEX:
                dst.SIBINDEX = src;
            break;

            case K.SIBSCALE:
                dst.SIBSCALE = src;
            break;

            case K.SMODE:
                dst.SMODE = src;
                break;

            case K.SRM:
                dst.SRM = src;
            break;

            case K.TZCNT:
                dst.TZCNT = src;
            break;

            case K.UBIT:
                dst.UBIT = src;
            break;

            case K.UIMM0:
                dst.UIMM0 = src;
            break;

            case K.UIMM1:
                dst.UIMM1 = src;
            break;

            case K.USING_DEFAULT_SEGMENT0:
                dst.USING_DEFAULT_SEGMENT0 = src;
            break;

            case K.USING_DEFAULT_SEGMENT1:
                dst.USING_DEFAULT_SEGMENT1 = src;
            break;

            case K.VEXDEST210:
                dst.VEXDEST210 = src;
            break;

            case K.VEXDEST3:
                dst.VEXDEST3 = src;
            break;

            case K.VEXDEST4:
                dst.VEXDEST4 = src;
            break;

            case K.VEXVALID:
                dst.VEXVALID = src;
            break;

            case K.VEX_C4:
                dst.VEX_C4 = src;
            break;

            case K.VEX_PREFIX:
                dst.VEX_PREFIX = src;
            break;

            case K.VL:
                dst.VL = src;
            break;

            case K.WBNOINVD:
                dst.WBNOINVD = src;
            break;

            case K.ZEROING:
                dst.ZEROING = src;
            break;

            case K.MEM0:
                dst.MEM0 = src;
            break;

            case K.MEM1:
                dst.MEM1 = src;
            break;

            case K.AGEN:
                dst.AGEN = src;
            break;

        }
        return ref dst;
    } 
}

