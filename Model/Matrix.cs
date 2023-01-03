namespace RowReductionAlgorithm;
    
/// <summary>
/// This class will handle the logic for the algorithm
/// </summary>
public class Matrix
{
    //dimensions of the matrix
    private int colNum;
    private int rowNum;
    public double[,]? backingArray;   

    /// <summary>
    /// property for columns of the matrix
    /// </summary>
    public int ColNum
    {
        get { return colNum; }
        set { colNum = value; }
    }
    /// <summary>
    /// property for columns of the matrix
    /// </summary>
    public int RowNum
    {
        get { return rowNum; }
        set { rowNum = value; }
    }
    /// <summary>
    /// property for setting the backing array and accessing
    /// </summary>
    public double[,]? BackingArray
    {
        get { return backingArray; }
        set { backingArray = value; }
    }

    public static double[,] RowReduce(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            // Find the pivot row
            int pivot = i;
            for (int j = i + 1; j < rows; j++)
            {
                if (Math.Abs(matrix[j, i]) > Math.Abs(matrix[pivot, i]))
                {
                    pivot = j;
                }
            }

            // Swap the pivot row with the current row
            if (pivot != i)
            {
                for (int j = 0; j < cols; j++)
                {
                    double temp = matrix[i, j];
                    matrix[i, j] = matrix[pivot, j];
                    matrix[pivot, j] = temp;
                }
            }

            // Normalize the current row
            double divisor = matrix[i, i];
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] /= divisor;
            }

            // Eliminate the current variable from the other rows
            for (int j = 0; j < rows; j++)
            {
                if (j == i) continue;

                double factor = matrix[j, i];
                for (int k = 0; k < cols; k++)
                {
                    matrix[j, k] -= factor * matrix[i, k];
                }
            }
        }

        return matrix;
    }
}
