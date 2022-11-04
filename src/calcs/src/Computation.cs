//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class Computation<S,T>
    {
        public abstract ResultCode Compute(in S src, out T dst);

        [Op]
        public static ResultCode error(Exception e)
            => new ResultCode(uint.MaxValue);

        public virtual ResultCode Compute(ReadOnlySpan<S> src, Span<T> dst)
        {
            var count = src.Length;
            if(count > dst.Length)
                return ResultCodes.BufferTooSmall;

            var result = ResultCodes.Ok;
            try
            {
                for(var i=0; i<count; i++)
                {
                    result = Compute(skip(src,i), out seek(dst,i));
                    if(result)
                        continue;
                    else
                        break;
                }
            }
            catch(Exception e)
            {
                return error(e);
            }

            return result;
        }
    }
}