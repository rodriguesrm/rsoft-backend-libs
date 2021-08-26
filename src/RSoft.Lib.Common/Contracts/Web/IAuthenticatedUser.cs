using System;

namespace RSoft.Lib.Common.Contracts.Web
{

    /// <summary>
    /// logged user/service interface
    /// </summary>
    public interface IAuthenticatedUser : IHttpLoggedUser<Guid>
    {
    }

}
