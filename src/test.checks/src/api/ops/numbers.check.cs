//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class ApiOps
{
    [CmdOp("numbers/check")]
    void CheckNumbers(CmdArgs args)
    {
        for(var i=z8; i<16; i++)
        for(var j=z8; j<16; j++)
        {
            var a = num4.number(i);
            var b = num4.number(j);
            //Channel.Row($"{a,-2} + {b,-2} = {a + b,-2}");
            Channel.Row($"{a,-2} - {b,-2} = {a - b,-2}");

            // if(b > 0)
            // {
            //     Channel.Row($"{a,-2} / {b,-2} = {a / b,-2}");
            //     Channel.Row($"{a,-2} % {b,-2} = {a % b,-2}");
            // }

        }



    }
}