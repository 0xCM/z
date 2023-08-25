//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public class AsmRegParser
{
    [Parser]
    public static bool parse(string src, out RegKind dst)
        => Lookup.TryGetValue(text.trim(src.ToLowerInvariant()), out dst);

    public static AsmRegParser create()
        => Instance;

    static ConcurrentDictionary<string,RegKind> Lookup {get;} = new();

    AsmRegParser()
    {

    }

    public bool Parse(string src, out RegKind dst)
        => parse(src, out dst);

    static AsmRegParser()
    {
        var symbols = Symbols.index<RegKind>();
        var count = symbols.Count;
        for(var i=0u; i<count; i++)
        {
            ref readonly var symbol = ref symbols[i];
            Lookup[symbol.Expr.Format()] = symbol.Kind;
        }
        Instance = new();
    }

    static readonly AsmRegParser Instance;
}
