//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        /// <summary>
        /// D:\env\dev\winmd\win32metadata\sources\MetadataUtils\WinmdUtils.cs
        /// </summary>
        public IEnumerable<DllImportInfo> ReadDllImports()
        {
            foreach (var methodDefHandle in MD.MethodDefinitions)
            {
                var method = MD.GetMethodDefinition(methodDefHandle);
                if (method.Attributes.HasFlag(System.Reflection.MethodAttributes.PinvokeImpl))
                {
                    var name = String(method.Name);
                    var import = method.GetImport();
                    var moduleRef = MD.GetModuleReference(import.Module);
                    var dllName = MD.GetString(moduleRef.Name);
                    var declaringType = MD.GetTypeDefinition(method.GetDeclaringType());
                    var declaringTypeName = String(declaringType.Name);
                    var declaringTypeNamespace = String(declaringType.Namespace);
                    var methodSignature = method.DecodeSignature<string, GenericContext>(GSTP, null);
                    yield return new DllImportInfo(name, dllName, $"{declaringTypeNamespace}.{declaringTypeName}", methodSignature);
                }
            }
        }
    }
}