using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JsonSerializer = Books.BL.Serializers.JsonSerializer;

namespace Books.BL.Tests.Serializers
{
	[TestClass]
	public class JsonSerializerTests
	{
		private Fixture _fixture;
		private JsonSerializer _target;
		private JsonSerializerSettings _serializerSettings;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_target = new JsonSerializer();

			_serializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new CamelCaseNamingStrategy()
				},
				Formatting = Formatting.Indented
			};
		}

		[TestMethod]
		public void Serialize()
		{
			// Arrange
			var value = new
			{
				TestProperty = _fixture.Create<string>()
			};

			var expected = JsonConvert.SerializeObject(value, _serializerSettings);

			// Act
			var result = _target.Serialize(value);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}
	}
}
