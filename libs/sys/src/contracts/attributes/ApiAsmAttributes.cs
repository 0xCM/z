//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a formal operation and its kind
    /// </summary>
    public class AsmAttribute : OpAttribute
    {
        public AsmAttribute(ApiAsmClass key)
        {
            Key = key;
        }

        public ApiAsmClass Key {get;}
    }
}