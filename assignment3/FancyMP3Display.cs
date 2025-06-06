using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{

    public class FancyMP3Display : IObserver
    {
        public FancyMP3Display(IObservable player)
        {
            player.AddObserver(this);
        }

        public void Update(Song song)
        {
            Console.WriteLine($"Fancy display: {song.Title} by {song.Artist} ({song.Duration})");
            Console.WriteLine("");
        }
    }
}
