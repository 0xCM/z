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
        // public void ReadFieldInfo(FieldDefinitionHandle handle, Action<AssemblyField> dst)
        // {
        //     var entry = MD.GetFieldDefinition(handle);
        //     var field = new AssemblyField();
        //     field.Index = handle;
        //     field.Offset = (uint)entry.GetOffset();
        //     field.Rva = entry.GetRelativeVirtualAddress();
        //     field.FieldName = MD.GetString(entry.Name);
        //     field.Attribs = entry.Attributes;
        //     field.Sig = ReadSigData(entry);
        //     dst(field);
        // }

        // public ReadOnlySpan<AssemblyField> ReadFieldInfo()
        // {
        //     var handles = MD.FieldDefinitions.ToReadOnlySpan();
        //     var count = handles.Length;
        //     var dst = alloc<AssemblyField>(count);
        //     for(var i=0u; i<count; i++)
        //     {
        //         ref readonly var handle = ref skip(handles,i);
        //         ReadFieldInfo(handle, f => seek(dst,i) = f);
        //     }
        //     return dst;
        // }

        public ReadOnlySeq<FieldDefRow> ReadFieldDefRows()
        {
            var handles = FieldDefHandles();
            var count = handles.Length;
            var dst = alloc<FieldDefRow>(count);
            for(var i=0; i<count; i++)
            {
                var handle = skip(handles,i);
                var def = MD.GetFieldDefinition(handle);
                ref var row = ref seek(dst,i);
                row.Index = handle;
                row.DeclaringType = def.GetDeclaringType();
                row.Marshal = def.GetMarshallingDescriptor();
                row.Name = def.Name;
                row.Attributes = def.Attributes;
                row.Offset = def.GetOffset();
                row.Sig = def.Signature;                
            }
            return dst;
        }
    }
}