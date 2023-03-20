//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EcmaMvid : IDataType<EcmaMvid>, IDataString
    {
        public readonly Guid Value;

        public EcmaMvid(Guid value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == Guid.Empty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != Guid.Empty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.nhash(Value);
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(EcmaMvid src)
            => Value == src.Value;

        public int CompareTo(EcmaMvid src)
            => sys.bytes(Value).SequenceCompareTo(sys.bytes(src.Value));

        public string Format()
            => sys.bytes(Value).FormatHex();

        public override string ToString()
            => Format();
            
        [MethodImpl(Inline)]
        public static implicit operator EcmaMvid(Guid src)
            => new EcmaMvid(src);
        
        public static EcmaMvid Empty => new EcmaMvid(Guid.Empty);
    }
}