//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public class FixedBitFormatter
    {
        [MethodImpl(Inline)]
        public static string format(uint1 src)
            => Instance.Format(src);

        [MethodImpl(Inline)]
        public static string format(uint2 src)
            => Instance.Format(src);

        [MethodImpl(Inline)]
        public static string format(uint3 src)
            => Instance.Format(src);

        [MethodImpl(Inline)]
        public static string format(uint4 src)
            => Instance.Format(src);

        [MethodImpl(Inline)]
        public static string format(uint5 src)
            => Instance.Format(src);

        [MethodImpl(Inline)]
        public static string format(uint6 src)
            => Instance.Format(src);

        [MethodImpl(Inline)]
        public static string format(uint7 src)
            => Instance.Format(src);

        [MethodImpl(Inline)]
        public static string format(uint8b src)
            => Instance.Format(src);

        public static FixedBitFormatter Service => Instance;

        public static FixedBitFormatter create()
            => Instance;

        readonly FixedBitFormatter<uint1> _f1;

        readonly FixedBitFormatter<uint2> _f2;

        readonly FixedBitFormatter<uint3> _f3;

        readonly FixedBitFormatter<uint4> _f4;

        readonly FixedBitFormatter<uint5> _f5;

        readonly FixedBitFormatter<uint6> _f6;

        readonly FixedBitFormatter<uint7> _f7;

        readonly FixedBitFormatter<uint8b> _f8;

        [MethodImpl(Inline)]
        public FixedBitFormatter()
        {
            _f1 = new(1);
            _f2 = new(2);
            _f3 = new(3);
            _f4 = new(4);
            _f5 = new(5);
            _f6 = new(6);
            _f7 = new(7);
            _f8 = new(8);
        }

        [MethodImpl(Inline)]
        public string Format(uint1 src)
            => _f1.Format(src);

        [MethodImpl(Inline)]
        public string Format(uint2 src)
            => _f2.Format(src);

        [MethodImpl(Inline)]
        public string Format(uint3 src)
            => _f3.Format(src);

        [MethodImpl(Inline)]
        public string Format(uint4 src)
            => _f4.Format(src);

        [MethodImpl(Inline)]
        public string Format(uint5 src)
            => _f5.Format(src);

        [MethodImpl(Inline)]
        public string Format(uint6 src)
            => _f6.Format(src);

        [MethodImpl(Inline)]
        public string Format(uint7 src)
            => _f7.Format(src);

        [MethodImpl(Inline)]
        public string Format(uint8b src)
            => _f8.Format(src);

        static FixedBitFormatter Instance;

        static FixedBitFormatter()
        {
            Instance = new();
        }
    }
}