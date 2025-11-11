using System;
using Municipality_App.Structures;

namespace Municipality_App.Models
{
    /// <summary>
    /// Represents a municipal service request submitted by a resident.
    /// </summary>
    public class ServiceRequest
    {
        /// <summary>
        /// Unique identifier assigned to the service request.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Short, user-facing title describing the request.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Service category (e.g., Roads, Waste, Water).
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Detailed description supplied by the resident.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Physical area or zone that the request pertains to.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Priority level guiding resource allocation.
        /// </summary>
        public ServiceRequestPriority Priority { get; set; }

        /// <summary>
        /// Current lifecycle state of the request.
        /// </summary>
        public ServiceRequestState CurrentStatus { get; set; }

        /// <summary>
        /// Name of the municipal team or contractor assigned.
        /// </summary>
        public string AssignedTeam { get; set; }

        /// <summary>
        /// When the request was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Optional target completion date supplied by operations.
        /// </summary>
        public DateTime? ExpectedCompletion { get; set; }

        /// <summary>
        /// Chronological history of status changes.
        /// </summary>
        public CustomList<ServiceRequestStatusUpdate> StatusHistory { get; set; } =
            new CustomList<ServiceRequestStatusUpdate>();
    }

    /// <summary>
    /// Represents a change in request status along with contextual metadata.
    /// </summary>
    public class ServiceRequestStatusUpdate
    {
        public ServiceRequestState Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string Notes { get; set; }
    }

    /// <summary>
    /// High-level status categories for requests.
    /// </summary>
    public enum ServiceRequestState
    {
        Submitted,
        Acknowledged,
        InProgress,
        OnHold,
        Completed,
        Closed,
        QualityCheck,
        Scheduled,
    }

    /// <summary>
    /// Priority levels used within the operations queue.
    /// </summary>
    public enum ServiceRequestPriority
    {
        Low,
        Medium,
        High,
        Critical,
    }
}
