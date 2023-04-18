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
        public ReadOnlySeq<TypeDefRow> ReadTypeDefRows()
        {
            var src = TypeDefHandles();
            var dst = sys.alloc<TypeDefRow>(src.Length);
            for(var i=0; i<src.Length; i++)
            {
                ref var row = ref seek(dst,i);
                ref readonly var handle = ref skip(src,i);
                var def = MD.GetTypeDefinition(handle);
                row.Index = handle;
                row.Attributes = def.Attributes;
                row.TypeName = def.Name;
                row.Namespace = def.Namespace;
                row.Layout = def.GetLayout();
                row.BaseType = def.BaseType;
                var field = def.GetFields().TryGetFirst(x => true);
                if(field)
                    row.FieldList = field.Value;
                var method = def.GetMethods().TryGetFirst(x => true);
                if(method)
                    row.MethodList = method.Value;
            }
            return dst;
        }

        public ReadOnlySeq<EcmaTypeDef> ReadTypeDefs()
        {
            var src = TypeDefHandles();
            var count = src.Length;
            var buffer = alloc<EcmaTypeDef>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var handle = ref skip(src,i);
                var def = MD.GetTypeDefinition(handle);
                ref var dst = ref buffer[i];
                dst.Token = handle;
                dst.Name = String(def.Name);
                dst.Attributes = def.Attributes;
                dst.Assembly = AssemblyKey();
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