//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class BinaryEncoderAttribute : Attribute
    {
        public readonly Type Target;
        
        public BinaryEncoderAttribute(Type type)
        {
            Target = type;
        }
    }
}