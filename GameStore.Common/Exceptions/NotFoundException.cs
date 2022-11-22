namespace GameStore.Common.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() 
            : base() { }

        public NotFoundException(string name, object id) 
            : base($"Entity {name} with id: {id} was not found") { }
    }
}
