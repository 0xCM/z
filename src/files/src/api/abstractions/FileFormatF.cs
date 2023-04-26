//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FileFormat
    {
        public string Name {get;}

        protected FileFormat(string name)
        {
            Name = name;
        }
    }

    public abstract class FileFormat<F> : FileFormat
        where F : FileFormat<F>, new()
    {
        protected FileFormat(string name)
            : base(name)
        {
        }

    }
}