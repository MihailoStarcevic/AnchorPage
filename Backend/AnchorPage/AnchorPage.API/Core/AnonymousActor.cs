using AnchorPage.Application;

namespace AnchorPage.API.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymous Actor";

        public IEnumerable<int> AllowedUseCases => new List<int> { 2, 5 };
    }
}
