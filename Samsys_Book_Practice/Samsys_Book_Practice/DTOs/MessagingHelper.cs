namespace Samsys_Book_Practice.DTOs
{
    public class MessagingHelper<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Obj { get; set; }
    }
}
