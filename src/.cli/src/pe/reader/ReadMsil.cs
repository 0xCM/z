//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    partial class PeReader
    {
        public ReadOnlySpan<MsilRow> ReadMsil()
        {
            var dst = list<MsilRow>();
            var types = MD.TypeDefinitions.ToArray();
            var typeCount = types.Length;
            for(var k=0u; k<typeCount; k++)
            {
                 var hType = skip(types, k);
                 var methods = MD.GetTypeDefinition(hType).GetMethods().Array();
                 var methodCount = methods.Length;
                 var definitions = map(methods, m=> MD.GetMethodDefinition(m));
                 for(var i=0u; i<methodCount; i++)
                 {
                    ref readonly var method = ref skip(methods,i);
                    ref readonly var definition = ref skip(definitions,i);
                    var rva = definition.RelativeVirtualAddress;
                    if(rva != 0)
                    {
                        var body = PE.GetMethodBody(rva);
                        dst.Add(new MsilRow
                        {
                            MethodRva = (Address32)rva,
                            Token = Clr.token(method),
                            ImageName = Source.FileName,
                            BodySize = body.Size,
                            LocalInit = body.LocalVariablesInitialized,
                            MaxStack = body.MaxStack,
                            MethodName = Clr.membername(MD.GetString(definition.Name)),
                            Code = body.GetILBytes(),
                        });
                    }
                 }
            }
            return dst.ViewDeposited();
        }
    }
}