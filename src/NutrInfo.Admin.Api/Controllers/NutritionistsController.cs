using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nutrinfo.Admin.Domain.Nutritionists;
using NutrInfo.Admin.Api.Authorization;
using NutrInfo.Admin.Application.Nutritionists;
using NutrInfo.Admin.Contracts;
using NutrInfo.Admin.Contracts.Nutritionists;
using NutrInfo.Admin.Contracts.Paginations;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/nutritionists")]
    public class NutritionistsController : Controller
    {
        private readonly INutritionistRepository _nutritionistRepository;
        private readonly IOptions<JwtOptions> _jwtOptions;

        public NutritionistsController(INutritionistRepository nutritionistRepository, IOptions<JwtOptions> jwtOptions)
        {
            _nutritionistRepository = nutritionistRepository;
            _jwtOptions = jwtOptions;
        }

        /// <summary>
        /// List all registered nutritionists
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetNutritionistResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromQuery] GetNutritionistsQuery queryString)
        {
            var nutritionists = await _nutritionistRepository.FindPaged(queryString.Name, queryString.Page);

            return Ok(new GetNutritionistResponse()
            {
                Nutritionists = nutritionists.Select(x => x.MapToResponse()),
                Pagination = new PaginationResponseMap<Nutritionist>().MapToResponse(nutritionists)
            });
        }

        /// <summary>
        /// Find a registered nutritionist
        /// </summary>
        /// <param name="nutritionistId"></param>
        /// <returns></returns>
        [HttpGet, Route("{nutritionistId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int nutritionistId)
        {
            var nutritionistSearch = new NutritionistSearch(_nutritionistRepository);
            var nutritionist = await nutritionistSearch.Find(nutritionistId);

            if (nutritionistSearch.NutritionistNotFound)
            {
                return NotFound(new ResponseError("NUTRITIONIST_NOT_FOUND"));
            }

            return Ok(nutritionist.MapToResponse());
        }

        /// <summary>
        /// Create a new Nutritionist
        /// </summary>
        /// <param name="nutritionistRequest"></param>
        [HttpPost]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] PostNutritionistRequest nutritionistRequest)
        {
            var nutritionistRegistration = new NutritionistRegistration(_nutritionistRepository);
            var nutritionist = await nutritionistRegistration.Register(nutritionistRequest.ToNutritionist());

            if (nutritionistRegistration.ValidationErrors.Any())
            {
                return UnprocessableEntity(new ResponseError(nutritionistRegistration.ValidationErrors));
            }

            return Created($"api/v1/nutritionists/{nutritionist.UserId}", nutritionist.MapToResponse());
        }

        /// <summary>
        /// Update a registered nutritionist
        /// </summary>
        /// <param name="nutritionistId"></param>
        /// <param name="nutritionistRequest"></param>
        /// <returns></returns>
        [HttpPut, Route("{nutritionistId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] int nutritionistId, [FromBody] PutNutritionistRequest nutritionistRequest)
        {
            var nutritionistUpdate = new NutritionistUpdate(_nutritionistRepository);
            var nutritionist = await nutritionistUpdate.Update(nutritionistId, nutritionistRequest);

            if (nutritionistUpdate.NutritionistNotFound)
            {
                return NotFound(new ResponseError("NUTRITIONIST_NOT_FOUND"));
            }

            return Ok(nutritionist.MapToResponse());
        }

        /// <summary>
        /// Archive a registered nutritionist
        /// </summary>
        /// <param name="nutritionistId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{nutritionistId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove([FromRoute] int nutritionistId)
        {
            var nutritionistUpdate = new NutritionistArchivement(_nutritionistRepository);
            var nutritionist = await nutritionistUpdate.Archive(nutritionistId);

            if (nutritionistUpdate.NutritionistNotFound)
            {
                return NotFound(new ResponseError("NUTRITIONIST_NOT_FOUND"));
            }

            return Ok(nutritionist.MapToResponse());
        }

        /// <summary>
        /// Activate a registered nutritionist
        /// </summary>
        /// <param name="nutritionistId"></param>
        /// <returns></returns>
        [HttpPut, Route("{nutritionistId}/activated")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Activate([FromRoute] int nutritionistId)
        {
            var nutritionistActivation = new NutritionistActivation(_nutritionistRepository);
            var nutritionist = await nutritionistActivation.Activate(nutritionistId);

            if (nutritionistActivation.NutritionistNotFound)
            {
                return NotFound(new ResponseError("NUTRITIONIST_NOT_FOUND"));
            }

            return Ok(nutritionist.MapToResponse());
        }

        /// <summary>
        /// Deactivate a registered nutritionist
        /// </summary>
        /// <param name="nutritionistId"></param>
        /// <returns></returns>
        [HttpPut, Route("{nutritionistId}/deactivated")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deactivate([FromRoute] int nutritionistId)
        {
            var nutritionistDeactivation = new NutritionistDeactivation(_nutritionistRepository);
            var nutritionist = await nutritionistDeactivation.Deactivate(nutritionistId);

            if (nutritionistDeactivation.NutritionistNotFound)
            {
                return NotFound(new ResponseError("NUTRITIONIST_NOT_FOUND"));
            }

            return Ok(nutritionist.MapToResponse());
        }

        /// <summary>
        /// User's Login
        /// </summary>
        /// <remarks>
        /// Create a Login From User's Credendentials
        /// </remarks>
        [HttpPost, AllowAnonymous, Route("signin")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> SignIn([FromBody] PostSignInRequest request)
        {
            var nutritionistSignIn = new NutritionistSignIn(_nutritionistRepository);
            var nutritionist = await nutritionistSignIn.Validate(request.ToUser());

            if (nutritionistSignIn.NutritionistNotFound)
            {
                return UnprocessableEntity(new ResponseError("NUTRITIONIST_NOT_FOUND"));
            }

            if (nutritionistSignIn.InvalidPassword)
            {
                return Forbid();
            }

            var apiToken = new ApiToken(_jwtOptions);
            apiToken.User = nutritionist.User;

            return Ok(new { Token = apiToken.ToString(), User = nutritionist.MapToResponse() });
        }
    }
}
