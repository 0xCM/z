//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
                dst = Vars.assign(Vars.var(name,type), value);
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
                    if(Vars.parse(line, out var assigment))
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
            => new VarDef(name, type ?? EmptyString, usage ?? EmptyString);

        public static VarAssignment<T> assign<T>(VarDef def, T value)
            => new VarAssignment<T>(def, value);

        public static VarAssignment<T> assign<T>(@string name, T value)
            => assign(var(name), value);


        // public static ScriptVar var(string name, AsciSymbol prefix, AsciFence fence, @string value = default)
        //     => new ScriptVar(name,prefix, fence, value);
            
        // public static string eval(string expr, ICollection<IScriptVar> vars)
        // {
        //     var result = expr;
        //     foreach(var v in vars)
        //     {
        //         if(v.Value(out var value))
        //             result = text.replace(result, string.Format("{0}{1}{2}{3}", v.Prefix, v.Fence.Left, v.Name, v.Fence.Right), value.ToString());
        //     }
        //     return result;
        // }

        // public static Dictionary<string,ScriptVar> extract(ReadOnlySpan<char> src, AsciSymbol prefix, AsciFence fence)
        // {
        //     var dst = dict<string,ScriptVar>();
        //     var count = src.Length;
        //     var lpos = -1;
        //     var rpos = -1;
        //     var parsing = false;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var c0 = ref skip(src,i);
        //         if(c0 == prefix)
        //         {
        //             if(i < count -1)
        //             {
        //                 parsing = skip(src,++i) == fence.Left;
        //                 lpos = i + 1;
        //             }
        //         }
        //         else if(c0 == fence.Right && parsing)
        //         {
        //             rpos = i - 1;                    
        //             var name = sys.@string(text.segment(src, lpos, rpos));
        //             dst.TryAdd(name, new ScriptVar(name,prefix,fence));
        //             lpos = -1;
        //             rpos = -1;                    
        //         }
        //     }

        //     return dst;
        // }
    }
}