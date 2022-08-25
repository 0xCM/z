//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;

    using static core;

    partial struct FS
    {
        public readonly struct Files : IIndex<FilePath>
        {
            public readonly Index<FilePath> Data;

            [MethodImpl(Inline)]
            public Files(FilePath[] src)
                => Data = src;

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public int Length
            {
                [MethodImpl(Inline)]
                get => Data.Length;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => (uint)Data.Length;
            }

            public ReadOnlySpan<FilePath> View
            {
                [MethodImpl(Inline)]
                get => Data.View;
            }

            public Span<FilePath> Edit
            {
                [MethodImpl(Inline)]
                get => Data.Edit;
            }

            public FilePath[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public FS.Files Exclude(FileExt ext)
            {
                var buffer = list<FilePath>();
                var view = View;
                var count = view.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var path = ref skip(view,i);
                    if(!path.Is(ext))
                    {
                        buffer.Add(path);
                    }
                }
                return buffer.ToArray();
            }

            public string Format()
            {
                var dst = text.emitter();
                for(var i=0; i<Count; i++)
                    dst.AppendLine(this[i].ToUri());
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public ReadOnlySpan<FilePath> ViewNonEmpty
                => Data.Storage.Where(x => x.IsNonEmpty);

            public Files Where(Func<FilePath,bool> f)
                => Data.Storage.Where(f);

            public Files Where(FileExt f)
                => Data.Storage.Where(x => x.Ext == f);

            public ref FilePath this[ulong index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public ref FilePath this[long index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public Outcome<uint> Delete()
            {
                var count = 0u;
                try
                {
                    foreach(var file in Data.View)
                    {
                        FS.delete(file);
                        count++;
                    }

                    Edit.Clear();

                    return count;
                }
                catch(Exception e)
                {
                    return e;
                }
            }

            IEnumerator<FilePath> IEnumerable<FilePath>.GetEnumerator()
                => ViewNonEmpty.ToEnumerable().GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator()
                => ViewNonEmpty.ToEnumerable().GetEnumerator();

            [MethodImpl(Inline)]
            public static implicit operator FilePath[](Files src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Files(FilePath[] src)
                => new Files(src);

            [MethodImpl(Inline)]
            public static implicit operator Files(Index<FilePath> src)
                => new Files(src.Storage);

            [MethodImpl(Inline)]
            public static implicit operator ReadOnlySpan<FilePath>(FS.Files src)
                => src.View;

            public static Files Empty
                => new Files(sys.empty<FilePath>());
        }
    }
}