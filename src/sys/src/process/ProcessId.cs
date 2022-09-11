//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ProcessId : IDataType<ProcessId>, IDataString
    {
        public readonly int Value;

        public ProcessId()
        {
            Value = 0;
        }

        [MethodImpl(Inline)]
        public ProcessId(int value)
        {
            Value = value;
        }
        
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(ProcessId src)
            => Value.CompareTo(src.Value);

        public string Format()
            => $"{Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ProcessId(int value)
            => new (value);

        public static ProcessId Empty => default;
    }
}