using System;
using System.Collections.Generic;
using System.IO;
using Municipality_App.Models;
using Municipality_App.Structures;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Municipality_App.Services
{
    /// <summary>
    /// Repository responsible for loading, querying, and persisting service requests.
    /// Backs onto a JSON data source stored within the application's data directory.
    /// </summary>
    public static class ServiceRequestRepository
    {
        private static readonly object _syncRoot = new object();
        private static readonly Lazy<CustomList<ServiceRequest>> _requests = new Lazy<
            CustomList<ServiceRequest>
        >(LoadRequests);
        private static readonly JsonSerializerSettings SerializerSettings;

        private static string DataFilePath =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "service_requests.json");

        static ServiceRequestRepository()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                Formatting = Formatting.Indented,
            };
            SerializerSettings.Converters.Add(new StringEnumConverter());
        }

        /// <summary>
        /// Returns all known service requests.
        /// </summary>
        public static CustomList<ServiceRequest> GetAll()
        {
            lock (_syncRoot)
            {
                return new CustomList<ServiceRequest>(_requests.Value);
            }
        }

        /// <summary>
        /// Attempts to find a service request by its unique identifier.
        /// </summary>
        public static ServiceRequest FindById(string requestId)
        {
            if (string.IsNullOrWhiteSpace(requestId))
                return null;

            lock (_syncRoot)
            {
                foreach (var request in _requests.Value)
                {
                    if (
                        string.Equals(
                            request.RequestId,
                            requestId,
                            StringComparison.OrdinalIgnoreCase
                        )
                    )
                    {
                        return request;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns all requests with the specified priority.
        /// </summary>
        public static CustomList<ServiceRequest> GetByPriority(ServiceRequestPriority priority)
        {
            lock (_syncRoot)
            {
                var filtered = new CustomList<ServiceRequest>();
                foreach (var request in _requests.Value)
                {
                    if (request.Priority == priority)
                    {
                        filtered.Add(request);
                    }
                }
                return filtered;
            }
        }

        /// <summary>
        /// Returns all requests currently in the specified state.
        /// </summary>
        public static CustomList<ServiceRequest> GetByStatus(ServiceRequestState state)
        {
            lock (_syncRoot)
            {
                var filtered = new CustomList<ServiceRequest>();
                foreach (var request in _requests.Value)
                {
                    if (request.CurrentStatus == state)
                    {
                        filtered.Add(request);
                    }
                }
                return filtered;
            }
        }

        /// <summary>
        /// Adds a new service request and persists the change.
        /// </summary>
        public static void Add(ServiceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            lock (_syncRoot)
            {
                if (FindByIdInternal(request.RequestId) != null)
                {
                    throw new InvalidOperationException(
                        $"A request with id '{request.RequestId}' already exists."
                    );
                }

                EnsureDefaults(request);
                _requests.Value.Add(request);
                Persist();
            }
        }

        /// <summary>
        /// Updates an existing request and persists the change.
        /// </summary>
        public static bool Update(ServiceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            lock (_syncRoot)
            {
                for (int i = 0; i < _requests.Value.Count; i++)
                {
                    if (
                        string.Equals(
                            _requests.Value[i].RequestId,
                            request.RequestId,
                            StringComparison.OrdinalIgnoreCase
                        )
                    )
                    {
                        EnsureDefaults(request);
                        _requests.Value[i] = request;
                        Persist();
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Reloads the repository from disk, discarding in-memory changes.
        /// </summary>
        public static void Refresh()
        {
            lock (_syncRoot)
            {
                _requests.Value.Clear();
                _requests.Value.AddRange(LoadRequests());
            }
        }

        private static ServiceRequest FindByIdInternal(string requestId)
        {
            foreach (var request in _requests.Value)
            {
                if (string.Equals(request.RequestId, requestId, StringComparison.OrdinalIgnoreCase))
                {
                    return request;
                }
            }
            return null;
        }

        private static CustomList<ServiceRequest> LoadRequests()
        {
            if (!File.Exists(DataFilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(DataFilePath));
                return new CustomList<ServiceRequest>();
            }

            var json = File.ReadAllText(DataFilePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new CustomList<ServiceRequest>();
            }

            var records =
                JsonConvert.DeserializeObject<List<ServiceRequestRecord>>(json, SerializerSettings)
                ?? new List<ServiceRequestRecord>();

            var requests = new CustomList<ServiceRequest>();
            foreach (var record in records)
            {
                requests.Add(ToDomain(record));
            }

            return requests;
        }

        private static void Persist()
        {
            var directory = Path.GetDirectoryName(DataFilePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var records = new List<ServiceRequestRecord>();
            foreach (var request in _requests.Value)
            {
                records.Add(FromDomain(request));
            }

            var json = JsonConvert.SerializeObject(records, SerializerSettings);
            File.WriteAllText(DataFilePath, json);
        }

        private static void EnsureDefaults(ServiceRequest request)
        {
            if (request.StatusHistory == null)
            {
                request.StatusHistory = new CustomList<ServiceRequestStatusUpdate>();
            }

            if (string.IsNullOrWhiteSpace(request.RequestId))
            {
                request.RequestId = $"SR-{DateTime.UtcNow:yyyyMMddHHmmssfff}";
            }

            if (request.CreatedAt == default(DateTime))
            {
                request.CreatedAt = DateTime.UtcNow;
            }
        }

        private static ServiceRequest ToDomain(ServiceRequestRecord record)
        {
            var request = new ServiceRequest
            {
                RequestId = record.RequestId,
                Title = record.Title,
                Category = record.Category,
                Description = record.Description,
                Location = record.Location,
                Priority = record.Priority,
                CurrentStatus = record.CurrentStatus,
                AssignedTeam = record.AssignedTeam,
                CreatedAt = record.CreatedAt,
                ExpectedCompletion = record.ExpectedCompletion,
            };

            if (record.StatusHistory != null)
            {
                request.StatusHistory.AddRange(record.StatusHistory);
            }

            return request;
        }

        private static ServiceRequestRecord FromDomain(ServiceRequest request)
        {
            var record = new ServiceRequestRecord
            {
                RequestId = request.RequestId,
                Title = request.Title,
                Category = request.Category,
                Description = request.Description,
                Location = request.Location,
                Priority = request.Priority,
                CurrentStatus = request.CurrentStatus,
                AssignedTeam = request.AssignedTeam,
                CreatedAt = request.CreatedAt,
                ExpectedCompletion = request.ExpectedCompletion,
                StatusHistory = new List<ServiceRequestStatusUpdate>(),
            };

            if (request.StatusHistory != null)
            {
                foreach (var status in request.StatusHistory)
                {
                    record.StatusHistory.Add(status);
                }
            }

            return record;
        }

        private class ServiceRequestRecord
        {
            public string RequestId { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public string Location { get; set; }
            public ServiceRequestPriority Priority { get; set; }
            public ServiceRequestState CurrentStatus { get; set; }
            public string AssignedTeam { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? ExpectedCompletion { get; set; }
            public List<ServiceRequestStatusUpdate> StatusHistory { get; set; }
        }
    }
}
