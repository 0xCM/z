//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class IntrinsicsDoc
{
    public class CpuIdMembership : List<CpuId>
    {
        public bool IsEmpty => Count == 0;

        public bool IsNonEmpty => Count != 0;

        public string Format()
            => this.Delimit().Format();

        public override string ToString()
            => Format();

        public static CpuIdMembership Empty => new();
    }
}
