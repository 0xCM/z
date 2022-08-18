//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDataConverter
    {
        Type SourceType {get;}

        Type TargetType {get;}

        Outcome Convert(object src, out object dst);
    }

    [Free]
    public interface IConverter<A,B> : IDataConverter
    {
        Type IDataConverter.SourceType
            => typeof(A);

        Type IDataConverter.TargetType => typeof(B);

        Outcome Convert(in A src, out B dst);

        Outcome IDataConverter.Convert(object src, out object dst)
        {
            var result = Outcome.Failure;
            dst = null;
            var tInput = src?.GetType() ?? typeof(void);
            var _dst = default(object);
            if(tInput == SourceType)
            {
                var a = (A)src;
                var b = default(B);
                result = Convert(a, out b);
                if(result)
                    dst = b;
            }

            return result;
        }
    }
}