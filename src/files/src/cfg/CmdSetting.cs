//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdSetting : CmdSetting<@string>
    {
        public CmdSetting(string name, @string value)
            : base(name,value)
        {

        }        
   }
}