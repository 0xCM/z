// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    partial struct core
    {
        /// <summary>
        /// Right now
        /// </summary>
        [MethodImpl(Inline), Op]
        public static DateTime now()
            => DateTime.Now;
    }
}