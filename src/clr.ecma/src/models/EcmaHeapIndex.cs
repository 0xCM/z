//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public readonly record struct EcmaHeapIndex
    {
        public readonly EcmaHeap Blobs;

        public readonly EcmaHeap Guids;

        public readonly EcmaHeap SystemStrings;

        public readonly EcmaHeap UserStrings;
    }
}