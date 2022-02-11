
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Observable{
    /// <summary>
    /// This interface will enable implementing classes to subscribe to an Observable-inheriting class (like a timed game loop)
    /// </summary>
    public interface ISubscriber {


        void DoAction();

    }
}