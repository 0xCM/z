//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [ApiHost]
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public AsmEtl AsmEtl(IWfRuntime wf)
                => Service<AsmEtl>(wf);

            public AsmDecoder AsmDecoder(IWfRuntime wf)
                => Service<AsmDecoder>(wf);

            public HostAsmEmitter HostAsmEmitter(IWfRuntime wf)
                => Service<HostAsmEmitter>(wf);

            public AsmCallPipe AsmCallPipe(IWfRuntime wf)
                => Service<AsmCallPipe>(wf);

            public ProcessAsmSvc ProcessAsm(IWfRuntime wf)
                => Service<ProcessAsmSvc>(wf);

            public AsmJmpPipe AsmJmpPipe(IWfRuntime wf)
                => Service<AsmJmpPipe>(wf);

            public AsmRowBuilder AsmRowBuilder(IWfRuntime wf)
                => Service<AsmRowBuilder>(wf);

            public ImmSpecializer ImmSpecializer(IWfRuntime wf)
                => Service<ImmSpecializer>(wf);

            public ApiImmEmitter ImmEmitter(IWfRuntime wf)
                => Service<ApiImmEmitter>(wf);
        }

        static Svc Services => Svc.Instance;

        public static AsmEtl AsmEtl(this IWfRuntime wf)
            => Services.AsmEtl(wf);

        public static AsmRowBuilder AsmRowBuilder(this IWfRuntime wf)
            => Services.AsmRowBuilder(wf);

        public static HostAsmEmitter HostAsmEmitter(this IWfRuntime wf)
            => Services.HostAsmEmitter(wf);

        public static AsmJmpPipe AsmJmpPipe(this IWfRuntime wf)
            => Services.AsmJmpPipe(wf);

        public static AsmDecoder AsmDecoder(this IWfRuntime wf)
            => Services.AsmDecoder(wf);

        public static ProcessAsmSvc ProcessAsmSvc(this IWfRuntime wf)
            => Services.ProcessAsm(wf);

        public static AsmCallPipe AsmCallPipe(this IWfRuntime wf)
            => Services.AsmCallPipe(wf);

        public static ImmSpecializer ImmSpecializer(this IWfRuntime wf)
            => Services.ImmSpecializer(wf);

        public static ApiImmEmitter ImmEmitter(this IWfRuntime wf)
            => Services.ImmEmitter(wf);

        public static ICaptureCore CaptureCore(this IWfRuntime wf)
            => Asm.CaptureCore.create(wf);
    }
}