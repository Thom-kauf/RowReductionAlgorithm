namespace RowReductionAlgorithm;
    
/// <summary>
/// This class will handle the logic for the algorithm
/// 
/// Authors: Thomas Kauffman and ChatGPT
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


}
