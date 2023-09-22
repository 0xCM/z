//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
public struct AsmBranchTarget
{
    const string TableId = "asm.branch";

    /// <summary>
    /// The target address
    /// </summary>
    [Render(16)]
    public MemoryAddress Address;

    /// <summary>
    /// The target classifier, near or far
    /// </summary>
    [Render(8)]
    public BranchTargetKind Kind;

    /// <summary>
    /// The target size
    /// </summary>
    [Render(8)]
    public BranchTargetWidth Width;

    /// <summary>
    /// Specifies a branch target selector, if far
    /// </summary>
    [Render(8)]
    public Address16 Selector;

    [MethodImpl(Inline)]
    public AsmBranchTarget(MemoryAddress dst, BranchTargetKind kind, BranchTargetWidth width, Address16? selector = null)
    {
        Kind = kind;
        Width = width;
        Address = dst;
        Selector = selector ?? 0;
    }


    public bool IsNear
    {
        [MethodImpl(Inline)]
        get => Kind == BranchTargetKind.Near;
    }

    public bool IsFar
    {
        [MethodImpl(Inline)]
        get => Kind == BranchTargetKind.Far;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Address != 0u;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Address == 0u;
    }

    public static AsmBranchTarget Empty
        => default;

}
