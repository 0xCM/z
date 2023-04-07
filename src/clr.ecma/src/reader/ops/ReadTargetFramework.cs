//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.Linq;
    using System.Runtime.Versioning;

    partial class EcmaReader
    {
        public ReadOnlySeq<CustomAttribute> ReadCustomAttributes()
            => MD.CustomAttributes.Map(x => MD.GetCustomAttribute(x));

        public string ReadTargetFramework()
        {
            try
            {
                var attribs = MD.GetAssemblyDefinition().GetCustomAttributes().Select(x => MD.GetCustomAttribute(x));
                foreach(var attrib in attribs)
                {
                    var cons = attrib.Constructor;
                    switch(cons.Kind)
                    {
                        case HandleKind.MemberReference:
                        {
                            var mref = ReadMemberRef((MemberReferenceHandle)cons);
                            var parent = mref.Parent;
                            var type = MD.GetTypeReference((TypeReferenceHandle)parent);
                            var name = String(type.Name);
                            if(name == nameof(TargetFrameworkAttribute))
                            {
                                return attrib.GetParameterValues(MD)[0];
                            }
                            
                        }
                        break;
                        case HandleKind.MethodDefinition:
                            var mdef = MD.GetMethodDefinition((MethodDefinitionHandle)cons);
                            
                        break;
                    }                                
                }
            }
            catch(Exception e)
            {
                term.warn(e);
            }
            return EmptyString;
        }
    }
}