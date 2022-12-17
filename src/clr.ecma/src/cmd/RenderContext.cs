//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RenderContext
    {
        public static RenderContext create(ITextEmitter dst, uint indent = 0)
            => new RenderContext(dst, indent);

        readonly ITextEmitter Target;

        uint Indent;

        public RenderContext(ITextEmitter dst, uint indent = 0)
        {
            Target = dst;
            Indent = 0;
        }

        void Advance()
            => Indent+=2;

        void Retreat()
            => Indent-=2;

        public void Render(object src)
        {
            if(src != null)
            {
                var type = src.GetType();
                var typename = type.DisplayName();
                var members = type.PublicInstanceFields().ToSeq();
                Target.IndentLine(Indent, Chars.LBrace);
                Advance();
                for(var i=0; i<members.Count; i++)
                {
                    ref readonly var member = ref members[i];
                    var name = member.Name;
                    var value = member.GetValue(src);
                    if(member.FieldType.Reifies(typeof(IEnumerable)))
                    {
                        Target.IndentLine(Indent, $"{member.Name}: {Chars.LBrace}");
                        Advance();
                        foreach(var v in (IEnumerable)(value))
                        {
                            Render(v);
                        }
                        Retreat();
                        Target.IndentLine(Indent,Chars.RBrace);
                    }
                    else
                    {
                        Target.IndentLine(Indent, $"{member.Name}: {value?.ToString() ?? EmptyString}");
                    }
                }
                Retreat();
                Target.IndentLine(Indent, Chars.RBrace);
            }
        }
    }
}