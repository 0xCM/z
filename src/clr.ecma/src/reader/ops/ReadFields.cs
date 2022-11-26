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
        [MethodImpl(Inline), Op]
        public FieldDefinition ReadFieldDef(FieldDefinitionHandle src)
            => MD.GetFieldDefinition(src);

        public ReadOnlySpan<Field> ReadFields()
        {
            var reader = MD;
            var handles = reader.FieldDefinitions.ToReadOnlySpan();
            var count = handles.Length;
            var dst = span<Field>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                var entry = reader.GetFieldDefinition(handle);
                ref var field = ref seek(dst,i);
                field.Token = EcmaTokens.token(handle);
                field.Offset = (uint)entry.GetOffset();
                field.Rva = entry.GetRelativeVirtualAddress();
                field.FieldName = MD.GetString(entry.Name);
                field.Attribs = entry.Attributes;
                field.Sig = ReadSigData(entry);
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public ref EcmaFieldInfo Row(FieldDefinitionHandle handle, ref EcmaFieldInfo dst)
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

        public uint Rows(ReadOnlySpan<FieldDefinitionHandle> src, Span<EcmaFieldInfo> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                 Row(skip(src,i), ref seek(dst,i));
            return count;
        }

        public ReadOnlySpan<EcmaFieldInfo> Rows(ReadOnlySpan<FieldDefinitionHandle> src)
        {
            var count = (uint)src.Length;
            var dst = span<EcmaFieldInfo>(count);
            Rows(src,dst);
            return dst;
        }

    }
}