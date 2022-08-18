//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// A register used by an instruction
    /// </summary>
    public readonly struct IceUsedRegister
    {
        /// <summary>
        /// Register
        /// </summary>
        public readonly IceRegister Register;

        /// <summary>
        /// Register access
        /// </summary>
        public readonly IceOpAccess Access;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reg">Register</param>
        /// <param name="access">Register access</param>
        public IceUsedRegister(IceRegister reg, IceOpAccess access)
        {
            Register = reg;
            Access = access;
        }

        /// <summary>
        /// ToString()
        /// </summary>
        public override string ToString()
            => Register.ToString() + ":" + Access.ToString();
    }
}