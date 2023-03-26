//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class TableBuilder
    {
        public static TableBuilder builder()
            => new TableBuilder();

        protected readonly List<Type> Types = new();
        
        public TableBuilder Include(params Type[] src)
        {
            Types.AddRange(src);            
            return this;
        }

        public TableBuilder<T0> Include<T0>()
        {
            Types.Add(typeof(T0));
            return new (Types.ViewDeposited());
        }
    }

    public class TableBuilder<T0> : TableBuilder
    {        
        public TableBuilder(ReadOnlySpan<Type> src)
        {
            iter(src, t => Types.Add(t));
        }
        
        public new TableBuilder<T0,T1> Include<T1>()
        {
            Types.Add(typeof(T1));
            return new (Types.ViewDeposited());
        }
    }


    public class TableBuilder<T0,T1> : TableBuilder
    {        
        public TableBuilder(ReadOnlySpan<Type> src)
        {
            iter(src, t => Types.Add(t));
        }
        
    }
}