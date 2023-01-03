namespace RowReductionAlgorithm;

public partial class MainPage : ContentPage
{
	private Matrix matrix;
	private Dictionary<string, Entry> entries;
	public MainPage()
	{
		InitializeComponent();
		matrix   = new Matrix();
        Title = "Set Dimensions";
	}

    /// <summary>
    /// Checks the number. If it is an integer greater than 0 (for now) set the number as the bound. If it's not, then 
    /// display an alert and have user try again
    /// </summary>
    /// <returns>false if the desired number does not check out. True otherwise</returns>
    private bool TrySetColumns()
    {
        int value = -1;

        //set column number
        if (!int.TryParse(colNum.Text, out value))
        {
            DisplayAlert("Invalid Input", "Value must be in the set of natural numbers", "cancel");
            return false;
        }

        //not sure about this
        else if (value < 1)
        {
            DisplayAlert("Invalid Input", "Value must be in the set of natural numbers", "cancel");
            return false;   
        }
        
        matrix.ColNum = value;
        return true;
    }

    /// <summary>
    /// Checks the number. If it is an integer greater than 0 (for now) set the number as the bound. If it's not, then 
    /// display an alert and have user try again
    /// </summary>
    /// <returns>false if the desired number does not check out. True otherwise</returns>
    private bool TrySetRows()
    {
        int value = -1;

        if (!int.TryParse(rowNum.Text, out value))
        {
            DisplayAlert("Invalid Input", "Value must be in the set of natural numbers", "cancel");
            return false;
        }
        else if (value < 1)
        {
            DisplayAlert("Invalid Input", "Value must be in the set of natural numbers", "cancel");
            return false;
        }

        matrix.RowNum = value;
        return true;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
	private async void SetDimensions(object sender, EventArgs e)
	{
        if (!TrySetColumns())
            return;

        if (!TrySetRows())
            return;
        //
        if (matrix.RowNum > 0 && matrix.ColNum > 0)
        {

            await Navigation.PushAsync(new SetValuesPage(matrix));
        }

        else
        {
            await DisplayAlert("Invalid Input", "Enter in your desired dimensions and try again", "cancel");
        }
    }

}

