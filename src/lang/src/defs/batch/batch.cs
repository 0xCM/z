//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    [ApiHost]
    public partial class Batch : Language<Batch>
    {        
        public Batch()
            : base("bat", "bat")
        {

        }

        public enum SyntaxKind : ushort
        {

        }

        public enum StatmentKind : ushort
        {
            None,

            Set,
        }

        public static bool parse(string src, out SetStatement dst)
        {
            var result = Outcome.Success;
            var parts = text.split(text.trim(src), "=").ToSeq();
            if(parts.Length != 2)
            {
                dst = new();
                result = false;
            }
            else
            {
                dst = new SetStatement(parts[0], parts[1]);
            }
            return result;
        }

        public abstract record class Syntax<S>
            where S : Syntax<S>,new()
        {
            public readonly SyntaxKind Kind;
            
        }

        public abstract record class Statement<S> : Syntax<S>
            where S : Statement<S>, new()
        {
            public new readonly StatmentKind Kind;

            protected Statement(StatmentKind kind)
            {
                Kind = kind;
            }
        }

        public record class SetStatement : Statement<SetStatement>
        {
            public @string Name;

            public @string Value;

            public SetStatement()
                : base(StatmentKind.Set)
            {
                Name = EmptyString;
                Value = EmptyString;
            }

            public SetStatement(@string name, @string value)
                : this()
            {
                Name = name;
                Value = value;
            }
        }
    }
}