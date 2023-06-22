//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Specifies a register paired with a specified value
    /// </summary>
    public readonly struct AsmRegValue<T>
        where T : unmanaged
    {
        public readonly AsmRegName Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public AsmRegValue(AsmRegName name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format("{0,-5}{1}", Name, HexFormatter.bytes(Value));

        public string FormatBits()
        {
            if(size<T>() == 1)
                return BitRender.format8(u8(Value));
            else if(size<T>() == 2)
                return BitRender.format16x8(u16(Value));
            else if(size<T>() == 4)
                return BitRender.format32x8(u32(Value));
            else if(size<T>() == 8)
                return BitRender.format64x8(u64(Value));
            else
                return EmptyString;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmRegValue<T>(Paired<AsmRegName,T> src)
            => @as<Paired<AsmRegName,T>,AsmRegValue<T>>(src);
    }
}