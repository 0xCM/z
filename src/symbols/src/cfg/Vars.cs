//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost,Free]
public class Vars
{
    const NumericKind Closure = UnsignedInts;

    public static bool parse(string src, out IVarAssignment dst)
    {
        dst = default;
        var i = text.index(src, '=');
        if(i>0)
        {
            var decl = text.left(src,i);
            var value = text.right(src,i);
            var j = text.index(decl, ':');
            var type = j > 0 ? text.right(decl,j) : EmptyString;
            var name = j > 0 ? text.left(decl,j) : decl;
            dst = assign(Vars.var(name,type), value);
        }
        return dst != null;
    }

    public static IVarAssignment[] assigments(ReadOnlySpan<string> lines, string commentPrefix)
    {
        var usage = EmptyString;
        var type = EmptyString;
        var name = EmptyString;
        var vars = list<IVarAssignment>();
        foreach(var line in lines)
        {
            if(text.begins(line,commentPrefix))
            {
                var i = text.index(line, commentPrefix);
                if(nonempty(usage))
                    usage += Chars.Space;

                usage += text.trim(text.despace(text.remove(text.right(line, i + commentPrefix.Length - 1), "\\n")));
            }
            else if(text.contains(line, "="))
            {
                if(parse(line, out var assigment))
                {
                    if(nonempty(usage))
                    {
                        var def = assigment.Def.WithUsage(usage);
                        vars.Add(Vars.assign(def, assigment.Value));
                    }
                    else
                        vars.Add(assigment);
                }
                usage = EmptyString;
                type = EmptyString;
                name = EmptyString;
            }
        }
        return vars.Array();
    }

    public static VarDef var(@string name, @string? type = null, @string? usage = null)
        => new (name, type ?? EmptyString, usage ?? EmptyString);

    public static VarAssignment<T> assign<T>(VarDef def, T value)
        => new (def, value);

    public static VarAssignment<T> assign<T>(@string name, T value)
        => assign(var(name), value);
}
