using System;

namespace bai_tap_tong_hop_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            int choice;
            bool checkInput = false;
            while (true)
            {
                Console.WriteLine();
                Menu();
                do
                {
                    Console.WriteLine("xin moi chon");
                    checkInput = int.TryParse(Console.ReadLine(), out choice);
                } while (!checkInput || choice <= 0 || choice > 5);
                switch (choice)
                {
                    case 1:
                        int number;
                        Console.WriteLine("chon do dai cua mang");
                        do
                        {
                            checkInput = int.TryParse(Console.ReadLine(), out number);
                        } while (!checkInput || number <= 0);
                        array = CreateArray(number);
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.Write(array[i] + " ");

                        }
                        break;
                    case 2:
                        if (IsSymmetryArray(array))
                        {
                            Console.WriteLine("mang doi xung");
                        }
                        else
                        {
                            Console.WriteLine("mang ko doi xung");
                        }
                        break;
                    case 3:
                        SelectionSort(array);
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.Write(array[i] + " ");

                        }
                        break;
                    case 4:
                        int numberToSearch;
                        if (CheckSort(array) == false)
                        {
                            Console.WriteLine("can pha sap xep trc khi tim");
                        }
                        else
                        {
                            Console.WriteLine("nhap so can tim");
                            do
                            {
                                checkInput = int.TryParse(Console.ReadLine(), out numberToSearch);
                            } while (!checkInput || numberToSearch <= 0);
                            if (FindKDQ(array, numberToSearch) != -1)
                            {
                                Console.WriteLine($"{numberToSearch} nam o vi tri so " + FindKDQ(array, numberToSearch));
                            }
                            else
                            {
                                Console.WriteLine($"{numberToSearch} khong co trong mang");
                            }
                        }




                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                }


            }

        }
        static void Menu()
        {
            Console.WriteLine("=========MENU=========");
            Console.WriteLine("1. TAO MANG: ");
            Console.WriteLine("2. KIEM TRA MANG DOI XUNG: ");
            Console.WriteLine("3. SAP XEP MANG: ");
            Console.WriteLine("4. TIM KIEM MANG: ");
            Console.WriteLine("5. THOAT ");
        }
        static int[] CreateArray(int n)
        {
            int[] array = new int[n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = r.Next(30, 60);
            }
            return array;
        }
        static bool IsSymmetryArray(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != arr[arr.Length - 1 - i])
                {
                    count++;
                    return false;
                }
            }
            return true;
        }
        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;

            }
        }
        static int Find(int[] arr, int low, int high, int numberSearch)
        {
            low = 0;
            high = arr.Length - 1;

            if (high >= low)
            {
                int mid = (high - low) / 2;
                if (arr[mid] == numberSearch)
                { return mid; }
                if (arr[mid] > numberSearch)
                { return Find(arr, low, mid - 1, numberSearch); }
                return Find(arr, mid + 1, high, numberSearch);
            }
            return -1;

        }
        static int FindKDQ(int[] arr, int numberSearch)
        {

            int low = 0;
            int high = arr.Length - 1;
            while (high >= low)
            {
                int mid = (high + low) / 2;
                if (numberSearch < arr[mid])
                {
                    high = mid - 1;
                }
                else if (numberSearch == arr[mid])
                {
                    return mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }
        static bool CheckSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
