//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider("ecma")]
    public class EcmaSections
    {
        public const string ApiHex = "metadata.hex";

        public const string MemberFields = "members.fields";

        public const string MemberRefs = "members.refs";
        
        public const string FieldDefs = "fields.defs";

        public const string ConstFields = "fields.const";

        public const string Methods = "methods";

        public const string Blobs = "blobs";

        public const string UserStrings = "strings.user";

        public const string SystemStrings = "strings.system";

        public const string Literals = "literals";

        public const string MsilData ="msil.data";
    }
}