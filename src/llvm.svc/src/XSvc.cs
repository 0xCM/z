//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using llvm;

    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public ProjectSvc ProjectSvc(IWfRuntime wf)
                => Service<ProjectSvc>(wf);

            public LlvmDataProvider LlvmDataProvider(IWfRuntime wf)
                => Service<LlvmDataProvider>(wf);

            public LlvmDataEmitter LlvmDataEmitter(IWfRuntime wf)
                => Service<LlvmDataEmitter>(wf);

            public LlvmDataCalcs LlvmDataCalcs(IWfRuntime wf)
                => Service<LlvmDataCalcs>(wf);

            public LlvmTableLoader LlvmTableLoader(IWfRuntime wf)
                => Service<LlvmTableLoader>(wf);

            public LlvmCmd LlvmCmd(IWfRuntime wf)
                => Service<LlvmCmd>(wf);

            public LlvmDataImporter LlvmDataImporter(IWfRuntime wf)
                => Service<LlvmDataImporter>(wf);

            public LlvmPaths LlvmPaths(IWfRuntime wf)
                => Service<LlvmPaths>(wf);

            public LlvmCodeGen LlvmCodeGen(IWfRuntime wf)
                => llvm.LlvmCodeGen.create(wf);

            public ProjectCmd ProjectCmd(IWfRuntime wf)
                => Service<ProjectCmd>(wf);

            public LlvmLineMaps LlvmLineMaps(IWfRuntime wf)
                => Service<LlvmLineMaps>(wf);

             public LlvmConfigSvc LlvmConfig(IWfRuntime wf)
                => Service<LlvmConfigSvc>(wf);
        }

        static Svc Services = Svc.Instance;

        public static ProjectCmd ProjectCmd(this IWfRuntime wf)
            => Services.ProjectCmd(wf);

        public static LlvmCodeGen LlvmCodeGen(this IWfRuntime wf)
            => Services.LlvmCodeGen(wf);

        public static ProjectSvc ProjectSvc(this IWfRuntime wf)
            => Services.ProjectSvc(wf);


        public static LlvmDataProvider LlvmDataProvider(this IWfRuntime wf)
            => Services.LlvmDataProvider(wf);

        public static LlvmDataEmitter LlvmDataEmitter(this IWfRuntime wf)
            => Services.LlvmDataEmitter(wf);

        public static LlvmDataCalcs LlvmDataCalcs(this IWfRuntime wf)
            => Services.LlvmDataCalcs(wf);

        public static LlvmTableLoader LlvmTableLoader(this IWfRuntime wf)
            => Services.LlvmTableLoader(wf);

        public static LlvmLineMaps LlvmLineMaps(this IWfRuntime wf)
            => Services.LlvmLineMaps(wf);

        public static LlvmCmd LlvmCmd(this IWfRuntime wf)
            => Services.LlvmCmd(wf);

        public static LlvmDataImporter LlvmDataImporter(this IWfRuntime wf)
            => Services.LlvmDataImporter(wf);

        public static LlvmPaths LlvmPaths(this IWfRuntime wf)
            => Services.LlvmPaths(wf);

        public static LlvmConfigSvc LlvmConfig(this IWfRuntime wf)
            => Services.LlvmConfig(wf);
    }
}