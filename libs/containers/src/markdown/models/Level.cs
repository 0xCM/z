//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct Level : IElement<Level>
        {
            public readonly byte Depth;

            public readonly DepthIndicator Indicator;

            [MethodImpl(Inline)]
            public Level(byte depth, DepthIndicator i)
            {
                Depth = depth;
                Indicator = i;
            }

            public string Format()
                => new string((char)Indicator, Depth);

            public override string ToString()
                => Format();
        }
    }
}