using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public class MP3Player : IObservable
    {
        private List<IObserver> observers;
        private List<Song> songs;
        private int currentSongIndex;

        public Song CurrentSong { get; private set; }

        public MP3Player()
        {
            observers = new List<IObserver>();
            songs = new List<Song>
        {
            new Song("Bruno Mars", "Billionaire", "03:31"),
            new Song("Pink Floyd", "Wish You Were Here", "05:39"),
            new Song("Editors", "Papillon", "05:24")
        };
            currentSongIndex = -1;
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NextSong()
        {
            currentSongIndex = (currentSongIndex + 1) % songs.Count;
            CurrentSong = songs[currentSongIndex];
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(CurrentSong);
            }
        }
    }
}
