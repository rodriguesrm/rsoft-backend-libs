using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Contracts;
using RSoft.Lib.Common.Resources;

namespace RSoft.Lib.Common.ValueObjects
{

    /// <summary>
    /// Author value object model
    /// </summary>
    public class Author<TKey> : BaseVO
        where TKey : struct
    {

        #region Constructors

        /// <summary>
        /// Create a new Author-Value-Object instance
        /// </summary>
        /// <param name="Id">Id key value</param>
        /// <param name="name">Author name</param>
        public Author(TKey Id, string name)
        {
            this.Id = Id;
            Name = name;
            Validate();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Author id
        /// </summary>
        public TKey Id { get; private set; }

        /// <summary>
        /// Author name
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override void Validate()
        {
            AddNotifications(new RequiredValidationContract<TKey>(Id, nameof(Id), ServiceActivator.GetStringInLocalizer<SharedLanguageResource>("ID_REQUIRED", "Id is required")).Contract.Notifications);
            AddNotifications(new SimpleStringValidationContract(Name, nameof(Name), true, 2, 150).Contract.Notifications);
        }

        #endregion

    }
}
