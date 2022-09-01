//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost, StructLayout(LayoutKind.Sequential)]
    public readonly struct CpuPorts
    {
        [MethodImpl(Inline), Op]
        public static CpuPorts range(Address16 min, Address16 max)
            => new CpuPorts(min, max);

        readonly Address16 Min;

        readonly Address16 Max;

        public ushort Count {get;}

        readonly ushort Data;

        [MethodImpl(Inline)]
        CpuPorts(Address16 min, Address16 max)
        {
            Min = min;
            Max = max;
            Count = max - min;
            Data = 0;
        }

        [MethodImpl(Inline), Op]
        public CpuPort Port(ushort index)
            => index < Count ? Min + index : CpuPort.Empty;

        [MethodImpl(Inline), Op]
        public CpuPort<ushort> Port(W16 w, ushort index)
            => new CpuPort<ushort>(Port(index).Address);

        [MethodImpl(Inline), Op]
        public CpuPort<uint> Port(W32 w, ushort index)
            => new CpuPort<uint>(Port(index).Address);
    }
}