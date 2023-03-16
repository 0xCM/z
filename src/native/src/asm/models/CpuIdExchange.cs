//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential)]
    public struct CpuIdExchange
    {
        [Op]
        public static string format(in CpuIdExchange src)
        {
            const string FormatPattern = "fx:{0} subfx:{1} => eax:{2} ebx:{3} ecx:{4} edx:{5}";
            return string.Format(FormatPattern, src.Fx, src.SubFx, src.Eax, src.Ebx, src.Ecx, src.Edx);
        }

        public uint Fx;

        public uint SubFx;

        public uint Eax;

        public uint Ebx;

        public uint Ecx;

        public uint Edx;

        public void Clear()
            => clear(ref this);

        [MethodImpl(Inline)]
        public CpuIdExchange WithRequest(uint fx, uint subfx)
        {
            Fx = fx;
            SubFx = subfx;
            return this;
        }

        [MethodImpl(Inline)]
        public CpuIdExchange WithResponse(in Cell128 src)
            => response(src, ref this);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static ref CpuIdExchange clear(ref CpuIdExchange target)
        {
            @as<CpuIdExchange,ByteBlock24>(target) = ByteBlocks.alloc(n24);
            return ref target;
        }

        [MethodImpl(Inline)]
        public static CpuIdExchange request(uint fx, uint subfx)
        {
            var cpuid = new CpuIdExchange();
            cpuid.Fx = fx;
            cpuid.SubFx = subfx;
            return cpuid;
        }

        [MethodImpl(Inline)]
        public static ref CpuIdExchange response(in Cell128 src, ref CpuIdExchange dst)
        {
            ref var target = ref seek64(@byte(dst),1);
            @as<Cell128>(target) = src;
            return ref dst;
        }
    }
}