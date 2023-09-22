//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[LiteralProvider(AsmPrefixTokens.GroupName)]
public enum PrefixTokenKind : byte
{
    None,

    Vsib,

    VexRXB,

    VexOpCodeExtension,

    VexLength,

    VexPrefix,
    
    VexM,
    
    VexWidth,
    
    EvexWidth,
    
    RexPrefix,
    
    RexField,

    RexMode,
    
    Lock,
    
    BranchHint,
    
    SizeOverride,
    
    Mandatory,
    
    Bnd,
    
    SegOverride,
    
    Rep
}

