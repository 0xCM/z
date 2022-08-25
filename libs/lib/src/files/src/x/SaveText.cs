//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Outcome Save(this FilePath dst, string src)
        {
            try
            {
                using var writer = dst.EnsureParentExists().Writer();
                writer.WriteLine(src);
                writer.Flush();
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }
    }
}
