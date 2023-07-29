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

        public IEnumerable<MethodDef> ReadMethodDefs()
        {
            foreach(var handle in MD.MethodDefinitions)
            {
                var src = MD.GetMethodDefinition(handle);
                var dst = new MethodDef();
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

        public ParallelQuery<MethodDefRow> ReadMethodDefRows()
            => from handle in MethodDefHandles()
                let method = MD.GetMethodDefinition(handle)
                let keys = ReadParameterRowKeys(method.GetParameters())
                select new MethodDefRow {
                    Index = EcmaTokens.token(handle),
                    DeclaringType = method.GetDeclaringType(),
                    Attributes = method.Attributes,
                    Rva = method.RelativeVirtualAddress,
                    NameKey = method.Name,
                    SigKey = method.Signature,
                    FirstParam = keys.IsNonEmpty ? keys.First : EcmaRowKey.Empty,
                    ParamCount = (ushort)keys.Count
                };

        public uint Read(ReadOnlySpan<MethodDefinitionHandle> src, Span<MethodDefRow> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                 Read(skip(src,i), ref seek(dst,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public ref MethodDefRow Read(MethodDefinitionHandle handle, ref MethodDefRow dst)
        {
            var method = MD.GetMethodDefinition(handle);
            dst.Index = EcmaTokens.token(handle);
            dst.DeclaringType = method.GetDeclaringType();
            dst.Attributes = method.Attributes;
            dst.ImplAttributes  = method.ImplAttributes;
            dst.Rva = method.RelativeVirtualAddress;
            dst.NameKey = method.Name;
            dst.SigKey = method.Signature;
            var keys = ReadParameterRowKeys(method.GetParameters());
            var count = keys.Count;
            if(count != 0)
            {
                dst.FirstParam = keys.First;
                dst.ParamCount = (ushort)count;
            }

            return ref dst;
        }

        public ParallelQuery<EcmaMethodInfo> ReadMethodInfo()
        {
            var handles = MethodDefHandles();
            return from handle in handles
                    let assembly = AssemblyName()
                    from row in ReadMethodDefRows()
                    let def = MD.GetMethodDefinition(handle)
                    let declarer = MD.GetTypeDefinition(def.GetDeclaringType())
                    select new EcmaMethodInfo {
                        AssemblyName = assembly,
                        Attributes = def.Attributes,
                        CliSig = BlobArray(def.Signature),
                        Namespace = String(declarer.Namespace),
                        ImplAttributes = def.ImplAttributes,
                        MethodName = String(def.Name),
                        Rva = def.RelativeVirtualAddress,
                        Token = handle                                                
                    };
        }
    }
}