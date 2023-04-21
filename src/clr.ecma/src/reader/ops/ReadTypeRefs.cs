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
        public ReadOnlySeq<TypeRefRow> ReadTypeRefs()
        {
            var handles = TypeRefHandles();
            var count = handles.Length;
            var dst = alloc<TypeRefRow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                ref var row = ref seek(dst,i);
                var typeref = MD.GetTypeReference(handle);
                row.Index = handle;
                row.ResolutionScope = typeref.ResolutionScope;
                row.TypeName = typeref.Name;
                row.TypeNamespace = typeref.Namespace;                
            }
            return dst;            
        }        
    }
}