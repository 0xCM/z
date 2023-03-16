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

        public static CmdVars cmdvars(params Pair<string>[] src)
        {
            var dst = new CmdVar[src.Length];
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = skip(src,i);
            return dst;
        }

        static ReadOnlySeq<VarPattern> Patterns = new VarPattern[]{
            new (AsciVarKind.None, AsciSymbol.Empty, AsciFence.Empty),
            new (AsciVarKind.Cmd, AsciSymbol.Empty, (AsciSymbols.Percent, AsciSymbols.Percent)),
            new (AsciVarKind.Bash, AsciSymbols.Dollar, AsciFence.Empty),
            new (AsciVarKind.Powershell, AsciSymbols.Dollar, AsciFence.Empty),
            new (AsciVarKind.MsBuild, AsciSymbols.Dollar, (AsciSymbols.LParen, AsciSymbols.RParen)),
            new (AsciVarKind.Template, AsciSymbols.Dollar, (AsciSymbols.LBrace, AsciSymbols.RBrace)),

        };

        [MethodImpl(Inline), Op]
        public static ref readonly VarPattern pattern(AsciVarKind vck)
            => ref Patterns[(byte)vck];
        
        public static string format(IScriptVar src)
        {
            var dst = EmptyString;
            if(src.Value(out var _value))
                dst = _value.ToString();
            else
            {
                if(src.IsPrefixedFence)
                    dst = string.Format("{0}{1}{2}{3}", src.Prefix, src.Fence.Left, src.Name, src.Fence.Right);
                if(src.IsPrefixed)
                    dst = string.Format("{0}{1}", src.Prefix, src.Name);
                else if(src.IsFenced)
                    dst = string.Format("{0}{1}{2}", src.Fence.Left, src.Name, src.Fence.Right);
                else
                    dst = src.Name;
            }

            return dst;
        }

        public static string format(CmdVars src)
        {
            var dst = text.buffer();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref src[i];
                if(item.Name.IsNonEmpty)   
                {
                    if(item.Value(out var value))
                        dst.AppendLineFormat("set {0}={1}", item.Name, value);
                    else
                        dst.AppendLineFormat("set {0}=", item.Name);
                }                                        
            }
            return dst.Emit();
        }

        public static string eval(string expr, ICollection<IScriptVar> vars)
        {
            var result = expr;
            foreach(var v in vars)
            {
                if(v.Value(out var value))
                    result = text.replace(result, string.Format("{0}{1}{2}{3}", v.Prefix, v.Fence.Left, v.Name, v.Fence.Right), value.ToString());
            }
            return result;
        }

        public static Dictionary<string,ScriptVar> extract(ReadOnlySpan<char> src, AsciSymbol prefix, AsciFence fence)
        {
            var dst = dict<string,ScriptVar>();
            var count = src.Length;
            var lpos = -1;
            var rpos = -1;
            var parsing = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var c0 = ref skip(src,i);
                if(c0 == prefix)
                {
                    if(i < count -1)
                    {
                        parsing = skip(src,++i) == fence.Left;
                        lpos = i + 1;
                    }
                }
                else if(c0 == fence.Right && parsing)
                {
                    rpos = i - 1;                    
                    var name = sys.@string(text.segment(src, lpos, rpos));
                    dst.TryAdd(name, new ScriptVar(name,prefix,fence));
                    lpos = -1;
                    rpos = -1;                    
                }
            }

            return dst;
        }
    }
}