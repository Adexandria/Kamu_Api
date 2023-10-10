using KAMU.API.Infrastructure.Extensions;
using KAMU.API.Infrastructure.Services.Authorisation;
using KAMU.API.Infrastructure.Services.Organization;
using KAMU.API.Infrastructure.Services.Security;
using KAMU.API.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace KAMU.API.Controllers
{
    /// <summary>
    /// Handles organisations
    /// </summary>
    [Route("api/organisations")]
    [ApiController]
    [HasRole(Role.SuperAdmin)]
    public class OrganisationController : BaseController
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="userContext">Manages the user details gotten from the claims</param>
        /// <param name="organisationService"> Manages the organisation services</param>
        /// <param name="validation">Validates request properties</param>
        public OrganisationController(IUserContext userContext, 
            IOrganisationService organisationService,
            Validation validation) : base(userContext, validation)
        {
            _organisationService = organisationService;
        }

        /// <summary>
        /// Creates a new organisation
        /// </summary>
        /// <returns>Action response</returns>
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ActionResponse<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResponse<Guid>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ActionResponse<Guid>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResponse<Guid>), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CreateOrganisation()
        {
            var response = await _organisationService.CreateOrganisation();
            return response.ResponseResult();
        }

        private readonly IOrganisationService _organisationService;
    }
}
