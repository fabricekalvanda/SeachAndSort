// Fabrice Kalvanda
// August 11th, 2020
// Seach_Sort.cs
// Purpose: Given a list of numbers by the user, this program will find the element the user is searching for

using System;

namespace LinearSearch
{
    class MainClass
    {
        /* First Sort Method */
        private static void QuickSort(int[] array)
        {
            int i, j;
            for (i = 1; i < array.Length; i++)
            {
                int item = array[i];
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    if (item < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = item;
                    }
                    else ins = 1;
                }
            }
        }

        /* second Sort Method */
        private static void BubbleSort(int[] array)
        {
            int t;
            for (int j = 0; j <= array.Length - 2; j++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        t = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = t;
                    }
                }
            }
        }

        /* First Search Method */
        private static void InterpolationSearch()
        {
            /* Getting the array length from the User */
            Console.WriteLine("How many numbers do yo have?");
            int totatNmbrs = Convert.ToInt32(Console.ReadLine());// getting array length from the User
            int[] numbers = new int[totatNmbrs];

            /* Getting array numbers from the User */
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Please enter a number: ", i);
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            QuickSort(numbers);//sorting the array

            Console.Write("\nWhat number are you looking for? \n");
            int searchNum = Convert.ToInt32(Console.ReadLine());

            /* Search Algorithm */
            int low = 0;
            int high = numbers.Length - 1;

            while (numbers[low] < searchNum && numbers[high] >= searchNum)
            {
                int mid = low + ((searchNum - numbers[low]) * (high - low)) / (numbers[high] - numbers[low]);

                if (numbers[mid] < searchNum)
                    low = mid + 1;
                else if (numbers[mid] > searchNum)
                    high = mid - 1;
                else
                    Console.WriteLine("The element you are looking for is in the index " + mid + " in the sorted list");
            }
            if (numbers[low] == searchNum)
                Console.WriteLine("The element you are looking for is in the index " + low + " in the sorted list");
            else
                Console.WriteLine("The element you are looking for is not in this list"); //Not found
        }

        /* Second Search Method */
        private static void BinarySearch()
        {
            /* Getting the array length from the User */
            Console.WriteLine("How many numbers do yo have?");
            int totatNmbrs = Convert.ToInt32(Console.ReadLine());// getting array length from the User
            int[] numbers = new int[totatNmbrs];

            /* Getting array numbers from the User */
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Please enter a number: ", i);
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            BubbleSort(numbers);//Bubble sorting the array

            Console.Write("\nWhat number are you looking for? \n");
            int searchNum = Convert.ToInt32(Console.ReadLine());

            /* Binary Searching */
            int left = 0;
            int right = numbers.Length - 1;
            bool found = false;//set a flag to check if the element is found or not

            
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (numbers[middle] == searchNum)
                {
                    Console.WriteLine("The element " + searchNum + " is in the index " + middle + " in the sorted list");
                    found = true;
                }
                if (searchNum < numbers[middle])
                    right = middle - 1;

                else
                    left = middle + 1;
            }
            if (found == false)
                Console.WriteLine("The element you are looking for is not in this list");
        }

        /* Third Search Method */
        private static void LinearSearch()
        {
            /* Getting the array length from the User */
            Console.WriteLine("How many numbers do yo have?");
            int totatNmbrs = Convert.ToInt32(Console.ReadLine());// getting array length from the User
            int[] numbers = new int[totatNmbrs];

            /* Getting array numbers from the User */
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Please enter a number: ", i);
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.Write("\nWhat number are you looking for? \n");
            int searchNum = Convert.ToInt32(Console.ReadLine());

            /* Linear searching */
            bool found = false;//set a flag to check if the element is found or not 
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == searchNum)
                {
                    Console.WriteLine("The element " + searchNum + " is in the index " + i + " in the list");
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine("The element you are looking for is not in this list");
        }

        /* Main Method */
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to my Searching and Sorting Algorithm!");
            Console.WriteLine("Tape either Linear Search, Binary Search, or Interpolation Search (case sensentive!)");
            Console.WriteLine("What search/sort method would you like to do? ");

            string method = Console.ReadLine();//Get the method from the userInput

            /* Calling method that userInput has choosen */
            if (method == "Binary Search")
                BinarySearch();
      
            if (method == "Linear Search")
                LinearSearch();

            if (method == "Interpolation Search")
                InterpolationSearch();
        }
    }
}
