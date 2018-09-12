﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Linq;
using NUnit.Framework;
using NHibernate.Linq;

namespace NHibernate.Test.NHSpecificTest.GH1121
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override void OnSetUp()
		{
			using (var session = OpenSession())
			using (var transaction = session.BeginTransaction())
			{
				session.Save(new Entity
				{
					Name = "Bob",
					Color = 2
				});

				transaction.Commit();
			}
		}

		protected override void OnTearDown()
		{
			using (var session = OpenSession())
			using (var transaction = session.BeginTransaction())
			{
				session.CreateQuery("delete from Entity").ExecuteUpdate();

				transaction.Commit();
			}
		}

		[Test]
		public async Task CanCastToDifferentTypeAsync()
		{
			using (var session = OpenSession())
			using (session.BeginTransaction())
			{
				var result = await ((
					from e in session.Query<Entity>()
					where e.Name == "Bob"
					select new
					{
						e.Id,
						MyColor = (int) e.Color
					}).ToListAsync());

				Assert.That(result, Has.Count.EqualTo(1));
				Assert.That(result[0].MyColor, Is.EqualTo(2));
			}
		}
		
		[Test]
		public async Task CanCastEnumWithDifferentUnderlyingTypeAsync()
		{
			using (var session = OpenSession())
			using (session.BeginTransaction())
			{
				var result = await ((
					from e in session.Query<Entity>()
					where e.Name == "Bob"
					select new
					{
						e.Id,
						MyColor = (Colors) e.Color
					}).ToListAsync());

				Assert.That(result, Has.Count.EqualTo(1));
				Assert.That(result[0].MyColor, Is.EqualTo(Colors.Green));
			}
		}
	}
}