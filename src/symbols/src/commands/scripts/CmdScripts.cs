//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    [ApiHost,Free]    
    public class CmdScripts
    {
        public static Seq<CmdSetExpr> setx(FileUri src)
        {
            var dst = list<CmdSetExpr>();
            using var reader = src.Utf8LineReader();
            var line = TextLine.Empty;
            while(reader.Next(out line))
            {
                if(line.IsNonEmpty)
                {
                    var parts = line.Split(Chars.Eq);
                    if(parts.Length == 2)
                    {
                        var left = skip(parts,0);
                        var i = text.index(left, "set");
                        if(i>= 0)
                        {
                            var name = text.trim(text.right(left, i + "set".Length - 1));
                            var value = text.trim(skip(parts,1));
                            dst.Add(new CmdSetExpr(name, value));
                        }
                    }
                }
            }
            return dst.Array();
        }

        public static CmdVars vars(params Pair<string>[] src)
        {
            var dst = new CmdVar[src.Length];
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = skip(src,i);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ref readonly VarPattern pattern(ScriptVarKind vck)
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

        public static ScriptVar var(string name, AsciSymbol prefix, AsciFence fence, @string value = default)
            => new ScriptVar(name,prefix, fence, value);
            
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

        static ReadOnlySeq<VarPattern> Patterns = new VarPattern[]{
            new (ScriptVarKind.None, AsciSymbol.Empty, AsciFence.Empty),
            new (ScriptVarKind.Cmd, AsciSymbol.Empty, (AsciSymbols.Percent, AsciSymbols.Percent)),
            new (ScriptVarKind.Bash, AsciSymbols.Dollar, AsciFence.Empty),
            new (ScriptVarKind.Powershell, AsciSymbols.Dollar, AsciFence.Empty),
            new (ScriptVarKind.MsBuild, AsciSymbols.Dollar, (AsciSymbols.LParen, AsciSymbols.RParen)),
            new (ScriptVarKind.Template, AsciSymbols.Dollar, (AsciSymbols.LBrace, AsciSymbols.RBrace)),
        };
    }
}