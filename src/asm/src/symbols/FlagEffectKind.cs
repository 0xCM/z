//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Adapted from https://github.com/intelxed/xed
/// </summary>
public enum FlagEffectKind
{
    [Symbol("u", "undefined (treated as a write)")]
    u,

    [Symbol("tst", "test (read)")]
    tst,

    [Symbol("mod", "modification (write)")]
    mod,

    [Symbol("0", "value will be zero (write)")]
    off,

    [Symbol("pop", "value comes from the stack (write)")]
    pop,

    [Symbol("ah", "value comes from AH (write)")]
    ah,

    [Symbol("1", "value will be 1 (write)")]
    on,
}
