//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaReader;
    
    partial class XTend
    {
        const TypeAttributes NestedMask = (TypeAttributes)0x00000006;

        [MethodImpl(Inline)]
        public static bool IsNested(this TypeAttributes flags)
            => (flags & NestedMask) != 0;

        // https://gist.github.com/jbe2277/f91ef12df682f3bfb6293aabcb47be2a
        public static ImmutableArray<string> GetParameterValues(this CustomAttribute customAttribute, MetadataReader reader)
        {
            if (customAttribute.Constructor.Kind != HandleKind.MemberReference) throw new InvalidOperationException();
            var ctor = reader.GetMemberReference((MemberReferenceHandle)customAttribute.Constructor);
            var provider = new StringParameterValueTypeProvider(reader, customAttribute.Value);
            var signature = ctor.DecodeMethodSignature(provider, null);
            return signature.ParameterTypes;
        }
    }
}