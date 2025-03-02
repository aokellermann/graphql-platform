using System.Linq;
using HotChocolate.Language;
using Xunit;

namespace HotChocolate.Stitching.Merge;

public class TypeInfoExtensionsTests
{
    [Fact]
    public void IsQueryType_True()
    {
        // arrange
        var schema = Utf8GraphQLParser.Parse(
            "type Query { a: String } type Abc { a: String }");
        var schemaInfo = new SchemaInfo("foo", schema);
        var queryType = schema.Definitions
            .OfType<ObjectTypeDefinitionNode>().First();
        var type = new ObjectTypeInfo(queryType, schemaInfo);

        // act
        var isQuery = type.IsQueryType();

        // assert
        Assert.True(isQuery);
    }

    [Fact]
    public void IsQueryType_False()
    {
        // arrange
        var schema = Utf8GraphQLParser.Parse(
            "type Query { a: String } type Abc { a: String }");
        var schemaInfo = new SchemaInfo("foo", schema);
        var queryType = schema.Definitions
            .OfType<ObjectTypeDefinitionNode>().Last();
        var type = new ObjectTypeInfo(queryType, schemaInfo);

        // act
        var isQuery = type.IsQueryType();

        // assert
        Assert.False(isQuery);
    }

    [Fact]
    public void IsMutationType_True()
    {
        // arrange
        var schema = Utf8GraphQLParser.Parse(
            "type Mutation { a: String } type Abc { a: String }");
        var schemaInfo = new SchemaInfo("foo", schema);
        var queryType = schema.Definitions
            .OfType<ObjectTypeDefinitionNode>().First();
        var type = new ObjectTypeInfo(queryType, schemaInfo);

        // act
        var isQuery = type.IsMutationType();

        // assert
        Assert.True(isQuery);
    }

    [Fact]
    public void IsMutationType_False()
    {
        // arrange
        var schema = Utf8GraphQLParser.Parse(
            "type Mutation { a: String } type Abc { a: String }");
        var schemaInfo = new SchemaInfo("foo", schema);
        var queryType = schema.Definitions
            .OfType<ObjectTypeDefinitionNode>().Last();
        var type = new ObjectTypeInfo(queryType, schemaInfo);

        // act
        var isQuery = type.IsMutationType();

        // assert
        Assert.False(isQuery);
    }

    [Fact]
    public void IsSubscriptionType_True()
    {
        // arrange
        var schema = Utf8GraphQLParser.Parse(
            "type Subscription { a: String } type Abc { a: String }");
        var schemaInfo = new SchemaInfo("foo", schema);
        var queryType = schema.Definitions
            .OfType<ObjectTypeDefinitionNode>().First();
        var type = new ObjectTypeInfo(queryType, schemaInfo);

        // act
        var isQuery = type.IsSubscriptionType();

        // assert
        Assert.True(isQuery);
    }

    [Fact]
    public void IsSubscriptionType_False()
    {
        // arrange
        var schema = Utf8GraphQLParser.Parse(
            "type Subscription { a: String } type Abc { a: String }");
        var schemaInfo = new SchemaInfo("foo", schema);
        var queryType = schema.Definitions
            .OfType<ObjectTypeDefinitionNode>().Last();
        var type = new ObjectTypeInfo(queryType, schemaInfo);

        // act
        var isQuery = type.IsSubscriptionType();

        // assert
        Assert.False(isQuery);
    }
}