//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a formal operation and its kind
    /// </summary>
    public class OpKindAttribute : OpAttribute
    {
        static ApiClassKind @class(object id)
            => (ApiClassKind)(ulong)Convert.ChangeType(id, typeof(ulong));

        protected OpKindAttribute(object id, ApiAsmClass asm = 0)
            : base(@class(id))
        {

        }

        public OpKindAttribute()
        {

        }
    }
}