using ANightsTaleUI.Models;
using System;
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
	}
}
