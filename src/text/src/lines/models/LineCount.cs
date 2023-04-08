//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineCount : IComparable<LineCount>
    {
        public readonly FileUri Source {get;}

        public readonly Count Lines {get;}

        [MethodImpl(Inline)]
        public LineCount(FileUri src, Count lines)
        {
            Source = src;
            Lines = lines;
        }

        public string Format()
            => string.Format("{0:D6}:{1}", (uint)Lines, Source);

        public override string ToString()
            => Format();

        public int CompareTo(LineCount src)
            =>  Source.CompareTo(src.Source);
    }
}