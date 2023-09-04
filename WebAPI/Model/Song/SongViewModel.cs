using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Musica
{
    [Table("TB_MUSICAS")]
    public class SongViewModel
    {
        [Column("SONG_ID")]
        public int Id { get; set; }

        [Column("MUSICA_Name")]
        [MaxLength(255)]
        public string? Name { get; set; }

    }
}
