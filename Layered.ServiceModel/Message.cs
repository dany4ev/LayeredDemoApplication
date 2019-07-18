using System;
using System.Collections.Generic;

namespace Layered.ServiceModel
{
    // Message Protocol
    public class Message<TViewModel> where TViewModel : class
    {
        public int UniqueCode { get; set; }
        public int StatusCode { get; set; }
        public string FriendlyMessage { get; set; }
        public TViewModel Data { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public Exception Error { get; set; }
    }
}
