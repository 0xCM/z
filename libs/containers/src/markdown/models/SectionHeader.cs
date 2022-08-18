//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct SectionHeader : ISectionHeader<SectionHeader>
        {
            public readonly Level Level;

            public readonly Name Name;

            [MethodImpl(Inline)]
            public SectionHeader(byte depth, Name name)
            {
                Level = new Level(depth, DepthIndicator.Hash);
                Name = name;
            }

            public string Format()
                => string.Format("{0} {1}", Level, Name);

            public override string ToString()
                => Format();

            Name INamed.Name
                => Name;

            Level ILeveled.Level
                => Level;
        }
    }
}