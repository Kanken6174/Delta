using Game.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoDelta.Game.Model.Levels
{
    public class Level
    {
        public float StartTargetAmount { get; set; } = 1;  //nombre de cibles au début
        public float StartTargetZ { get; set; } = 4;   //distance de départ des cibles
        public float TargetSpeed { get; set; } = 0.01f;    //vitesse des cibles
        public float BonusChance { get; set; } = 30;    //chance de spawner un bonus (/100)
        public float PlayerLives { get; set; } = 3;    //nb de vies du joueur au début
        public float WinScore { get; set; } = 1000;       //Score requis pour gagner
        public string LevelName { get; set; } = "Level";     //nom du niveau
        public float Gravity { get; set; } = 0;    //déviation d'accélération YY
        public List<Gun> PossibleWeapons { get; set; } = new List<Gun>();   //liste des armes pouvant apparaître dans ce niveau
        public ushort StartingGunIndex { get; set; } = 0;   //arme de départ
        public float Wind { get; set; } = 0;   //déviation d'accélération X
    }
}
