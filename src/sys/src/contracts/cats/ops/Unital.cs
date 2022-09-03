//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes operations over a unital type
        /// </summary>
        /// <typeparam name="T">The characterized type</typeparam>
        public interface IUnital<T>
        {
            /// <summary>
            /// The unital value
            /// </summary>
            T One {get;}
        }
    }
}