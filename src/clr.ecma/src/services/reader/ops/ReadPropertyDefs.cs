//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

    partial class EcmaReader
    {
        public ReadOnlySeq<PropertyDef> ReadPropertyDefs()
        {
            var name = AssemblyKey().AssemblyName;
            var handles = PropertyDefHandles();
            var count = handles.Length;
            var buffer = sys.alloc<PropertyDef>(count);
            for(var i=0; i<count; i++)
            {
                var handle = skip(handles,i);
                var def = ReadPropertyDef(handle);
                ref var dst = ref seek(buffer, i);
                dst.Index = handle;
                dst.Name = def.Name;
                dst.Attributes = def.Attributes;
                var accessors = def.GetAccessors();
                var declarer = default(TypeDefinition);
                var declhandle = default(TypeDefinitionHandle);
                if(!accessors.Getter.IsNil)
                {
                    var getter = MD.GetMethodDefinition(accessors.Getter);
                    declhandle = getter.GetDeclaringType();                
                    declarer = MD.GetTypeDefinition(declhandle);
                }
                if(!accessors.Setter.IsNil)
                {
                    var setter = MD.GetMethodDefinition(accessors.Setter);
                    declhandle = setter.GetDeclaringType();                
                    declarer = MD.GetTypeDefinition(declhandle);
                }
                dst.DeclaringType = declhandle;
                dst.Namespace = declarer.Namespace;            
            }
            return buffer;
        }
        
        [MethodImpl(Inline), Op]
        public PropertyDefinition ReadPropertyDef(PropertyDefinitionHandle src)
            => MD.GetPropertyDefinition(src);
    }
}