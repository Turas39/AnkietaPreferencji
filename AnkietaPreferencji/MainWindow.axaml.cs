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
        PodsumowanieButton.Click += PodsumowanieButton_Click;
    }
    
    private string Imie;
    private void SubmitButton_Click(object? sender, RoutedEventArgs e)
    {
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
    
    private void PodsumowanieButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            Imie = imie.Text;
            var Zainteresowania = (zainteresowania.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Nic";
            
            int liczbaTak = 0;
            if (checkbox1.IsChecked == true) liczbaTak++;
            if (checkbox2.IsChecked == true) liczbaTak++;
            if (checkbox3.IsChecked == true) liczbaTak++;
            if (checkbox4.IsChecked == true) liczbaTak++;

            PodsumowanieTextBlock.Text = $"Imię: {Imie}\nKategoria: {Zainteresowania}\nLiczba odpowiedzi TAK: {liczbaTak}";
            
        }
        catch (Exception exception)
        {
            InfoLabel.Content = $"Błąd: {exception.Message}";

        }
    }
    
}
