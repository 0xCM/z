//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <def>An asset is an addressable data type of known size</def>
    public interface IAsset : IDataType, IAddressable, ISized
    {

    }

    /// <typeparam name="T">The concretized asset</typeparam>
    public interface IAsset<T> : IAsset, IDataType<T>
        where T : IAsset<T>
    {

    }
}