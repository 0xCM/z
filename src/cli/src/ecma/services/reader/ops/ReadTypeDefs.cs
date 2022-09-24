//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [Op]
        public ReadOnlySpan<TypeDefinitionHandle> TypeDefHandles()
            => MD.TypeDefinitions.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<TypeDefinition> ReadTypeDefs()
        {
            var src = TypeDefHandles();
            var count = src.Length;
            var dst = alloc<TypeDefinition>(count);
            Read(src,dst);
            return dst;
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