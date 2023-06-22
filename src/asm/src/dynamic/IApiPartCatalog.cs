//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes the api set exposed by a part
    /// </summary>
    [Free]
    public interface IApiPartCatalog
    {
        /// <summary>
        /// The defining assembly
        /// </summary>
        Assembly Component {get;}

        /// <summary>
        /// Api types
        /// </summary>
        Index<ApiCompleteType> ApiTypes {get;}

        /// <summary>
        /// The api hosts known to the catalog, including both operation and data type hosts
        /// </summary>
        ApiHosts ApiHosts {get;}

        /// <summary>
        /// The operations defined by <see cref='ApiHosts'/>
        /// </summary>
        Index<MethodInfo> Methods {get;}

        /// <summary>
        /// The identity of the assembly that defines and owns the catalog
        /// </summary>
        PartName PartName 
            => Component.PartName();

        /// <summary>
        /// Specifies whether the catalog contains content from an identified assembly
        /// </summary>
        bool IsIdentified 
            => PartName.IsNonEmpty;
    }
}