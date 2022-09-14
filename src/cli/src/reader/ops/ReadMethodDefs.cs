//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CliReader
    {
        public ReadOnlySpan<MethodDefRelations> ReadMethodDefRows()
        {
            var src = MethodDefHandles();
            var count = src.Length;
            var dst = alloc<MethodDefRelations>(count);
            Read(src,dst);
            return dst;
        }

        public uint Read(ReadOnlySpan<MethodDefinitionHandle> src, Span<MethodDefRelations> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                 Read(skip(src,i), ref seek(dst,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public ref MethodDefRelations Read(MethodDefinitionHandle handle, ref MethodDefRelations dst)
        {
            var src = MD.GetMethodDefinition(handle);
            dst.Token = Clr.token(handle);
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

        public ReadOnlySpan<MethodDefInfo> ReadMethodDefInfo()
        {
            var rows = ReadMethodDefRows();
            var count = rows.Length;
            var dst = span<MethodDefInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                ref var info = ref seek(dst,i);
                info.Token = row.Token;
                info.Component = MD.GetAssemblyDefinition().GetAssemblyName().SimpleName();
                info.Attributes = row.Attributes;
                info.ImplAttributes = row.ImplAttributes;
                info.Rva = row.Rva;
                info.CliSig = Read(row.SigKey);
                info.Name = Read(row.NameKey);
            }
            return dst;
        }
    }
}