//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using api = CheckClose;

    public interface ICheckClose : ICheckLengths
    {
        bool almost(float lhs, float rhs)
            => api.almost(lhs,rhs);

        bool almost(double lhs, double rhs)
            => api.almost(lhs,rhs);

        void close<T>(T lhs, T rhs)
            where T : unmanaged
                => api.close(lhs,rhs);

        void close<T>(Span<T> lhs, Span<T> rhs, T tolerance)
            where T : unmanaged
                => api.close(lhs, rhs, tolerance);
    }
}