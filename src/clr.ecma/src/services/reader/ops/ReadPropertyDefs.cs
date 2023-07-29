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
        public IEnumerable<PropertyDef> ReadPropertyDefs()
        {
            var handles = PropertyDefHandles();
            foreach(var handle in handles)
            {
                var def = ReadPropertyDef(handle);
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

                yield return new PropertyDef{
                    Index = handle,
                    Name = def.Name,
                    Attributes = def.Attributes,
                    DeclaringType = declhandle,
                    Namespace = declarer.Namespace
                };
            }
        }
        
        [MethodImpl(Inline), Op]
        public PropertyDefinition ReadPropertyDef(PropertyDefinitionHandle src)
            => MD.GetPropertyDefinition(src);
    }
}