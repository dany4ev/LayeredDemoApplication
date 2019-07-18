namespace Layered.ServiceModel
{
    // Message Protocol
    public class ValidationError
    {
        public string FieldName { get; set; }
        public string[] Error { get; set; }
    }
}
