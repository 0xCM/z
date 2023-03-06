//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public abstract class Language<L> : Language
        where L : Language<L>,new()
    {
        protected Language(string id, string name)
            : base(id,name)
        {

        }

        static readonly L _Instance = new();

        public static ref readonly L Instance => ref _Instance;
    }
}