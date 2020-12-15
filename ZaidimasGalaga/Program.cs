using System;
using ZaidimasGalaga.Game;
using ZaidimasGalaga.GUI;

namespace ZaidimasGalaga
{
    class Program
    {
        static void Main(string[] args)
        {


            GuiController guiController = new GuiController();
            guiController.ShowMenu();


            MenuController menu = new MenuController();
            menu.ShowMenu();


            
        }
    }
}
