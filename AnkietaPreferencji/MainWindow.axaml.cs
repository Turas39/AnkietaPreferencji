using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Tmds.DBus.Protocol;
using Path = Avalonia.Controls.Shapes.Path;

namespace AnkietaPreferencji;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SubmitButton.Click += SubmitButton_Click;
    }
    
    private string Imie;
    private ComboBox Zainteresowania;

    private void SubmitButton_Click(object? sender, RoutedEventArgs e)
    {
        
        Imie = imie.Text;
        Zainteresowania = zainteresowania;
        
        try
        {
            var comboBoxValue = (zainteresowania.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Nic";

            var content = $"ComboBox: {comboBoxValue}";

            var desktopPath = Environment.GetFolderPath((Environment.SpecialFolder.Desktop));
            var filePath = System.IO.Path.Combine(desktopPath, "dane z apki");
            File.WriteAllText(filePath, content);


            InfoLabel.Content = "Zapisano";
        }
        catch (Exception exception)
        {
            InfoLabel.Content = $"Błąd: {exception.Message}";

        }
    }
}
