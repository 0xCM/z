//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EmptyZero<T>
        where T : unmanaged
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public EmptyZero(T src)
        {
            Value = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.bw64(Value) == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.bw64(Value) != 0;
        }

        public override string ToString()
            => Format();

        public string Format()
        {
            if(IsEmpty)
                return EmptyString;
            else
                return Value.ToString();
        }

        [MethodImpl(Inline)]
        public static implicit operator EmptyZero<T>(T src)
            => new EmptyZero<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(EmptyZero<T> src)
            => src.Value;
    }
}