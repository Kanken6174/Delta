namespace Game.Model.loops
{
    public abstract class TimedLoop : Observable.Observable
    {

        public TimedLoop()
        {
        }

        private int period;


        public abstract void Start();

        public abstract void Stop();

    }
}