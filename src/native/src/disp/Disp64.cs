//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a signed 64-bit displacement
    /// </summary>
    public readonly struct Disp64 : IDisplacement<Disp64,long>
    {
        [Parser]
        public static Outcome parse(string src, out Disp64 dst)
        {
            var result = Outcome.Success;
            if(text.empty(text.trim(src)))
            {
                dst = 0L;
                return true;
            }

            dst = default;
            var i = text.index(src,HexFormatSpecs.PreSpec);
            var disp = 0L;
            if(i>=0)
            {
                result = Hex.parse64i(src, out disp);
                if(result)
                    dst = disp;
            }
            else
            {
                result = NumericParser.parse(src, out disp);
                if(result)
                    dst = disp;
            }
            return result;
        }

        public readonly long Value;

        [MethodImpl(Inline)]
        public Disp64(long value)
        {
            Value = value;
        }

        public NativeSize Size
            => NativeSizeCode.W64;

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool Positive
        {
            [MethodImpl(Inline)]
            get => Value > 0;
        }

        public bool Negative
        {
            [MethodImpl(Inline)]
            get => Value < 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(Disp64 src)
            => Value == src.Value;

        public string Format()
            => Disp.format(this);

        public override string ToString()
            => Format();

        long IDisplacement<long>.Value
             => Value;

        long IDisplacement.Value
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(Disp64 src)
            => (ulong)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator long(Disp64 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp64 src)
            => new Disp(src.Value, src.Size);

        [MethodImpl(Inline)]
        public static implicit operator Disp64(ulong src)
            => new Disp64((long)src);

        [MethodImpl(Inline)]
        public static implicit operator Disp64(long src)
            => new Disp64((int)src);

        public static Disp64 Empty
        {
            [MethodImpl(Inline)]
            get => new Disp64(0);
        }
    }
}