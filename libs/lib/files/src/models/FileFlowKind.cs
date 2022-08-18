//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct FileFlowKind : IFlow<FileKind,FileKind>
    {
        public readonly FileKind Source;

        public readonly FileKind Target;

        [MethodImpl(Inline)]
        public FileFlowKind(FileKind src, FileKind dst)
        {
            Source = src;
            Target = dst;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source == 0 || Target == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source != 0 && Target != 0;
        }

        K IArrow<K, K>.Source
            => Source;

        K IArrow<K, K>.Target
            => Target;

        public string Format()
            => $"{Source.Format()} -> {Target.Format()}";
    }
}