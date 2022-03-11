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
        private float startTargetAmount = 1;  //nombre de cibles au début
        private float startTargetZ = 4;   //distance de départ des cibles
        private float targetSpeed = 0.01f;    //vitesse des cibles
        private float bonusChance = 30;    //chance de spawner un bonus
        private float playerLives = 3;    //nb de vies du joueur au début
        private float winScore = 1000;       //Score requis pour gagner
        private string levelName = "Level";     //nom du niveau
        private List<Gun> possibleWeapons = new List<Gun>();    //armes pouvant apparaîtres en tant que bonus
        private Gun startgun = null;  //arme de départ
        private float gravity = 0;    //déviation d'accélération YY
        private float wind = 0;   //déviation d'accélération X

        public float StartTargetAmount { get => startTargetAmount; set => startTargetAmount = value; }
        public float StartTargetZ { get => startTargetZ; set => startTargetZ = value; }
        public float TargetSpeed { get => targetSpeed; set => targetSpeed = value; }
        public float BonusChance { get => bonusChance; set => bonusChance = value; }
        public float PlayerLives { get => playerLives; set => playerLives = value; }
        public float WinScore { get => winScore; set => winScore = value; }
        public string LevelName { get => levelName; set => levelName = value; }
        public List<Gun> PossibleWeapons { get => possibleWeapons; set => possibleWeapons = value; }
        public Gun Startgun { get => startgun; set => startgun = value; }
        public float Gravity { get => gravity; set => gravity = value; }
        public float Wind { get => wind; set => wind = value; }
    }
}
