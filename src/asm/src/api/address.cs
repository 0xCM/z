//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;

partial struct asm
{
    /// <summary>
    /// Specifies a generalized address
    /// </summary>
    /// <param name="base">The base register</param>
    /// <param name="index">The index register</param>
    /// <param name="scale">The scale</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(RegOp @base, RegOp index, MemoryScale scale, Disp disp = default)
        => new (@base, index, scale,disp);

    /// <summary>
    /// Specifies an effective adress for 8-bit operands
    /// </summary>
    /// <param name="base">The base register</param>
    /// <param name="index">The index register</param>
    /// <param name="scale">The scale</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(r8 @base, r8 index, MemoryScale scale, Disp8 disp = default)
        => new (@base, index, scale, disp);

    /// <summary>
    /// Specifies an effective adress for 16-bit operands
    /// </summary>
    /// <param name="base">The base register</param>
    /// <param name="index">The index register</param>
    /// <param name="scale">The scale</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(r16 @base, r16 index, MemoryScale scale, Disp16 disp = default)
        => new AsmAddress(@base,index, scale, disp);

    /// <summary>
    /// Specifies an effective adress for 32-bit operands
    /// </summary>
    /// <param name="base">The base register</param>
    /// <param name="index">The index register</param>
    /// <param name="scale">The scale</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(r32 @base, r32 index, MemoryScale scale, Disp32 disp = default)
        => new (@base,index, scale, disp);

    /// <summary>
    /// Specifies an effective adress for 64-bit operands
    /// </summary>
    /// <param name="base">The base register</param>
    /// <param name="index">The index register</param>
    /// <param name="scale">The scale</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(r64 @base, r64 index, MemoryScale scale, Disp32 disp = default)
        => new (@base, index, scale, disp);

    /// <summary>
    /// Specifies an effective address for 8-bit operands
    /// </summary>
    /// <param name="w">The register width selector</param>
    /// <param name="base">The base register code</param>
    /// <param name="index">The index register code</param>
    /// <param name="scale">The scale factor</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(W8 w, RegIndexCode @base, RegIndexCode index, MemoryScale scale, Disp8 disp = default)
        => address(reg(NativeSizeCode.W8, RegClassCode.GP, @base), reg(NativeSizeCode.W8, RegClassCode.GP, index), scale,disp);

    /// <summary>
    /// Specifies an effective address for 16-bit operands
    /// </summary>
    /// <param name="w">The register width selector</param>
    /// <param name="base">The base register code</param>
    /// <param name="index">The index register code</param>
    /// <param name="scale">The scale factor</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(W16 w, RegIndexCode @base, RegIndexCode index, MemoryScale scale, Disp16 disp = default)
        => address(reg(NativeSizeCode.W16, RegClassCode.GP, @base), reg(NativeSizeCode.W16, RegClassCode.GP, index), scale,disp);

    /// <summary>
    /// Specifies an effective address for 32-bit operands
    /// </summary>
    /// <param name="w">The register width selector</param>
    /// <param name="base">The base register code</param>
    /// <param name="index">The index register code</param>
    /// <param name="scale">The scale factor</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(W32 w, RegIndexCode @base, RegIndexCode index, MemoryScale scale, Disp32 disp = default)
        => address(reg(NativeSizeCode.W32, RegClassCode.GP, @base), reg(NativeSizeCode.W32, RegClassCode.GP, index), scale,disp);

    /// <summary>
    /// Specifies an effective address for 64-bit operands
    /// </summary>
    /// <param name="w">The register width selector</param>
    /// <param name="base">The base register code</param>
    /// <param name="index">The index register code</param>
    /// <param name="scale">The scale factor</param>
    /// <param name="disp">The displacement</param>
    [MethodImpl(Inline), Op]
    public static AsmAddress address(W64 w, RegIndexCode @base, RegIndexCode index, MemoryScale scale, Disp32 disp = default)
        => address(reg(NativeSizeCode.W64, RegClassCode.GP, @base), reg(NativeSizeCode.W64, RegClassCode.GP, index), scale,disp);
}
