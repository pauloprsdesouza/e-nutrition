using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrInfo.Admin.Api.Features.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Serialization.Nutritionists;
using NutrInfo.Admin.Api.Models.Nutritionists;
using NutrInfo.Admin.Api.Models;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/nutritionists")]
    public class NutritionistsController : Controller
    {
        public readonly ApiDbContext _dbContext;

        public NutritionistsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
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
            var nutritionists = await _dbContext.Nutritionists
                                                .ContainsName(queryString.Name)
                                                .WithCRN(queryString.Crn)
                                                .IncludeUser()
                                                .ToListAsync();

            return Ok(new GetNutritionistResponse()
            {
                Nutritionists = nutritionists.Select(nutritionist => nutritionist.MapToResponse())
            });
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
        public async Task<IActionResult> Find([FromRoute] int crn)
        {
            var nutritionistSearch = new NutritionistSearch(_dbContext);
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
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NutritionistResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] PostNutritionistRequest nutritionistRequest)
        {
            var nutritionistRegistration = new NutritionistRegistration(_dbContext);
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
            var nutritionistUpdate = new NutritionistUpdate(_dbContext);
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
            var nutritionistSearch = new NutritionistSearch(_dbContext);
            var nutritionist = await nutritionistSearch.Find(crn);

            if (nutritionistSearch.NutritionistNotFound)
            {
                return NotFound();
            }

            var deleteNutritionist = new NutritionistRemoval(_dbContext);
            await deleteNutritionist.Delete(crn);

            return Ok(nutritionist.MapToResponse());
        }
    }
}
