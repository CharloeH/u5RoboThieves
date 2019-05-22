/*
 * Sebastian Horton
 * Wednesday May 22, 2019
 * The Unit 5 Summative Problem: RoboThieves, completed in just over 1 hour (~365 days)
 * */

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

namespace U5RoboThieves
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int height;
        int width;
        int[,] walls;
        int[,] emptyCells;
        int[,] cameras;
        int[,] conveyers;
        int[,] robotPosition;
        char[,] map;
        List<char> grid;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void getInput()
        {
            string input = txtInput.Text;
            int.TryParse(input.Substring(0, 1), out height);
            int.TryParse(input.Substring(2, 1), out width);

            List<char> remaingInput = input.Substring(input.IndexOf("\r")).ToList<char>();
            grid = new List<char>();
           
           foreach(char c in remaingInput)
            {
                if (c != '\r' && c != '\n')
                {
                    grid.Add(c);
                   
                }     
            }
            drawMatrices();

        }
           
        private void drawMatrices()
        {
            walls = new int[height, width];
            emptyCells = new int[height, width];
            cameras = new int[height, width];
            conveyers = new int[height, width];
            robotPosition = new int[height, width];
            map = new char[height, width];
            int i = 0;
            for(int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[y, x] = grid[i];
                    MessageBox.Show(grid[i].ToString());
                    i++;
                }
            }
        }
        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            getInput();
        }
    }
}
