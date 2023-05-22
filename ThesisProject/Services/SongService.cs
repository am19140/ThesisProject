using System;
using ThesisProject.Context;
using ThesisProject.Models;

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
}
