namespace PilotProject.CustomExeptions
{
    internal class ArgumentInvalidRangeException : ArgumentException
    {
        public int Value { get; }

        public ArgumentInvalidRangeException() : base(){ }
        public ArgumentInvalidRangeException(string message) : base(message) { }
        public ArgumentInvalidRangeException(string message, string value) : base(message, value) { }
        public ArgumentInvalidRangeException(string message, int value) : base(message) { Value = value; }
    }
}