/*
Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/
using System;
using static System.Console;

// Создаем пустой (с нулями) массив;
int[,,] GetArray(int size1, int size2, int size3)
{
    int[,,] array = new int[size1, size2, size3];
    return array;
}

//Создаем ряд неповторяющихся случайных двузначных чисел;
int[] GetOneSizeArray(int[,,] array)
{
    int[] oneSizeArray = new int[array.GetLength(0) * array.GetLength(1) * array.GetLength(2)];
    oneSizeArray[0] = new Random().Next(10, 100);

    for (int i = 1; i < oneSizeArray.Length; i++)
    {
        oneSizeArray[i] = new Random().Next(10, 100);
        
        for (int j = 0; j<i; j++)
        {
            if (oneSizeArray[j] == oneSizeArray[i])
            {
                oneSizeArray[i] = new Random().Next(10, 100);
                j=-1;
            }

        }
    }
    return oneSizeArray;
}

// Заполняем пустой массив неповторяющимися числами из ранее созданного ряда
int [,,]GetUniqueArray(int [,,]array, int []oneSizeArray)
{
    int index = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = oneSizeArray[index];
                index++;
            }
        }
    }
    return array;
}

//Выводим на экран
void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Write($"{array[i, j, k]}({i},{j},{k}) ");
            }
            WriteLine();
        }
    }
}

Clear();
int[,,] array = GetArray(4, 4, 5);

if (array.GetLength(0) * array.GetLength(1) * array.GetLength(2) > 90)
{
    WriteLine("Такой массив не будет содержать неповторяющиеся двузначные элементы");
    return;
}

int[] oneSizeArray = GetOneSizeArray(array);
int[,,] uniqueArray = GetUniqueArray(array, oneSizeArray);
PrintArray(uniqueArray);

