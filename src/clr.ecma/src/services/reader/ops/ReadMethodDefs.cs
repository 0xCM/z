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
        public ParallelQuery<MethodDef> ReadMethodDefs()
        {
            var name = AssemblyName();
            var key = AssemblyKey();
            var query = from handle in  MethodDefHandles()
                        let def = MD.GetMethodDefinition(handle)
                        let declarer = MD.GetTypeDefinition(def.GetDeclaringType())
                        select new MethodDef {
                            Token = EcmaTokens.token(handle),
                            AssemblyKey = key,
                            Namespace = String(declarer.Namespace),
                            DeclaringType = String(declarer.Name),
                            MethodName = String(def.Name),
                            Rva = def.RelativeVirtualAddress,
                            BinarySig = BlobArray(def.Signature),
                            Attributes = def.Attributes,
                            ImplAttributes = def.ImplAttributes,
                    };
            return query;
        }

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

        // public IEnumerable<MethodDef> ReadMethodDefs()
        // {
        //     foreach(var handle in MD.MethodDefinitions)
        //     {
        //         var src = MD.GetMethodDefinition(handle);
        //         var dst = new MethodDef();
        //         var declarer = MD.GetTypeDefinition(src.GetDeclaringType());
        //         var declname = String(declarer.Name);
        //         var ns = String(declarer.Namespace);
        //         dst.AssemblyKey = AssemblyKey();
        //         dst.DeclaringType = declname;
        //         dst.Namespace = ns;
        //         dst.Token = EcmaTokens.token(handle);
        //         dst.MethodName = String(src.Name);
        //         dst.CliSig = Blob(src.Signature);
        //         dst.Attributes = src.Attributes;
        //         dst.ImplAttributes = src.ImplAttributes;
        //         dst.Rva = src.RelativeVirtualAddress;
        //         yield return dst;                
        //     }
        // }

        // public ParallelQuery<MethodDefRow> ReadMethodDefRows()
        //     => from handle in MethodDefHandles()
        //         let method = MD.GetMethodDefinition(handle)
        //         let keys = ReadParameterRowKeys(method.GetParameters())
        //         select new MethodDefRow {
        //             Index = EcmaTokens.token(handle),
        //             DeclaringType = method.GetDeclaringType(),
        //             Attributes = method.Attributes,
        //             Rva = method.RelativeVirtualAddress,
        //             NameKey = method.Name,
        //             SigKey = method.Signature,
        //             FirstParam = keys.IsNonEmpty ? keys.First : EcmaRowKey.Empty,
        //             ParamCount = (ushort)keys.Count
        //         };


        // [MethodImpl(Inline), Op]
        // public ref MethodDefRow Read(MethodDefinitionHandle handle, ref MethodDefRow dst)
        // {
        //     var method = MD.GetMethodDefinition(handle);
        //     dst.Index = EcmaTokens.token(handle);
        //     dst.DeclaringType = method.GetDeclaringType();
        //     dst.Attributes = method.Attributes;
        //     dst.ImplAttributes  = method.ImplAttributes;
        //     dst.Rva = method.RelativeVirtualAddress;
        //     dst.NameKey = method.Name;
        //     dst.SigKey = method.Signature;
        //     var keys = ReadParameterRowKeys(method.GetParameters());
        //     var count = keys.Count;
        //     if(count != 0)
        //     {
        //         dst.FirstParam = keys.First;
        //         dst.ParamCount = (ushort)count;
        //     }

        //     return ref dst;
        // }


    }
}