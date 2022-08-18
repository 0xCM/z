//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Indicates the target's numeric base preference
    /// </summary>
    public class NumericBaseAttribute : Attribute
    {
        public NumericBaseKind Base {get;}

        public int? MaxDigits {get;}

        public NumericBaseAttribute(int @base)
        {
            Base = (NumericBaseKind)@base;
        }

        public NumericBaseAttribute(int @base, int digits)
        {
            Base = (NumericBaseKind)@base;
            MaxDigits = digits;
        }

        public NumericBaseAttribute(NumericBaseKind @base)
        {
            Base = @base;
        }
    }
}