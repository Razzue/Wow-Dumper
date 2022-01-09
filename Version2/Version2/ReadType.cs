namespace Version2
{
    internal enum ReadType : int
    {
        Null = 0,
        Byte = 1,
        Word = 2,
        DWord = 4,
        QWord = 8,
        Extra = 10,
        Massive = 25,
        Maximum = 50,
    }
}