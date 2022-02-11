
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Observable{
    public abstract class Observable {

        public Observable() {
        }

        private List<ISubscriber> subscribers;


        /// <summary>
        /// @param subscriber
        /// </summary>
        public void subscribe(ISubscriber subscriber) {
            // TODO implement here
        }

        /// <summary>
        /// @param subscriber
        /// </summary>
        public void unsubscribe(ISubscriber subscriber) {
            // TODO implement here
        }

    }
}