//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class ClrQuery
    {
        /// <summary>
        /// Queries the source type for its fundamental kind
        /// </summary>
        /// <param name="src">The source type</param>
        [Op]
        public static ClrTypeKind Kind(this Type src)
        {
            if(src.IsClass)
                return ClrTypeKind.Class;
            else if(src.IsEnum)
                return ClrTypeKind.Enum;
            else if(src.IsInterface)
                return ClrTypeKind.Interface;
            else if(src.IsStruct())
                return ClrTypeKind.Struct;
            else if(src.IsDelegate())
                return ClrTypeKind.Delegate;
            else
                return ClrTypeKind.None;
        }
    }
}