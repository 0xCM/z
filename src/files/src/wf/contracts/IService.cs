//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes nothing but is a marker for a type that, perhaps, defines something useful to someone
    /// </summary>
    [Free]
    public interface IService
    {
        Type HostType => GetType();
    }

    /// <summary>
    /// Characterizes reified service
    /// </summary>
    /// <typeparam name="H">The service host type</typeparam>
    [Free]
    public interface IService<H> : IService
        where H : IService<H>, new()
    {
        Type IService.HostType
            => typeof(H);
    }
}