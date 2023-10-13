//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using T = Z0;

partial struct BitNumbers
{
    /// <summary>
    /// Creates a <see cref='T.uint2'/> of the form [0000 00ba]
    /// </summary>
    /// <param name="a">Bit 0</param>
    /// <param name="b">Bit 1</param>
    [MethodImpl(Inline), Op]
    public static uint2 join(bit a, bit b)
            => wrap2(Bytes.or(
                Bytes.sll((byte)a, 0),
                Bytes.sll((byte)b, 1)
                ));

    /// <summary>
    /// Creates a <see cref='T.uint3'/> of the form [0000 0cba]
    /// </summary>
    /// <param name="a">Bit 0</param>
    /// <param name="b">Bit 1</param>
    /// <param name="c">Bit 2</param>
    [MethodImpl(Inline), Op]
    public static uint3 join(bit a, bit b, bit c)
            => wrap3(Bytes.or(
                Bytes.sll((byte)a, 0),
                Bytes.sll((byte)b, 1),
                Bytes.sll((byte)c, 2)
                ));

    /// <summary>
    /// Creates a <see cref='T.uint4'/> of the form [0000 dcba]
    /// </summary>
    /// <param name="a">Bit 0</param>
    /// <param name="b">Bit 1</param>
    /// <param name="c">Bit 2</param>
    /// <param name="d">Bit 3</param>
    [MethodImpl(Inline), Op]
    public static uint4 join(bit a, bit b, bit c, bit d)
            => wrap4(Bytes.or(
                Bytes.sll((byte)a, 0),
                Bytes.sll((byte)b, 1),
                Bytes.sll((byte)c, 2),
                Bytes.sll((byte)d, 3)
                ));

    /// <summary>
    /// Creates a <see cref='T.uint5'/> value of the form [000e dcba]
    /// </summary>
    /// <param name="a">Bit 0</param>
    /// <param name="b">Bit 1</param>
    /// <param name="c">Bit 2</param>
    /// <param name="d">Bit 3</param>
    /// <param name="e">Bit 4</param>
    [MethodImpl(Inline), Op]
    public static uint5 join(bit a, bit b, bit c, bit d, bit e)
            => wrap5(Bytes.or(
                Bytes.sll((byte)a, 0),
                Bytes.sll((byte)b, 1),
                Bytes.sll((byte)c, 2),
                Bytes.sll((byte)d, 3),
                Bytes.sll((byte)e, 4)
                ));

    /// <summary>
    /// Produces a <see cref='T.uint3'/> value of the form [0000 0cba]
    /// </summary>
    /// <param name="a">Source bit 0</param>
    /// <param name="b">Source bit 1</param>
    /// <param name="b">Source bit 2</param>
    [MethodImpl(Inline), Op]
    public static uint3 join(uint1 a, uint1 b, uint1 c)
            => wrap3(Bytes.or(
                Bytes.sll((byte)a, 0),
                Bytes.sll((byte)b, 1),
                Bytes.sll((byte)c, 2)
                ));

    /// <summary>
    /// Produces a <see cref='T.uint2'/> value of the form [0000 00ba]
    /// </summary>
    /// <param name="a">Source bit 0</param>
    /// <param name="b">Source bit 1</param>
    [MethodImpl(Inline), Op]
    public static uint2 join(uint1 a, uint1 b)
            => wrap2(Bytes.or(
                Bytes.sll((byte)a, 0),
                Bytes.sll((byte)b, 1)
                ));

    /// <summary>
    /// Produces a <see cref='T.uint8b'/> value of the form [bbbb bbba]
    /// </summary>
    /// <param name="a">Source bit 0</param>
    /// <param name="b">Source bits 1-7</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint1 a, uint7 b)
        => movzx(a, w8) | (movzx(b, w8) << 1);

    /// <summary>
    /// Produces a <see cref='T.uint4'/> value of the form [0000 bbaa]
    /// </summary>
    /// <param name="a">Source bits 0-1</param>
    /// <param name="b">Source bits 2-3</param>
    [MethodImpl(Inline), Op]
    public static uint4 join(uint2 a, uint2 b)
        => movzx(a, w4) | (movzx(b, w4) << 2);

    /// <summary>
    /// Produces a <see cref='T.uint6'/> value of the form [cc bbaa]
    /// </summary>
    /// <param name="a">Source bits 0-1</param>
    /// <param name="b">Source bits 2-3</param>
    /// <param name="c">Source bits 4-5</param>
    [MethodImpl(Inline), Op]
    public static uint6 join(uint2 a, uint2 b, uint2 c)
        => movzx(a,w6) | (movzx(b,w6) << 2) | (movzx(c,w6) << 4);

    /// <summary>
    /// Produces a <see cref='T.uint8b'/> value of the form [ddcc bbaa]
    /// </summary>
    /// <param name="a">Source bits 0-1</param>
    /// <param name="b">Source bits 2-3</param>
    /// <param name="c">Source bits 4-5</param>
    /// <param name="d">Source bits 6-7</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint2 a, uint2 b, uint2 c, uint2 d)
        => movzx(a, w8) | (movzx(b, w8) << 2) | (movzx(c, w8) << 4) | (movzx(d, w8) << 6);

    /// <summary>
    /// Produces a <see cref='T.uint8b'/> value of the form [bbbb bbaa]
    /// </summary>
    /// <param name="a">The lo bits</param>
    /// <param name="b">The hi bits</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint2 a, uint6 b)
        => movzx(a, w8) | (movxz(b, w8) << 2);

    /// <summary>
    /// Produces a <see cref='T.uint4'/> value of the form [baaa]
    /// </summary>
    /// <param name="a">Specifies bits [2:0]</param>
    /// <param name="b">Specifies bit 3</param>
    [MethodImpl(Inline), Op]
    public static uint4 join(uint3 a, bit b)
        => movzx(a,w4) | (movzx(b,w4) << 3);

    /// <summary>
    /// Produces a <see cref='T.uint5'/> value of the form [c baaa]
    /// </summary>
    /// <param name="a">Specifies bits [2:0]</param>
    /// <param name="b">Specifies bit 3</param>
    /// <param name="c">Specifies bit 4</param>
    [MethodImpl(Inline), Op]
    public static uint5 join(uint3 a, bit b, bit c)
        => movzx(a,w5) | (movzx(b,w5) << 3) | (movzx(c,w5) << 4);

    /// <summary>
    /// Produces a <see cref='T.uint6'/> value of the form [dc baaa]
    /// </summary>
    /// <param name="a">Specifies bits [2:0]</param>
    /// <param name="b">Specifies bit 3</param>
    /// <param name="c">Specifies bit 4</param>
    /// <param name="d">Specifies bit 5</param>
    [MethodImpl(Inline), Op]
    public static uint6 join(uint3 a, bit b, bit c, bit d)
        => movzx(a,w6) | movzx(b,w6) << 3 | movzx(c,w6) << 4 | movzx(d,w6) << 5;

    /// <summary>
    /// Produces a <see cref='T.uint6'/> value of the form [dd dcba]
    /// </summary>
    /// <param name="b">Specifies bit 0</param>
    /// <param name="b">Specifies bit 1</param>
    /// <param name="c">Specifies bit 2</param>
    /// <param name="d">Specifies bits [5:3]</param>
    [MethodImpl(Inline), Op]
    public static uint6 join(bit a, bit b, bit c, uint3 d)
        => movzx(a,w6) | movzx(b,w6)<< 1 | movzx(c,w6) << 2 | movzx(c,w6) << 3;

    /// <summary>
    /// Produces a <see cref='T.uint5'/> value of the form [b baaa]
    /// </summary>
    /// <param name="a">Specifies bits [2:0]</param>
    /// <param name="b">Specifies bit 3</param>
    [MethodImpl(Inline), Op]
    public static uint5 join(uint3 a, uint2 b)
        => (uint5)a | (uint5)b << 3;

    /// <summary>
    /// (a,b,c,d) -> [cc bbb aaa]
    /// </summary>
    /// <param name="a">Source bits 0-2</param>
    /// <param name="b">Source bits 3-5</param>
    /// <param name="c">Source bits 6-7</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint3 a, uint3 b, uint2 c)
        => movzx(a, w8) | (movzx(b, w8) << 3) | (movzx(c, w8) << 6);

    /// <summary>
    /// Produces a <see cref='T.uint7'/> value of the form [bbb baaa]
    /// </summary>
    /// <param name="a">Specifies bits [2:0]</param>
    /// <param name="a">Specifies bits [7:3]</param>
    [MethodImpl(Inline), Op]
    public static uint7 join(uint3 a, uint4 b)
        => (uint7)a | (uint7)b << 3;

    /// <summary>
    /// Produces a <see cref='uint8b'/> value of the form [bbbb baaa]
    /// </summary>
    /// <param name="a">Specifies bits [2:0]</param>
    /// <param name="a">Specifies bits [7:3]</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint3 a, uint5 b)
        => movzx(a, w8) | ((uint8b)b << 3);

    /// <summary>
    /// Produces a <see cref='uint8b'/> value by contcatenating the operand-suppled bits
    /// </summary>
    /// <param name="a0">The lo bits</param>
    /// <param name="a1">The hi bits</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint4 a0, uint4 a1)
        => movzx(a0, w8) | (movzx(a1, w8) << 4);

    /// <summary>
    /// Produces a <see cref='uint8b'/> value by contcatenating the operand-suppled bits
    /// </summary>
    /// <param name="a0">The lo bits</param>
    /// <param name="a1">The hi bits</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint5 a0, uint3 a1)
        => movzx(a0, w8) | (movzx(a1, w8) << 5);

    /// <summary>
    /// Produces a <see cref='uint8b'/> value by contcatenating the operand-suppled bits
    /// </summary>
    /// <param name="a0">The lo bits</param>
    /// <param name="a1">The hi bits</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint6 a0, uint2 a1)
        => movxz(a0, w8) | (movzx(a1, w8) << 6);

    /// <summary>
    /// Produces a <see cref='uint8b'/> value by contcatenating the operand-suppled bits
    /// </summary>
    /// <param name="a0">The lo bits</param>
    /// <param name="a1">The hi bits</param>
    [MethodImpl(Inline), Op]
    public static uint8b join(uint7 a0, uint1 a1)
        => movzx(a0, w8) | (movzx(a1,w8) << 7);
}
