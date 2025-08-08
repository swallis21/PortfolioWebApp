using System.Diagnostics;

namespace PortfolioWebApp.Domain.Models.Singletons;

public class MusicData
{
    private static List<Song> _Songs { get; set; }
    private static IEnumerator<Song> _CurrentSong { get; set; }

    public MusicData()
    {
        _Songs = new List<Song>()
        {
            new Song {
                URL = "/music/Milky Chance - Addicted.mp3",
                Artist = "Milky Chance",
                Title = "Addicted"
            },
            new Song
            {
                URL = "/music/Moby - Hymn.mp3",
                Artist = "Moby",
                Title = "Hymn"
            },
            new Song
            {
                URL = "/music/Joywave - Destruction.mp3",
                Artist = "Joywave",
                Title = "Destruction"
            },
            new Song
            {
                URL = "/music/Ratatat - Mirando.mp3",
                Artist = "Ratatat",
                Title = "Mirando"
            },
            new Song
            {
                URL = "/music/Emancipator - First Snow.mp3",
                Artist = "Emancipator",
                Title = "First Snow"
            },
            new Song
            {
                URL = "/music/Phantogram - Feedback Invisible.mp3",
                Artist = "Phantogram",
                Title = "Feedback Invisible"
            },
            new Song
            {
                URL = "/music/The Crystal Method - Trip Like I Do.mp3",
                Artist = "The Crystal Method",
                Title = "Trip Like I Do"
            }
        };
        _CurrentSong = _Songs.GetEnumerator();
        _CurrentSong.MoveNext();
    }

    public async Task<Song> GetSong()
    {
        return await Task.FromResult(_CurrentSong.Current);
    }

    public async Task<Song> RandomSong()
    {
        _CurrentSong.Reset();
        var rnd = new Random();
        for (int i = rnd.Next(_Songs.Count); i >= 0; i -= 1)
        {
            _CurrentSong.MoveNext();
        }
        return await GetSong();
    }

    public async Task<Song> NextSong()
    {
        if (!_CurrentSong.MoveNext())
        {
            _CurrentSong.Reset();
            _CurrentSong.MoveNext();
        }
        return await GetSong();
    }
}
