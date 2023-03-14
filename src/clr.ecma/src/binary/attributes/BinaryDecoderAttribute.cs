//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class BinaryDecoderAttribute : Attribute
    {
        public readonly Type Target;
        
        public BinaryDecoderAttribute(Type type)
        {
            Target = type;
        }
    }
}