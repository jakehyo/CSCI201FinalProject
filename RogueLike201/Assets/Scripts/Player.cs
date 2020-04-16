using System;
using System.Collections.Generic;

namespace Final_Project_Client
{
    [Serializable]
    public class Player
    {
        public int playerID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int highScore { get; set; }
        public List<int> AllhighScore { get; set; }
        public bool newGamePlus { get; set; }
        public List<bool> cosmetic { get; set; }
        public int weaponID { get; set; }
        public int money { get; set; }
    }
}
