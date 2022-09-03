//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CsModels
    {
        public class CsOperand
        {
            public static CsOperand define(Identifier type, Identifier name, params string[] mods)
                => new CsOperand(type, name, mods);

            public CsOperand(Identifier type, Identifier name, params string[] mods)
            {
                Type = type;
                Name = name;
                ArgMods = mods;
                TypeMods = sys.empty<string>();
            }

            public readonly Identifier Type;

            public readonly Identifier Name;

            public readonly Index<string> ArgMods;

            public readonly Index<string> TypeMods;

            public string Format()
            {
                if(ArgMods.IsEmpty && TypeMods.IsEmpty)
                    return string.Format("{0} {1}", Type, Name);
                else if(ArgMods.IsNonEmpty && TypeMods.IsNonEmpty)
                    return string.Format("{0} {1} {2} {3}", ArgMods, Type, TypeMods.Delimit(Chars.Space), Name);
                else
                {
                    if(ArgMods.IsNonEmpty)
                        return string.Format("{0} {1} {2}", ArgMods, Type, Name);
                    else
                        return string.Format("{0} {1} {2}", Type, TypeMods.Delimit(Chars.Space), Name);
                }
            }

            public override string ToString()
                => Format();
        }
    }
}