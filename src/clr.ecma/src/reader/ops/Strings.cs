//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public string String(UserStringHandle handle)
            => MD.GetUserString(handle);

        [MethodImpl(Inline), Op]
        public string String(DocumentNameBlobHandle handle)
            => MD.GetString(handle);

        [MethodImpl(Inline), Op]
        public string String(StringHandle src)
            => MD.GetString(src);

        public uint Strings(EcmaStringKind kind, List<string> dst)
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
                dst.Add(String(handle));
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
                dst.Add(String(handle));
                counter++;
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return counter;
        }
    }
}