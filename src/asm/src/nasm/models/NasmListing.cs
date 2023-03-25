//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct NasmListing : IRenderCapable<NasmListing>
    {
        public FilePath Source {get;}

        public Index<NasmListLine> Lines {get;}

        [MethodImpl(Inline)]
        public NasmListing(FilePath src, Index<NasmListLine> lines)
        {
            Source = src;
            Lines = lines;
        }

        public void Render(ITextBuffer dst)
        {
            var src = Lines.View;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                dst.AppendLine(line.Format());
            }
        }

        public uint LineCount
        {
            [MethodImpl(Inline)]
            get => Lines.Count;
        }

        [MethodImpl(Inline)]
        public ref readonly NasmListLine Line(uint number)
        {
            ref readonly var line =  ref Lines[number - 1];
            return ref line;
        }

        public string Format()
            => RenderCapable.format(this);


        public override string ToString()
            => Format();
    }
}