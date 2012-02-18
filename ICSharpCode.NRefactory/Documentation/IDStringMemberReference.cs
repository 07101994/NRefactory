﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Documentation
{
	[Serializable]
	class IDStringMemberReference : IMemberReference
	{
		readonly ITypeReference declaringTypeReference;
		readonly char memberType;
		readonly string memberName;
		readonly string memberIDString;
		
		public IDStringMemberReference(ITypeReference declaringTypeReference, char memberType, string memberName, string memberIDString)
		{
			this.declaringTypeReference = declaringTypeReference;
			this.memberType = memberType;
			this.memberName = memberName;
			this.memberIDString = memberIDString;
		}
		
		bool CanMatch(IUnresolvedMember member)
		{
			if (member.Name != memberName)
				return false;
			switch (member.EntityType) {
				case EntityType.Field:
					return memberType == 'F';
				case EntityType.Property:
				case EntityType.Indexer:
					return memberType == 'P';
				case EntityType.Event:
					return memberType == 'E';
				case EntityType.Method:
				case EntityType.Operator:
				case EntityType.Constructor:
				case EntityType.Destructor:
					return memberType == 'M';
				default:
					throw new NotSupportedException(member.EntityType.ToString());
			}
		}
		
		public IMember Resolve(ITypeResolveContext context)
		{
			IType declaringType = declaringTypeReference.Resolve(context);
			foreach (var member in declaringType.GetMembers(CanMatch, GetMemberOptions.IgnoreInheritedMembers)) {
				if (IDStringProvider.GetIDString(member) == memberIDString)
					return member;
			}
			return null;
		}
	}
}
