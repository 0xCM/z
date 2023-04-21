//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public Ecma.TypeLayout ReadTypeLayout(TypeDefinitionHandle typeDef)
        {
            var dst = Ecma.TypeLayout.Empty;            
            var def = MetadataReader.GetTypeDefinition(typeDef);
            var kind = LayoutKind.Auto;
            switch (def.Attributes & TypeAttributes.LayoutMask)
            {
                case TypeAttributes.SequentialLayout:
                    kind = LayoutKind.Sequential;
                    break;

                case TypeAttributes.ExplicitLayout:
                    kind = LayoutKind.Explicit;
                    break;

                case TypeAttributes.AutoLayout:
                    return dst;

                default:
                    return dst;
            }

            var layout = def.GetLayout();
            return new Ecma.TypeLayout(kind, (uint)layout.Size, (uint)layout.PackingSize);
        }
    }
}