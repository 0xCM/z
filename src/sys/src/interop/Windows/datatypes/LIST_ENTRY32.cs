namespace Windows
{

    [StructLayout(LayoutKind.Sequential)]
    public struct LIST_ENTRY32
    {
        public uint Flink;

        public uint Blink;
    }
}
