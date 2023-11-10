//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public sealed class InstBlockLines : ConcurrentDictionary<XedInstForm,InstBlockLineSpec>
    {
        public InstBlockLines()
        {

        }

        public bool Add(InstBlockLineSpec src)
            => TryAdd(src.Form,src);

        [MethodImpl(Inline)]
        public InstBlockLines(InstBlockLineSpec[] src)
            : base(src.Select(x => (x.Form,x)).ToDictionary())
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator InstBlockLines(InstBlockLineSpec[] src)
            => new (src);
    }
}
