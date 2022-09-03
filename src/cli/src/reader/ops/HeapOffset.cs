//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CliReader
    {
        [MethodImpl(Inline), Op]
        public Address32 HeapOffset(UserStringHandle handle)
            => (Address32)MD.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public Address32 HeapOffset(BlobHandle handle)
            => (Address32)MD.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public Address32 HeapOffset(StringHandle handle)
            => (Address32)MD.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public Address32 HeapOffset(GuidHandle handle)
            => (Address32)MD.GetHeapOffset(handle);
    }
}