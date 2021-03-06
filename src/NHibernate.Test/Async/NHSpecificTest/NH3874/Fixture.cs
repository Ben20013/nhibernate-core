﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH3874
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override bool AppliesTo(Dialect.Dialect dialect)
		{
			return dialect.SupportsIdentityColumns;
		}

		object _id;

		protected override void OnSetUp()
		{
			using (var session = OpenSession())
			using (var tx = session.BeginTransaction())
			{
				var one = new One { Name = "One" };
				var two = new Two { One = one };
				two.One.Twos = new[] { two };
				_id = session.Save(one);
				 session.Save(two);

				tx.Commit();
			}
		}

		[Test]
		public async Task EvictShallNotThrowWhenLoggingIsEnabledAsync()
		{
			using (var session = OpenSession())
			using (session.BeginTransaction())
			{
				var one = await (session.GetAsync<One>(_id));

				await (session.EvictAsync(one));
			}
		}

		protected override void OnTearDown()
		{
			using (var session = OpenSession())
			using (var tx = session.BeginTransaction())
			{
				session.Delete("from Two");
				session.Delete("from One");

				tx.Commit();
			}
		}
	}
}
