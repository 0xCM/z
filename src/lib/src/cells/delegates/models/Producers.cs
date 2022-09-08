//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Delegates
    {
        /// <summary>
        /// Characterizes a function that produces spans values
        /// </summary>
        /// <typeparam name="T">The emission type</typeparam>
        [Free]
        public delegate Span<T> SpanProducer<T>();
    }
}