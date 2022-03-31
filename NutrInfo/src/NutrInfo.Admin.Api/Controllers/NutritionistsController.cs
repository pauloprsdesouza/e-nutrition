using System;
using System.Collections.Generic;
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

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("Nutritionists")]
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
        public async Task<IActionResult> Find([FromRoute] int crn)
        {
            var nutritionistSearch = new NutritionistSearch(_dbContext);
            var nutritionist = await nutritionistSearch.Find(crn);

            if (nutritionistSearch.NutritionistNotFound)
            {
                return NotFound();
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
        public async Task<IActionResult> Create([FromBody] PostNutritionistRequest nutritionistRequest)
        {
            var nutritionistSearch = new NutritionistSearch(_dbContext);
            var nutritionist = await nutritionistSearch.Find(nutritionistRequest.Crn);

            if (nutritionist == null)
            {
                var createNutritionist = new CreateNutritionist(_dbContext);
                nutritionist = nutritionistRequest.ToNutritionist();
                await createNutritionist.Register(nutritionist);
            }

            return Created("", nutritionist.MapToResponse());
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
            var nutritionistSearch = new NutritionistSearch(_dbContext);
            var nutritionist = await nutritionistSearch.Find(crn);

            if (nutritionistSearch.NutritionistNotFound)
            {
                return NotFound();
            }

            var updateNutritionist = new NutritionistUpdate(_dbContext);
            nutritionistRequest.MapTo(nutritionist);

            await updateNutritionist.Update(nutritionist);

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
        public async Task<IActionResult> Delete([FromRoute] int crn)
        {
            var nutritionistSearch = new NutritionistSearch(_dbContext);
            var nutritionist = await nutritionistSearch.Find(crn);

            if (nutritionistSearch.NutritionistNotFound)
            {
                return NotFound();
            }

            var deleteNutritionist = new DeleteNutritionist(_dbContext);
            await deleteNutritionist.Delete(nutritionist);

            return Ok(nutritionist.MapToResponse());
        }
    }
}
