//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class Schema<S> : ISchema, ISchema<S>
        where S : ISchema<S>, new()
    {
        public static S Empy = new();
    }
}