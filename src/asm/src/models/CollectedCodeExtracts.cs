//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;

    public class CollectedCodeExtracts : IEnumerable<CollectedCodeExtract>
    {
        readonly List<CollectedCodeExtract> Data;

        public CollectedCodeExtracts(params CollectedCodeExtract[] src)
        {
            Data = new(src);
        }

        public IEnumerator<CollectedCodeExtract> GetEnumerator()
            => ((IEnumerable<CollectedCodeExtract>)Data).GetEnumerator();

        public void Include(CollectedCodeExtract src)
            => Data.Add(src);

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)Data).GetEnumerator();

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public static CollectedCodeExtracts Empty => new (sys.empty<CollectedCodeExtract>());
    }
}