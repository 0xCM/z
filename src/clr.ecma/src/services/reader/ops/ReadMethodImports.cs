//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public IEnumerable<EcmaMethodImport> ReadMethodImports()
        {
            foreach (var methodDefHandle in MD.MethodDefinitions)
            {
                var method = MD.GetMethodDefinition(methodDefHandle);
                if (IsPinvoke(method))
                    yield return ReadMethodImport(method);
            }
        }

        public EcmaMethodImport ReadMethodImport(MethodDefinition src)
        {
            var dst = EcmaMethodImport.Empty;
            try
            {
                if(IsPinvoke(src))
                {
                    var import = src.GetImport();
                    var moduleRef = MD.GetModuleReference(import.Module);
                    var declaringType = MD.GetTypeDefinition(src.GetDeclaringType());
                    dst.TargetName = String(import.Name);
                    dst.MethodName = String(src.Name);
                    dst.Library = String(moduleRef.Name);
                    dst.DeclaringType = $"{String(declaringType.Namespace)}.{String(declaringType.Name)}";
                    dst.MethodSignature = src.DecodeSignature<string, GenericContext>(GSTP, null);
                }
            }
            catch(Exception)
            {
                term.warn($"Reading import for {AssemblyKey()}::{src.Name} failed");
            }

            return dst;            
        }
    }
}