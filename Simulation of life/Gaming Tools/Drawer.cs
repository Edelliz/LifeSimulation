using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Simulation_of_life.Gaming_Tools;

namespace Simulation_of_life
{
    public class Drawer
    {
        private readonly PictureBox _gamePlace;
        private Graphics _graphics;
        
        public static Point InformationCell = new Point(-1000, -1000);
        public Drawer(PictureBox gamePlace)
        {
            _gamePlace = gamePlace;
        }

        public void Draw()
        {
            _gamePlace.Image = new Bitmap(_gamePlace.Width, _gamePlace.Height);
            _graphics = Graphics.FromImage(_gamePlace.Image);

            _graphics.Clear(SetBackground());

            DrawingEntities();
        }

        public void RedrawState()
        {      
            _graphics.Clear(SetBackground());
            _gamePlace.SizeMode = PictureBoxSizeMode.StretchImage;

            SendDataToTheInformationForm();
            
            DrawingEntities();

            _gamePlace.Refresh();
        }

        private void DrawingEntities()
        {
            var listOfAllEntity = World.ListOfEdiblePlants
                                                   .Concat<Entity>(World.ListOfInediblePlants)
                                                   .Concat(World.ListOfOmnivorousAnimals)
                                                   .Concat(World.ListOfCarnivorousAnimals)
                                                   .Concat(World.ListOfHerbivorousAnimals)
                                                   .Concat(World.ListOfHumans).ToList();

            foreach (var t in listOfAllEntity)
            {
                _graphics.DrawImage(t.CurrentImage, new Point(t.X, t.Y));

            }

            foreach (var t in World.ListOfBerries)
            {
                _graphics.DrawImage(t.CurrentImage, new Point(t.GetPosition.X, t.GetPosition.Y));
            }
        }

        private Color SetBackground()
        {
            return SimulationEngine.currentSeasons switch
            {
                EnumOfSeasons.Summer => World.Summer.ChangeColorOfTheSeason(),
                EnumOfSeasons.Winter => World.Winter.ChangeColorOfTheSeason(),
                EnumOfSeasons.Spring => World.Spring.ChangeColorOfTheSeason()
            };
            
        }
        
        private bool isFirst = true;
        public InformationFormAboutHuman InformationFormAboutHuman;
        private Tuple<int, int, EnumOfEntities, Inventory, OmnivorousAnimal, Animal> infoBlock;

        private Animal currentPers = null;
        private void SendDataToTheInformationForm()
        {
            if (InformationCell.X != -1000 && InformationCell.Y != -1000)
            {
                if (isFirst)
                {
                    infoBlock = IdentifyTheEntity();

                    if (infoBlock == null)
                    {
                        InformationCell.X = -1000;
                        InformationCell.Y = -1000;

                        return;
                    }
                    
                    InformationFormAboutHuman = new InformationFormAboutHuman();
                    InformationFormAboutHuman.GetInfoOfEntity(infoBlock);
                    
                    isFirst = false;
                }

                if (currentPers == null)
                {
                    InformationFormAboutHuman.Close();
                }

                if (currentPers._typeOfThis == EnumOfEntities.Human)
                {
                    var currentPersHuman = (Human) (currentPers);;
                    
                    InformationFormAboutHuman.GetInfoOfEntity(new Tuple<int, int, EnumOfEntities, Inventory, OmnivorousAnimal, Animal>
                        (currentPersHuman.Hp, currentPersHuman.Satiety, currentPersHuman._typeOfThis, currentPersHuman._inventory, currentPersHuman._pet, currentPersHuman.Lover));
                }

                else
                {
                    InformationFormAboutHuman.GetInfoOfEntity(new Tuple<int, int, EnumOfEntities, Inventory, OmnivorousAnimal, Animal>
                        (currentPers.Hp, currentPers.Satiety, currentPers._typeOfThis, null, null, null));
                }
                
                
                //Закрыть нормально форму

                if (InformationFormAboutHuman.IsCancel)
                {
                    InformationCell.X = -1000;
                    InformationCell.Y = -1000;
                    isFirst = true;
                    return;
                    
                }
                InformationFormAboutHuman.Show();
                
            }
        }
        
        private Tuple<int, int, EnumOfEntities,Inventory, OmnivorousAnimal, Animal> IdentifyTheEntity()
        {
            var animal = World.ListOfHerbivorousAnimals.Concat<Animal>(World.ListOfOmnivorousAnimals)
                .Concat(World.ListOfCarnivorousAnimals).ToList();
            
            foreach (var e in World.ListOfHumans)
            {
                if (InformationCell.X == e.X && InformationCell.Y == e.Y)
                {
                    currentPers = e;
                    return new Tuple<int, int, EnumOfEntities,Inventory, OmnivorousAnimal, Animal>(e.Hp, e.Satiety, e._typeOfThis, e._inventory, e._pet, e.Lover);
                }
            }
            
            foreach (var e in animal)
            {
                if (InformationCell.X == e.X && InformationCell.Y == e.Y)
                {
                    currentPers = e;
                    return new Tuple<int, int, EnumOfEntities,Inventory, OmnivorousAnimal, Animal>(e.Hp, e.Satiety, e._typeOfThis, null, null, null);
                }
            }

            return null;
        }
    }
}