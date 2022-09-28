//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tools
    {
        public partial class Git
        {
            public struct AddSubmodule : ICmd<AddSubmodule>
            {
                public Submodule Submodule;

                public AddSubmodule(Submodule src)            
                {
                    Submodule = src;
                }
            }
        }
    }
}