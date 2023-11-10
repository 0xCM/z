//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static XedRules;
using static sys;

using K = XedRules.FieldKind;
using R = XedRules;

partial class XedFields
{
    [MethodImpl(Inline)]
    static FieldValue value(K kind, bit value)
        => new (kind, value);

    [MethodImpl(Inline)]
    static FieldValue value(K kind, byte value)
        => new (kind, value);

    [MethodImpl(Inline)]
    static FieldValue value(K kind, XedRegId value)            
        => new (kind, value);

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

        XedFields.update(fields, ref state);
        return (uint)count;
    }

    public static Index<FieldValue> parse(IReadOnlyDictionary<string,string> src, out XedFieldState dst)
    {
        var count = (uint)src.Count;
        var fields = alloc<FieldValue>(count);
        parse(src,fields, out dst);
        return fields;
    }

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

}