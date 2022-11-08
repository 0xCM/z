//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedImport
    {
        public sealed class InstBlockLines : ConcurrentDictionary<InstForm,InstBlockLineSpec>
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
                => new InstBlockLines(src);
        }
    }
}