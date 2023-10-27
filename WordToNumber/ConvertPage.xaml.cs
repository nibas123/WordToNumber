using WordToNumber.Helper;

namespace WordToNumber;

public partial class ConvertPage : ContentPage
{
	public ConvertPage()
	{
		InitializeComponent();
	}

    private void OnConvertClicked(object sender, System.EventArgs e)
    {
        if (int.TryParse(numberEntry.Text, out int number))
        {
            string result = NumberToWordsConverter.ConvertToWords(number);
            resultLabel.Text = $"In words: {result}";
        }
        else
        {
            resultLabel.Text = "Invalid input. Please enter a valid number.";
        }
    }
}