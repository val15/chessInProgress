using Chess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chess.View
{
  /// <summary>
  /// Interaction logic for SaveBestPositionsFofWindow.xaml
  /// </summary>
  public partial class SaveBestPositionsFofWindow : Window
  {
    private long? _turnId;
    private string _computerColore;
    private int _weight;
    public SaveBestPositionsFofWindow(long? turnId,string computerColore,int weight)
    {
      if (turnId == null)
        return;
      InitializeComponent();
      
      _turnId = turnId;
      _computerColore = computerColore;
      _weight = weight;
      var colorComboBoxItemsSource = new List<string>();
      colorComboBoxItemsSource.Add("White");
      colorComboBoxItemsSource.Add("Black");
      ColorComboBox.ItemsSource = colorComboBoxItemsSource;
      //la couleur par défaut est le contraire du computerColore
      if (_computerColore == "White")
        ColorComboBox.SelectedIndex = 1;
      else
        ColorComboBox.SelectedIndex = 0;
      WeightTextBox.Text = _weight.ToString();
    }

    private void PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      e.Handled = !IsTextAllowed(e.Text);
    }

    private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
    private static bool IsTextAllowed(string text)
    {
      return !_regex.IsMatch(text);
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      var service = new ServiceChessDB();

        service.AddBestPositionsFor(_turnId, ColorComboBox.SelectedItem.ToString(), _weight);
      
      this.Close();
      
    }
  }
}
