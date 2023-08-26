//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IAsmChecker
{
    ExecToken RunCheck(string name, EventHandler dst);
}
