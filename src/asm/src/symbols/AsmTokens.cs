//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public class AsmTokens
{        
    static readonly SymbolGroup _AsmOcTokens = new SymbolGroup(typeof(AsmOcTokenKind), typeof(AsmOpCodeTokens));

    static readonly SymbolGroup _AsmRegTokens = new SymbolGroup(typeof(AsmRegTokenKind), typeof(AsmRegTokens));

    static readonly SymbolGroup _AsmSigTokens = new SymbolGroup(typeof(AsmSigTokenKind), typeof(AsmSigTokens));

    static readonly SymbolGroup _ConditionTokens = new SymbolGroup(typeof(ConditionTokenKind), typeof(ConditionTokens));

    static readonly SymbolGroup _AsmOcTables = new SymbolGroup(typeof(AsmOcTableKind), typeof(AsmOcTables));

    static readonly SymbolGroup _PrefixTokens = new SymbolGroup(typeof(PrefixTokenKind), typeof(AsmPrefixTokens));

    public static ref readonly SymbolGroup OpCodes => ref _AsmOcTokens;

    public static ref readonly SymbolGroup Registers => ref _AsmRegTokens;

    public static ref readonly SymbolGroup Sigs => ref _AsmSigTokens;

    public static ref readonly SymbolGroup Conditions => ref _ConditionTokens;

    public static ref readonly SymbolGroup OpCodeTables => ref _AsmOcTables;

    public static ref readonly SymbolGroup PrefixTokens => ref _PrefixTokens;

    public static IEnumerable<SymbolGroup> groups()
    {
        yield return _AsmOcTokens;
        yield return _AsmRegTokens;
        yield return _AsmSigTokens;
        yield return _AsmOcTables;
        yield return _ConditionTokens;
        yield return _PrefixTokens;
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
    {
        dst = AsmOcToken.Empty;
        return true;
    }
}
