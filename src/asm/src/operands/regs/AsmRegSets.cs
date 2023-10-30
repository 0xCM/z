//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using System.IO;

using static sys;
using static RegFacets;
using static RegClassCode;
using static AsmRegBits;

using SZ = NativeSizeCode;

[ApiComplete]
public class AsmRegSets
{
    public static AsmRegSets create()
        => Instance;

    AsmRegSets()
    {

    }

    Span<char> Buffer()
        => _Buffer.Clear();

    public uint Emit(in AsciGrid src, StreamWriter dst)
    {
        var count = src.RowCount;
        for(byte i=0; i<count; i++)
            dst.WriteLine(AsciSymbols.format(src.Row(i), Buffer()));
        return (uint)count;
    }

    public static RegNameSet RegNames(RegClassCode @class, NativeSize? size = null)
    {
        var names = Asm.RegNameSet.Empty;
        switch(@class)
        {
            case GP:
                if(size == null)
                    names = GpRegNames();
                else
                    names = GpRegNames(size.Value);
            break;
            case XMM:
                names = XmmRegNames();
            break;
            case YMM:
                names = YmmRegNames();
            break;
            case ZMM:
                names = ZmmRegNames();
            break;
            case MASK:
                names = MaskRegNames();
            break;
            case BND:
                names = BndRegNames();
            break;
            case MMX:
                names = MmxRegNames();
            break;
            case SEG:
                names = SegRegNames();
            break;
            case CR:
                names = CrRegNames();
            break;
            case DB:
                names = DbRegNames();
            break;

        }
        return names;
    }

    public static RegOpSeq Regs(RegClassCode @class, NativeSize? size = null)
    {
        var regs = RegOpSeq.Empty;
        switch(@class)
        {
            case RegClassCode.GP:
                if(size == null)
                    regs = GpRegs();
                else
                    regs = GpRegs(size.Value);
            break;
            case RegClassCode.XMM:
                regs = XmmRegs();
            break;
            case RegClassCode.YMM:
                regs = YmmRegs();
            break;
            case RegClassCode.ZMM:
                regs = ZmmRegs();
            break;
            case RegClassCode.MASK:
                regs = MaskRegs();
            break;
            case RegClassCode.MMX:
                regs = MmxRegs();
            break;
            case RegClassCode.SEG:
                regs = SegRegs();
            break;
            case RegClassCode.BND:
                regs = BndRegs();
            break;
            case RegClassCode.CR:
                regs = CrRegs();
            break;
            case RegClassCode.DB:
                regs = DbRegs();
            break;
        }
        return regs;
    }

    public static RegOpSeq GpRegs()
    {
        return data(nameof(GpRegs), Load);

        RegOpSeq Load()
        {
            var gp8 = Gp8Regs();
            var gp16 = Gp16Regs();
            var gp32 = Gp32Regs();
            var gp64 = Gp64Regs();
            return gp8.Concat(gp16, gp32, gp64);
        }
    }

    public static RegOpSeq XmmRegs()
        => data(nameof(XmmRegs), () => RegSeq(XmmRegSize, XMM, XmmRegCount));

    public static RegOpSeq YmmRegs()
        => data(nameof(XmmRegs), () => RegSeq(YmmRegSize, YMM, YmmRegCount));

    public static RegOpSeq ZmmRegs()
        => data(nameof(ZmmRegs), () => RegSeq(ZmmRegSize, ZMM, ZmmRegCount));

    public static RegOpSeq Gp8Regs()
    {
        return data(nameof(Gp8Regs), Load);

        RegOpSeq Load()
        {
            var count = Gp8RegCount;
            var buffer = alloc<RegOp>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = reg(Gp8RegSize, GpRegClass, (RegIndexCode)i);
            return buffer;
        }
    }

    public static RegOpSeq Gp16Regs()
    {
        return data(nameof(Gp16Regs), Load);

        RegOpSeq Load()
        {
            const byte Count = Gp16RegCount;
            var buffer = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(buffer,i) = reg(Gp16RegSize, GpRegClass, (RegIndexCode)i);
            return buffer;
        }
    }

    public static RegOpSeq Gp32Regs()
    {
        return data(nameof(Gp32Regs), Load);

        RegOpSeq Load()
        {
            const byte Count = Gp32RegCount;
            var buffer = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(buffer,i) = reg(Gp32RegSize, GpRegClass, (RegIndexCode)i);
            return buffer;
        }
    }

    public static RegOpSeq Gp64Regs()
    {
        return data(nameof(Gp64Regs), Load);

        RegOpSeq Load()
        {
            const byte Count = Gp64RegCount;
            var buffer = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(buffer,i) = reg(Gp64RegSize, GpRegClass, (RegIndexCode)i);
            return buffer;
        }
    }

    public static RegOpSeq GpRegs(NativeSizeCode width)
    {
        var dst = RegOpSeq.Empty;
        switch(width)
        {
            case Gp8RegSize:
                dst = Gp8Regs();
            break;
            case Gp16RegSize:
                dst = Gp16Regs();
            break;
            case Gp32RegSize:
                dst = Gp32Regs();
            break;
            case Gp64RegSize:
                dst = Gp64Regs();
            break;
        }
        return dst;
    }

    public static RegNameSet GpRegNames(NativeSizeCode width)
    {
        var dst = Asm.RegNameSet.Empty;
        switch(width)
        {
            case Gp8RegSize:
                dst = Gp8RegNames();
            break;
            case Gp16RegSize:
                dst = Gp16RegNames();
            break;
            case Gp32RegSize:
                dst = Gp32RegNames();
            break;
            case Gp64RegSize:
                dst = Gp64RegNames();
            break;
        }
        return dst;
    }

    public static RegOpSeq MaskRegs()
    {
        return data(nameof(MaskRegs), Load);

        RegOpSeq Load()
        {
            const byte Count = MaskRegCount;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = reg(MaskRegSize, MaskRegClass, (RegIndexCode)i);
            return dst;
        }
    }

    public static RegOpSeq CrRegs()
    {
        return data(nameof(CrRegs), Load);

        RegOpSeq Load()
        {
            const byte Count = CrRegCount;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = reg(CrRegSize, CrRegClass, (RegIndexCode)i);
            return dst;
        }
    }

    public static RegOpSeq DbRegs()
    {
        return data(nameof(DbRegs), Load);

        RegOpSeq Load()
        {
            const byte Count = DbRegCount;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = reg(DbRegSize, DbRegClass, (RegIndexCode)i);
            return dst;
        }
    }

    public static RegOpSeq MmxRegs()
    {
        return data(nameof(MmxRegs), Load);

        RegOpSeq Load()
        {
            const byte Count = MmxRegCount;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = reg(MmxRegSize, MmxRegClass, (RegIndexCode)i);
            return dst;
        }
    }

    public static RegOpSeq TmmRegs()
    {
        return data(nameof(TmmRegs), Load);

        RegOpSeq Load()
        {
            const byte Count = TmmRegCount;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = reg(MmxRegSize, TmmRegClass, (RegIndexCode)i);
            return dst;
        }
    }

    public static RegOpSeq BndRegs()
    {
        return data(nameof(BndRegs), Load);

        RegOpSeq Load()
        {
            const byte Count = BndRegCount;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = reg(BndRegSize, RegClassCode.BND, (RegIndexCode)i);
            return dst;
        }
    }

    public static RegOpSeq SegRegs()
    {
        return data(nameof(SegRegs), Load);
        RegOpSeq Load()
        {
            const byte Count = SegRegCount;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = reg(SZ.W16, RegClassCode.SEG, (RegIndexCode)i);
            return dst;
        }
    }

    public static RegOpSeq FpuRegs()
    {
        return data(nameof(FpuRegs), Load);
        RegOpSeq Load()
        {
            const byte Count = FpuRegCount;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = reg(FpuRegSize, FpuRegClass, (RegIndexCode)i);
            return dst;
        }
    }

    public static RegNameSet GpRegNames()
        => data(nameof(GpRegNames), () => Names(GpRegClass, GpRegs()));

    public static RegNameSet Gp8RegNames()
        => data(nameof(Gp8RegNames), () => Names("Gp8", Gp8Regs()));

    public static RegNameSet Gp16RegNames()
        => data(nameof(Gp16RegNames), () => Names("Gp16", Gp16Regs()));

    public static RegNameSet Gp32RegNames()
        => data(nameof(Gp32RegNames), () => Names("Gp32", Gp32Regs()));

    public static RegNameSet Gp64RegNames()
        => data(nameof(Gp64RegNames), () => Names("Gp64",Gp64Regs()));

    public static RegNameSet XmmRegNames()
        => data(nameof(XmmRegNames), () => Names(XmmRegClass, XmmRegs()));

    public static RegNameSet YmmRegNames()
        => data(nameof(YmmRegNames), () => Names(YmmRegClass, YmmRegs()));

    public static RegNameSet ZmmRegNames()
        => data(nameof(ZmmRegNames), () => Names(ZmmRegClass, ZmmRegs()));

    public static RegNameSet MaskRegNames()
        => data(nameof(MaskRegNames), () => Names(MaskRegClass, MaskRegs()));

    public static RegNameSet MmxRegNames()
        => data(nameof(MmxRegNames), () => Names(MmxRegClass, MmxRegs()));

    public static RegNameSet SegRegNames()
        => data(nameof(SegRegNames), () => Names(SegRegClass, SegRegs()));

    public static RegNameSet BndRegNames()
        => data(nameof(BndRegNames), () => Names(BndRegClass, BndRegs()));

    public static RegNameSet CrRegNames()
        => data(nameof(CrRegNames), () => Names(CrRegClass, CrRegs()));

    public static RegNameSet DbRegNames()
        => data(nameof(DbRegNames), () => Names(DbRegClass, DbRegs()));

    public static RegNameSet FpuRegNames()
        => data(nameof(FpuRegNames), () => Names(FpuRegClass,FpuRegs()));

    static RegOpSeq RegSeq(NativeSizeCode size, RegClassCode @class, byte count)
    {
        var dst = alloc<RegOp>(count);
        for(var i=0; i<count; i++)
            seek(dst,i) = reg(size, @class, (RegIndexCode)i);
        return dst;
    }

    static RegNameSet Names(RegClassCode @class, RegOpSeq src)
    {
        var count = src.Count;
        var buffer = alloc<AsmRegName>(count);
        for(var i=0; i<count; i++)
            seek(buffer,i) = src[i].Name;
        return (format(@class), buffer);
    }

    static RegNameSet Names(string name, RegOpSeq src)
    {
        var count = src.Count;
        var buffer = alloc<AsmRegName>(count);
        for(var i=0; i<count; i++)
            seek(buffer,i) = src[i].Name;
        return (name,buffer);
    }

    readonly Index<char> _Buffer = alloc<char>(256);

    static ConcurrentDictionary<string,object> _Data {get;}
        = new();

    [MethodImpl(Inline)]
    protected static D data<D>(string key, Func<D> factory)
        => (D)_Data.GetOrAdd(key, k => factory());

    static AsmRegSets Instance = new();

    [MethodImpl(Inline)]
    static string format(RegClassCode src)
        => RegClassFormatter.Format(src);

    static EnumRender<RegClassCode> RegClassFormatter = new();
}
