using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using YesSql;

namespace Workshop.Demo.Module.Controllers
{
    public class ContentItemController : Controller
    {
        private readonly ISession session;

        public ContentItemController(ISession session)
        {
            this.session = session;
        }

        [Route("PersonItems")]
        public async Task<string> Index()
        {
            var personItems = await session.Query<ContentItem, ContentItemIndex>(index => index.ContentType == "PersonPage").ListAsync();
            return string.Join(", ", personItems);
        }
    }
}
