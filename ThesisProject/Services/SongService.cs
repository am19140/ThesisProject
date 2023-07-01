using System;
using ThesisProject.Context;
using ThesisProject.Models;
using System.Linq;

public class SongService
{
    private readonly DatabaseContext _context;

    public SongService(DatabaseContext context)
	{
        _context = context;

    }

    public List<(SongModel songmodel, bool isLiked)> getAllSongs(string username, string mood)
    {
        var songs = _context.songs.Where(x => x.mood == mood).OrderBy(x => x.songname).ToList();
        List<(SongModel songmodel, bool isLiked)> tuples = new List<(SongModel songmodel, bool isLiked)>();

        foreach (var song in songs)
        {
            bool isliked = _context.likes.Any(x => x.songId == song.songId && x.username == username);
            tuples.Add((song, isliked));
        }

        return tuples;

    }


    public List<(SongModel songmodel,bool isLiked)> getSongList(string username,string mood)
    {        
        var songs = _context.songs.Where(x => x.mood == mood).OrderBy(x => x.songname).ToList();

        var listened = (from h in _context.history.ToList()
                        join s in songs on h.songId equals s.songId
                        where h.username == username && h.timesListened > 0
                        orderby h.timesListened descending
                        select new SongModel
                        {
                            songId = h.songId,
                            songname = s.songname,
                            artist = s.artist,
                            duration = s.duration,
                            mood = s.mood,
                            genre = s.genre,
                            songfile = s.songfile

                        }).ToList();
        if (listened.Count > 0)
        {
            var most_frequent1 = listened.GroupBy(h => h.GetType().GetProperty("genre").GetValue(h))
                .Select(g => new Genre { genre = g.Key.ToString(), count = g.Count() });

            var most_freq_genres = most_frequent1.OrderByDescending(x => x.count).ToList().Take(3);
            var given_songs = new List<SongModel>();
            foreach (var genre in most_freq_genres)
            {
                var list_genre = _context.songs.Where(x => x.mood == mood).Where(x => x.genre == genre.genre).ToList();
                foreach (var l in list_genre)
                {
                    given_songs.Add(l);
                }
            }


            //var given_songs = _context.songs.Where(x => x.mood == mood).Where(x => x.genre == most_freq_genres.ElementAt(0).genre || x.genre == most_freq_genres.ElementAt(1).genre || x.genre == most_freq_genres.ElementAt(2).genre).ToList();

            List<(SongModel songmodel, bool isLiked)> tuples = new List<(SongModel songmodel, bool isLiked)>();

            foreach (var song in given_songs)
            {
                bool isliked = _context.likes.Any(x => x.songId == song.songId && x.username == username);
                tuples.Add((song, isliked));
            }

            return tuples;
        }
        else {
            List<(SongModel songmodel, bool isLiked)> tuples = new List<(SongModel songmodel, bool isLiked)>();

            foreach (var song in songs)
            {
                bool isliked = _context.likes.Any(x => x.songId == song.songId && x.username == username);
                tuples.Add((song, isliked));
            }

            return tuples;
        }


    }

    public List<SongModel> getLikedSongs(string username)
    {
        var songs =(from l in _context.likes join 
                    s in _context.songs on l.songId equals s.songId
                    where l.username==username
                    orderby l.id
                    select s).ToList();
                
        return songs;
    }

    public List<(SongModel songmodel,bool isLiked)> Like(string username,string mood,int songid,bool isliked)
    {
        var recordtoremove = _context.likes.FirstOrDefault(x => x.songId == songid && x.username==username);
        if (recordtoremove!=null)
        {            
            _context.likes.Remove(recordtoremove);
            _context.SaveChanges();
        }
        else
        {
            var likedsong = new LikedModel
            {
                username = username,
                songId = songid
                
            };
            _context.likes.Add(likedsong);
            _context.SaveChanges();
        }
        var songs = _context.songs.Where(x => x.mood == mood).ToList();

        List<(SongModel songmodel,bool isLiked)> tuples = new List<(SongModel songmodel, bool isLiked)>();
        foreach (var song in songs)
        {
            bool Isliked = _context.likes.Any(x => x.songId == song.songId && x.username==username);
            tuples.Add((song,Isliked));
        }

        return tuples;
    }

    public List<SongModel> UnLike(string username, string mood, int songid, bool isliked)
    {
        var recordtoremove = _context.likes.FirstOrDefault(x => x.songId == songid && x.username == username);
        if (recordtoremove != null)
        {
            _context.likes.Remove(recordtoremove);
            _context.SaveChanges();
        }
        else
        {
            var likedsong = new LikedModel
            {
                username = username,
                songId = songid

            };
            _context.likes.Add(likedsong);
            _context.SaveChanges();
        }
        var songs = (from l in _context.likes
                     join
                     s in _context.songs on l.songId equals s.songId
                     where l.username == username
                     select s).ToList();

        return songs;
    }

    public void Counter(string username,int songid)
    {  
        var songlistened = _context.history.FirstOrDefault(x=>x.songId== songid &&x.username==username);

        if(songlistened != null)
        {
            songlistened.timesListened += 1;
            _context.SaveChanges();
        }
        else
        {
            var id=_context.history.OrderByDescending(x=>x.id).FirstOrDefault();
            var listened_song = new HistoryModel
            {
                id=id.id+1,
                songId = songid,
                username = username,
                timesListened = 1
            };
            _context.history.Add(listened_song);
            _context.SaveChanges();
        }
        

    }

    public List<SongModel> getTopFive(string username)
    {
        List<SongModel> songs = _context.songs.ToList();
        List<HistoryModel> history = _context.history.ToList();
        var listened = (from h in history
                       join s in songs on h.songId equals s.songId
                       where h.username == username && h.timesListened>0
                       orderby h.timesListened descending
                       select new SongModel
                       {                         
                           songId=h.songId,
                           songname=s.songname,
                           artist=s.artist,
                           duration=s.duration,
                           mood=s.mood,
                           genre=s.genre,
                           songfile=s.songfile

                       }).Take(5).ToList();

        if(listened.Count < 5) {

            var toplistened = (from h in history
                               join s in songs on h.songId equals s.songId
                               where h.username == username && h.timesListened > 0
                               orderby h.timesListened descending
                               select new SongModel
                               {
                                   songId = h.songId,
                                   songname = s.songname,
                                   artist = s.artist,
                                   duration = s.duration,
                                   mood = s.mood,
                                   genre = s.genre,
                                   songfile = s.songfile

                               }).ToList();
            return toplistened;
        }
        return listened;


    }

    public  (UserModel,SongModel,Genre,Artist,Mood) getProfileInfo(string username)
    {
        var info = _context.users.FirstOrDefault(x=>x.username==username);
        List<SongModel> songs = _context.songs.ToList();
        List<HistoryModel> history = new List<HistoryModel>();        


        var mostplayed = from h in _context.history
                         group h by h.username into usergroup
                         where usergroup.Any(x=>x.timesListened>0 && x.username==username)
                         select new HistoryModel
                         {                             
                             username = username,                             
                             timesListened = usergroup.Max(x => x.timesListened),
                             songId=usergroup.OrderByDescending(x=>x.timesListened)
                             .Select(x=>x.songId)
                             .FirstOrDefault()
                             
                         };

        var mostplayedsong = (from m in mostplayed.AsEnumerable()
                             join
                             s in songs on m.songId equals s.songId
                             where m.username == username & m.timesListened>0
                             select new SongModel
                             {
                                 songId=s.songId,
                                 songname=s.songname,
                                 duration=s.duration,
                                 artist=s.artist,
                                 mood=s.mood,
                                 genre=s.genre,
                                 songfile=s.songfile
                             }).FirstOrDefault();

        var listened = (from h in _context.history.ToList()
                        join s in songs on h.songId equals s.songId
                        where h.username == username && h.timesListened > 0
                        orderby h.timesListened descending
                        select new SongModel
                        {
                            songId = h.songId,
                            songname = s.songname,
                            artist = s.artist,
                            duration = s.duration,
                            mood = s.mood,
                            genre = s.genre,
                            songfile = s.songfile

                        }).ToList();

        var most_frequent1 = listened.GroupBy(h => h.GetType().GetProperty("genre").GetValue(h))
            .Select(g=>new Genre {genre=g.Key.ToString(),count=g.Count()});

        var most_freq_genre = most_frequent1.OrderByDescending(x => x.count).FirstOrDefault();

        var most_frequent2 = listened.GroupBy(h => h.GetType().GetProperty("artist").GetValue(h))
            .Select(g => new Artist { artist = g.Key.ToString(), count = g.Count() });

        var most_freq_artist = most_frequent2.OrderByDescending(x=>x.count).FirstOrDefault();

        var most_frequent3 = listened.GroupBy(h => h.GetType().GetProperty("mood").GetValue(h))
            .Select(g => new Mood { mood = g.Key.ToString(), count = g.Count() });

        var most_freq_mood= most_frequent3.OrderByDescending(x => x.count).FirstOrDefault();

        var tuple = (info,mostplayedsong,most_freq_genre,most_freq_artist,most_freq_mood);     
        return tuple;
    }

    public void SetProfilePicture(string username,string path)
    {
        var user = _context.users.FirstOrDefault(x => x.username == username);
        user.profileImage = path;
        _context.SaveChanges();

    }

    public void  Registration(RegistrationModel registration) {

        var newuser = new UserModel
        {
            username = registration.username,
            password = registration.password,
            firstname = registration.firstname,
            lastname = registration.lastname,
            email = registration.email,
            gender = registration.gender,
            profileImage = registration.profileImage
        };
        _context.users.Add(newuser);
        _context.SaveChanges();
        

    }

    public bool Login(string username, string password)
    {
        var authentication = _context.users.FirstOrDefault(x => x.username == username && x.password == password);
        if (authentication != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetProfilePicture(string username)
    {
        var file = (from u in _context.users
                   where u.username == username
                   select u.profileImage).FirstOrDefault();

        return file;
    }
  



}
