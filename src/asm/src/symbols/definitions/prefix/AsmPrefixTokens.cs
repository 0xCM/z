//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static Hex8Kind;

using NBK = NumericBaseKind;
using Tk = PrefixTokenKind;

[ApiHost]
public class AsmPrefixTokens
{
    public const string GroupName = "prefixes";

    [MethodImpl(Inline), Op]
    public static RexPrefix rex(bit w, bit r, bit x, bit b)
    {
        var bx = math.slor((byte)b, 0, (byte)x, 1);
        var rw = math.slor((byte)r, 2, (byte)w, 3);
        return math.or(bx, rw, rex());
    }

    [MethodImpl(Inline), Op]
    public static RexPrefix rex()
        => (byte)0x40;
    
    [SymSource(GroupName, NBK.Base16), TokenKind(Tk.BranchHint)]
    public enum BranchHintCode : byte
    {
        /// <summary>
        /// Branch taken
        /// </summary>
        [Symbol("BT", "2e - Branch Taken")]
        BT = 0x2E,

        /// <summary>
        /// Branch not taken
        /// </summary>
        [Symbol("BT", "3e - Branch Not Taken")]
        BNT = 0x3e,
    }

    [SymSource(GroupName, NBK.Base16), TokenKind(Tk.Bnd)]
    public enum BndPrefixCode : byte
    {
        [Symbol("BND")]
        BND = xf2
    }

}
