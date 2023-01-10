//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TextVar : ITextVar
    {
        public static VarKind Kind = new VarKind();

        public sealed class VarKind : PatternTextVar<VarKind>
        {
            public override Fence<char> Fence
                => ((char)SymNotKind.Lt, (char)SymNotKind.Gt);
        }

        public @string Name {get;}

        public string Value;

        [MethodImpl(Inline)]
        public TextVar(string name)
        {
            Name = name;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public TextVar(string name, string val)
        {
            Name = name;
            Value = val;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Value);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Value);
        }

        ITextVarExpr ITextVar.Expr
            => Kind;

        @string IVar<@string>.Value
            => Value;

        public string Format()
            => Vars.format(this);

        public override string ToString()
            => Format();
    }
}