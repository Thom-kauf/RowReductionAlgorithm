

namespace RowReductionAlgorithm;

public partial class MainPage : ContentPage
{
	private Matrix matrix;

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
			HSL.Clear();
            MakeGrid();
        }

		else
		{
			DisplayAlert("Invalid Input", "Enter in your desired dimensions and try again", "cancel");

		}
	}

	/// <summary>
	/// Makes a grid of entries that is rowNum rows by colNum columns
	/// </summary>
	private void MakeGrid()
	{

		List<Entry> entries = new List<Entry>();

        for (int i = 0; i < matrix.RowNum; i++)
        {
			HorizontalStackLayout hsl = new();
			vsl.Add(hsl);
			for (int j = 0; j < matrix.ColNum; j++)
			{
				Entry entry = new Entry();
				hsl.Add(entry);

				
				entries.Add(entry);
			}
        }


		HorizontalStackLayout hsl2 = new();
		vsl.Add(hsl2);

		

		Button refButton = new();
		refButton.Text = "REF that shit";

		Button reffButton = new();
		reffButton.Text = "REFF that shit";

		hsl2.Add(reffButton);
		hsl2.Add(refButton);

		//set up the handlers for the different buttons
		reffButton.Clicked += BeginReff;
		refButton.Clicked  += BeginRef;



        //boolean to keep track of if the next step needs to be commenced
        int neccessarryFilledEntries = matrix.RowNum * matrix.ColNum;
		int filledEntries = 0;
		//while all the entries are NOT filled, keep checking
        while (filledEntries < neccessarryFilledEntries)
        {
			foreach(Entry entry in entries)
			{
				entry.TextChanged
			}
        }






    }

	private void BeginReff(object sender, EventArgs e)
	{
		DisplayAlert("yes", "yues", "yes");
	}

    private void BeginRef(object sender, EventArgs e)
    {
        DisplayAlert("no", "no", "no");
    }
}

