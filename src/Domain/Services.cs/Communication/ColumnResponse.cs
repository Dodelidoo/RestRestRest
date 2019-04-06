using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class ColumnResponse : BaseResponse
    {
        public Column Column { get; private set; }

        private ColumnResponse(bool success, string message, Column column) : base(success, message)
        {
            Column = column;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="column">Saved column.</param>
        /// <returns>Response.</returns>
        public ColumnResponse(Column column) : this(true, string.Empty, column)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ColumnResponse(string message) : this(false, message, null)
        { }
    }
}