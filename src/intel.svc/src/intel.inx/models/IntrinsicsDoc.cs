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

        static string format(Parameter src)
        {
            var parts = text.trim(text.split(text.remove(src.type.Format(), Chars.Star), Chars.Space));
            var sig = EmptyString;
            var modifiers = EmptyString;
            for(var i=0; i<parts.Length; i++)
            {
                var part = parts[i];
                if(IsModifier(part))
                {
                    if(text.nonempty(modifiers))
                        modifiers += $" {part}";
                    else
                        modifiers = part;
                }
                else
                {
                    if(i != 0)
                        sig += $" {part}";
                    else
                        sig += part;
                }
            }

            if(src.IsPointer)
                sig += "*";

            return string.Format("{0} {1}", text.nonempty(modifiers) ? $"{modifiers} {sig}" : sig, src.varname);
        }
    }
}