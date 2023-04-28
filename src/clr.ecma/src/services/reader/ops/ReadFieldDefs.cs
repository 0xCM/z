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
        public ReadOnlySeq<FieldDef> ReadFieldDefs()
        {
            var name = AssemblyKey().AssemblyName;
            var handles = FieldDefHandles();
            var count = handles.Length;
            var buffer = sys.list<FieldDef>();
            for(var j=0; j<count; j++)
            {
                var dst = new FieldDef();
                ref readonly var handle = ref skip(handles,j);
                var def = MD.GetFieldDefinition(handle);
                var type = MD.GetTypeDefinition(def.GetDeclaringType());
                dst.Token = EcmaTokens.token(handle);            
                dst.DeclaringType = String(type.Name);
                dst.Namespace = String(type.Namespace);
                dst.Assembly = AssemblyKey();
                dst.Attributes = def.Attributes;
                dst.CliSig = BlobArray(def.Signature);
                dst.Name = String(def.Name);
            }
            return buffer.Array();
        }


    }
}