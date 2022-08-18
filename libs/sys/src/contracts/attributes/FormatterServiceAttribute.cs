//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Applied to a type to specify a non-default formatter
    /// </summary>
    public class FormatterServiceAttribute : Attribute
    {
        public FormatterServiceAttribute(Type realization)
            => this.Realization = realization;

        /// <summary>
        /// Specifies the type that realizes IFormatter and its generic variants if extant
        /// </summary>
        public Type Realization {get;}
    }
}