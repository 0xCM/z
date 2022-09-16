//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct ProcessId : IDataType<ProcessId>, IDataString
    {
        public static void parse(CmdArgs src, ConcurrentBag<ProcessId> dst)
        {
            iter(src, arg => {
                if(parse(arg.Value, out ProcessId id))
                    dst.Add(id);
            });

        }

        public static bool parse(string src, out ProcessId dst)
        {
            var result = false;
            result = int.TryParse(src, out var i);
            dst = i;
            return result;
        }

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

       [MethodImpl(Inline)]
        public static implicit operator ProcessId(uint value)
            => new ((int)value);

        [MethodImpl(Inline)]
        public static implicit operator ulong(ProcessId src)
            => (ulong)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator long(ProcessId src)
            => src.Value;

        public static ProcessId Empty => default;
    }
}