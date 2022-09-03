namespace Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LIST_ENTRY
    {
        public unsafe LIST_ENTRY* Flink;

        public unsafe LIST_ENTRY* Blink;
    }
}