//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    public abstract class EcmaReceiver
    {
        readonly EcmaReader Reader;

        readonly MetadataReader MD;

        protected EcmaReceiver(EcmaReader reader)
        {
            Reader = reader;
            MD = reader.MetadataReader;
        }

        public void ReadMethodDefs()
        {
            var def = MethodDef.Empty;
            var assname = Reader.AssemblyName().SimpleName();
            iter(Reader.MethodDefHandles(), handle => {
                var src = MD.GetMethodDefinition(handle);
                def.Token = EcmaTokens.token(handle);
                def.Component = assname;
                def.Attributes = src.Attributes;
                def.ImplAttributes = src.ImplAttributes;
                def.Rva = src.RelativeVirtualAddress;
                def.CliSig = Reader.ReadBlobData(src.Signature);
                def.Name = Reader.String(src.Name);
                Receive(def);
            });

        }

        public virtual void Receive(MethodDef src) {}

    }
}