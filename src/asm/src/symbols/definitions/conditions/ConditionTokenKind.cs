//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[LiteralProvider(ConditionTokens.GroupName)]
public enum ConditionTokenKind : byte
{
    None = 0,

    Condition,

    Alt,
}
