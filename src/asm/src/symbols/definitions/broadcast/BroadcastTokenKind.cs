//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[LiteralProvider(BroadcastTokens.GroupName)]
public enum BroadcastTokenKind : byte
{
    Broadcast8,

    Broadcast16,

    Broadcast32,

    Broadcast64
}
