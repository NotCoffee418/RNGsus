using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RNGsus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static double NextDouble()
        {
            byte[] bytes = new byte[8];
            RandomNumberGenerator.Fill(bytes);
            ulong ulongRand = BitConverter.ToUInt64(bytes, 0);

            // We use BitConverter.ToUInt64 to ensure the number is non-negative.
            // Then we divide by UInt64.MaxValue + 1.0 (which is 2^64) to get a value between 0.0 and 1.0.
            return (ulongRand / (UInt64.MaxValue + 1.0));
        }

        private void BlessedValueBtn_Click(object sender, RoutedEventArgs e)
        {
            BlessedValueBtn.Text = Math.Round(NextDouble() * 100.0, 1).ToString();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}