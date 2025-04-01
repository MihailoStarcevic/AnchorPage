using AnchorPage.Application;

namespace AnchorPage.API.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "TestUser";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 100).ToList();
    }
}
