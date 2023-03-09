/*
Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/
using System;
using static System.Console;

int[,] GetArray1(int rows, int columns, int minRandomValue, int maxRandomValue)
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

int[,] GetArray2(int [,]firstArray, int columns, int minRandomValue, int maxRandomValue)
{
    int[,] array = new int[firstArray.GetLength(1), columns];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(minRandomValue, maxRandomValue + 1);
        }
    }
    return array;
}

int[,] GetArray3(int [,]firstArray, int [,]secondArray)
{
    int[,] array = new int[firstArray.GetLength(0), secondArray.GetLength(1)];
    int sum = 0;
    

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k<firstArray.GetLength(1); k++)
            {
                sum = sum + firstArray[i, k]*secondArray[k, j];
            }
            array[i, j] = sum;
            sum = 0;
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

Clear();
int rows = new Random().Next(1, 10);
int columnsFirstArray = new Random().Next(1, 10);
int columnsSecondArray = new Random().Next(1, 10);
int minRandomValue = 1;
int maxRandomValue = 10;
int [,] firstArray = GetArray1(rows, columnsFirstArray, minRandomValue, maxRandomValue);
int [,] secondArray = GetArray2(firstArray, columnsSecondArray, minRandomValue, maxRandomValue);
int [,] finalArray = GetArray3(firstArray, secondArray);
PrintArray(firstArray);
WriteLine();
PrintArray(secondArray);
WriteLine();
PrintArray(finalArray);
