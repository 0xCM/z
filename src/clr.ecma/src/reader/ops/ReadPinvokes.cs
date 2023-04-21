//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public ReadOnlySeq<EcmaPinvoke> ReadPinvokes()
        {
            var buffer = list<EcmaPinvoke>();
            var handles = MethodDefHandles();
            var key = AssemblyKey();
            for(var i=0; i<handles.Length; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                var method = MD.GetMethodDefinition(handle);
                if(IsPinvoke(method))
                {
                    var dst = new EcmaPinvoke();
                    var src = MD.GetMethodDefinition(handle);
                    dst.Token= EcmaTokens.token(handle);
                    dst.Assembly = key;
                    dst.MethodName = String(src.Name);
                    dst.MethodImport = ReadMethodImport(method);
                    buffer.Add(dst);
                }
            }
            return buffer.ToArray();            
        }
    }
}