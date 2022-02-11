
using Game.Model.weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.events{
    public class WeaponCollectedEventArgs : EventArgs {

        public WeaponCollectedEventArgs() {
        }

        public Gun collectedWeapon;

    }
}