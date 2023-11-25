//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Defines an instance of a JMP r/m64 instruction: Jump near, absolute indirect, RIP = 64-Bit offset from register or memory
/// </summary>
/// <example>
/// jmp qword ptr [rip+3ffah]                     # 0000h  | 6   | ff 25 fa 3f 00 00                | (JMP r/m64) = FF /4
/// </example>
[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly record struct JmpRip64<T>
    where T : unmanaged,  IDisplacement
{
    public static byte InsructionSize => (byte)sys.size<JmpRip64<T>>();

    public const byte OpCodeValue = 0xFF;

    public const byte ModRmValue = 0x25;

    public readonly Hex8 OpCode;

    public readonly ModRm ModRm;

    public readonly T Disp;

    public JmpRip64(T disp)
    {
        OpCode = OpCodeValue;
        ModRm = ModRmValue;
        Disp = disp;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => OpCode == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => OpCode != 0;
    }

    public static JmpRip64<T> Empty => default;
}

