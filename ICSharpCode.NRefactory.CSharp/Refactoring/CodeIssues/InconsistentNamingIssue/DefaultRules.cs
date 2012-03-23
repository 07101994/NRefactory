// 
// DefaultRules.cs
//  
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
// 
// Copyright (c) 2012 Xamarin <http://xamarin.com>
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public static class DefaultRules
	{
		public static readonly List<NamingRule> Rules = new List<NamingRule>();

		static DefaultRules()
		{
			Rules.AddRange(GetFdgRules());
		}

		public static IEnumerable<NamingRule> GetFdgRules()
		{
			// PascalCasing for namespace
			yield return new NamingRule(AffectedEntity.Namespace) {
				NamingStyle = NamingStyle.PascalCase
			};
			
			// PascalCasing for types
			yield return new NamingRule(AffectedEntity.Type) {
				NamingStyle = NamingStyle.PascalCase
			};
			
			yield return new NamingRule(AffectedEntity.Interface) {
				NamingStyle = NamingStyle.PascalCase,
				RequiredPrefixes = new [] { "I" }
			};

			yield return new NamingRule(AffectedEntity.CustomAttributes) {
				NamingStyle = NamingStyle.PascalCase,
				RequiredSuffixes = new [] { "Attribute" }
			};
			
			yield return new NamingRule(AffectedEntity.CustomEventArgs) {
				NamingStyle = NamingStyle.PascalCase,
				RequiredSuffixes = new [] { "EventArgs" }
			};
			
			yield return new NamingRule(AffectedEntity.CustomExceptions) {
				NamingStyle = NamingStyle.PascalCase,
				RequiredSuffixes = new [] { "Exception" }
			};

			// PascalCasing for members
			yield return new NamingRule(AffectedEntity.Method) {
				NamingStyle = NamingStyle.PascalCase
			};
			
			yield return new NamingRule(AffectedEntity.Field) {
				NamingStyle = NamingStyle.PascalCase,
				VisibilityMask = Modifiers.Public | Modifiers.Protected | Modifiers.Internal
			};
			
			yield return new NamingRule(AffectedEntity.Property) {
				NamingStyle = NamingStyle.PascalCase
			};

			yield return new NamingRule(AffectedEntity.Event) {
				NamingStyle = NamingStyle.PascalCase
			};

			yield return new NamingRule(AffectedEntity.EnumMember) {
				NamingStyle = NamingStyle.PascalCase
			};

			// Parameters should be camelCase
			yield return new NamingRule(AffectedEntity.Parameter) {
				NamingStyle = NamingStyle.CamelCase
			};

			// Type parameter should be PascalCase
			yield return new NamingRule(AffectedEntity.TypeParameter) {
				NamingStyle = NamingStyle.PascalCase
			};
		}
	}
}

