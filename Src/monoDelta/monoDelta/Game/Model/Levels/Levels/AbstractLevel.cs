using Game.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoDelta.Game.Model.Levels
{
    public abstract class AbstractLevel
    {
        public float StartTargetAmount { get; protected set; }  //nombre de cibles au début
        public float StartTargetZ { get; protected set; }   //distance de départ des cibles
        public float TargetSpeed { get; protected set; }    //vitesse des cibles
        public float BonusChance { get; protected set; }    //chance de spawner un bonus
        public float PlayerLives { get; protected set; }    //nb de vies du joueur au début
        public float WinScore { get; protected set; }       //Score requis pour gagner
        public string LevelName { get; protected set; }     //nom du niveau
        public List<Gun> PossibleWeapons { get; protected set; }    //armes pouvant apparaîtres en tant que bonus
        public Gun Startgun { get; protected set; }  //arme de départ
        public float Gravity { get; protected set; }    //déviation d'accélération YY
        public float Wind { get; protected set; }   //déviation d'accélération X
    }
}
