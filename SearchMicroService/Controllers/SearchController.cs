using Microsoft.AspNetCore.Mvc;
using SearchMicroService.Models;
using SearchMicroService.Services;

namespace SearchMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {

        public UserSearchService _SearchService;

        public SearchController(UserSearchService SearchService) => _SearchService = SearchService;

        [HttpGet]

        public ActionResult<List<User>> Get()
        { 
            return _SearchService.Get();
        }


    }
}
