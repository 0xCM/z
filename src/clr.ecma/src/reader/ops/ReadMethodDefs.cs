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
        public ReadOnlySeq<EcmaMember> ReadMembers()
        {
            var types = TypeDefHandles();
            var dst = bag<EcmaMember>();
            var key = AssemblyKey();
            iter(types, t => {
                var typedef = MD.GetTypeDefinition(t);                
                var typename = String(typedef.Name);
                var declarer = MD.GetTypeDefinition(typedef.GetDeclaringType());
                var declname = String(declarer.Name);
                var ns = String(typedef.Namespace);

                iter(typedef.GetMethods(), handle => {
                    var member = new EcmaMember();
                    var method = MD.GetMethodDefinition(handle);
                    member.Token = EcmaTokens.token(handle);
                    member.Kind = EcmaMemberKind.Method;
                    member.Namespace = ns;
                    member.Assembly = key;
                    member.DeclaringType = declname;
                    member.Name = String(method.Name);                                    
                });

                
            }, true);
            return dst.Array().Sort();
        }

        public IEnumerable<EcmaMethodDef> ReadMethodDefs()
        {
            foreach(var handle in MD.MethodDefinitions)
            {
                var src = ReadMethodDef(handle);                
                var dst = new EcmaMethodDef();
                var declarer = MD.GetTypeDefinition(src.GetDeclaringType());
                var declname = String(declarer.Name);
                var ns = String(declarer.Namespace);
                dst.DeclaringType = declname;
                dst.Namespace = ns;
                dst.Token = EcmaTokens.token(handle);
                dst.MethodName = String(src.Name);
                dst.SigData = Blob(src.Signature);
                dst.Attributes = src.Attributes;
                dst.ImplAttributes = src.ImplAttributes;
                dst.Rva = src.RelativeVirtualAddress;
                yield return dst;                
            }
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