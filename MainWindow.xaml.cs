using System;
using System.Collections.Generic;
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

namespace Simple_BAC_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double bac = 0;
        double drinks = 0;
        double weight = 0;
        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        /// <summary>
        /// Checks the first radio button in the application for user validation
        /// </summary>
        private void InitializeWindow()
        {
            TextBox_Weight.Focus();
            RadioButton_Male.IsChecked = true;
        }

        /// <summary>
        /// Exits the application window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Calculate users BAC based on weight, drinks, and gender constants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Calc_BAC_Click(object sender, RoutedEventArgs e)
        {

            if (ValidInputs(out string userFeedback))
            {
                drinks = Convert.ToDouble(TextBox_Drinks.Text) * 14;
                weight = Convert.ToDouble(TextBox_Weight.Text) * 454;

                if (RadioButton_Male.IsChecked == true)
                {
                    bac = (drinks / (weight * 0.68)) * 100;
                    TextBox_Answer.Text = bac.ToString();
                    ;
                }
                if (RadioButton_Female.IsChecked == true)
                {
                    bac = (drinks / (weight * 0.55)) * 100;
                    TextBox_Answer.Text = bac.ToString();
                }
            }
            else
            {
                //
                //creates popup message for user validation
                //
                MessageBox.Show(userFeedback);
            }
        }

        private void RadioButton_Male_Checked(object sender, RoutedEventArgs e)
        {
            
        } 
        private void RadioButton_Female_Checked(object sender, RoutedEventArgs e)
        {
            
        }
        /// <summary>
        /// Validation for number of drinks and users weight
        /// </summary>
        /// <param name="userFeedback"></param>
        /// <returns>valid input</returns>
        private bool ValidInputs(out string userFeedback)
        {
            bool validInputs = true;
            userFeedback = "";

            if (!double.TryParse(TextBox_Weight.Text, out double tempWeight))
            {
                validInputs = false;
                userFeedback += "You have entered an invalid weight. Please enter a valid number (0-400)." + Environment.NewLine;
            }
            if (!double.TryParse(TextBox_Drinks.Text, out double tempDrinks))
            {
                validInputs = false;
                userFeedback += "Invalid entry. Please enter amount of drinks as a number." + Environment.NewLine;
            }

            return validInputs;
        }

        /// <summary>
        /// Clear button to reset all of the attributes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            bac = 0;
            weight = 0;
            drinks = 0;
            TextBox_Drinks.Text = "";
            TextBox_Weight.Text = "";
            TextBox_Answer.Text = "";
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }
    }
}
