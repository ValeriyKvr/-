using System.Diagnostics;

class Program
{
    private static void Main()
    {
        Console.WriteLine("Введіть к-сть елементів: ");
        int maxNum = Convert.ToInt32(Console.ReadLine());

        int[] notSortArr = Generate(maxNum, 0, maxNum);

        int[] sortCopy1 = notSortArr;
        int[] sortCopy2 = notSortArr;
        int[] sortCopy3 = notSortArr;
        int[] sortCopy4 = notSortArr;

        Stopwatch sw1 = new Stopwatch();

        sw1.Start();
        BubbleSort(sortCopy1);
        sw1.Stop();
        
        Stopwatch sw2 = new Stopwatch();
        
        sw2.Start();
        QuickSort(sortCopy2, 0, notSortArr.Length - 1);
        sw2.Stop();
        
        Stopwatch sw3 = new Stopwatch();

        sw3.Start();
        CountingSort(sortCopy3);
        sw3.Stop();
        
        
        Stopwatch sw4 = new Stopwatch();
        
        sw4.Start();
        Array.Sort(sortCopy4);
        sw4.Stop();
        
        Console.WriteLine($" Бульбашкове: {sw1.Elapsed}\n" +
                          $" Швидке: {sw2.Elapsed}\n" +
                          $" Підрахунком: {sw3.Elapsed}\n" +
                          $" Базове: {sw4.Elapsed}\n");
        
        if (isSame(sortCopy1, sortCopy4) && isSame(sortCopy2, sortCopy4) &&
            isSame(sortCopy1, sortCopy4))
        {
            Console.WriteLine("Arrays sorted by different algorithms are the same as basic!");
        }
        else
        {
            Console.WriteLine("Arrays are not the same!");
        }

    }
    //Генерація масива випадкових чисел
    private static Random rand = new Random();
    private static int[] Generate(int arrSize, int minNum, int maxNum) 
    {
        int[] arr = new int[arrSize];
        for (int i = 0; i < arr.Length; i++) 
        {
            arr[i] = rand.Next(minNum, maxNum + 1);
        }
        return arr;
    }
    //Бульбашкове сортування 
    private static int[] BubbleSort(int[] arrToSort)
    {
        for (int i = 0; i < arrToSort.Length; i++)
        {
            for (int j = 0; j < arrToSort.Length - 1; j++)
            {
                if (arrToSort[j] > arrToSort[j + 1])
                {
                    (arrToSort[j], arrToSort[j + 1]) = (arrToSort[j + 1], arrToSort[j]);
                }
            }
        }
        return arrToSort;
    }
    //Швидке сортування
    private static int[] QuickSort(int[] arrToSort, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return arrToSort;
        }

        int pivotIndex = Partition(arrToSort, minIndex, maxIndex);

        QuickSort(arrToSort, minIndex, pivotIndex - 1);

        QuickSort(arrToSort, pivotIndex + 1, maxIndex);

        return arrToSort;
    }

    private static int Partition(int[] arrToSort, int minIndex, int maxIndex)
    {
        int pivotElem = minIndex - 1;

        for (int i = minIndex; i <= maxIndex; i++)
        {
            if (arrToSort[i] < arrToSort[maxIndex])
            {
                pivotElem++;
                (arrToSort[pivotElem], arrToSort[i]) = (arrToSort[i], arrToSort[pivotElem]);
            }
        }

        pivotElem++;
        (arrToSort[pivotElem], arrToSort[maxIndex]) = (arrToSort[maxIndex], arrToSort[pivotElem]); //Swap

        return pivotElem;
    }
    //Cортування підрахунком
    private static int[] CountingSort(int[] arrToSort)
    {
        int minElem = arrToSort.Min();
        int maxElem = arrToSort.Max();

        int correctionFactor = minElem != 0 ? -minElem : 0; //Оскільки індекс масиву не може бути негативним, то
        //приводимо мінімальне значення діапазону до нуля, при цьому будемо враховувати поправку на всіх наступних кроках.
        //Це також дозволить економити пам’ять на масивах даних, в яких мінімальне значення більше нуля.
        maxElem += correctionFactor;

        int[] count = new int[maxElem + 1];
        for (int i = 0; i < arrToSort.Length; i++) count[arrToSort[i] + correctionFactor]++;

        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            for (int j = 0; j < count[i]; j++)
            {
                arrToSort[index] = i - correctionFactor;
                index++;
            }
        }

        return arrToSort;
    }
    //Порівняння результатів сортування алгоритмів
    private static bool isSame(int[] sortedArray, int[] basicSortedArray)
    {
        for (int i = 0; i < sortedArray.Length; i++)
        {
            if (sortedArray[i] == basicSortedArray[i])
            {
                return true;
            }
        }
        return false;
    }
}
