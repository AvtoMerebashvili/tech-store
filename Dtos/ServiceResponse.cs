namespace tech_store.Dtos
{
    public class ServiceResponse <T>
    {
        public T? result { get; set; }
        public bool success { get; set; } = true;
        public string message { get; set; } = string.Empty;
    }
}
