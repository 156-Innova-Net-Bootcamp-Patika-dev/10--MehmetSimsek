using ListenASong.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ListenASong.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        List<Song> _songs;
        List<Album> _albums;
        List<Singer> _singers;
       
        public SongsController()
        {
             _songs = new List<Song>
        {
            new Song{SongId =1, AlbumId=1, SingerId =1, SongName="Centruies"},
            new Song{SongId =2, AlbumId=2, SingerId =2, SongName="Stereo Hearts"},
            new Song{SongId =3, AlbumId=3, SingerId =3, SongName="Counting Stars"},


        };
             _albums = new List<Album>
        {
            new Album{AlbumId=1, AlbumName="American Beauty"},
            new Album{AlbumId=2, AlbumName="The Papercut Chronicles"},
            new Album{AlbumId=3, AlbumName="Native"},


        };
             _singers = new List<Singer>
        {
            new Singer{SingerId=1,SingerName="Fall Out Boys"},
            new Singer{SingerId=2,SingerName="Gym Class Hereos"},
            new Singer{SingerId=3,SingerName="One Republic"},


        };
               
        }
       
       [HttpGet]
       public IActionResult GetAllSongs()
        {
            var _songsDto = from s in _songs
                            join si in _singers
                            on s.SingerId equals si.SingerId
                            join a in _albums
                            on s.AlbumId equals a.AlbumId
                            select new SongDto { AlbumName = a.AlbumName, SingerName = si.SingerName, SongName = s.SongName };

            if (_songsDto == null)
            {
                return BadRequest("There is no song on the database.");
            }
            return Ok(_songsDto);
        }


        [HttpPost]
        public IActionResult AddSong(Song song)
        {
            var result = _songs.SingleOrDefault(s=>s.SongId == song.SongId);
            if (ModelState.IsValid && result==null )
            {
                _songs.Add(song);

                return Created("The song is added successfully!", _songs);
            }
            else
            {
                return BadRequest("The song name cannot be empty or There cannot be two songs with the same id!");
            }
            
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSong(int id)
        {
            var songToDelete = _songs.SingleOrDefault(s=>s.SongId == id);
            if (songToDelete== null)
            {
                return BadRequest("The song you want to delete cannot be found!");
            }
            _songs.Remove(songToDelete);
            return Ok(_songs);
        }
        [HttpPut]
        public IActionResult UpdateSong(Song song)
        {
            var songToUpdate = _songs.SingleOrDefault(s=>s.SongId==song.SongId);
            if (songToUpdate== null)
            {
                return BadRequest("The song you want to update cannot be found");
            }
            songToUpdate.SingerId = song.SingerId;
            songToUpdate.SongName = song.SongName;
            songToUpdate.AlbumId = song.AlbumId;
            return Ok(songToUpdate);
        }
        [HttpGet("{id}")]
        public IActionResult GetBySongId(int id)
        {
            var result = _songs.SingleOrDefault(s => s.SongId == id);
            if (result == null)
            {
                return BadRequest("The song you have searched cannot be found!");
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("search")]
        public IActionResult GetBySongName(string name)
        {
            var result = _songs.Where(s => s.SongName.ToLower().Contains(name.ToLower())).ToList();
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("The song you have searched cannot be found");
            }
            else if(result == null)
            {
                
                return BadRequest("The song you have searched cannot be found");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
