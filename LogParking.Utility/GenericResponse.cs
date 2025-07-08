namespace LogParking.Utility
{
    public class GenericResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Error { get; set; }

        public static GenericResponse<T> Ok(T data) => new() { Success = true, Data = data };
        public static GenericResponse<T> Fail(string error) => new() { Success = false, Error = error };
    }
}
