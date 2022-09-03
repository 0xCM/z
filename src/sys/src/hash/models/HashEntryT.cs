//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HashEntry<T> : IComparable<HashEntry<T>>
        where T : IEquatable<T>
    {
        const string TableId = "hashes";

        public uint Seq;

        public Hash32 Code;

        public T Content;

        public int CompareTo(HashEntry<T> src)
            => Seq.CompareTo(src.Seq);
    }
}