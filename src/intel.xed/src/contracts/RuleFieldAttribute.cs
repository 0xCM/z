//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XedRules
    {
        public class RuleFieldAttribute : Attribute
        {
            public RuleFieldAttribute(FieldKind kind, byte width, Type type)
            {
                Kind = kind;
                Width = width;
                EffectiveType = type;
                Description = EmptyString;
            }

            public RuleFieldAttribute(FieldKind kind, byte width, Type type, string desc)
            {
                Kind = kind;
                Width = width;
                EffectiveType = type;
                Description = desc;
            }

            public FieldKind Kind {get;}

            public byte Width {get;}

            public Type EffectiveType {get;}

            public string Description {get;}
        }
    }
}