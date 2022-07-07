using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraySort : MonoBehaviour
{
    /* Array */
    private int[] array;
    private int[] array_Two = new int[7];
    public int[] array_Three = { 7, 13, 2, 5, 1, 8 };

    /* Rectangular two dimensional array */
    public int[,] rectangularArray2D; 
    public int[,] rectangularArray2D_Two = new int[3, 2]; //row = 3 | col = 2
    public int[,] rectangularArray2D_Three = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

    /* Jagged array (More efficient) */
    public int[][] jaggedArray; 
    public int[][] jaggedArray_Two = new int[4][];
    public int[][] jaggedArray_Three = {
                                    new int[] { 1, 3, 5, 7, 9 },
                                    new int[] { 0, 2, 4, 6 },
                                    new int[] { 11, 22 }
                                    };

    void Start()
    {

        //int totalNumberCells = rectangularArray2D.Length;
        //int rowSize = rectangularArray2D.GetLength(0);
        //int colSize = rectangularArray2D.GetLength(1);
        int rowIndex = 0;

        int rowSize = jaggedArray.Length;
        int colSize = jaggedArray[rowIndex].Length;

        int element = jaggedArray[2][1];

        //Get the element in the row 2 and col 1
        //int element = rectangularArray2D[2, 1];

        for (int i = 0; i < array_Three.Length; i++)
        {

        }
    }
}
