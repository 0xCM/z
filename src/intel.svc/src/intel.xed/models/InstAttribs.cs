//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

partial class XedModels
{
    public readonly struct InstAttribs : IEnumerable<InstAttrib>
    {
        [MethodImpl(Inline)]
        public Bitset128<InstAttrib> Bitset()
            => Bitsets.init(n128, Storage);

        readonly Index<InstAttrib> Data;

        [MethodImpl(Inline)]
        public InstAttribs(InstAttrib[] src)
        {
            Data = src;
        }

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

        public InstAttrib[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref InstAttrib this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref InstAttrib this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public bool Locked
        {
            [MethodImpl(Inline)]
            get => Data.Any(x => x == InstAttribKind.LOCKED);
        }

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        public IEnumerator<InstAttrib> GetEnumerator()
            => (((IEnumerable<InstAttrib>)Data).Where(x => x.IsNonEmpty)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        [MethodImpl(Inline)]
        public static implicit operator InstAttribs(InstAttrib[] src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator InstAttrib[](InstAttribs src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Index<InstAttrib>(InstAttribs src)
            => src.Data;

        public static InstAttribs Empty => sys.empty<InstAttrib>();
    }
}
