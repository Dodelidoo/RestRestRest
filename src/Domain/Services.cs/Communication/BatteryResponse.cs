using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class BatteryResponse : BaseResponse
    {
        public Battery Battery { get; private set; }

        private BatteryResponse(bool success, string message, Battery battery) : base(success, message)
        {
            Battery = battery;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="battery">Saved battery.</param>
        /// <returns>Response.</returns>
        public BatteryResponse(Battery battery) : this(true, string.Empty, battery)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BatteryResponse(string message) : this(false, message, null)
        { }
    }
}