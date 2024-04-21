using System;
using Conversion;
using Validation;
using Microsoft.Extensions.Logging;

namespace UriConversion
{
    /// <summary>
    /// The convertor class from string to Uri.
    /// </summary>
    public class UriConverter : IConverter<Uri?>
    {
        private readonly IValidator<string>? validator;
        private readonly ILogger? logger;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UriConverter"/> class.
        /// </summary>
        /// <param name="validator">The string validator.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">Throw if validator is null.</exception>
        public UriConverter(IValidator<string>? validator, ILogger<UriConverter>? logger = default)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.logger = logger;
        }

        /// <summary>
        /// Converts the source string to Uri object.
        /// </summary>
        /// <param name="obj">The source string.</param>
        /// <returns> The Uri object if source string is valid and null otherwise.</returns>
        /// <exception cref="ArgumentNullException">Throw if source string is null.</exception>
        public Uri? Convert(string? obj)
        {
            var isValid = obj != null && this.validator!.IsValid(obj);
            this.logger?.LogTrace("Converting string {Obj}. Result: {Result}", obj, isValid);
            return isValid ? new Uri(obj!) : null;
        }
    }
}
