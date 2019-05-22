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
        int moves;
        int height;
        int width;
        int[,] walls;
        int[,] emptyCells;
        List<Point> emptyCellsList;
        int[,] cameras;
        int[,] conveyers;
        Point robotPosition;
        char[,] map;
        List<char> grid;
        List<Point> foundPoints;
        int i;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void getInput()
        {
            string input = txtInput.Text;
            int.TryParse(input.Substring(0, 1), out width);
            int.TryParse(input.Substring(2, 1), out height);

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
            foreach(int i in emptyCells)
            {
                if(i == 1)
                Console.WriteLine("empty");
            }
        }
           
        private void drawMatrices()
        {
            walls = new int[height, width];
            emptyCells = new int[height, width];
            cameras = new int[height, width];
            conveyers = new int[height, width];
            map = new char[height, width];
            emptyCellsList = new List<Point>();
            int i = 0;
            for(int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[y, x] = grid[i];
                    //MessageBox.Show(grid[i].ToString());
                    i++;
                }
            }
            assignMatrices();
        }
        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            getInput();
        }
        private void assignMatrices()
        {
            for(int y = 0; y < map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {
                    switch (map[y, x])
                    {
                        case 'W':
                        {
                            walls[y, x] = 1;
                            break;
                        }
                        case 'S':
                        {
                            robotPosition = new Point(y,x);
                            break;
                        }
                        case '.':
                        {
                            emptyCells[y, x] = 1;
                            Point p = new Point(y, x);
                            Console.WriteLine(p);
                            emptyCellsList.Add(p);
                            break;
                        }
                    }

                }
            }
            i = 0;
            moves = 0;
            txtOutput.Text = "";
            foundPoints = new List<Point>();
            escape(robotPosition);
        }
        private void escape(Point robotPos)
        {
            i++;
                foreach (Point p in emptyCellsList)
                {
                if(foundPoints.Contains(p))
                {
                    continue;
                }
                    if (p.Y == robotPos.Y)
                    {
                        if (p.X == robotPos.X + 1)
                        {
                            foundPoints.Add(p);
                            moves = i;
                            txtOutput.Text += moves.ToString() + "\r";
                            escape(new Point(robotPos.X + 1, robotPos.Y));
                        }
                        else if (p.X == robotPos.X - 1)
                        {
                            foundPoints.Add(p);
                            moves = i;
                            txtOutput.Text += moves.ToString() + "\r";
                            escape(new Point(robotPos.X - 1, robotPos.Y));
                        }
                    }
                    else if (p.X == robotPos.X)
                    {
                        if (p.Y == robotPos.Y + 1)
                        {
                            foundPoints.Add(p);
                            moves = i;
                            txtOutput.Text += moves.ToString() + "\r";
                            escape(new Point(robotPos.X, robotPos.Y + 1));
                        }
                        else if (p.Y == robotPos.Y - 1)
                        {
                            foundPoints.Add(p);
                            moves = i;
                            txtOutput.Text += moves.ToString() + "\r";
                            escape(new Point(robotPos.X, robotPos.Y - 1));
                        }
                    }
                }
        }
    }
}
