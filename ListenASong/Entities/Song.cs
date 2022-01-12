using System.ComponentModel.DataAnnotations;

namespace ListenASong.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public int AlbumId { get; set; }
        public int SingerId { get; set; }
        [Required]
        public string SongName { get; set; }
    }
}
