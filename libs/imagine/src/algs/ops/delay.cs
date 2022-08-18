//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        /// <summary>
        /// Returns after specified duration has elapsed
        /// </summary>
        /// <param name="duration">The time to wait before returning</param>
        [MethodImpl(Inline), Op]
        public static void delay(TimeSpan duration)
            => Task.Delay(duration).RunSynchronously();

        /// <summary>
        /// Introduces an asynchronous delay
        /// </summary>
        /// <param name="duration">The length of the delay to introduce</param>
        [MethodImpl(Inline), Op]
        public static async Task delayAsync(TimeSpan duration)
            => await Task.Delay(duration);

        [MethodImpl(Inline), Op]
        public static void delay(uint ms)
            => Task.Run(async delegate {await Task.Delay((int)ms);}).Wait();
    }
}