using RecipeManagement.Api.Controllers;
using RecipeManagement.Api.Entities.Recipes;
using System.Diagnostics.CodeAnalysis;

namespace RecipeManagement.Api.Tests.Controllers;

[TestClass]
[ExcludeFromCodeCoverage]
public sealed class RecipesControllerTests
{
    private RecipesController _controller = default!;
    private List<Recipe> _recipes = [];

    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        // This method is called once for the test assembly, before any tests are run.
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        // This method is called once for the test assembly, after all tests are run.
    }

    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        // This method is called once for the test class, before any tests of the class are run.
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        // This method is called once for the test class, after all tests of the class are run.
    }

    [TestInitialize]
    public void TestInit()
    {
        _recipes = [];
        _controller = new RecipesController(null);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        // This method is called after each test method.
    }

}
