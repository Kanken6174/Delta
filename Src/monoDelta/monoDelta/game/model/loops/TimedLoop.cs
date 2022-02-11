
using Game.Model.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.loops{
    public abstract class TimedLoop : Observable.Observable {

        public TimedLoop() {
        }

        private int period;


        public abstract void Start();

        public abstract void Stop();

    }
}