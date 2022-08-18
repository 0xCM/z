// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [NativeModule(LibName)]
    public readonly struct KernelBase
    {
        public const string LibName = "kernelbase.dll";

        public string Name => LibName;

        /// <summary>
        /// Waits for the value at the specified address to change
        /// </summary>
        /// <param name="Address">The address on which to wait. If the value at Address differs from the value at CompareAddress,
        /// the function returns immediately. If the values are the same, the function does not return until another thread
        /// in the same process signals that the value at Address has changed by calling WakeByAddressSingle or WakeByAddressAll
        /// or the timeout elapses, whichever comes first.</param>
        /// <param name="CompareAddress">A pointer to the location of the previously observed value at Address.
        /// The function returns when the value at Address differs from the value at CompareAddress.</param>
        /// <param name="AddressSize">The size of the value, in bytes. This parameter can be 1, 2, 4, or 8</param>
        /// <param name="dwMilliseconds">The number of milliseconds to wait before the operation times out. If this parameter is INFINITE, the thread waits indefinitely.</param>
        /// <returns>TRUE if the wait succeeded. If the operation fails, the function returns FALSE. If the wait fails, call GetLastError to obtain extended error information. In particular, if the operation times out, GetLastError returns ERROR_TIMEOUT.</returns>
		[Free, DllImport(LibName, SetLastError = true)]
		public static extern unsafe bool WaitOnAddress(void* Address, void* CompareAddress, ulong AddressSize, uint dwMilliseconds);

        /// <summary>
        /// Wakes all threads that are waiting for the value of an address to change
        /// See https://docs.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-wakebyaddressall
        /// </summary>
        /// <param name="Address">The address to signal. If any threads have previously called <see cref='WaitOnAddress'/> for this address,
        /// the system wakes all of the waiting threads.</param>
		[Free, DllImport(LibName, SetLastError = true)]
		public static extern unsafe void WakeByAddressAll(void* Address);

        /// <summary>
        /// Wakes one thread that is waiting for the value of an address to change
        /// </summary>
        /// <param name="Address">The address to signal. If another thread has previously called
        /// <see cref='WaitOnAddress'/> for this address, the system wakes the waiting thread. If multiple threads
        /// are waiting for this address, the system wakes the first thread to wait.</param>
		[Free, DllImport(LibName, SetLastError = true)]
		public static extern unsafe void WakeByAddressSingle(void* Address);
    }
}