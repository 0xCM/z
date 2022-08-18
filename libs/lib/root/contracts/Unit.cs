//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Defines a slot in the type system for an "empty" type
    /// In this way, void functions can be considered
    /// to yield a value and participate in functional/monadic expressions
    /// </summary>
    public readonly struct Unit
    {
        public static Unit Value => new Unit();

        public static Type Type => typeof(Unit);

        /// <summary>
        /// Executes the action and returns the unit value
        /// </summary>
        /// <param name="a">The action to execute</param>
        public static explicit operator Unit(Action a)
        {
            a();
            return Value;
        }
    }
}