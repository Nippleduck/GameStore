namespace GameStore.Common.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }

        public NotFoundException(string name) : base($"Entity {name} was not found") { }
    }
}
