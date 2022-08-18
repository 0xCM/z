//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        public interface IProjectProperty : IProjectElement, IExpr
        {
            string Name {get;}

            dynamic Value {get;}

            bool INullity.IsEmpty
                => Value == null;

            bool INullity.IsNonEmpty
                => Value != null;
        }

        public interface IProjectProperty<T> : IProjectProperty
        {
            new T Value {get;}

            dynamic IProjectProperty.Value
                => Value;
        }

        public interface IProjectProperty<F,T> : IProjectProperty<T>, IProjectElement<F>
            where F : struct, IProjectProperty<F,T>
            where T : IProjectProperty
        {
        }

        public interface IBuildProperty : IProjectProperty
        {


        }

        public interface IBuildProperty<T> : IBuildProperty
        {
            new T Value {get;}

            dynamic IProjectProperty.Value
                => Value;
        }
    }
}