namespace Code.Gameplay.Common.Identifiers.Service
{
    public class IdentifierService : IIdentifierService
    {
        private int _next;
        public int Next() => ++_next; 
    }
}