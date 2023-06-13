//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using CC = RegClassCode;

    public readonly struct RegClasses
    {
        public static GpClass Gp => default;

        public static GP8HiClass Gp8Hi => default;

        public static SegClass Seg => default;

        public static FlagClass Flag => default;

        public static MaskClass KReg => default;

        public static CrClass Cr => default;

        public static TrClass Tr => default;

        public static XCrClass XCr => default;

        public static DbClass Db => default;

        public static XmmClass Xmm => default;

        public static YmmClass Ymm => default;

        public static ZmmClass Zmm => default;

        public static IPtrClass IP => default;

        public static SPtrClass SP => default;

        public static BndClass Bnd => default;

        public static StClass St => default;

        public static MmxClass Mmx => default;

        public readonly struct GP8HiClass : IRegClass<GP8HiClass>
        {
            public CC Kind => CC.GP8HI;

            public asci8 Name => nameof(CC.GP8HI);

            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 2;
                const string Data = "ahchdhbh";
                var i0 = ((byte)index - 4)*RegLength;
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }
        }

        public readonly struct GpClass : IRegClass<GpClass>
        {
            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index, NativeSizeCode size)
            {
                const byte RegLength = 4;
                const string R0 = "rax eax ax  al  ";
                const string R1 = "rcx ecx cx  cl  ";
                const string R2 = "rdx edx dx  dl  ";
                const string R3 = "rbx ebx bx  bl  ";
                const string R4 = "rsp esp sp  spl ";
                const string R5 = "rbp ebp bp  bpl ";
                const string R6 = "rsi esi si  sil ";
                const string R7 = "rdi edi di  dil ";
                const string R8 = "r8  r8d r8w r8b ";
                const string R9 = "r9  r9d r9w r9b ";
                const string R10 = "r10 r10dr10wr10b";
                const string R11 = "r11 r11dr11wr11b";
                const string R12 = "r12 r12dr12wr12b";
                const string R13 = "r13 r13dr13wr13b";
                const string R14 = "r14 r14dr14wr14b";
                const string R15 = "r15 r15dr15wr15b";
                const string Data = R0 + R1 + R2 + R3 + R4 + R5 + R6 + R7 + R8 + R9 + R10 + R11 + R12 + R13 + R14 + R15;
                var data = 0ul;
                var i0 = offset(index, size);
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            [MethodImpl(Inline), Op]
            static ushort offset(RegIndexCode index, NativeSizeCode size)
            {
                const byte RegLength = 4;
                const byte RowLength = 4*RegLength;
                var row = (uint)((uint)index*RowLength);
                var col = z32;
                if(size == NativeSizeCode.W64)
                    col = 0;
                else if(size == NativeSizeCode.W32)
                    col = 4;
                else if(size == NativeSizeCode.W16)
                    col = 8;
                else
                    col = 12;

                return (ushort)(row + col);
            }

            public CC Kind => CC.GP;

            public asci8 Name => nameof(CC.GP);

            public static implicit operator CC(GpClass src)
                => src.Kind;
        }

        public readonly struct SegClass : IRegClass<SegClass>
        {
            public CC Kind => CC.SEG;

            public asci8 Name => nameof(CC.SEG);

            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 2;
                const string Data = "csdsssesfsgs";
                var i0 = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            public static implicit operator CC(SegClass src)
                => src.Kind;
        }

        public readonly struct FlagClass : IRegClass<FlagClass>
        {
            public CC Kind => CC.FLAG;

            public asci8 Name => nameof(CC.FLAG);

            [MethodImpl(Inline), Op]
            public AsmRegName RegName(NativeSize size)
            {
                const byte RegLength = 6;
                const string Data = "flags eflagsrflags";
                var offset = 12;
                if(size == NativeSizeCode.W32)
                    offset = 6;
                else if(size == NativeSizeCode.W16)
                    offset = 0;
                return new asci8(slice(text.chars(Data), offset, RegLength));
            }

            public static implicit operator CC(FlagClass src)
                => src.Kind;
        }

        public readonly struct CrClass : IRegClass<CrClass>
        {
            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 3;
                const string Data = "cr0cr1cr2cr3cr4cr5cr6cr7";
                var offset = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), offset, RegLength));
            }

            public CC Kind => CC.CR;

            public asci8 Name => nameof(CC.CR);

            public static implicit operator CC(CrClass src)
                => src.Kind;
        }

        public readonly struct TrClass : IRegClass<TrClass>
        {
            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 3;
                const string Data = "tr0tr1tr2tr3tr4tr5tr6tr7";
                var offset = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), offset, RegLength));
            }

            public CC Kind => CC.TR;

            public asci8 Name => nameof(CC.TR);

            public static implicit operator CC(TrClass src)
                => src.Kind;
        }

        public readonly struct DbClass : IRegClass<DbClass>
        {
            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 3;
                const string Data = "db0db1db2db3db4db5db6db7";
                var offset = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), offset, RegLength));
            }

            public CC Kind => CC.DB;

            public asci8 Name => nameof(CC.DB);

            public static implicit operator CC(DbClass src)
                => src.Kind;
        }

        public readonly struct IPtrClass : IRegClass<IPtrClass>
        {
            public CC Kind => CC.IPTR;

            public asci8 Name => nameof(CC.IPTR);

            [MethodImpl(Inline), Op]
            public AsmRegName RegName(NativeSize size)
            {
                const byte RegLength = 3;
                const string Data = "ip eiprip";
                var offset = 6;
                if(size == NativeSizeCode.W32)
                    offset = 3;
                else if(size == NativeSizeCode.W16)
                    offset = 0;
                return new asci8(slice(text.chars(Data), offset, RegLength));
            }

            public static implicit operator CC(IPtrClass src)
                => src.Kind;
        }

        public readonly struct SPtrClass : IRegClass<SPtrClass>
        {
            public CC Kind => CC.SPTR;

            public asci8 Name => nameof(CC.SPTR);

            public static implicit operator CC(SPtrClass src)
                => src.Kind;
        }

        public readonly struct XmmClass : IRegClass<XmmClass>
        {
            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 5;
                const string Data = "xmm0 xmm1 xmm2 xmm3 xmm4 xmm5 xmm6 xmm7 xmm8 xmm9 xmm10xmm11xmm12xmm13xmm14xmm15xmm16xmm17xmm18xmm19xmm20xmm21xmm22xmm23xmm24xmm25xmm26xmm27xmm28xmm29xmm30xmm31";
                var i0 = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            public CC Kind => CC.XMM;


            public asci8 Name => nameof(CC.XMM);

            public static implicit operator CC(XmmClass src)
                => src.Kind;

        }

        public readonly struct YmmClass : IRegClass<YmmClass>
        {

            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 5;
                const string Data = "ymm0 ymm1 ymm2 ymm3 ymm4 ymm5 ymm6 ymm7 ymm8 ymm9 ymm10ymm11ymm12ymm13ymm14ymm15ymm16ymm17ymm18ymm19ymm20ymm21ymm22ymm23ymm24ymm25ymm26ymm27ymm28ymm29ymm30ymm31";
                var i0 = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            public CC Kind => CC.YMM;

            public asci8 Name => nameof(CC.YMM);

            public static implicit operator CC(YmmClass src)
                => src.Kind;
        }

        public readonly struct ZmmClass : IRegClass<ZmmClass>
        {
            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 5;
                const string Data = "zmm0 zmm1 zmm2 zmm3 zmm4 zmm5 zmm6 zmm7 zmm8 zmm9 zmm10zmm11zmm12zmm13zmm14zmm15zmm16zmm17zmm18zmm19zmm20zmm21zmm22zmm23zmm24zmm25zmm26zmm27zmm28zmm29zmm30zmm31";
                var i0 = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            public CC Kind => CC.ZMM;

            public asci8 Name => nameof(CC.ZMM);

            public static implicit operator CC(ZmmClass src)
                => src.Kind;
        }

        public readonly struct MaskClass : IRegClass<MaskClass>
        {

            public CC Kind => CC.MASK;

            public asci8 Name => nameof(CC.MASK);

            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 2;
                const string Data = "k0k1k2k3k4k5k6k7";
                var i0 = (ushort)((uint)index*RegLength);
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            public static implicit operator CC(MaskClass src)
                => src.Kind;
        }

        public readonly struct BndClass : IRegClass<BndClass>
        {
            public CC Kind => CC.BND;

            public asci8 Name => nameof(CC.BND);

            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 4;
                const string Data = "bnd0bnd1bnd2bnd3";
                var i0 = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            public static implicit operator CC(BndClass src)
                => src.Kind;
        }

        public readonly struct StClass : IRegClass<StClass>
        {
            public CC Kind => CC.ST;

            public asci8 Name => nameof(CC.ST);

            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 3;
                const string Data = "st0st1st2st3st4st5st6st7";
                var i0 = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            public static implicit operator CC(StClass src)
                => src.Kind;
        }

        public readonly struct MmxClass : IRegClass<MmxClass>
        {
            [MethodImpl(Inline), Op]
            public AsmRegName RegName(RegIndexCode index)
            {
                const byte RegLength = 3;
                const string Data = "mm0mm1mm2mm3mm4mm5mm6mm7";
                var i0 = (uint)index*RegLength;
                return new asci8(slice(text.chars(Data), i0, RegLength));
            }

            public CC Kind => CC.MMX;

            public asci8 Name => nameof(CC.MMX);

            public static implicit operator CC(MmxClass src)
                => src.Kind;
        }

        public readonly struct XCrClass : IRegClass<XCrClass>
        {
            public CC Kind => CC.XCR;

            public asci8 Name => nameof(CC.XCR);

            public static implicit operator CC(XCrClass src)
                => src.Kind;
        }
    }
}