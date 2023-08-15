//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class IntrinsicsDoc
    {
        static string[] Modifiers = new string[]{"const", "unsigned"};

        static bool IsModifier(string src)
        {
            var result = false;
            foreach(var m in Modifiers)
            {
                result = src == m;
                if(result)
                    break;
            }
            return result;
        }

        static IEnumerable<string> modifiers(string expr)
        {
            var parts = text.trim(text.trim(text.split(expr, Chars.Space)));
            foreach(var part in parts)
            {
                if(IsModifier(part))
                    yield return part;
            }
        }

        static string format(Parameter src)
        {
            var type = text.trim(text.despace(src.type.Format()));
            var parts = text.trim(text.split(text.remove(type, Chars.Star), Chars.Space));
            var mods = text.join(Chars.Space, modifiers(src.type).Array());            
            var sig = mods;
            foreach(var part in parts)
            {
                if(IsModifier(part))
                    continue;

                if(text.nonempty(sig))
                    sig += $" {part}";
                else
                    sig += part;
            }

            if(src.IsPointer)
                sig += "*";

            return string.Format("{0} {1}",sig, src.varname);
        }
    }
}