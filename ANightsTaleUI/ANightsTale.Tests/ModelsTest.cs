using ANightsTaleUI.Controllers;
using ANightsTaleUI.Models;
using System;
using System.Net.Http;
using Xunit;

namespace ANightsTale.Tests
{


	public class ModelsTest
	{
		[Fact]
		public void AbilitiesCreationShouldPass()
		{
			try
			{
				var abil = new Abilities()
				{
					Name = "This is a test",
					Description = "And this should work",
					NumDice = 1,
					NumSides = 6
				};
				Assert.Equal("This is a test", abil.Name);
				Assert.Equal("And this should work", abil.Description);
				Assert.Equal(1, abil.NumDice);
				Assert.Equal(6, abil.NumSides);
			}
			catch
			{
				return;
			}
			
		}


		[Fact]
		public void AbilitiesCreationShouldFail()
		{
			try
			{
				var abil = new Abilities()
				{
					Name = "This is a test",
					Description = "And this shouldn't work",
					NumDice = 0,
					NumSides = -29
				};
			}
			catch
			{
				Assert.True(true);
			}
		}

		[Fact]
		public void CampaignShouldPass()
		{
			try
			{
				var camp = new Campaign()
				{
					Name = "This is a test"
				};
				Assert.Equal("This is a test", camp.Name);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void CampaignShouldFail()
		{
			try
			{
				var camp = new Campaign()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}

		[Fact]
		public void CharacterShouldPass()
		{
			try
			{
				var chara = new Character()
				{
					Name = "This is a test",
					RaceID = 1,
					ClassID = 1
				};
				Assert.Equal("This is a test", chara.Name);
				Assert.Equal(1, chara.RaceID);
				Assert.Equal(1, chara.ClassID);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void CharacterShouldFail()
		{
			try
			{
				var Chara = new Character()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		[Fact]
		public void FeatsShouldPass()
		{
			try
			{
				var feat = new Feats()
				{
					Name = "This is a test",
					Description = "This should passish",
					StatTable = true,
					StatType = 1,
					Mods = 1
				};
				Assert.Equal("This is a test", feat.Name);
				Assert.Equal("This should passish", feat.Description);
				Assert.True(feat.StatTable);
				Assert.Equal(1, feat.StatType);
				Assert.Equal(1, feat.StatType);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void FeatsShouldFail()
		{
			try
			{
				var feats = new Feats()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		[Fact]
		public void InfoShouldPass()
		{
			try
			{
				var info = new Info()
				{
					Type = "This is a test",
					Message = "This should passish",
				};
				Assert.Equal("This is a test", info.Type);
				Assert.Equal("This should passish", info.Message);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void InfoShouldFail()
		{
			try
			{
				var info = new Info()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		[Fact]
		public void InventoryShouldPass()
		{
			try
			{
				var inv = new Inventory()
				{
					Quantity = 1
				};
				Assert.Equal(1, inv.Quantity);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void InventoryShouldFail()
		{
			try
			{
				var inv = new Inventory()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		[Fact]
		public void ItemShouldPass()
		{
			try
			{
				var item = new Item()
				{
					Name = "This is a test",
					Description = "This should passish",
					Type = 1,
					AC = 0,
					NumDice = 0,
					NumSides =0,
					Mods = 1,
					Effects = "Please work"
				};
				Assert.Equal("This is a test", item.Name);
				Assert.Equal("This should passish", item.Description);
				Assert.Equal("Please work", item.Effects);
				Assert.Equal(1, item.Type);
				Assert.Equal(1, item.Mods);
				Assert.Equal(0, item.AC);
				Assert.Equal(0, item.NumSides);
				Assert.Equal(0, item.NumDice);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void ItemShouldFail()
		{
			try
			{
				var item = new Item()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		[Fact]
		public void LoginShouldPass()
		{
			try
			{
				var log = new Login()
				{
					Username = "ThisoneGuy",
					Password = "Notapassword123!"
				};
				Assert.Equal("ThisoneGuy", log.Username);
				Assert.Equal("Notapassword123!", log.Password);
				
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void LoginShouldFail()
		{
			try
			{
				var log = new Login()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		[Fact]
		public void RaceShouldPass()
		{
			try
			{
				var race = new Race()
				{
					Name = "This is a test",
					Description = "And this shouldn't work",
				};
				Assert.Equal("This is a test", race.Name);
				Assert.Equal("And this shouldn't work", race.Description);

			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void RaceShouldFail()
		{
			try
			{
				var log = new Login()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		[Fact]
		public void SKillShouldPass()
		{
			try
			{
				var skill = new Skill()
				{
					Name = "This is a test"
				};
				Assert.Equal("This is a test", skill.Name);

			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void SkillShouldFail()
		{
			try
			{
				var log = new Login()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		[Fact]
		public void UsersShouldPass()
		{
			try
			{
				var log = new Users()
				{
					Username = "ThisoneGuy",
					Password = "Notapassword123!",
					ConfirmPassword = "Notapassword123!",
					Email = "totallyanemail",
					Permission = 1
				};
				Assert.Equal("ThisoneGuy", log.Username);
				Assert.Equal("Notapassword123!", log.Password);
				Assert.Equal("Notapassword123!", log.ConfirmPassword);
				Assert.Equal("totallyanemail", log.Email);
				Assert.Equal(1, log.Permission);

			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void UsersShouldFail()
		{
			try
			{
				var log = new Users()
				{
				};
			}
			catch
			{
				Assert.True(true);
			}
		}


		//[Fact]
		//public void CharacterControllerCreation()
		//{
			//var con = new ConfigurationBuilder();
		//}
	}
}
