//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {            
        public void ReadTypeRefs()
        {
            foreach(var src in TypeRefHandles().Select(ReadTypeRef))
            {
                switch(src.ResolutionScope.Kind)
                {
                    case HandleKind.ExportedType:
                    break;
                    case HandleKind.TypeReference:
                    break;
                    case HandleKind.ModuleReference:
                    break;
                    case HandleKind.ModuleDefinition:
                    break;
                    case HandleKind.AssemblyReference:
                    break;

                }
            }
        }
        
        [MethodImpl(Inline), Op]
        public TypeReference ReadTypeRef(TypeReferenceHandle src)
            => MD.GetTypeReference(src);        
    }
}