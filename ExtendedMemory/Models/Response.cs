namespace ExtendedMemory.Models
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T Item { get; set; }
    }
}
