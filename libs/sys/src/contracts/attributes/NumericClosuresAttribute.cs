//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Applies to a generic type/method to advertise the types over which type parameter(s) may be closed
    /// </summary>
    public class NumericClosuresAttribute : ClosuresAttribute
    {
        public NumericClosuresAttribute(NumericKind nk)
            : base(nk)
        {
            
        }

        public NumericKind NumericPrimitive 
            => (NumericKind)Spec;
    }    
}