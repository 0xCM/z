//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public abstract class Validator<T> : AppService<T>
        where T : Validator<T>, new()
    {
        public abstract void Run();

        protected IPolyrand Random;

        protected Validator()
        {
            Random = Rng.wyhash64(PolySeed64.Seed03);
        }

        public T WithSource(IPolyrand src)
        {
            Random = src;
            return (T)this;
        }
    }
}
