namespace ModelObjects
{
    public class Message
    {
        public required string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public required User User { get; set; }
        public override string ToString()
        {
            return $"[{Timestamp.Hour}:{Timestamp.Minute}] {User.Username}: {Text}";
        }
    }
}
