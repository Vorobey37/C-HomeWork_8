/*
Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/
using System;
using static System.Console;

// Работает с любым массивом (любое количество rows и columns)
int[,] GetArray(int rows, int columns)
{
    int[,] array = new int[rows, columns];
    int maxResult = rows * columns;
    int sum = 0;
    int startRows = 0;
    int startColumns = -1;
    int index = 0;

    while (sum < maxResult)
    {
        for (int j = index; j < columns; j++)
        {
            sum = sum + 1;
            array[array.GetLength(0) - rows, j] = sum;
        }

        if (sum >= maxResult)
        {
            return array;
        }

        index++;

        for (int i = index; i < rows; i++)
        {
            sum = sum + 1;
            array[i, columns - 1] = sum;
        }

        if (sum >= maxResult)
        {
            return array;
        }

        for (int j = array.GetLength(1) - 1 - index; j > startColumns; j--)
        {
            sum = sum + 1;
            array[rows - 1, j] = sum;
        }

        if (sum >= maxResult)
        {
            return array;
        }

        for (int i = array.GetLength(0) - 1 - index; i > startRows; i--)
        {
            sum = sum + 1;
            array[i, array.GetLength(1) - columns] = sum;
        }

        if (sum >= maxResult)
        {
            return array;
        }

        rows--;
        columns--;
        startRows++;
        startColumns++;
    }

    return array;
}

void PrintArray(int[,] array) //Для красивой печати рассчитано только для одно- и двузначных значений элементов
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < 10)
            {
                Write($"0{array[i, j]} ");
            }
            else
            {
                Write($"{array[i, j]} ");
            }
        }
        WriteLine();
    }
}

Clear();
int rows = new Random().Next(1, 11);
int columns = new Random().Next(1, 11);
int[,] array = GetArray(rows, columns);
PrintArray(array);


