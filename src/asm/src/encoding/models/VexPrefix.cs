//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using K = VexPrefixKind;
using api = Vex;

/// <remarks>
/// [ Byte1[R | vvvv | L | pp] | Byte0[11000101b=0xC5]]
/// [ Byte2[W | vvvv | L | pp] | Byte1[R | X | B | mmmmm] | Byte0[11000100b=0xC4]]
/// R - REX.R in one's complement form
/// X - REX.X in one's complement form
/// B - REX.B in one's complement form
/// mmmmm
/// 00001 => specifies 0F leading opcode byte
/// 00010 => specifies 0F38 leading opcode byte
/// 00011 => specifies 0F3A Leading opcode byte
/// vvvv - specifies a register in one's complement form
/// L - specifies a length
/// 0 => a scalar or 128-bit vector
/// 1 => a 256-bit vector
/// pp - opcode extension
/// 00 => None
/// 01 => 66
/// 10 => F3
/// 11 => F2
/// </remarks>
[ApiHost]
public record struct VexPrefix
{
    internal uint _Data;

    [MethodImpl(Inline)]
    internal VexPrefix(K k, byte b1)
    {
        _Data = Bitfields.join((byte)k, b1, 0, 2);
    }

    [MethodImpl(Inline)]
    internal VexPrefix(K k, byte b1, byte b2)
    {
        _Data = Bitfields.join((byte)k, b1, b2, 3);
    }

    public K VexKind
    {
        [MethodImpl(Inline)]
        get => (K)_Data;
    }

    public string Bitstring()
        => api.bitstring(this);

    public string Format()
        => api.format(this);

    public override string ToString()
        => Format();

    public static VexPrefix Empty => default;
}
