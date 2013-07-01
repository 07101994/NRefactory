//
// ConditionalTernaryEqualBranch.cs
//
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
//
// Copyright (c) 2013 Xamarin Inc. (http://xamarin.com)
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

using System.Collections.Generic;
using ICSharpCode.NRefactory.Refactoring;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	[IssueDescription("'?:' expression has identical true and false branches",
	                  Description = "'?:' expression has identical true and false branches",
	                  Category = IssueCategories.CodeQualityIssues,
	                  Severity = Severity.Warning,
	                  ResharperDisableKeyword = "ConditionalTernaryEqualBranch")]
	public class ConditionalTernaryEqualBranchIssue : ICodeIssueProvider
	{
		public IEnumerable<CodeIssue> GetIssues(BaseRefactoringContext context)
		{
			return new GatherVisitor(context).GetIssues();
		}

		class GatherVisitor : GatherVisitorBase<ConditionalTernaryEqualBranchIssue>
		{
			public GatherVisitor (BaseRefactoringContext ctx) : base (ctx)
			{
			}

			public override void VisitConditionalExpression(ConditionalExpression conditionalExpression)
			{
				Match m = conditionalExpression.TrueExpression.Match(conditionalExpression.FalseExpression);
				if (m.Success) {
					AddIssue(conditionalExpression, ctx.TranslateString("Replace '?:' with branch"), script => {
						script.Replace (conditionalExpression, conditionalExpression.TrueExpression.Clone ());
					});
				}
				base.VisitConditionalExpression (conditionalExpression);
			}
		}
	}
}