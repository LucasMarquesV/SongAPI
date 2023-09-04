using Business.SongInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Musica;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : Controller
    {

        private readonly ISong<SongViewModel> _ISong;
        public SongsController(ISong<SongViewModel> Song)
        {
            _ISong = Song;
        }

        [HttpGet("ListSong")]
        public async Task<IActionResult> ListSong()
        {
            return Json(await _ISong.List());
        }
        [HttpPost("GetSongById")]
        public async Task<IActionResult> GetSongById(int Id)
        {
            return Json(await _ISong.GetEntityById(Id));
        }
        [HttpPost("AddSong")]
        public async Task AddSong(string songName)
        {
            SongViewModel song = new();
            song.Name = songName;
            await _ISong.Add(song);
        }
        [HttpPost("UpdateSong")]
        public async Task UpdateSong(SongViewModel song)
        {
            await _ISong.Update(song);
        }
        [HttpPost("DeleteSong")]
        public async Task DeleteSong(SongViewModel song)
        {
            await _ISong.Delete(song);
        }
    }
}
