//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        /// <summary>
        /// Represents a path to a file that defines a solution
        /// </summary>
        public readonly record struct SlnFile : IFsEntry<SlnFile>
        {
            public readonly FilePath Path;

            public PathPart Name
            {
                [MethodImpl(Inline)]
                get => Path.Name;
            }

            [MethodImpl(Inline)]
            public SlnFile(FilePath src)
                => Path = src;

            [MethodImpl(Inline)]
            public string Format()
                => Path.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator SlnFile(FilePath src)
                => new SlnFile(src);

            [MethodImpl(Inline)]
            public static implicit operator FilePath(SlnFile src)
                => src.Path;
        }
    }
}