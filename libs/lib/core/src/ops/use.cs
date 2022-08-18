//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct core
    {
        public static void use<T>(T resource, Action<T> worker)
            where T : IDisposable
        {
            try
            {
                worker(resource);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                resource.Dispose();
            }
        }
    }
}