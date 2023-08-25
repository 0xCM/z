//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly record struct HeapIndex
        {
            public readonly EcmaHeap Blobs;

            public readonly EcmaHeap Guids;

            public readonly EcmaHeap SystemStrings;

            public readonly EcmaHeap UserStrings;
        }
    }

}