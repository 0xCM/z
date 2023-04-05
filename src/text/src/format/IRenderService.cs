//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRenderService
    {
        void Render(object src, StreamWriter dst);
    }

    public interface IRenderService<T> : IRenderService
    {
        void Render(T src, StreamWriter dst);

        void IRenderService.Render(object src, StreamWriter dst)
            => Render((T)src, dst);
    }
}