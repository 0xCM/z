//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    partial struct FS
    {
        /// <summary>
        /// Deletes the file if it exists
        /// </summary>
        /// <param name="src">The path to the file</param>
        public static FilePath delete(FilePath src)
        {
            if(src.Exists)
            {
                File.Delete(src.Name);
                return src;
            }
            else
                return src;
        }

        /// <summary>
        /// Deletes the file if it exists
        /// </summary>
        /// <param name="src">The path to the file</param>
        public static FilePath delete(FilePath src, Action<Exception> error)
        {
            try
            {
                if(!src.Exists)
                    return src;

                File.Delete(src.Name);
                return src;

            }
            catch(Exception e)
            {
                error(e);
                return src;
            }
        }
    }
}