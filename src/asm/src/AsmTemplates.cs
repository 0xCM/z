//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// https://github.com/dotnet/BenchmarkDotNet/blob/96844853b8c15eeed65ef8349aa9dbe47fb05248/src/BenchmarkDotNet/Disassemblers/IntelDisassembler.cs
/// </summary>
public class AsmTemplates
{
    // See dotnet/runtime src/coreclr/vm/amd64/thunktemplates.asm/.S for the stub code
    // mov    rax,QWORD PTR [rip + DATA_SLOT(CallCountingStub, RemainingCallCountCell)]
    // dec    WORD PTR [rax]
    // je     LOCAL_LABEL(CountReachedZero)
    // jmp    QWORD PTR [rip + DATA_SLOT(CallCountingStub, TargetForMethod)]
    // LOCAL_LABEL(CountReachedZero):
    // jmp    QWORD PTR [rip + DATA_SLOT(CallCountingStub, TargetForThresholdReached)]
    public static ReadOnlySpan<byte> CallCounting => new byte[10] { 0x48, 0x8b, 0x05, 0xf9, 0x0f, 0x00, 0x00, 0x66, 0xff, 0x08 };

    // mov    r10, [rip + DATA_SLOT(StubPrecode, MethodDesc)]
    // jmp    [rip + DATA_SLOT(StubPrecode, Target)]
    public static ReadOnlySpan<byte> StubPrecode => new byte[13] { 0x4c, 0x8b, 0x15, 0xf9, 0x0f, 0x00, 0x00, 0xff, 0x25, 0xfb, 0x0f, 0x00, 0x00 };
    
    // jmp    [rip + DATA_SLOT(FixupPrecode, Target)]
    // mov    r10, [rip + DATA_SLOT(FixupPrecode, MethodDesc)]
    // jmp    [rip + DATA_SLOT(FixupPrecode, PrecodeFixupThunk)]
    public static ReadOnlySpan<byte> FixupPrecode => new byte[19] { 0xff, 0x25, 0xfa, 0x0f, 0x00, 0x00, 0x4c, 0x8b, 0x15, 0xfb, 0x0f, 0x00, 0x00, 0xff, 0x25, 0xfd, 0x0f, 0x00, 0x00 };
}    
