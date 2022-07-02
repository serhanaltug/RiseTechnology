using Microsoft.Extensions.DependencyInjection;

namespace RT.Contacts.CompositionRoot
{
    public class RepositoryFixture
    {
        public ServiceCollection Services { get; } = new ServiceCollection();

        public RepositoryFixture()
        {
            MockSetup.InitializeTestContainer(Services);
        }

    }
}
