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
        // public ReadOnlySeq<TypeDefRow> ReadTypeDefRows()
        // {
        //     var src = TypeDefHandles();
        //     var dst = sys.alloc<TypeDefRow>(src.Length);
        //     for(var i=0; i<src.Length; i++)
        //     {
        //         ref var row = ref seek(dst,i);
        //         ref readonly var handle = ref skip(src,i);
        //         var def = MD.GetTypeDefinition(handle);
        //         row.Index = handle;
        //         row.Attributes = def.Attributes;
        //         row.TypeName = def.Name;
        //         row.Namespace = def.Namespace;
        //         row.Layout = ReadTypeLayout(handle);
        //         row.BaseType = def.BaseType;
        //         var field = def.GetFields().TryGetFirst(x => true);
        //         if(field)
        //             row.FieldList = field.Value;
        //         var method = def.GetMethods().TryGetFirst(x => true);
        //         if(method)
        //             row.MethodList = method.Value;
        //     }
        //     return dst;
        // }


    }
}