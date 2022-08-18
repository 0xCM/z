//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the content of a <typeparamref name='T'/> cell of width <typeparamref name='W'/>
    /// </summary>
    public readonly struct CellW<W,T> : IDataCell<CellW<W,T>,W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged, IDataCell<T>
    {
        public readonly T Content;

        [MethodImpl(Inline)]
        public CellW(T data)
            => Content = data;

        public uint Width
        {
            [MethodImpl(Inline)]
            get => (uint)DataWidths.measure<W>();
        }

        public string Format()
            => Content.Format();

        public bool Equals(CellW<W,T> src)
            => Content.Equals(src.Content);
    }
}