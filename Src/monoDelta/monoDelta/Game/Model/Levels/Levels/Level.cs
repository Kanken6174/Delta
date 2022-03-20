using Game.Model.Weapons;
using System.Collections.Generic;

namespace monoDelta.Game.Model.Levels
{
    /// <summary>
    /// this class represents a single game level
    /// </summary>
    public class Level
    {
        public float StartTargetAmount { get; set; } = 1;  //number of targets at start
        public float StartTargetZ { get; set; } = 10;   //starting distance of targets
        public int TargetSpawnDelay { get; set; } = 200; //the delay between each target spawn
        public float TargetSpeed { get; set; } = -0.005f;    //the speed at which each target will move (negative to move towards the player
        public float BonusChance { get; set; } = 0.01f;    //probability of spawning a bonus instead of a target
        public int PlayerLives { get; set; } = 3;    //starting amount of lives for the player
        public float WinScore { get; set; } = 1000;       //Minimum score to win the level
        public string LevelName { get; set; } = "Level";     //level name
        public float Gravity { get; set; } = 0;    //Y speed deviation
        public float Wind { get; set; } = 0;   //X speed deviation
        public List<Gun> PossibleWeapons { get; set; } = new List<Gun>();   //list of the weapons you can use in this level
        public ushort StartingGunIndex { get; set; } = 0;   //index fo whoch gun should be used at the start
    }
}
