//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public PolyBits PolyBits(IWfRuntime wf)
                => Service<PolyBits>(wf);


            public BitfieldServices Bitfields(IWfRuntime wf)
                => Service<BitfieldServices>(wf);
        }

        static Svc Services => Svc.Instance;

        public static PolyBits PolyBits(this IWfRuntime wf)
            => Services.PolyBits(wf);

        public static BitfieldServices Bitfields(this IWfRuntime wf)
            => Services.Bitfields(wf);
    }
}