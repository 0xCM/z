//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public static MethodSignature<string> sig(MethodDefinition src)
            => src.DecodeSignature<string, GenericContext>(EcmaReader._GSTP, null);

        public ParallelQuery<EcmaMethodImport> ReadMethodImports()
            => from handle in MD.MethodDefinitions.AsParallel()
                let method = MD.GetMethodDefinition(handle)
                where IsPinvoke(method)
                select ReadMethodImport(method);

        public EcmaMethodImport ReadMethodImport(MethodDefinition src)
        {
            var dst = EcmaMethodImport.Empty;
            Require.invariant(IsPinvoke(src));
            var import = src.GetImport();
            var moduleRef = MD.GetModuleReference(import.Module);
            var declaringType = MD.GetTypeDefinition(src.GetDeclaringType());
            dst.TargetName = String(import.Name);
            dst.MethodName = String(src.Name);
            dst.Library = String(moduleRef.Name);
            dst.DeclaringType = $"{String(declaringType.Namespace)}.{String(declaringType.Name)}";
            dst.MethodSignature = src.DecodeSignature<string, GenericContext>(_GSTP, null);
            return dst;            
        }
    }
}