//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static EmptyRecord<T> empty<T>()
            => default;

        [Op, Closures(Closure)]
        public static EmptyRecord empty()
            => default;
    }
}