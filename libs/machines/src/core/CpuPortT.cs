//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CpuPort<T>
        where T : unmanaged
    {
        public Address16 Address {get;}

        readonly ushort Data;

        [MethodImpl(Inline)]
        public CpuPort(Address16 address)
        {
            Address = address;
            Data = 0xFFFF;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public DataWidth Width
        {
            [MethodImpl(Inline)]
            get => core.width<T>();
        }

        public string Format()
            => string.Format("w{0:D2}:{1}", (ushort)Width, Address.Format());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CpuPort<T>(Address16 src)
            => new CpuPort<T>(src);

        public static CpuPort<T> Empty => default;
    }
}