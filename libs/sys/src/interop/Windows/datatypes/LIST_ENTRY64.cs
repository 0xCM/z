namespace Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LIST_ENTRY64
    {
        public ulong Flink;

        public ulong Blink;
    }
}
