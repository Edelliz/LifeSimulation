using System;
using System.Timers;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Simulation_of_life
{
    public partial class Form1 : Form

    {
        private SimulationEngine _simulationEngine = new();
        private Drawer _drawer;
        private World _world = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            ReadDataFromTextBoxes();

            _drawer = new Drawer(GamePlace);
            _simulationEngine.InitializeMap();

            _drawer.Draw();
            timer1.Enabled = true;
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (World.ListOfCarnivorousAnimals.Any() && World.ListOfOmnivorousAnimals.Any() &&
                World.ListOfHerbivorousAnimals.Any())
            {
                timer1.Enabled = false;
            }

            _simulationEngine.SimulateNewState();
            _drawer.RedrawState();
            timer1.Enabled = true;
        }

        private void ReadDataFromTextBoxes()
        {
            GamePlace.Width = Convert.ToInt32(textBoxSizeWorld.Text);
            GamePlace.Height = Convert.ToInt32(textBoxSizeWorld.Text);
            
            //Identity of world

            World.SizeCell = Convert.ToInt32(textBoxCellSize.Text);
            World._sizeOfWorld = Convert.ToInt32(textBoxSizeWorld.Text);

            //Identity of animals
            World.StartingNumberOfHuman = Convert.ToInt32(textBoxHuman.Text);
            World.StartingNumberOfHerbivorousAnimal = Convert.ToInt32(textBoxNOH.Text);
            World.StartingNumberOfCarnivorousAnimal = Convert.ToInt32(textBoxNOC.Text);
            World.StartingNumberOfOmnivorousAnimal = Convert.ToInt32(textBoxNOO.Text);

            //IdentityOfPlants
            World.StartingNumberOfInediblePlantWithBerries = Convert.ToInt32(textBoxNOIPWB.Text);
            World.StartingNumberOfInediblePlantWithoutBerries = Convert.ToInt32(textBoxNOIPWTB.Text);

            World.StartingNumberOfEdibleToxicPlantWithBerries = Convert.ToInt32(textBoxNOTPWB.Text);
            World.StartingNumberOfEdibleToxicPlantWithoutBerries = Convert.ToInt32(textBoxNOTPWTB.Text);

            World.StartingNumberOfEdibleNonToxicPlantWithBerries = Convert.ToInt32(textBoxNONPWB.Text);
            World.StartingNumberOfEdibleNonToxicPlantWithoutBerries = Convert.ToInt32(textBoxNONPWTB.Text);
        }
        
        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            GamePlace.Width = (int) (GamePlace.Width / 1.2);
            GamePlace.Height = (int) (GamePlace.Height / 1.2);
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            GamePlace.Width = (int) (GamePlace.Width * 1.2);
            GamePlace.Height = (int) (GamePlace.Height * 1.2);
        }

        private void textBoxNOIPWB_Click(object sender, EventArgs e)
        {
            textBoxNOIPWB.Clear();
            textBoxNOIPWB.Text = 10.ToString();
        }

        private void textBoxNOIPWTB_Click(object sender, EventArgs e)
        {
            textBoxNOIPWTB.Clear();
            textBoxNOIPWTB.Text = 10.ToString();
        }

        private void textBoxNOTPWB_Click(object sender, EventArgs e)
        {
            textBoxNOTPWB.Clear();
            textBoxNOTPWB.Text = 20.ToString();
        }

        private void textBoxNOTPWTB_Click(object sender, EventArgs e)
        {
            textBoxNOTPWTB.Clear();
            textBoxNOTPWTB.Text = 20.ToString();
        }

        private void textBoxNONPWB_Click(object sender, EventArgs e)
        {
            textBoxNONPWB.Clear();
            textBoxNONPWB.Text = 100.ToString();
        }

        private void textBoxNONPWTB_Click(object sender, EventArgs e)
        {
            textBoxNONPWTB.Clear();
            textBoxNONPWTB.Text = 100.ToString();
        }

        private void textBoxNOH_Click(object sender, EventArgs e)
        {
            textBoxNOH.Clear();
            textBoxNOH.Text = 50.ToString();
        }

        private void textBoxNOC_Click(object sender, EventArgs e)
        {
            textBoxNOC.Clear();
            textBoxNOC.Text = 20.ToString();
        }

        private void textBoxNOO_Click(object sender, EventArgs e)
        {
            textBoxNOO.Clear();
            textBoxNOO.Text = 50.ToString();
        }
        
        private void textBoxCellSize_Click(object sender, EventArgs e)
        {
            textBoxCellSize.Clear();
            textBoxCellSize.Text = 10.ToString();
        }

        private void textBoxSizeWorld_Click(object sender, EventArgs e)
        {
            textBoxSizeWorld.Clear();
            textBoxSizeWorld.Text = 1000.ToString();
        }

        private void textBoxHuman_Click(object sender, EventArgs e)
        {
            textBoxHuman.Clear();
            textBoxHuman.Text = 20.ToString();
        }
        
        private void textBoxNOIPWB_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBoxNOIPWTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBoxNOTPWB_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBoxNOTPWTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBoxNONPWB_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBoxNONPWTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBoxNOH_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBoxNOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBoxNOO_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }
        
        private void textBoxCellSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }
        
        private void textBoxSizeWorld_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }
        
        private void textBoxHuman_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 8)
            {
                ((TextBox) sender).Clear();
            }
        }

        private void GamePlace_MouseClick(object sender, MouseEventArgs e)
        {
            Drawer.InformationCell.X = ReduceTheNumberToMultiple(e.X);
            Drawer.InformationCell.Y = ReduceTheNumberToMultiple(e.Y);
        }

        private int ReduceTheNumberToMultiple(int num)
        {
            if (num % World.SizeCell == 0)
            {
                return num;
            }

            for (var i = 1; i <= World.SizeCell; i++)
            {
                if ((num - i) % World.SizeCell == 0)
                {
                    return num - i;
                }
            }
            
            return -1000;
        }
        
    }
}