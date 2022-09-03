//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public readonly struct BinaryFormatMarkers
        {
            [TextMarker]
            public const string register1_to_register2 = "register1 to register2";

            [TextMarker]
            public const string register2_to_register1 = "register2 to register1";

            [TextMarker]
            public const string memory_to_register = "memory to register";

            [TextMarker]
            public const string register_to_memory = "register to memory";

            [TextMarker]
            public const string qwordregister1_to_qwordregister2 = "qwordregister1 to qwordregister2";

            [TextMarker]
            public const string memory64_to_qwordregister = "memory64 to qwordregister";

            [TextMarker]
            public const string qwordregister_to_memory64 = "qwordregister to memory64";

            [TextMarker]
            public const string immediate_to_register = "immediate to register";

            [TextMarker]
            public const string immediate_to_qwordregister = "immediate to qwordregister";

            [TextMarker]
            public const string immediate_to_RAX = "immediate to RAX";

            [TextMarker]
            public const string immediate_to_AL_or_AX_or_EAX = "immediate to AL, AX, or EAX";

            [TextMarker]
            public const string immediate_to_memory = "immediate to memory";

            [TextMarker]
            public const string immediate8_to_memory64 = "immediate8 to memory64";

            [TextMarker]
            public const string immediate32_to_memory64 = "immediate32 to memory64";

            [TextMarker]
            public const string immediate32_to_qwordregister = "immediate32 to qwordregister";

            [TextMarker]
            public const string immediate32_to_RAX = "immediate32 to RAX";
        }
   }
}