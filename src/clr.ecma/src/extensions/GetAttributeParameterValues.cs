//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaReader;
    
    partial class XTend
    {
        // https://gist.github.com/jbe2277/f91ef12df682f3bfb6293aabcb47be2a
        public static ImmutableArray<string> GetAttributeParameterValues(this CustomAttribute src, MetadataReader reader)
        {
            var ctor = reader.GetMemberReference((MemberReferenceHandle)src.Constructor);
            var provider = new StringParameterValueTypeProvider(reader, src.Value);
            var signature = ctor.DecodeMethodSignature(provider, null);
            return signature.ParameterTypes;
        }
    }
}