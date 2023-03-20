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
            var attribs = MD.GetAssemblyDefinition().GetCustomAttributes().Select(x => MD.GetCustomAttribute(x));
            var target = EmptyString;
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
                            var values = attrib.GetParameterValues(MD);
                            target = values[0];
                        }
                        
                    }
                    break;
                    case HandleKind.MethodDefinition:
                        var mdef = ReadMethodDef((MethodDefinitionHandle)cons);
                        
                    break;
                }                                
            }
            return target;
        }
    }
}