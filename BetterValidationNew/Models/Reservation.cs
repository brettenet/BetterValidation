using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BetterValidation.Extensions;
using FluentValidation;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace BetterValidation.Models
{
    /// <summary>
    /// Simple Domain Object
    /// </summary>
    public class Reservation : IValidatableObject
    {
        #region Private Members

        private readonly IValidator _validator;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string LastName { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Reservation" /> class.
        /// </summary>
        public Reservation()
        {
            _validator = new ReservationValidator();
        }

        #endregion

        #region IValidatableObject

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>
        /// A collection that holds failed-validation information.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return _validator.Validate(this).ToValidationResult();
        }

        #endregion
    }
}