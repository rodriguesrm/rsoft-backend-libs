using FluentValidator;
using RSoft.Lib.Common.Contracts.Dtos;
using System.Linq;

namespace RSoft.Lib.Common.Dtos
{

    /// <summary>
    /// Abstract dto model base object
    /// </summary>
    public abstract class AppDtoBase : Notifiable, IAppDto
    {

        #region Public Methods

        ///<inheritdoc/>
        public string GetName()
            => GetType().Name.Split(".").ToList().Last();

        #endregion

    }

}
