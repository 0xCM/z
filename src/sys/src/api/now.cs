// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    partial class sys
    {
        /// <summary>
        /// Right now
        /// </summary>
        [MethodImpl(Inline), Op]
        public static DateTime now()
            => DateTime.Now;
    }
}