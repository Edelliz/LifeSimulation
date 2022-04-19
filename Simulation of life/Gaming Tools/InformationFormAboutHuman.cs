using System;
using System.Windows.Forms;

namespace Simulation_of_life.Gaming_Tools
{
    public partial class InformationFormAboutHuman : Form
    {
        public bool IsCancel = false;
        public InformationFormAboutHuman()
        {
            InitializeComponent();
        }

        public void GetInfoOfEntity(Tuple<int, int, EnumOfEntities, Inventory, OmnivorousAnimal, Animal> info)
        {
            if (info.Item3 == EnumOfEntities.Human)
            {
                FillInTheDataForTheHuman(info);
            }

            else
            {
                FillInTheDataForTheAnimal(info);
            }
        }

        private void FillInTheDataForTheAnimal(
            Tuple<int, int, EnumOfEntities, Inventory, OmnivorousAnimal, Animal> info)
        {
            ClearAll();

            textBoxHP.Text = info.Item1.ToString();
            textBoxSatiety.Text = info.Item2.ToString();
            textBoxType.Text = info.Item3.ToString();
            
            listBoxTamedAnimal.Items.Add("Not a human");
            listBoxPartner.Items.Add("Not a human");
            listBoxInfoInventory.Items.Add("Not a human");


        }
        private void FillInTheDataForTheHuman(Tuple<int, int, EnumOfEntities, Inventory, OmnivorousAnimal, Animal> info)
        {
            ClearAll();

            textBoxHP.Text = info.Item1.ToString();
            textBoxSatiety.Text = info.Item2.ToString();
            textBoxType.Text = info.Item3.ToString();

            string[] infoInv =
            {
                "Meat: " + info.Item4.AmountOfMeat + "\n",
                "Edible plant: " + info.Item4.SectionWithEdiblePlants.Count + "\n",
                "Inedible plant: " + info.Item4.SectionWithInediblePlants.Count + "\n",
                "Berries: " + info.Item4.SectionWithBerries.Count
            };

            listBoxInfoInventory.Items.AddRange(infoInv);

            if (info.Item5 != null)
            {
                string[] infoPet =
                {
                    "Coordinate: X = " + info.Item5.X, " Y = " + info.Item5.Y + "\n",
                    "Subspecies: " + info.Item5._typeOfThis
                };

                listBoxTamedAnimal.Items.AddRange(infoPet);
            }
            else
            {
                listBoxTamedAnimal.Items.Add("No pet");
            }

            if (info.Item6 != null)
            {
                string[] infoLover =
                {
                    "Coordinate: \n X = " + info.Item6.X, "\n Y = " + info.Item6.Y + "\n"
                };

                listBoxPartner.Items.AddRange(infoLover);
            }
            else
            {
                listBoxPartner.Items.Add("No lover");
            }
        }
        private void ClearAll()
        {
            textBoxHP.Clear();
            textBoxSatiety.Clear();
            textBoxType.Clear();
            listBoxInfoInventory.Items.Clear();
            listBoxTamedAnimal.Items.Clear();
            listBoxPartner.Items.Clear();
        }
        
        public void InformationFormAboutHuman_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Вы действительно хотите выйти из программы?",
                "Завершение программы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (dialog == DialogResult.Yes)
            {
                IsCancel = true;
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}