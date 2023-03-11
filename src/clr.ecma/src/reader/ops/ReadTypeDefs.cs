//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {
        public ReadOnlySeq<TypeDefInfo> ReadTypeDefs()
        {
            var src = TypeDefHandles();
            var count = src.Length;
            var buffer = alloc<TypeDefInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var handle = ref skip(src,i);
                var def = MD.GetTypeDefinition(handle);
                ref var dst = ref buffer[i];
                dst.Token = handle;
                dst.Name = String(def.Name);
                dst.Attributes = def.Attributes;
                if(def.IsNested)
                {
                    var declarer = MD.GetTypeDefinition(def.GetDeclaringType());
                    dst.DeclaringType = String(declarer.Name);
                    dst.Namespace = String(declarer.Namespace);                    
                }
                else
                {
                    dst.Namespace = String(def.Namespace);
                }

                var @base = def.BaseType;
                if(!def.BaseType.IsNil)
                {
                    switch((@base.Kind))
                    {
                        case HandleKind.TypeDefinition: 
                        {
                            dst.BaseName = String(MD.GetTypeDefinition((TypeDefinitionHandle)def.BaseType).Name);
                        }                                                       
                        break;
                        case HandleKind.TypeReference:
                        {
                            dst.BaseName = String(MD.GetTypeReference((TypeReferenceHandle)def.BaseType).Name);
                        }
                        break;
                    }
                }

                var full = dst.Name;                        
                if(dst.DeclaringType.IsNonEmpty)
                    full = $"{dst.DeclaringType}.{full}";
                if(dst.Namespace.IsNonEmpty)
                    full = $"{dst.Namespace}.{full}";
                dst.FullName = full;

            }
            return buffer;
        }
    }
}