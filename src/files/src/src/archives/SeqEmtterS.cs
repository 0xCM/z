//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public unsafe class SeqEmitter<S>
        where S : unmanaged
    {
        readonly TextWriter Writer;
        
        readonly bool OwnsResources;

        public SeqEmitter()
        {
            Writer = Console.Out;
            OwnsResources = false;
        }

        public SeqEmitter(TextWriter writer, bool owns)
        {
            Writer = writer;
            OwnsResources = owns;
        }

        void Write(PinnedPtr<S> src, uint count)
        {
            Writer.Write(recover<S,char>(cover(src.First,count)));
            src.Dispose();
        }

        public Task BeginWrite(ReadOnlySpan<S> src)
        {
            ref readonly var _ref = ref src.GetPinnableReference();
            var pin = memory.pin<S>(_ref);
            var count = (uint)src.Length;
            return start(() => Write(pin,count));                
        }

        public void Write(ReadOnlySpan<S> src)
            => Writer.Write(recover<S,char>(src));

        public void Dispose()
        {
            
        }
    }
}