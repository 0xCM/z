//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaModels;

    public record struct TypeDefInfo
    {
        public @string Name;

        public TypeAttributes Attributes;
    }

    partial class EcmaReader
    {
        [Op]
        public void ReadTypeDefs(Action<TypeDefInfo> dst)
        {
            var info = new TypeDefInfo();
            iter(MD.TypeDefinitions, handle => {
                var src = MD.GetTypeDefinition(handle);
                info.Name = String(src.Name);
                info.Attributes = src.Attributes;
                var @base = src.BaseType;
                if(!@base.IsNil)
                {
                    
                }
                dst(info);
            });
        }

        [MethodImpl(Inline), Op]
        public TypeDefinition Read(TypeDefinitionHandle src)
            => MD.GetTypeDefinition(src);
    }
}