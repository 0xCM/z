//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public class ScriptVars
    {
        const NumericKind Closure = UnsignedInts;

       public static string format<T>(ScriptVar<T> src)
            where T : IEquatable<T>, IComparable<T>, new()
        {
            var dst = EmptyString;
            if(src.IsPrefixedFence)
                dst = $"{src.Prefix}{src.Fence.Left}{src.VarName}{src.Fence.Right}";
            else if(src.IsPrefixed)
                dst = $"{src.Prefix}{src.VarName}";
            else if(src.IsFenced)
                dst = $"{src.Fence.Left}{src.VarName}{src.Fence.Right}";
            else
                dst = src.Format();
            return dst;            
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