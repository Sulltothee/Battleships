using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool[,] BackendGrid = new bool[8,8];
        bool[,] FrontEndGrid = new bool[8, 8];
        Boat[] allboats;
        int boatsDestroyed = 0;
        Random Rand = new Random();
        public struct Boat
        {
            //first int is which coordinate second digit is x / y
            public int[,] coordinates ;
            public int length;
            public int AmountDestroyed;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateBoats();
            GenerateButtons();
        }
        private const int GRID_SIZE = 8;

        private void GenerateButtons()
        {
            const int buttonSize = 30;
            const int spacing = 5;

            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    Button button = new Button();
                    //makes the button 30 x 30
                    button.Size = new System.Drawing.Size(buttonSize, buttonSize);
                    //decides the button's location
                    button.Location = new System.Drawing.Point(col * (buttonSize + spacing) + 20, row * (buttonSize + spacing) + 20);
                    button.Name = "(" + row.ToString() + "," + col.ToString() + ")";
                    //when the button is clicked references the function
                    button.Click += Button_Click;
                    Controls.Add(button);
                }
            }
        }
        void GenerateBoats()
        {
            int[] lengths = { 2, 3 , 3,4,5};
            allboats = new Boat[lengths.Length];
            for (int i = 0; i < lengths.Length; i++)
            {
                Boat freshBoat = new Boat();
                GenerateBoat(lengths[i], ref freshBoat);
                allboats[i] = freshBoat;
            }
            

        }
       void GenerateBoat(int length , ref Boat boat )
        {
            bool Done = false;
            while (!Done)
            {
                boat = new Boat();
                boat.length = length;
                bool RightOrDown = Convert.ToBoolean(Rand.Next(0, 2));
                boat.coordinates = new int[length, 2];
                bool valid = true;
                if (RightOrDown)
                {
                    boat.coordinates[0, 0] = Rand.Next(0, 8 - length);
                    boat.coordinates[0, 1] = Rand.Next(0, 8);
                    for (int i = 0; i < boat.length; i++)
                    {
                        if (BackendGrid[boat.coordinates[0, 0] + i, boat.coordinates[0, 1]] == true) { valid = false; break; }
                        else { boat.coordinates[0 + i, 0] = boat.coordinates[0, 0] + i; boat.coordinates[0 + i, 1] = boat.coordinates[0, 1]; }
                    }
                }
                else
                {
                    boat.coordinates[0, 0] = Rand.Next(0, 8);
                    boat.coordinates[0, 1] = Rand.Next(0, 8 - length);

                    for (int i = 0; i < boat.length; i++)
                    {
                        if (BackendGrid[boat.coordinates[0, 0], boat.coordinates[0, 1] + i] == true) { valid = false; break; }
                        else { boat.coordinates[0 + i, 0] = boat.coordinates[0, 0]; boat.coordinates[0 + i, 1] = boat.coordinates[0, 1] + i; }
                    }
                }
                if (valid)
                {
                    boat.AmountDestroyed = 0;
                    Done= true;
                    for (int i = 0; i < boat.length; i++)
                    {
                        BackendGrid[boat.coordinates[i, 0], boat.coordinates[i, 1]] = true;
                        
                    }
                }
            }
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int column = Convert.ToInt32(clickedButton.Name[3]-48);
                int row = Convert.ToInt32(clickedButton.Name[1]-48);
                if (BackendGrid[row, column] && !FrontEndGrid[row, column])
                {
                    FrontEndGrid[row, column] = true;
                    clickedButton.BackColor = Color.Red;
                    //checks each boat
                    for (int i = 0; i < allboats.Length; i++)
                    {
                        //checks all  t he boat coordinates
                        for (int j = 0; j < allboats[i].length; j++)
                        {
                            if (allboats[i].coordinates[j, 0] == row && allboats[i].coordinates[j, 1] == column)
                            {
                                allboats[i].AmountDestroyed += 1;
                                if (allboats[i].AmountDestroyed == allboats[i].length)
                                {
                                    boatsDestroyed += 1;
                                    SunkOutput.Text = ("Boats Sunk : " + boatsDestroyed);
                                }
                                i = allboats.Length; break;
                            }
                        }
                    }
                }
                else if (!FrontEndGrid[row, column]) { clickedButton.BackColor = Color.Azure; }
            }
        }


    }
}
