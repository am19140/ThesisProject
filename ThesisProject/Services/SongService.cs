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
    public List<(SongModel songmodel,bool isLiked)> getSongList(string username,string mood)
    {
        var songs = _context.songs.Where(x=>x.mood==mood).ToList();
        List<(SongModel songmodel,bool isLiked)> tuples = new List<(SongModel songmodel, bool isLiked)>();
        foreach (var song in songs)
        {
            bool isliked = _context.likes.Any(x => x.songId == song.songId && x.username==username);
            tuples.Add((song,isliked));
        }

        return tuples;
    }

    public List<SongModel> getLikedSongs(string username)
    {
        var songs =(from l in _context.likes join 
                    s in _context.songs on l.songId equals s.songId
                    where l.username==username
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
            var listened_song = new HistoryModel
            {
                songId = songid,
                username = username,
                timesListened = 1
            };
            _context.history.Add(listened_song);
            _context.SaveChanges();
        }
        

    }

    public  (UserModel,SongModel) getProfileInfo(string username)
    {
        var info = _context.users.FirstOrDefault(x=>x.username==username);
        var mostplayed = from history in _context.history
                         group history by history.username into usergroup
                         select new HistoryModel
                         {                             
                             username = username,
                             timesListened = usergroup.Max(x => x.timesListened),
                             songId=usergroup.OrderByDescending(x=>x.timesListened).Select(x=>x.songId).FirstOrDefault()
                             
                         };
        List<SongModel> songs = _context.songs.ToList();
        var mostplayedsong = (from m in mostplayed.AsEnumerable()
                             join
                             s in songs on m.songId equals s.songId
                             where m.username == username
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

        var tuple = (info,mostplayedsong);     
        return tuple;
    }

    public void SetProfilePicture(string username,string path)
    {
        var user = _context.users.FirstOrDefault(x => x.username == username);
        user.profileImage = path;
        _context.SaveChanges();

    }
  



}
