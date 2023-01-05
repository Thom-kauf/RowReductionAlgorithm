namespace RowReductionAlgorithm;

public partial class AnswerPage : ContentPage
{
    private Matrix matrix;
    private Dictionary<string, Entry> entries;
    public AnswerPage(Matrix matrix, Dictionary<string, Entry> entries)
	{
		InitializeComponent();

        this.matrix = matrix;
        this.entries = entries;

        DisplayResults();

	}

    private void DisplayResults()
    {
        MakeGrid();
        RowReduce();
    }

    /// <summary>
    /// ChatGPT helped with this method. I'm going to modify it to trigger an event that displays each step.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public void RowReduce()
    {
        int rows = matrix.BackingArray.GetLength(0);
        int cols = matrix.BackingArray.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {
            // Find the pivot row
            int pivot = i;
            for (int j = i + 1; j < rows; j++)
            {
                if (Math.Abs(matrix.backingArray[j, i]) > Math.Abs(matrix.backingArray[pivot, i]))
                {
                    pivot = j;
                    //highlight the pivot row with a color
                    //entries["" + j + i].BackgroundColor = Colors.LightBlue;
                }

            }

            // Swap the pivot row with the current row
            if (pivot != i)
            {
                for (int j = 0; j < cols; j++)
                {
                    double temp = matrix.BackingArray[i, j];
                    matrix.BackingArray[i, j] = matrix.BackingArray[pivot, j];
                    matrix.BackingArray[pivot, j] = temp;

                    entries["" + i + j].Text = matrix.backingArray[i, j].ToString();
                }

                

            }
            

            // Normalize the current row
            double divisor = matrix.BackingArray[i, i];
            for (int j = 0; j < cols; j++)
            {
                matrix.BackingArray[i, j] /= divisor;
                entries["" + i + j].Text = matrix.backingArray[i, j].ToString();
            }
            

            // Eliminate the current variable from the other rows
            for (int j = 0; j < rows; j++)
            {
                if (j == i) continue;

                double factor = matrix.BackingArray[j, i];
                for (int k = 0; k < cols; k++)
                {
                    matrix.BackingArray[j, k] -= factor * matrix.BackingArray[i, k];
                    entries["" + j + k].Text = matrix.backingArray[j, k].ToString();
                }
            }
            
        }

    }


    /// <summary>
    /// Makes a grid of entries that is rowNum rows by colNum columns
    /// </summary>
    private void MakeGrid()
    {
        
        //initialize the 2d arrays of entries
        entries = new();
        //generate as many entries as specified
        for (int i = 0; i < matrix.RowNum; i++)
        {
            //make the entries in a list of vertical stack layouts essentially
            HorizontalStackLayout hsl = new();
            hsl.HorizontalOptions = LayoutOptions.Center;
            hsl.VerticalOptions = LayoutOptions.Center;
            vsl.Add(hsl);


            for (int j = 0; j < matrix.ColNum; j++)
            {
                //show it in gui
                Entry entry = new Entry();
                entry.WidthRequest = 450 / matrix.ColNum;
                entry.HeightRequest = 200 / matrix.RowNum;
                entry.HorizontalOptions = LayoutOptions.Center;
                hsl.Add(entry);

                //add to dictionary to keep track of index
                entries.Add("" + i + j, entry);
            }
        }

    }
}