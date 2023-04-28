using CV12;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http.Json;

namespace CalcApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBox_Initialize(operation);
        }
        private HttpClient _client;
        private async void Calculate(object sender, RoutedEventArgs e)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7261/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new
            MediaTypeWithQualityHeaderValue("application/json"));
            CalcDTO calcDTO = new CalcDTO();
            calcDTO.Operand1 = decimal.Parse(operand1.Text);
            calcDTO.Operand2 = decimal.Parse(operand2.Text);
            if (operation.Text == "+")
            {
                calcDTO.Operation = "plus";
            }
            else if (operation.Text == "-")
            {
                calcDTO.Operation = "minus";
            }
            else if (operation.Text == "*")
            {
                calcDTO.Operation = "times";
            }
            else if (operation.Text == "/")
            {
                calcDTO.Operation = "devide";
            }
            HttpResponseMessage response = await
            _client.PostAsJsonAsync($"api/calc", calcDTO);
            response.EnsureSuccessStatusCode();
            result.Content = await response.Content.ReadAsStringAsync();
        }

        private void ComboBox_Initialize(object sender)
        {
            ComboBox comboBox = sender as ComboBox;
            comboBox.Items.Add("+");
            comboBox.Items.Add("-");
            comboBox.Items.Add("*");
            comboBox.Items.Add("/");
        }
    }
}
