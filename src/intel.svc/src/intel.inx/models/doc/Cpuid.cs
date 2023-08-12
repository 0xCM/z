//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class IntrinsicsDoc
{
    public readonly record struct CpuId : IComparable<CpuId>
    {
        public const string ElementName = "CPUID";

        public readonly string Content;

        [MethodImpl(Inline)]
        public CpuId(string src)
        {
            Content = src;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Content);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Content.GetHashCode();
        }

        public override int GetHashCode()
            => Hash;

        public int CompareTo(CpuId src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public bool Equals(CpuId src)
            => Content == src.Content;

        public string Format()
            => Content;

        public override string ToString()
            => Content;

        [MethodImpl(Inline)]
        public static implicit operator CpuId(string src)
            => new CpuId(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CpuId src)
            => src.Format();
    }
}
