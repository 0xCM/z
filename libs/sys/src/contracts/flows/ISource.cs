//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a point emitter
    /// </summary>
    [Free]
    public interface ISource
    {
        /// <summary>
        /// Retrieves the next value from the source
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        T Next<T>();

        bool Next<T>(out T dst)
        {
            dst = Next<T>();
            return true;
        }

        uint Fill<T>(Span<T> dst)
        {
            var count = (uint)dst.Length;
            if(count != 0)
            {
                for(var i=0; i<count; i++)
                    dst[i] = Next<T>();
            }
            return count;
        }
    }

    /// <summary>
    /// Characterizes an unlimited emitter
    /// </summary>
    /// <typeparam name="T">The production element type</typeparam>
    [Free]
    public interface ISource<T>
    {
        /// <summary>
        /// Retrieves the next item from the source
        /// </summary>
        T Next();

        bool Next(out T dst)
        {
            dst = Next();
            return true;
        }
    }

    [Free]
    public interface ISource<H,T> : ISource<T>
        where H : struct, ISource<H,T>
    {

    }
}