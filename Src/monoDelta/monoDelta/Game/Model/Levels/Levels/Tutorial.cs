using Game.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game.Model.Entity.Projectiles;

namespace monoDelta.Game.Model.Levels.Levels
{
    public class Tutorial : AbstractLevel
    {
        public Tutorial(Microsoft.Xna.Framework.Game game)
        {
            StartTargetAmount = 1;
            StartTargetZ = 100;
            TargetSpeed = -0.01f;
            BonusChance = 30;
            WinScore = 10;
            LevelName = "First shots (tutorial)";
            PlayerLives = 100;
            PossibleWeapons.Add(new Handgun(game, new SmallProjectile(game)));
            Startgun = PossibleWeapons[0];
            Gravity = 0;
            Wind = 0;
        }


    }
}
