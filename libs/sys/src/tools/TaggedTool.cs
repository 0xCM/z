//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TaggedTool : IEquatable<TaggedTool>
    {
        public @string Tool {get;}

        public @string Tag {get;}

        [MethodImpl(Inline)]
        public TaggedTool(string tool, string tag)
        {
            Tool = tool;
            Tag = tag;
        }

        public bool Equals(TaggedTool src)
            => Tool == src.Tool && Tag == src.Tag;

        public override bool Equals(object src)
            => src is TaggedTool t && Equals(t);

        public string Format()
            => string.Format("{0}-{1}", Tool, Tag);

        public override int GetHashCode()
            => Format().GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator TaggedTool((string tool, string tag) src)
            => new TaggedTool(src.tool, src.tag);
    }
}