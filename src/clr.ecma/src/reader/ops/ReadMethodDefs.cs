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
                    member.AssemblyName = key.AssemblyName;
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
                var src = MD.GetMethodDefinition(handle);
                var dst = new EcmaMethodDef();
                var declarer = MD.GetTypeDefinition(src.GetDeclaringType());
                var declname = String(declarer.Name);
                var ns = String(declarer.Namespace);
                dst.AssemblyName = AssemblyKey().AssemblyName;
                dst.AssemblyKey = AssemblyKey();
                dst.DeclaringType = declname;
                dst.Namespace = ns;
                dst.Token = EcmaTokens.token(handle);
                dst.Name = String(src.Name);
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

        public ReadOnlySeq<EcmaMethodInfo> ReadMethodInfo()
        {
            var handles = MethodDefHandles();
            var count = handles.Length;
            var rows = ReadMethodDefRows();
            var buffer = alloc<EcmaMethodInfo>(count);
            var assembly = AssemblyName();
            for(var i=0; i<count; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                var def = MD.GetMethodDefinition(handle);
                var declarer = MD.GetTypeDefinition(def.GetDeclaringType());
                seek(buffer,i) = new EcmaMethodInfo{
                    AssemblyName = assembly,
                    Attributes = def.Attributes,
                    CliSig = BlobArray(def.Signature),
                    DeclaringType = String(declarer.Name),
                    Namespace = String(declarer.Namespace),
                    ImplAttributes = def.ImplAttributes,
                    MethodName = String(def.Name),
                    Rva = def.RelativeVirtualAddress,
                    Token = handle                    
                };                        
            }
            return buffer.Sort();            
        }

    }
}