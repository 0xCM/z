//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public uint ReadStrings(EcmaStringKind kind, List<string> dst)
            => kind switch {
                EcmaStringKind.User => ReadUserStrings(dst),
                EcmaStringKind.System => ReadSystemStrings(dst),
                _ => 0u
            };

        uint ReadUserStrings(List<string> dst)
        {
            var counter = 0u;
            int size = HeapSize(HeapIndex.UserString);
            if (size == 0)
                return counter;

            var handle = MetadataTokens.UserStringHandle(0);
            do
            {
                dst.Add(Read(handle));
                counter++;
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return counter;
        }

        uint ReadSystemStrings(List<string> dst)
        {
            var counter = 0u;
            int size = HeapSize(HeapIndex.String);
            if (size == 0)
                return counter;

            var handle = MetadataTokens.StringHandle(0);
            do
            {
                dst.Add(Read(handle));
                counter++;
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return counter;
        }
    }
}