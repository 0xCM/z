//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial struct FS
    {
        /// <summary>
        /// For a managed module, retrieves its name and returns true; otherwise, returns false
        /// </summary>
        /// <param name="src">The source path</param>
        public static bool name(FilePath src, out AssemblyName dst)
        {
            try
            {
                dst = AssemblyName.GetAssemblyName(src.Name);
                return true;
            }
            catch(Exception)
            {
                dst = null;
                return false;
            }
        }
    }
}