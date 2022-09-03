//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
    public class ConverterAttribute : Attribute
    {
        public Type SourceType {get;}

        public Type TargetType {get;}

        public ConverterAttribute(Type src, Type dst)
        {
            SourceType = src;
            TargetType = dst;
        }
    }
}