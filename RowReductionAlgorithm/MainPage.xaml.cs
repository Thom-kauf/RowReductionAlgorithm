namespace RowReductionAlgorithm;

public partial class MainPage : ContentPage
{
	private Matrix matrix;
	private Dictionary<string, Entry> entries;
	public MainPage()
	{
		InitializeComponent();
		matrix = new Matrix();
	}

	/// <summary>
	/// Sets column dimension for the matrix. Doesn't follow perfect mvc, but it would be really annoying to do this the 
	/// "right" way
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void SetColNum(object sender, EventArgs e)
	{
		int value = -1;

		if (!int.TryParse(colNum.Text, out value))
			DisplayAlert("Invalid Input", "Value must be in the set of natural numbers", "cancel");

		//not sure about this
		else if (value < 1)
			DisplayAlert("Invalid Input", "Value must be in the set of natural numbers", "cancel");

		else
			matrix.ColNum = value;

	}
	/// <summary>
	/// Doesn't follow perfect mvc, but it would be really annoying to do this the 
	/// "right" way
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void SetRowNum(object sender, EventArgs e)
	{
		int value = -1;

		if (!int.TryParse(rowNum.Text, out value))
			DisplayAlert("Invalid Input", "Value must be in the set of natural numbers", "cancel");

		else if (value < 1)
			DisplayAlert("Invalid Input", "Value must be in the set of natural numbers", "cancel");

		else
			matrix.RowNum = value;



	}

	private void SetDimensions(object sender, EventArgs e)
	{
		if (matrix.RowNum > 0 && matrix.ColNum > 0)
		{
			matrix.BackingArray = new double[matrix.RowNum, matrix.ColNum];
			HSL.Clear();
            MakeGrid();
        }

		else
		{
			DisplayAlert("Invalid Input", "Enter in your desired dimensions and try again", "cancel");

		}
	}

	private void SetBackingArr()
	{

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
			vsl.Add(hsl);


			for (int j = 0; j < matrix.ColNum; j++)
			{
				//show it in gui
				Entry entry = new Entry();
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
        refButton.Text = "REF";

        Button rrefButton = new();
        rrefButton.Text = "RREF";

        hsl2.Add(rrefButton);
        hsl2.Add(refButton);

        //set up the handlers for the different buttons
        rrefButton.Clicked += BeginRRef;
        refButton.Clicked += BeginRef;
    }

    /// <summary>
    /// When the RREF button is clicked, this method will be called. If every entry is filled in with a number, then 
    /// the backing 2D array will be filled in. Else, a warning will pop up and tell the user to fill out the grid 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BeginRRef(object sender, EventArgs e)
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
					DisplayAlert("Invalid Input", "Please enter numbers into each entry box in the grid and try again", "OK");
					return;
				}
            }
        }

		matrix.Ref();

    }

	/// <summary>
	/// When the Ref button is clicked, this method will be called. If every entry is filled in with a number, then 
	/// the backing 2D array will be filled in. Else, a warning will pop up and tell the user to fill out the grid 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void BeginRef(object sender, EventArgs e)
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
                    DisplayAlert("Invalid Input", "Please enter numbers into each entry box in the grid and try again", "OK");
                    return;
                }
            }
        }
		matrix.Rref();
    }
}

