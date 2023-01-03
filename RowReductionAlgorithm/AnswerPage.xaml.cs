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

        double[,] newBackingArr = Matrix.RowReduce(matrix.BackingArray);

        for (int i = 0; i < matrix.RowNum; i++)
        {
            for (int j = 0; j < matrix.ColNum; j++)
            {
                double newValue = newBackingArr[i, j];

                if (newValue.ToString().Equals("-0"))
                    newBackingArr[i, j] = 0;

                entries["" + i + j].Text = newBackingArr[i, j].ToString();
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