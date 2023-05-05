//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe class CellWriter<S> : IDisposable
        where S : unmanaged
    {
        readonly BinaryWriter Writer;
        
        readonly bool OwnsResources;

        public CellWriter(BinaryWriter writer, bool owns)
        {
            Writer = writer;
            OwnsResources = owns;
        }

        [MethodImpl(Inline)]
        void Write(in PinnedPtr<S> src, uint count)
        {
            Writer.Write(recover<S,char>(cover(src.First,count)));
            src.Dispose();
        }

        public Task BeginWrite(ReadOnlySpan<S> src)
        {
            ref readonly var _ref = ref src.GetPinnableReference();
            var pin = Pins.pointer<S>(_ref);
            var count = (uint)src.Length;
            return start(() => Write(pin,count));                
        }

        public void Write(ReadOnlySpan<S> src)
            => Writer.Write(recover<S,char>(src));

        public void Dispose()
        {
            if(OwnsResources)
                Writer.Dispose();
        }
    }
}