namespace RowReductionAlgorithm;

public partial class SetValuesPage : ContentPage
{
    private Matrix matrix;
    private Dictionary<string, Entry> entries;
    public SetValuesPage(Matrix matrix)
	{

        Title = "Set Entries";

		InitializeComponent();
        this.matrix = matrix;
        MakeGrid();
    }


    /// <summary>
    /// Makes a grid of entries that is rowNum rows by colNum columns
    /// </summary>
    private void MakeGrid()
    {
        matrix.BackingArray = new double[matrix.RowNum, matrix.ColNum];
        //initialize the 2d arrays of entries
        entries = new();
        //generate as many entries as specified
        for (int i = 0; i < matrix.RowNum; i++)
        {
            //make the entries in a list of vertical stack layouts essentially
            HorizontalStackLayout hsl = new();

        
            vsl.Add(hsl);


            for (int j = 0; j < matrix.ColNum; j++)
            {
                //show it in gui
                Entry entry = new Entry();
                entry.HeightRequest = this.Height / matrix.RowNum;
                entry.WidthRequest = this.Width / matrix.ColNum;
                hsl.Add(entry);

                //add to dictionary to keep track of index
                entries.Add("" + i + j, entry);
            }
        }
        MakeButtons();
    }

    /// <summary>
    /// helper method just for readibility. Makes the ref and rref buttons to start the next phase of the app
    /// </summary>
    private void MakeButtons()
    {
        //create the buttons
        HorizontalStackLayout hsl2 = new();
        vsl.Add(hsl2);

        Button refButton = new();
        refButton.Text = "Reduce";
        hsl2.Add(refButton);

        //set up the handler
        refButton.Clicked += BeginRef;
    }

    /// <summary>
    /// When the Ref button is clicked, this method will be called. If every entry is filled in with a number, then 
    /// the backing 2D array will be filled in. Else, a warning will pop up and tell the user to fill out the grid 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BeginRef(object sender, EventArgs e)
    {
        double value;
        //loop through both dimensions of the matrix. If we can't parse one thing to a double, then display an alert
        for (int i = 0; i < matrix.RowNum; i++)
        {
            for (int j = 0; j < matrix.ColNum; j++)
            {
                if (double.TryParse(entries["" + i + j].Text, out value))
                    //set it
                    matrix.backingArray[i, j] = value;
                else
                {
                    await DisplayAlert("Invalid Input", "Please enter numbers into each entry box in the grid and try again", "OK");
                    return;
                }
            }
        }
        await Navigation.PushAsync(new AnswerPage(matrix, entries));
    }


}