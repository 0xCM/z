//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiRuntimeMember : IAddressable, ISequential<ApiRuntimeMember>, IComparable<ApiRuntimeMember>
    {
        public const string TableId ="api.member";

        [Render(8)]
        public uint Seq;

        [Render(16)]
        public PartName Part;

        [Render(12)]
        public EcmaToken Token;

        [Render(16)]
        public MemoryAddress Address;

        [Render(120)]
        public MethodDisplaySig DisplaySig;

        [Render(1)]
        public OpUri Uri;

        [MethodImpl(Inline)]
        public int CompareTo(ApiRuntimeMember src)
            => Address.CompareTo(src.Address);

        MemoryAddress IAddressable.Address
            => Address;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        public static ApiRuntimeMember Empy => default;
    }
}