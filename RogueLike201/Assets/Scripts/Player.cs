using System;
using System.Collections.Generic;
using UnityEngine;

[SerializableAttribute]
public class Player
{
    public int PlayerID { get; set; }
    public string username { get; set; }
    public int HighScore { get; set; }
    public List<int> AllHighScore { get; set; }
    public bool NewGamePlus { get; set; }
    public List<bool> Cosmetic { get; set; }
    public int WeaponID { get; set; }
    public int Money { get; set; }
}
