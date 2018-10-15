namespace FXCMCommands
{
    public class LivePriceSubscriber
    {
        //todo fire event of price when received
        
        private string s;
        public string Symbol

        {
            get { return s;}
            set { s = value;}
        }
        

        public LivePriceSubscriber(string s)
        {
            this.s = s;
        }

        
    }
}