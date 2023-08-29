//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


public abstract class Control<T> : Control, IControl<T>
    where T : Control<T>, new()
{
    public static ref readonly T Service => ref Instance;

    static T Instance = new();
}
