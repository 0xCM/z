//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
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
                dst.WriteLine(Asci.format(src.Row(i), Buffer()));
            return (uint)count;
        }

        public RegNameSet RegNames(RegClassCode @class, NativeSize? size = null)
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
                break;
                case MMX:
                    names = MmxRegNames();
                break;
                case SEG:
                    names = SegRegNames();
                break;
                case RegClassCode.CR:
                break;
                case RegClassCode.DB:
                break;

            }
            return names;
        }

        public RegOpSeq Regs(RegClassCode @class, NativeSize? size = null)
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
                case RegClassCode.GP8HI:
                    regs = Gp8HiRegs();
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

        public RegOpSeq GpRegs()
        {
            return Data(nameof(GpRegs), Load);

            RegOpSeq Load()
            {
                var gp8 = Gp8Regs();
                var gp16 = Gp16Regs();
                var gp32 = Gp32Regs();
                var gp64 = Gp64Regs();
                return gp8.Concat(gp16, gp32, gp64);
            }
        }

        public RegOpSeq XmmRegs()
            => Data(nameof(XmmRegs), () => RegSeq(XmmRegSize, XMM, XmmRegCount));

        public RegOpSeq YmmRegs()
            => Data(nameof(XmmRegs), () => RegSeq(YmmRegSize, YMM, YmmRegCount));

        public RegOpSeq ZmmRegs()
            => Data(nameof(ZmmRegs), () => RegSeq(ZmmRegSize, ZMM, ZmmRegCount));

        public RegOpSeq Gp8HiRegs()
        {
            return Data(nameof(Gp8HiRegs), Load);

            RegOpSeq Load()
            {
                var count = Gp8HiRegCount;
                var buffer = alloc<RegOp>(count);
                for(byte i=0,j=4; i<count; i++,j++)
                    seek(buffer,i) = reg(Gp8RegSize, GP8HI, (RegIndexCode)j);
                return buffer;
            }
        }

        public RegOpSeq Gp8LoRegs()
        {
            return Data(nameof(Gp8LoRegs), Load);

            RegOpSeq Load()
            {
                var count = Gp8LoRegCount;
                var buffer = alloc<RegOp>(count);
                for(var i=0; i<count; i++)
                    seek(buffer,i) = reg(Gp8RegSize, GP, (RegIndexCode)i);
                return buffer;
            }
        }

        public RegOpSeq Gp8Regs()
        {
            return Data(nameof(Gp8Regs), Load);

            RegOpSeq Load()
            {
                var count = Gp8RegCount;
                var buffer = alloc<RegOp>(count);
                for(var i=0; i<16; i++)
                    seek(buffer,i) = reg(Gp8RegSize, GpRegClass, (RegIndexCode)i);
                for(byte i=16,j=4; i<20; i++,j++)
                    seek(buffer,i) = reg(Gp8RegSize, GP8HI, (RegIndexCode)j);
                return buffer;
            }
        }

        public RegOpSeq Gp16Regs()
        {
            return Data(nameof(Gp16Regs), Load);

            RegOpSeq Load()
            {
                const byte Count = Gp16RegCount;
                var buffer = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(buffer,i) = reg(Gp16RegSize, GpRegClass, (RegIndexCode)i);
                return buffer;
            }
        }

        public RegOpSeq Gp32Regs()
        {
            return Data(nameof(Gp32Regs), Load);

            RegOpSeq Load()
            {
                const byte Count = Gp32RegCount;
                var buffer = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(buffer,i) = reg(Gp32RegSize, GpRegClass, (RegIndexCode)i);
                return buffer;
            }
        }

        public RegOpSeq Gp64Regs()
        {
            return Data(nameof(Gp64Regs), Load);

            RegOpSeq Load()
            {
                const byte Count = Gp64RegCount;
                var buffer = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(buffer,i) = reg(Gp64RegSize, GpRegClass, (RegIndexCode)i);
                return buffer;
            }
        }

        public RegOpSeq GpRegs(NativeSizeCode width)
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

        public RegNameSet GpRegNames(NativeSizeCode width)
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

        public RegOpSeq MaskRegs()
        {
            return Data(nameof(MaskRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = MaskRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = reg(MaskRegSize, MaskRegClass, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq CrRegs()
        {
            return Data(nameof(CrRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = CrRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = reg(CrRegSize, CrRegClass, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq DbRegs()
        {
            return Data(nameof(DbRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = DbRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = reg(DbRegSize, DbRegClass, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq MmxRegs()
        {
            return Data(nameof(MmxRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = MmxRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = reg(MmxRegSize, MmxRegClass, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq TmmRegs()
        {
            return Data(nameof(TmmRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = TmmRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = reg(MmxRegSize, TmmRegClass, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq BndRegs()
        {
            return Data(nameof(BndRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = BndRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = reg(BndRegSize, RegClassCode.BND, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq SegRegs()
        {
            return Data(nameof(SegRegs), Load);
            RegOpSeq Load()
            {
                const byte Count = SegRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = reg(SZ.W16, RegClassCode.SEG, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq FpuRegs()
        {
            return Data(nameof(FpuRegs), Load);
            RegOpSeq Load()
            {
                const byte Count = FpuRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = reg(FpuRegSize, FpuRegClass, (RegIndexCode)i);
                return dst;
            }
        }

        public RegNameSet GpRegNames()
            => Data(nameof(GpRegNames), () => Names(GpRegClass, GpRegs()));

        public RegNameSet Gp8RegNames()
            => Data(nameof(Gp8RegNames), () => Names("Gp8", Gp8Regs()));

        public RegNameSet Gp16RegNames()
            => Data(nameof(Gp16RegNames), () => Names("Gp16", Gp16Regs()));

        public RegNameSet Gp32RegNames()
            => Data(nameof(Gp32RegNames), () => Names("Gp32", Gp32Regs()));

        public RegNameSet Gp64RegNames()
            => Data(nameof(Gp64RegNames), () => Names("Gp64",Gp64Regs()));

        public RegNameSet XmmRegNames()
            => Data(nameof(XmmRegNames), () => Names(XmmRegClass, XmmRegs()));

        public RegNameSet YmmRegNames()
            => Data(nameof(YmmRegNames), () => Names(YmmRegClass, YmmRegs()));

        public RegNameSet ZmmRegNames()
            => Data(nameof(ZmmRegNames), () => Names(ZmmRegClass, ZmmRegs()));

        public RegNameSet MaskRegNames()
            => Data(nameof(MaskRegNames), () => Names(MaskRegClass, MaskRegs()));

        public RegNameSet MmxRegNames()
            => Data(nameof(MmxRegNames), () => Names(MmxRegClass, MmxRegs()));

        public RegNameSet SegRegNames()
            => Data(nameof(SegRegNames), () => Names(SegRegClass, SegRegs()));

        public RegNameSet BndRegNames()
            => Data(nameof(BndRegNames), () => Names(BndRegClass, BndRegs()));

        public RegNameSet CrRegNames()
            => Data(nameof(CrRegNames), () => Names(CrRegClass, CrRegs()));

        public RegNameSet DbRegNames()
            => Data(nameof(DbRegNames), () => Names(DbRegClass, DbRegs()));

        public RegNameSet FpuRegNames()
            => Data(nameof(FpuRegNames), () => Names(FpuRegClass,FpuRegs()));

        RegOpSeq RegSeq(NativeSizeCode size, RegClassCode @class, byte count)
        {
            var dst = alloc<RegOp>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = reg(size, @class, (RegIndexCode)i);
            return dst;
        }


        RegNameSet Names(RegClassCode @class, RegOpSeq src)
        {
            var count = src.Count;
            var buffer = alloc<AsmRegName>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = src[i].Name;
            return (format(@class), buffer);
        }

        RegNameSet Names(string name, RegOpSeq src)
        {
            var count = src.Count;
            var buffer = alloc<AsmRegName>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = src[i].Name;
            return (name,buffer);
        }

        readonly Index<char> _Buffer = alloc<char>(256);

        ConcurrentDictionary<string,object> _Data {get;}
            = new();

        [MethodImpl(Inline)]
        protected D Data<D>(string key, Func<D> factory)
            => (D)_Data.GetOrAdd(key, k => factory());

        [MethodImpl(Inline)]
        protected void ClearCache()
            => _Data.Clear();

        static AsmRegSets Instance = new();

        [MethodImpl(Inline)]
        static string format(RegClassCode src)
            => RegClassFormatter.Format(src);

        static EnumRender<RegClassCode> RegClassFormatter = new();
    }
}