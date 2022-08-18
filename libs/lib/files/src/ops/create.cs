//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        /// <summary>
        /// Creates the specified folder if it does not exist; if it already exists, the file system is unmodified.
        /// </summary>
        /// <param name="dst">The source path</param>
        /// <remarks>The operation is idempotent</remarks>
        [MethodImpl(Inline), Op]
        public static FolderPath create(FolderPath dst)
        {
            void f()
            {
                if(!Directory.Exists(dst.Name))
                    Directory.CreateDirectory(dst.Name);
            }

            f();
            return dst;
        }
    }
}