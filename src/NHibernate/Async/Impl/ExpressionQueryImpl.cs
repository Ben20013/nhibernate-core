﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Engine;
using NHibernate.Engine.Query;
using NHibernate.Hql.Ast.ANTLR;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Impl
{
	using System.Threading.Tasks;
	using System.Threading;

	internal partial class ExpressionFilterImpl : ExpressionQueryImpl
	{

		public override async Task<IList> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			VerifyParameters();
			var namedParams = NamedParams;
			Before();
			try
			{
				return await (Session.ListFilterAsync(collection, ExpandParameters(namedParams), GetQueryParameters(namedParams), cancellationToken)).ConfigureAwait(false);
			}
			finally
			{
				After();
			}
		}

		public override async Task<IList<T>> ListAsync<T>(CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			VerifyParameters();
			var namedParams = NamedParams;
			Before();
			try
			{
				//6.0 TODO: Add Session.ListFilter<T> that accepts IQueryExpression
				var result = await (Session.ListFilterAsync(collection, ExpandParameters(namedParams), GetQueryParameters(namedParams), cancellationToken)).ConfigureAwait(false);

				return result as IList<T> ?? result.Cast<T>().ToList();
			}
			finally
			{
				After();
			}
		}

		public override async Task ListAsync(IList results, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			ArrayHelper.AddAll(results, await (ListAsync(cancellationToken)).ConfigureAwait(false));
		}

		public override Task<IEnumerable> EnumerableAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new NotImplementedException();
		}

		public override Task<IEnumerable<T>> EnumerableAsync<T>(CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new NotImplementedException();
		}

		// Since v5.2
		/// <inheritdoc />
		[Obsolete("This method has no usages and will be removed in a future version")]
		protected internal override Task<IEnumerable<ITranslator>> GetTranslatorsAsync(ISessionImplementor session, QueryParameters queryParameters, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<IEnumerable<ITranslator>>(cancellationToken);
			}
			try
			{
				return Task.FromResult<IEnumerable<ITranslator>>(GetTranslators(session, queryParameters));
			}
			catch (Exception ex)
			{
				return Task.FromException<IEnumerable<ITranslator>>(ex);
			}
		}
	}
}
