//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures invocation origin details
    /// </summary>
    public readonly record struct CallingMember
    {
        /// <summary>
        /// The originator name
        /// </summary>
        public readonly @string CallerName;

        /// <summary>
        /// The name of the file from which the invocation occurred
        /// </summary>
        public readonly @string CallerFile;

        /// <summary>
        /// The file-relative invocation line number
        /// </summary>
        public readonly uint CallerLine;

        [MethodImpl(Inline)]
        public CallingMember(string name, string file, int line)
        {
            CallerName = name;
            CallerFile = file;
            CallerLine = (uint)line;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => CallerName.Hash | CallerFile.Hash | (Hash32)CallerLine;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => CallerName.IsEmpty || CallerFile.IsEmpty;
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(CallingMember src)
            => CallerName == src.CallerName && CallerFile == src.CallerFile && CallerLine == src.CallerLine;

        public string Format()
            => string.Format("{0} | {1}:{2}", CallerName, CallerFile, CallerLine);

        public override string ToString()
            => Format();

        public static CallingMember Empty => new CallingMember(EmptyString,EmptyString,0);
    }
}