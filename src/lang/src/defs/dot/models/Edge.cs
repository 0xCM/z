//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Dot
{
    public record class Edge : Statement
    {
        public readonly Node Source;

        public readonly ReadOnlySeq<Node> Targets;

        public Edge(Node src, params Node[] dst)
        {
            Source = src;
            Targets = dst;
        }

        protected virtual string EdgeGlyph => "--";

        public override string Format()
        {
            var dst = text.emitter();
            dst.Append(Source.Format());
            if(Targets.IsNonEmpty)
            {
                dst.Append($" {EdgeGlyph} ");
                if(Targets.Count > 1)
                    dst.Append(Chars.LBrace);

                for(var i=0; i<Targets.Count; i++)
                {
                    if(i > 1)
                        dst.Append($", ");
                    
                    dst.Append(Targets[i].Format());
                }

                if(Targets.Count > 1)
                    dst.Append(Chars.RBrace);

            }
            return dst.Emit();
        }
    }

}
