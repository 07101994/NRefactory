﻿// Copyright (c) 2010 AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under MIT X11 license (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public sealed class ParameterListComparer : IEqualityComparer<IParameterizedMember>
	{
		ITypeResolveContext context;
		
		/// <summary>
		/// Creates a new ParameterListComparer that compares type <b>references</b>.
		/// </summary>
		public ParameterListComparer()
		{
		}
		
		/// <summary>
		/// Creates a new ParameterListComparer that uses the specified context to resolve types.
		/// </summary>
		public ParameterListComparer(ITypeResolveContext context)
		{
			this.context = context;
		}
		
		public bool Equals(IParameterizedMember x, IParameterizedMember y)
		{
			var px = x.Parameters;
			var py = y.Parameters;
			if (px.Count != py.Count)
				return false;
			for (int i = 0; i < px.Count; i++) {
				var a = px[i];
				var b = py[i];
				if (a == null && b == null)
					continue;
				if (a == null || b == null)
					return false;
				if (context != null) {
					if (!a.Type.Resolve(context).Equals(b.Type.Resolve(context)))
						return false;
				} else {
					if (!a.Type.Equals(b.Type))
						return false;
				}
			}
			return true;
		}
		
		public int GetHashCode(IParameterizedMember obj)
		{
			int hashCode = obj.Parameters.Count;
			unchecked {
				foreach (IParameter p in obj.Parameters) {
					hashCode *= 27;
					if (context != null)
						hashCode += p.Type.Resolve(context).GetHashCode();
					else
						hashCode += p.Type.GetHashCode();
				}
			}
			return hashCode;
		}
	}
}
