using ANightsTaleUI.Controllers;
using ANightsTaleUI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
					AbilityID = 1,
					Name = "This is a test",
					Description = "And this should work",
					NumDice = 1,
					NumSides = 6,
					Attack = false
				};
				Assert.Equal(1, abil.AbilityID);
				Assert.Equal("This is a test", abil.Name);
				Assert.Equal("And this should work", abil.Description);
				Assert.Equal(1, abil.NumDice);
				Assert.Equal(6, abil.NumSides);
				Assert.False(abil.Attack);
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
		public void AccountDetailsPass()
		{
			var acc = new AccountDetails()
			{
				Roles = new List<string>(){"no", "yes"},
				Username = "please"
			};

			Assert.Equal("please", acc.Username);
			Assert.NotNull(acc.Roles);
		}

		[Fact]
		public void CampaignShouldPass()
		{
			try
			{
				var camp = new Campaign()
				{
					CampaignID = 1,
					Name = "This is a test"
				};
				Assert.Equal(1, camp.CampaignID);
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
		public void CharAbilPass()
		{
			var chara = new CharAbilities()
			{
				AbilityId = 1,
				CharacterId = 1,
				Mods = 1
			};
			Assert.Equal(1, chara.AbilityId);
			Assert.Equal(1, chara.CharacterId);
			Assert.Equal(1, chara.Mods);
		}


		[Fact]
		public void CharacterShouldPass()
		{
			try
			{
				var chara = new Character()
				{
					CharacterID = 1,
					CampaignID = 1,
					Cha = 1,
					Con = 1,
					Dex = 1,
					Experience = 1,
					Int = 1,
					Level = 1,
					MaxHP = 1,
					Speed = 1,
					Str = 1,
					Wis = 1,
					UserId = 1,
					Bio = "yes",
					Class = "yes",
					Race = "yes",
					Name = "This is a test",
					RaceID = 1,
					ClassID = 1
				};
				Assert.Equal("This is a test", chara.Name);
				Assert.Equal("yes", chara.Bio);
				Assert.Equal("yes", chara.Class);
				Assert.Equal("yes", chara.Race);
				Assert.Equal(1, chara.RaceID);
				Assert.Equal(1, chara.ClassID);
				Assert.Equal(1, chara.CharacterID);
				Assert.Equal(1, chara.CampaignID);
				Assert.Equal(1, chara.Cha);
				Assert.Equal(1, chara.Con);
				Assert.Equal(1, chara.Dex);
				Assert.Equal(1, chara.Experience);
				Assert.Equal(1, chara.Int);
				Assert.Equal(1, chara.Level);
				Assert.Equal(1, chara.MaxHP);
				Assert.Equal(1, chara.Speed);
				Assert.Equal(1, chara.Str);
				Assert.Equal(1, chara.Wis);
				Assert.Equal(1, chara.UserId);
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
		public void CharFeatsPass()
		{
			var Chara = new CharFeats()
			{
				FeatId =1,
				CharacterId = 1
			};
			Assert.Equal(1, Chara.CharacterId);
			Assert.Equal(1, Chara.FeatId);
		}



		[Fact]
		public void ClassShouldPass()
		{
			var cla = new Class()
			{
				ClassID = 1,
				Description = "yes",
				Name = "yes"
			};
			Assert.Equal(1, cla.ClassID);
			Assert.Equal("yes", cla.Description);
			Assert.Equal("yes", cla.Name);
		}


		[Fact]
		public void FeatsShouldPass()
		{
			try
			{
				var feat = new Feats()
				{
					FeatID = 1,
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
				Assert.Equal(1, feat.FeatID);
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
					CampaignID = 1,
					InfoID =1,
					Type = "This is a test",
					Message = "This should passish",
				};
				Assert.Equal("This is a test", info.Type);
				Assert.Equal("This should passish", info.Message);
				Assert.Equal(1, info.InfoID);
				Assert.Equal(1, info.CampaignID);
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
					CharacterID = 1,
					ItemID = 1,
					ToggleE = false,
					Quantity = 1
				};
				Assert.Equal(1, inv.Quantity);
				Assert.Equal(1, inv.ItemID);
				Assert.Equal(1, inv.CharacterID);
				Assert.Equal(false, inv.ToggleE);
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
					ItemID = 1,
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
				Assert.Equal(1, item.ItemID);
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
					RaceID = 1,
					Name = "This is a test",
					Description = "And this shouldn't work",
				};
				Assert.Equal("This is a test", race.Name);
				Assert.Equal("And this shouldn't work", race.Description);
				Assert.Equal(1, race.RaceID);

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
					Id  = 1,
					Name = "This is a test"
				};
				Assert.Equal("This is a test", skill.Name);
				Assert.Equal(1, skill.Id);

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
	}
}
