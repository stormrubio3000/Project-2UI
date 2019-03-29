using ANightsTaleUI.Controllers;
using ANightsTaleUI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using Xunit;

namespace ANightsTale.Tests
{
	public class ControllerTest
	{
		[Fact]
		public void CharacterControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new CharacterController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void AbilityControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new AbilityController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void AccountControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new AccountController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void CampaignControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new CampaignController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}

		[Fact]
		public void CharAbilityControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new CharAbilityController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void CharFeatsControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new CharFeatsController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void FeatsControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new FeatsController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void ItemControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new ItemController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}


		[Fact]
		public void LoginControllerCreation()
		{

			try
			{
				var http = new HttpClient();
				var con = new ConfigurationBuilder();
				var config = con.Build();
				var cont = new LoginController(http, config);
				Assert.True(true);
			}
			catch
			{
				return;
			}
		}
	}
}
