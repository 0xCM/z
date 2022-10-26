//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

public class SymbolAttribute : Attribute
{
    public static string symbol(FieldInfo src)
    {
        var symbol = src.Name;
        if(sys.tag<SymbolAttribute>(src, out var a))
        {
            if(!string.IsNullOrEmpty(a.Symbol))
                symbol = a.Symbol;
        }

        return symbol;
    }

    object _Symbol {get;}

    public Type SourceType
        => _Symbol.GetType();

    public string Symbol
        => _Symbol.ToString();

    public string Description {get;}

    public string Refinement {get;}

    public SymbolAttribute(object symbol)
    {
        _Symbol = symbol;
        Description = string.Empty;
        Refinement = string.Empty;
    }

    public SymbolAttribute(object symbol, string description)
    {
        _Symbol = symbol;
        Description = description;
        Refinement = string.Empty;
    }

    public SymbolAttribute(object symbol, string description, string refinement)
    {
        _Symbol = symbol;
        Description = description;
        Refinement = refinement;
    }
}