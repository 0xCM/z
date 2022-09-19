//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedForms
    {
        public static string symbolize(FormTokenKind kind, string part)
        {
            var dst = part;
            var atoms = TokenData.Names(kind);
            foreach(var atom in atoms)
            {
                if(part.EndsWith(atom))
                {
                    dst = dst.Replace(atom, string.Format(".{0}", atom));
                    break;
                }
                else if(part.StartsWith(atom))
                {
                    dst = dst.Replace(atom, string.Format("{0}.", atom));
                    break;
                }

            }
            return dst;
        }
    }
}