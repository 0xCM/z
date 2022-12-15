//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

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
            // var src = MD.TypeDefinitions.ToReadOnlySpan();
            // var count = src.Length;
            // var dst = alloc<TypeDefinition>(count);
            // Read(src, dst);
            // return dst;
        }

        [MethodImpl(Inline), Op]
        public void Read(ReadOnlySpan<TypeDefinitionHandle> src, Span<TypeDefinition> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = Read(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public TypeDefinition Read(TypeDefinitionHandle src)
            => MD.GetTypeDefinition(src);
    }
}