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
        public ReadOnlySeq<EcmaMethodDef> ReadMethodDefs()
        {
            var handles = MethodDefHandles();
            var count = handles.Length;
            var buffer = alloc<EcmaMethodDef>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var handle = ref skip(handles,i);
                ReadMethodDef(handle, ref dst);
            }

            return buffer;
        }

        void ReadMethodDef(MethodDefinitionHandle handle, ref EcmaMethodDef dst)        
        {
            var src = MD.GetMethodDefinition(handle);
            dst.Token= EcmaTokens.token(handle);
            dst.Attributes = src.Attributes;
            dst.ImplAttributes = src.ImplAttributes;
            dst.Name = String(src.Name);
            dst.Rva = src.RelativeVirtualAddress;                
        }
 
        public ReadOnlySeq<EcmaPinvokeMethodDef> ReadPinvokeMethodDefs()
        {
            var buffer = list<EcmaPinvokeMethodDef>();
            var handles = MethodDefHandles();
            for(var i=0; i<handles.Length; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                var method = MD.GetMethodDefinition(handle);
                if(IsPinvoke(method))
                {
                    var dst = new EcmaPinvokeMethodDef();
                    var _dst = (EcmaMethodDef)dst;
                    ReadMethodDef(handle, ref _dst);
                    dst.Import = ReadMethodImport(method);
                    buffer.Add(dst);
                }
            }
            return buffer.ToArray();            
        }

        public ReadOnlySpan<MethodRelations> ReadMethodDefRows()
        {
            var src = MethodDefHandles();
            var count = src.Length;
            var dst = alloc<MethodRelations>(count);
            Read(src,dst);
            return dst;
        }

        public uint Read(ReadOnlySpan<MethodDefinitionHandle> src, Span<MethodRelations> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                 Read(skip(src,i), ref seek(dst,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public ref MethodRelations Read(MethodDefinitionHandle handle, ref MethodRelations dst)
        {
            var src = MD.GetMethodDefinition(handle);
            dst.Token = EcmaTokens.token(handle);
            dst.Attributes = src.Attributes;
            dst.ImplAttributes  = src.ImplAttributes;
            dst.Rva = src.RelativeVirtualAddress;
            dst.NameKey = src.Name;
            dst.SigKey = src.Signature;
            var keys = ReadParameterRowKeys(src.GetParameters());
            var count = keys.Count;
            if(count != 0)
            {
                dst.FirstParam = keys.First;
                dst.ParamCount = (ushort)count;
            }

            return ref dst;
        }

        public MethodDefinition ReadMethodDef(MethodDefinitionHandle handle)
            => MD.GetMethodDefinition(handle);

        public ReadOnlySeq<EcmaMethodInfo> ReadMethodDefInfo()
        {
            var rows = ReadMethodDefRows();
            var count = rows.Length;
            var dst = alloc<EcmaMethodInfo>(count);
            var assembly = AssemblyName().SimpleName();
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                ref var info = ref seek(dst,i);
                info.Token = row.Token;
                info.Component = assembly;
                info.Attributes = row.Attributes;
                info.ImplAttributes = row.ImplAttributes;
                info.Rva = row.Rva;
                info.CliSig = BlobArray(row.SigKey);
                info.Name = String(row.NameKey);
            }
            return dst;
        }

        public uint ReadMethodDefs(List<EcmaMethodInfo> dst)
        {
            var rows = ReadMethodDefRows();
            var count = rows.Length;
            var counter = 0u;
            for(var i=0; i<count; i++, counter++)
            {
                ref readonly var src = ref skip(rows,i);
                var def = new EcmaMethodInfo();
                def.Token = src.Token;
                def.Component = AssemblyName().SimpleName();
                def.Attributes = src.Attributes;
                def.ImplAttributes = src.ImplAttributes;
                def.Rva = src.Rva;
                def.CliSig = BlobArray(src.SigKey);
                def.Name = String(src.NameKey);
                dst.Add(def);
            }
            return counter;
        }        
    }
}