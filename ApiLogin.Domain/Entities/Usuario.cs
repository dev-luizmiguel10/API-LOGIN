using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiLogin.Domain.Entities
{
    [Table("tb_Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public DateTime dt_criacao { get; set; } = DateTime.UtcNow;
        public bool Usuario_Ativo { get; set; } = true;
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public string TokenUsuario { get; set; }
    }
}
