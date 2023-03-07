/*
Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки 
с наименьшей суммой элементов: 1 строка
*/
using System;
using static System.Console;

int CorrectColumns (int rows)
{
    int columns = new Random().Next(1, 11);
    if (rows == columns)
    {
        columns = columns+1;
    }
    return columns;
}

int[,] GetArray(int rows, int columns, int minRandomValue, int maxRandomValue)
{
    int[,] array = new int[rows, columns];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(minRandomValue, maxRandomValue + 1);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Write($"{array[i, j]} ");
        }
        WriteLine();
    }
}

int[,] SumColumnsInEachRow(int[,] array)
{
    int[,] sum = new int[array.GetLength(0), 1];
    for (int i = 0; i < sum.GetLength(0); i++)
    {
        int result = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            result = result + array[i, j];
        }
        sum[i, 0] = result;
    }
    return sum;
}

void FindMinRow(int[,] array)
{
    int min = array[0, 0];
    int index = 1;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (array[i, 0] < min)
        {
            min = array[i, 0];
            index = i + 1;
        }
    }
    WriteLine($"Номер строки с наименьшей суммой элементов: {index} строка");
}

Clear();
int rows = new Random().Next(1, 11);
int columns = CorrectColumns (rows);
int[,] array = GetArray(rows, columns, -10, 10);
PrintArray(array);
WriteLine();
int[,] sum = SumColumnsInEachRow(array);
FindMinRow(sum);