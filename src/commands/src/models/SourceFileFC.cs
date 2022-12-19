//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public abstract record class SourceFile<F,C> : SourceFile, IModel<F>
        where F : SourceFile<F,C>, new()
        where C : IExpr
    {
        protected SourceFile(FilePath location, C content)   
            : base(location,content)
        {

        }

        public static F Empty => new();
    }
}