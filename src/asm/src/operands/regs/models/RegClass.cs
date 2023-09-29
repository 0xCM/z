//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Specifies a <see cref='RegClassCode'/>
/// </summary>
public readonly struct RegClass
{
    public readonly RegClassCode Code;

    [MethodImpl(Inline)]
    public RegClass(RegClassCode code)
    {
        Code = code;
    }

    public string Format()
        => AsmRender.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator RegClassCode(RegClass src)
        => src.Code;

    [MethodImpl(Inline)]
    public static implicit operator RegClass(RegClassCode src)
        => new (src);
}
