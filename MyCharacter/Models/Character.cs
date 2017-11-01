using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCharacter.Models
{
	public class Character
	{
		public int CharacterID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Race { get; set; }
		public int Age { get; set; }
	}
}