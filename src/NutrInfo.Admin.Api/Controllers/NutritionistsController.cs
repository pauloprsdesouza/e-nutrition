using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutrInfo.Admin.Api.Models.Nutritionists;
using NutrInfo.Admin.Api.Models;
using Nutrinfo.Admin.Domain.Nutritionists;
using Microsoft.AspNetCore.Authorization;
using NutrInfo.Admin.Api.Authorization;
using Microsoft.Extensions.Options;
using NutrInfo.Admin.Application.Nutritionists;

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

            return Ok();
        }

        /// <summary>
        /// Find a registered nutritionist
        /// </summary>
        /// <param name="crn"></param>
        /// <returns></returns>
        [HttpGet, Route("{crn}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int crn)
        {
            var nutritionistSearch = new NutritionistSearch(_nutritionistRepository);
            var nutritionist = await nutritionistSearch.Find(crn);

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
        [HttpPost, AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] PostNutritionistRequest nutritionistRequest)
        {
            var nutritionistRegistration = new NutritionistRegistration(_nutritionistRepository);
            var nutritionist = await nutritionistRegistration.Register(nutritionistRequest.ToNutritionist());

            if (nutritionistRegistration.NutritionistAlreadyExists)
            {
                return UnprocessableEntity(new ResponseError("NUTRITIONIST_ALREADY_EXISTS"));
            }

            return Created($"api/v1/nutritionists/{nutritionist.UserId}", nutritionist.MapToResponse());
        }

        /// <summary>
        /// Update a registered nutritionist
        /// </summary>
        /// <param name="crn"></param>
        /// <param name="nutritionistRequest"></param>
        /// <returns></returns>
        [HttpPut, Route("{crn}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] int crn, [FromBody] PutNutritionistRequest nutritionistRequest)
        {
            var nutritionistUpdate = new NutritionistUpdate(_nutritionistRepository);
            var nutritionist = await nutritionistUpdate.Update(crn, nutritionistRequest);

            if (nutritionistUpdate.NutritionistNotFound)
            {
                return NotFound(new ResponseError("NUTRITIONIST_NOT_FOUND"));
            }

            return Ok(nutritionist.MapToResponse());
        }

        /// <summary>
        /// Delete a registered nutritionist
        /// </summary>
        /// <param name="crn"></param>
        /// <returns></returns>
        [HttpDelete, Route("{crn}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int crn)
        {
            var nutritionistRemoval = new NutritionistRemoval(_nutritionistRepository);
            var nutritionist = await nutritionistRemoval.Delete(crn);

            if (nutritionistRemoval.NutritionistNotFound)
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
