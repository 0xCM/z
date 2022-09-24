//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public ReadOnlySpan<CliMemberField> ReadFieldInfo()
        {
            var reader = MD;
            var handles = reader.FieldDefinitions.ToReadOnlySpan();
            var count = handles.Length;
            var dst = span<CliMemberField>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                var entry = reader.GetFieldDefinition(handle);
                ref var field = ref seek(dst,i);
                field.Token = Clr.token(handle);
                field.Offset = (uint)entry.GetOffset();
                field.Rva = entry.GetRelativeVirtualAddress();
                field.FieldName = MD.GetString(entry.Name);
                field.Attribs = entry.Attributes;
                field.Sig = ReadSig(entry);
            }
            return dst;
        }

        CliFieldName ReadFieldName(StringHandle handle, Count seq)
        {
            var value = MD.GetString(handle);
            var offset = MD.GetHeapOffset(handle);
            var size = MD.GetHeapSize(HeapIndex.String);
            return new CliFieldName(seq, size, (Address32)offset, value);
        }
    }
}