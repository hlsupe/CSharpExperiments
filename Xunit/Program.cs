using FluentAssertions;
using Xunit;

//TODO Try Fixture and Provide test data from a class https://www.programmingwithwolfgang.com/xunit-getting-started/. Code at https://github.com/WolfgangOfner/xUnit-Getting-Started. Also https://app.pluralsight.com/library/courses/dotnet-core-testing-code-xunit-dotnet-getting-started/table-of-contents
// TODO Add DataAnnotation
// TODO Add XBehave
// TODO Add AutoFixture vs. FakeItEasy
// TODO Implement Fluent Interface https://assist-software.net/blog/design-and-implement-fluent-interface-pattern-c
// TODO Add morelinq
// TODO Add RestAssure



namespace XUnitPatterns
{
	public interface IUser
	{
		string GetUserType();
	}

	internal class IndividualUser : IUser
	{
		public string GetUserType()
		{
			return "Individual";
		}
	}

	internal class BusinessUser : IUser
	{
		public string GetUserType()
		{
			return "Business";
		}
	}

	public class IndividualUserTests : UserTests
	{
		public IndividualUserTests(): base(new IndividualUser())
		{
		}
	}

	public class BusinessUserTests : UserTests
	{
		public BusinessUserTests() : base(new BusinessUser())
		{
		}

		[Fact]
		public void GetUserType_IsBusinessUser()
		{
			Sut.GetUserType().Should().Be("BusinessUser");
		}
	}


	public abstract class UserTests
	{
		protected readonly IUser Sut;

		protected UserTests(IUser sut)
		{
			Sut = sut;
		}

		[Fact]
		public void GetUserType_ReturnsNonEmptyString()
		{
			Sut.GetUserType().Should().NotBeNullOrEmpty();
		}
	}
}