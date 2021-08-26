using FluentValidator;

namespace RSoft.Lib.Common.ValueObjects
{

    /// <summary>
    /// Value object model bases
    /// </summary>
    public abstract class BaseVO : Notifiable
    {

        #region Public methods

        /// <summary>
        /// Execute validate
        /// </summary>
        protected abstract void Validate();

        #endregion

    }
}
