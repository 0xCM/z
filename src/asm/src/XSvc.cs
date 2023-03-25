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

            public ApiCapture ApiCapture(IWfRuntime wf)
                => Service<ApiCapture>(wf);

            public AsmCmdService AsmCmdSvc(IWfRuntime wf)
                => Service<AsmCmdService>(wf);

            public AsmTables AsmTables(IWfRuntime wf)
                => Service<AsmTables>(wf);

            public AsmCoreCmd AsmCoreCmd(IWfRuntime wf)
                => Service<AsmCoreCmd>(wf);

            public StanfordAsmCatalog StanfordCatalog(IWfRuntime wf)
                => Service<StanfordAsmCatalog>(wf);

            public AsmDocs AsmDocs(IWfRuntime wf)
                => Service<AsmDocs>(wf);

            public CultProcessor CultProcessor(IWfRuntime wf)
                => Service<CultProcessor>(wf);
 
            public AsmFlowCmd AsmFlowCmd(IWfRuntime wf)
                => Service<AsmFlowCmd>(wf);

            public AsmDbCmd AsmDbCmd(IWfRuntime wf)
                => Service<AsmDbCmd>(wf);

            public NasmCatalog NasmCatalog(IWfRuntime wf)
                => Service<NasmCatalog>(wf);

            public AsmGenCmd AsmGenCmd(IWfRuntime wf)
                => Service<AsmGenCmd>(wf);

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

        public static ICaptureCore CaptureCore(this IWfRuntime wf)
            => Asm.CaptureCore.create(wf);

        public static ApiCapture ApiCapture(this IWfRuntime wf)
            => Services.ApiCapture(wf);

        public static AsmCmdService AsmCmdSvc(this IWfRuntime wf)
            => Services.AsmCmdSvc(wf);

        public static AsmCoreCmd AsmCoreCmd(this IWfRuntime wf)
            => Services.AsmCoreCmd(wf);

        public static AsmTables AsmTables(this IWfRuntime wf)
            => Services.AsmTables(wf);

         public static StanfordAsmCatalog StanfordCatalog(this IWfRuntime wf)
            => Services.StanfordCatalog(wf);

         public static AsmDocs AsmDocs(this IWfRuntime wf)
            => Services.AsmDocs(wf);

         public static AsmFlowCmd AsmFlowCmd(this IWfRuntime wf)
           => Services.AsmFlowCmd(wf);

         public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Services.CultProcessor(wf);

         public static AsmDbCmd AsmDbCmd(this IWfRuntime wf)
            => Services.AsmDbCmd(wf);

         public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Services.NasmCatalog(wf);

        public static AsmGenCmd AsmGenCmd(this IWfRuntime wf)
            => Services.AsmGenCmd(wf);             
    }
}