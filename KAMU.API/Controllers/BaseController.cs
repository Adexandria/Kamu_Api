using KAMU.API.Infrastructure.Services.Security;
using KAMU.API.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace KAMU.API.Controllers
{
    /// <summary>
    /// Inject dependencies
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userContext">Manages the user details gotten from the claims</param>
        /// <param name="validation">Validates request properties</param>
        public BaseController(IUserContext userContext, Validation validation)
        {
            CurrentOrganisationId = userContext.OrganisationId;
            CurrentUserEmail = userContext.Email;
            CurrentUserId = userContext.CurrentUserId;
            Validator = validation;
        }
        /// <summary>
        /// Organisation id
        /// </summary>
        protected Guid CurrentOrganisationId { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        protected string CurrentUserEmail { get; set; }

        /// <summary>
        /// User's id
        /// </summary>
        protected Guid CurrentUserId { get; set; }

        /// <summary>
        /// Validates request properties
        /// </summary>
        protected Validation Validator { get; set; }
    }
}
