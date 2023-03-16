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
        public void ReadFieldInfo(FieldDefinitionHandle handle, Action<EcmaFieldInfo> dst)
        {
            var entry = MD.GetFieldDefinition(handle);
            var field = new EcmaFieldInfo();
            field.Token = EcmaTokens.token(handle);
            field.Offset = (uint)entry.GetOffset();
            field.Rva = entry.GetRelativeVirtualAddress();
            field.FieldName = MD.GetString(entry.Name);
            field.Attribs = entry.Attributes;
            field.Sig = ReadSigData(entry);
            dst(field);
        }

        public ReadOnlySpan<EcmaFieldInfo> ReadFieldDefs()
        {
            var handles = MD.FieldDefinitions.ToReadOnlySpan();
            var count = handles.Length;
            var dst = alloc<EcmaFieldInfo>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                ReadFieldInfo(handle, f => seek(dst,i) = f);
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public ref FieldRow Row(FieldDefinitionHandle handle, ref FieldRow dst)
        {
            var src = MD.GetFieldDefinition(handle);
            dst.Attributes = src.Attributes;
            dst.Name = src.Name;
            dst.Sig = src.Signature;
            dst.Offset = (uint)src.GetOffset();
            dst.Marshal = src.GetMarshallingDescriptor();
            return ref dst;
        }

        EcmaName ReadFieldName(StringHandle handle, Count seq)
        {
            var value = MD.GetString(handle);
            var offset = MD.GetHeapOffset(handle);
            var size = MD.GetHeapSize(HeapIndex.String);
            return new EcmaName(seq, size, (Address32)offset, value);
        }
    }
}