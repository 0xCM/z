//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct HResult<T> : IEquatable<HResult<T>>
    {
        public HResult Code {get;}

        public T Payload {get;}

        [MethodImpl(Inline)]
        public HResult(int value, T payload)
        {
            Code = value;
            Payload = payload;
        }

        [MethodImpl(Inline)]
        public HResult(int code)
        {
            Code = code;
            Payload = default;
        }
        public bool Success
        {
            [MethodImpl(Inline)]
            get => Code.Success && Payload != null;
        }

        public bool Failure
        {
            [MethodImpl(Inline)]
            get => Code.Failure;
        }

        [MethodImpl(Inline)]
        public bool Equals(HResult<T> src)
            => Code.Equals(src.Code);

        [MethodImpl(Inline)]
        public override bool Equals(object src)
            => src is HResult r && Equals(r);

        public override int GetHashCode()
            => Code;
        public string Format()
            => Code.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator true(HResult<T> src)
            => src.Success;

        [MethodImpl(Inline)]
        public static bool operator false(HResult<T> src)
            => src.Failure;

        [MethodImpl(Inline)]
        public static implicit operator bool(HResult<T> src)
            => src.Success;

        [MethodImpl(Inline)]
        public static implicit operator HResult<T>(T src)
            => new HResult<T>(Ok,src);

        [MethodImpl(Inline)]
        public static implicit operator HResult<T>(HResult src)
            => new HResult<T>(src);

        public static HResult Ok => default;
    }
}