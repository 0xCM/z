//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public class AsmTokens
{        
    static readonly SymbolGroup _AsmOcTokens = new SymbolGroup(typeof(AsmOcTokenKind), typeof(AsmOcTokens));

    static readonly SymbolGroup _AsmRegTokens = new SymbolGroup(typeof(AsmRegTokenKind), typeof(AsmRegTokens));

    static readonly SymbolGroup _AsmSigTokens = new SymbolGroup(typeof(AsmSigTokenKind), typeof(AsmSigTokens));

    static readonly SymbolGroup _ConditionTokens = new SymbolGroup(typeof(ConditionTokenKind), typeof(ConditionCodes));

    public static ref readonly SymbolGroup OpCodeTokens => ref _AsmOcTokens;

    public static ref readonly SymbolGroup RegTokens => ref _AsmRegTokens;

    public static ref readonly SymbolGroup SigTokens => ref _AsmSigTokens;

    public static ref readonly SymbolGroup ConditionTokens => ref _ConditionTokens;

    public static IEnumerable<SymbolGroup> groups()
    {
        yield return _AsmOcTokens;
        yield return _AsmRegTokens;
        yield return _AsmSigTokens;
        yield return _ConditionTokens;
    }

    [MethodImpl(Inline), Op]
    public static AsmSigToken sig(in AsmTokenRecord src)
        => new ((AsmSigTokenKind)src.Index, (byte)src.Value);

    [MethodImpl(Inline), Op]
    public static AsmOcToken opcode(in AsmTokenRecord src)
        => new ((AsmOcTokenKind)src.Index, (byte)src.Value);

    public static bool parse(string expr, out AsmSigToken dst)
        => throw new NotImplementedException();

    public static bool parse(string expr, out AsmOcToken dst)
        => throw new NotImplementedException();
}
