//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public ReadOnlySpan<EcmaMethodRelations> ReadMethodDefRows()
        {
            var src = MethodDefHandles();
            var count = src.Length;
            var dst = alloc<EcmaMethodRelations>(count);
            Read(src,dst);
            return dst;
        }

        public uint Read(ReadOnlySpan<MethodDefinitionHandle> src, Span<EcmaMethodRelations> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                 Read(skip(src,i), ref seek(dst,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public ref EcmaMethodRelations Read(MethodDefinitionHandle handle, ref EcmaMethodRelations dst)
        {
            var src = MD.GetMethodDefinition(handle);
            dst.Token = Ecma.token(handle);
            dst.Attributes = src.Attributes;
            dst.ImplAttributes  = src.ImplAttributes;
            dst.Rva = src.RelativeVirtualAddress;
            dst.NameKey = src.Name;
            dst.SigKey = src.Signature;
            var keys = Keys(src.GetParameters());
            var count = keys.Count;
            if(count != 0)
            {
                dst.FirstParam = keys.First;
                dst.ParamCount = (ushort)count;
            }

            return ref dst;
        }

        public ReadOnlySpan<EcmaMethodDef> ReadMethodDefInfo()
        {
            var rows = ReadMethodDefRows();
            var count = rows.Length;
            var dst = span<EcmaMethodDef>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                ref var info = ref seek(dst,i);
                info.Token = row.Token;
                info.Component = MD.GetAssemblyDefinition().GetAssemblyName().SimpleName();
                info.Attributes = row.Attributes;
                info.ImplAttributes = row.ImplAttributes;
                info.Rva = row.Rva;
                info.CliSig = ReadBlob(row.SigKey);
                info.Name = Read(row.NameKey);
            }
            return dst;
        }

        public uint ReadMethodDefs(List<EcmaMethodDef> dst)
        {
            var rows = ReadMethodDefRows();
            var count = rows.Length;
            var counter = 0u;
            for(var i=0; i<count; i++, counter++)
            {
                ref readonly var src = ref skip(rows,i);
                var def = new EcmaMethodDef();
                def.Token = src.Token;
                def.Component = MD.GetAssemblyDefinition().GetAssemblyName().SimpleName();
                def.Attributes = src.Attributes;
                def.ImplAttributes = src.ImplAttributes;
                def.Rva = src.Rva;
                def.CliSig = ReadBlob(src.SigKey);
                def.Name = Read(src.NameKey);
                dst.Add(def);
            }
            return counter;
        }        
    }
}