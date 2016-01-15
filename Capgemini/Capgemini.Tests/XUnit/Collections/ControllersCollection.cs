using Capgemini.Tests.XUnit.Fixtures;
using Xunit;

namespace Capgemini.Tests.XUnit.Collections
{
    [CollectionDefinition("Controllers Collection")]
    public class ControllersCollection : ICollectionFixture<ControllersFixture>
    {
    }
}
