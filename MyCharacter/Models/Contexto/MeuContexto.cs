using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyCharacter.Models.Contexto
{
	public class MeuContexto : DbContext
	{
		public MeuContexto() : base("strConn")
		{

		}

		public System.Data.Entity.DbSet<MyCharacter.Models.Character> Characters { get; set; }
	}
}