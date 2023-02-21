using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace IdentificationNumber
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cnpCode;
        Excel.Application app;

        public MainWindow()
        {
            InitializeComponent();
             app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open($"{Directory.GetCurrentDirectory()}\\Roman.xls");
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();

            Excel.Range range = app.get_Range("A1", "A42");
            Excel.Range range2 = app.get_Range("C1", "C42");

            foreach (Excel.Range item in range)
                list.Add(item.Text.ToString());
            foreach (Excel.Range item in range2)
                list2.Add(item.Text.ToString());

            CityComboBox.ItemsSource = list2;

         



        }

        private void GenerationButton_Click(object sender, RoutedEventArgs e)
        {
           


            int fisrtnumber;

            if (YesRadioButton.IsChecked == true)
            {


                if (BirthdayDatePicker.SelectedDate.Value.Year >= 1900 && BirthdayDatePicker.SelectedDate.Value.Year < 1950)
                {
                    fisrtnumber = 1;
                    cnpCode += Convert.ToString(fisrtnumber);
                }
                if (BirthdayDatePicker.SelectedDate.Value.Year >= 1950 && BirthdayDatePicker.SelectedDate.Value.Year < 2000)
                {
                    fisrtnumber = 2;
                    cnpCode += Convert.ToString(fisrtnumber);
                }
                if (BirthdayDatePicker.SelectedDate.Value.Year >= 1800 && BirthdayDatePicker.SelectedDate.Value.Year < 1850)
                {
                    fisrtnumber = 3;
                    cnpCode += Convert.ToString(fisrtnumber);
                }
                if (BirthdayDatePicker.SelectedDate.Value.Year >= 1850 && BirthdayDatePicker.SelectedDate.Value.Year < 1900)
                {
                    fisrtnumber = 4;
                    cnpCode += Convert.ToString(fisrtnumber);
                }
                if (BirthdayDatePicker.SelectedDate.Value.Year >= 2000 && BirthdayDatePicker.SelectedDate.Value.Year < 2050)
                {
                    fisrtnumber = 5;
                    cnpCode += Convert.ToString(fisrtnumber);
                }
                if (BirthdayDatePicker.SelectedDate.Value.Year >= 2050 && BirthdayDatePicker.SelectedDate.Value.Year < 2100)
                {
                    fisrtnumber = 6;
                    cnpCode += Convert.ToString(fisrtnumber);
                }
            }
            if(NoRadioButton.IsChecked== true)
           
            {
             Random rnd = new Random();

      int randomnumber = rnd.Next(7, 9);
                
                fisrtnumber = randomnumber;

                cnpCode += Convert.ToString(fisrtnumber);
            }
            int secondnumber;

            secondnumber = BirthdayDatePicker.SelectedDate.Value.Year;

   char[] arrYear = Convert.ToString(secondnumber).ToCharArray();


            string newSecondNumber = "";
            newSecondNumber += (Convert.ToString(arrYear[2]));


            newSecondNumber += (Convert.ToString(arrYear[3]));

            cnpCode += newSecondNumber;

            int thirdnumber;

            string newthirdnumber = "0";

            thirdnumber = BirthdayDatePicker.SelectedDate.Value.Month;

            if (thirdnumber < 10)
            {
                newthirdnumber += Convert.ToString(thirdnumber);

                cnpCode += newthirdnumber;
            }
            else
            {
                cnpCode += Convert.ToString(thirdnumber);
            }
            
            int fourthnumber;

            string newfourthnumber = "0";

            fourthnumber = BirthdayDatePicker.SelectedDate.Value.Day;

            if( fourthnumber < 10) 
            { 
                newfourthnumber += Convert.ToString(fourthnumber);

                cnpCode += newfourthnumber;
            }
            else
            {
                cnpCode+= Convert.ToString(fourthnumber);
            }
            int fifthnumber;

            string newfifthnumber = "0";

            fifthnumber = CityComboBox.SelectedIndex + 1;

            if(fifthnumber < 10)
            {
                newfifthnumber += Convert.ToString(fifthnumber);

                cnpCode += newfifthnumber;
            }
            else
            {
                cnpCode +=Convert.ToString(fifthnumber);
            }

           

            if(ManRadioButton.IsChecked == true)
            {
                cnpCode += "1";
            }
            if(WomanRadioButton.IsChecked == true)
            {
                cnpCode += "0";
            }

            char seventhnumber;

            string surName;

            string newSeventhnumber = "0";

            surName = SurNameTextBox.Text;

            char[] arrSurname = surName.ToCharArray();

            seventhnumber = arrSurname[0];

            if (Convert.ToInt32(seventhnumber) < 10)
            {
                newSeventhnumber += Convert.ToString(seventhnumber);

                cnpCode += newSeventhnumber;
            }
           
            else
            {
                cnpCode += Convert.ToInt32(seventhnumber).ToString();
            }

            int sum = 0;

            string cnpCodeControl = cnpCode;

            char[] arrControl = cnpCodeControl.ToCharArray();

            for(int i = 0; i < arrControl.Length; i++)
            {
                int y = 1;
           int abc = Convert.ToInt32(arrControl[i]) * y;

                sum = abc + sum;
                
                y++;
                
            }

            int ostatok;

            ostatok = sum % 11;

         if(ostatok == 10)
            {
                cnpCode += "1";
            }
            else
            {
                cnpCode += Convert.ToString(ostatok);
            }


            int dlinna = cnpCode.Length;
            MessageBox.Show($"Уникальный идентификационный номер Румынии равен:" + cnpCode + $"Его длинна составляет:{dlinna}");



        }

        private void Window_Closed(object sender, EventArgs e)
        {
            app.Quit();
        }
    }
}
