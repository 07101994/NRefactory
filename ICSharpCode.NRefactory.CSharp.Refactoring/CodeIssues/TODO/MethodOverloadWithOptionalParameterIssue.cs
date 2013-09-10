//
// MethodOverloadWithOptionalParameterIssue.cs
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
using System;
using ICSharpCode.NRefactory.Refactoring;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	/*
 public static class Super
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

// case: Method with optional parameter is hidden by overload
        private static void Print(string message, string messageDelimiter = "===\n")
        {
            Console.WriteLine(message + messageDelimiter);

        }

    }

No resolution - ps. should work for indexers as well.
	 */ 
//	[IssueDescription (
//		"Method with optional parameter is hidden by overload",
//		Description = "Method with optional parameter is hidden by overload",
//		Category = IssueCategories.CodeQualityIssues,
//		Severity = Severity.Warning,
//		ResharperDisableKeyword = "MethodOverloadWithOptionalParameter")]
//	public class MethodOverloadWithOptionalParameterIssue : GatherVisitorCodeIssueProvider
//	{
//		protected override IGatherVisitor CreateVisitor(BaseRefactoringContext context)
//		{
//			return new GatherVisitor(context);
//		}
//
//		class GatherVisitor : GatherVisitorBase<MethodOverloadWithOptionalParameterIssue>
//		{
//			public GatherVisitor (BaseRefactoringContext ctx) : base (ctx)
//			{
//			}
//		}
//	}
}

