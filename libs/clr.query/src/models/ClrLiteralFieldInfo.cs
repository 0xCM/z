//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ClrLiteralFieldInfo : ClrFieldInfo
    {
        public ClrLiteralKind LiteralKind;

        public dynamic Value;

        public ClrLiteralFieldInfo(Identifier name, ClrLiteralKind kind, dynamic value, TextBlock desc)
        {
            Name = name;
            LiteralKind = kind;
            FieldType = kind.CsKeyword();
            Value = value;
            Description = desc;
            Access = ClrAccessKind.Public;
            Modifiers = ClrModifierKind.Const;
        }
    }
    
}