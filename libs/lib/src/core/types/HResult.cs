//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct HResult : ITextual, IEquatable<HResult>
    {
        public int Code {get;}

        [MethodImpl(Inline)]
        public HResult(int value)
        {
            Code = value;
        }

        public bool Success
        {
            [MethodImpl(Inline)]
            get => Code == 0;
        }

        public bool Failure
        {
            [MethodImpl(Inline)]
            get => Code != 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(HResult src)
            => Code == src.Code;

        [MethodImpl(Inline)]
        public override bool Equals(object src)
            => src is HResult r && Equals(r);

        public override int GetHashCode()
            => Code;
        public string Format()
            => Success ? Code.ToString() : Code.ToString("X8");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator true(HResult src)
            => src.Success;

        [MethodImpl(Inline)]
        public static bool operator false(HResult src)
            => src.Failure;

        [MethodImpl(Inline)]
        public static implicit operator bool(HResult src)
            => src.Success;

        [MethodImpl(Inline)]
        public static implicit operator Outcome<int>(HResult src)
            => new Outcome<int>(src.Success, src.Code);

        [MethodImpl(Inline)]
        public static implicit operator HResult(int src)
            => new HResult(src);

        [MethodImpl(Inline)]
        public static implicit operator int(HResult src)
            => src.Code;

        public static HResult Ok => default;

        public static HResult False => new HResult(1);
    }
}