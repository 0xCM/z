//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRatio<T> : ITextual
    {
        /// <summary>
        /// The dividend
        /// </summary>
        T Over {get;}

        /// <summary>
        /// The divisor
        /// </summary>
        T Under {get;}
    }

    [Free]
    public interface IRatio<H,T> : IRatio<T>
        where H : struct, IRatio<H,T>
    {

    }
}