//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AlgDynamic
    {
        [ApiHost]
        public readonly struct CSlots
        {
            [Op]
            public static byte exec(byte a, byte b)
            {
                var s0 = new Slots_n16x8x8x8();
                var s1 = new Slots_n16x8x8x8();
                var x = s0.Slot0(a,b);
                var y = s1.Slot0(a,b);
                var z = s0.Slot1(x,y);
                x = s1.Slot1(x,y);
                y = s0.Slot2(z,y);
                x = s0.Slot3(x,y);
                y = s1.Slot4(z,y);
                x = s0.Slot5(x,y);
                y = s1.Slot6(z,y);
                x = s0.Slot7(x,y);
                y = s1.Slot8(z,y);
                x = s0.Slot9(x,y);
                y = s1.SlotA(z,y);
                x = s0.SlotB(x,y);
                y = s1.SlotC(z,y);
                x = s0.SlotD(x,y);
                y = s1.SlotE(z,y);
                z = s0.SlotF(z, s1.SlotF(z,b));
                return z;
            }

            [ApiComplete]
            public readonly struct Slots_n16x8x8x8
            {
                [Op]
                public static byte exec1(byte a, byte b)
                {
                    var s0 = new Slots_n16x8x8x8();
                    var s1 = new Slots_n16x8x8x8();
                    var x = s0.Slot0(a,b);
                    var y = s0.Slot1(x,b);
                    var z = s0.Slot2(y,a);
                    y = s0.Slot3(z,y);
                    x = s0.Slot4(x,y);
                    x = s0.Slot5(x,z);
                    x = s0.Slot6(x,y);
                    x = s0.Slot7(x,y);
                    x = s0.Slot8(x,z);
                    x = s0.Slot9(x,y);
                    x = s0.SlotA(x,y);
                    x = s0.SlotB(x,y);
                    x = s0.SlotC(x,z);
                    x = s0.SlotD(y,x);
                    x = s0.SlotE(x,y);
                    z = s0.SlotF(z,b);
                    return z;
                }

                [MethodImpl(NotInline)]
                public byte Slot0(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot1(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot2(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot3(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot4(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot5(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot6(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot7(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot8(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte Slot9(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte SlotA(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte SlotB(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte SlotC(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte SlotD(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte SlotE(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(NotInline)]
                public byte SlotF(byte a, byte b)
                    => filler(a,b);

                [MethodImpl(Inline)]
                static byte filler(byte a, byte b)
                {
                    var x = Bytes.add(a, b);
                    var y = Bytes.xor(x, b);
                    var z = Bytes.xnor(y,a);
                    return Bytes.cnonimpl(x,z);
                }
            }
        }
    }
}