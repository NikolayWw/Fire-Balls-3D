namespace CodeBase.Data.Extension
{
    public static class DataExtension
    {
        public static void BubbleSort<TSort>(this TSort[] array) where TSort : ISort
        {
            TSort temp;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1 - i; j++)
                    if (array[j].SortNumber > array[j + 1].SortNumber)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
        }
    }
}