//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct ThreadId : IDataType<ThreadId>, IDataString
    {
        public static void parse(CmdArgs src, ConcurrentBag<ThreadId> dst)
        {
            iter(src, arg => {
                if(parse(arg.Value, out ThreadId id))
                    dst.Add(id);
            });
        }

        public static bool parse(string src, out ThreadId dst)
        {
            var result = false;
            result = int.TryParse(src, out var i);
            dst = i;
            return result;
        }

        public readonly int Value;

        public ThreadId()
        {
            Value = 0;
        }

        [MethodImpl(Inline)]
        public ThreadId(int value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public ThreadId(uint value)
        {
            Value = (int)value;
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
        public int CompareTo(ThreadId src)
            => Value.CompareTo(src.Value);

        public string Format()
            => $"{Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ThreadId(int value)
            => new (value);

       [MethodImpl(Inline)]
        public static implicit operator ThreadId(uint value)
            => new ((int)value);

        [MethodImpl(Inline)]
        public static implicit operator uint(ThreadId src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator int(ThreadId src)
            => src.Value;

        public static ThreadId Empty => default;
    }
}