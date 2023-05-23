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


}
