
using Game.Model.Weapons;
using System;

namespace Game.Model.events
{
    public class WeaponCollectedEventArgs : EventArgs
    {

        public WeaponCollectedEventArgs()
        {
        }

        public Gun collectedWeapon;

    }
}