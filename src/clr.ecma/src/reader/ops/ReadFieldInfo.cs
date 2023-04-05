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

        public ReadOnlySpan<EcmaFieldInfo> ReadFieldInfo()
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
        public FieldDefRow ReadFieldDefRow(FieldDefinitionHandle handle)
        {
            var dst = new FieldDefRow();            
            var def = MD.GetFieldDefinition(handle);
            dst.Attributes = def.Attributes;
            var type = MD.GetTypeDefinition(def.GetDeclaringType());
            dst.Name = def.Name;
            dst.Sig = def.Signature;
            dst.Offset = (uint)def.GetOffset();
            dst.Marshal = def.GetMarshallingDescriptor();
            return dst;
        }

    }
}