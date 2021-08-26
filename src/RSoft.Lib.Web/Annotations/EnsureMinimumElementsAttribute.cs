using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace RSoft.Lib.Web.Annotations
{

    /// <summary>
    /// Ensure mininum elements attributes
    /// </summary>
    public class EnsureMinimumElementsAttribute : ValidationAttribute
    {

        #region Local objects/variables

        private readonly int _minElements;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of this attribute
        /// </summary>
        /// <param name="minElements">Minimum number of elements</param>
        /// <exception cref="ArgumentException"/>
        public EnsureMinimumElementsAttribute(int minElements)
        {
            if (minElements <= 0)
                throw new ArgumentException("Minimum number of elements must be greater than 0 (zero)");
            _minElements = minElements;
        }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        public override bool IsValid(object value)
        {
            IList list = value as IList;
            bool valid = false;
            if (list != null)
                valid = list.Count >= _minElements;
            return valid;
        }

        #endregion

    }
}
