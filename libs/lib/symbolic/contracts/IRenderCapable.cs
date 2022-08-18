//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = RenderCapable;

    public interface IRenderCapable : ITextual
    {
        void Render(ITextBuffer dst);

        string ITextual.Format()
            => api.format(this);
    }

    public interface IRenderCapable<T> : IRenderCapable
        where T : IRenderCapable<T>
    {

    }
}