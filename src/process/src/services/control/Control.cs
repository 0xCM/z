//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IControl : IDisposable
    {

    }

    public interface IControl<T> : IControl
        where T : IControl<T>
    {

    }

    public abstract class Control : IControl
    {
        protected abstract void Disposing();

        void IDisposable.Dispose()
            => Disposing();
    }

    public abstract class Control<T> : Control, IControl<T>
        where T : Control<T>, new()
    {
        public static ref readonly T Service => ref Instance;

        static T Instance = new();
    }
}