using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AnkietaPreferencji;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private string Imie;
    private ComboBox Zainteresowania;

    private void SubmitButton_Click(object? sender, RoutedEventArgs e)
    {
        Imie = imie.Text;
        Zainteresowania = zainteresowania;
    }
}