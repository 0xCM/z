//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaModels;

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
                var def = ReadTypeDef(handle);
                ref var dst = ref buffer[i];
                dst.Token = handle;
                dst.Name = String(def.Name);
                dst.Attributes = def.Attributes;
                var @base = def.BaseType;
                if(!@base.IsNil)
                {
                    switch((@base.Kind))
                    {
                        case HandleKind.TypeDefinition: 
                        {
                            var pdef = ReadTypeDef((TypeDefinitionHandle)@base);
                            dst.BaseName = String(pdef.Name);
                            
                        }                                                       
                        break;
                        case HandleKind.TypeReference:
                        {
                            var tref = ReadTypeRef((TypeReferenceHandle)@base);
                            dst.BaseName = String(tref.Name);
                        }
                        break;
                        case HandleKind.TypeSpecification:
                        {
                            var tspec = ReadTypeSpec((TypeSpecificationHandle)@base);
                            dst.BaseName = tspec.Signature.ToString();
                        }
                        break;
                    }
                }                
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public TypeSpecification ReadTypeSpec(TypeSpecificationHandle src)
            => MD.GetTypeSpecification(src);

        [MethodImpl(Inline), Op]
        public TypeDefinition ReadTypeDef(TypeDefinitionHandle src)
            => MD.GetTypeDefinition(src);
    }
}