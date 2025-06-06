namespace assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an MP3 player
            IObservable player = new MP3Player();

            // create the displays
            IObserver mp3Display1 = new SimpleMP3Display(player);
            IObserver mp3Display2 = new FancyMP3Display(player);

            // change song a few times
            player.NextSong();
            player.NextSong();
            player.NextSong();
        }
    }
}