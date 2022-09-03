//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a file emission payload
    /// </summary>
    public readonly struct FileEmission
    {
        /// <summary>
        /// The emission target
        /// </summary>
        public readonly FilePath Target;

        public readonly uint Count;

        [MethodImpl(Inline)]
        public FileEmission(FilePath target, Count count)
        {
            Target = target;
            Count = count;
        }

        public bool Succeeded
        {
            [MethodImpl(Inline)]
            get => Count >= 0;
        }
    }
}