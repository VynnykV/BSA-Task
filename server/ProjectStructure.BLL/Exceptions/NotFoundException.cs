using System;

namespace ProjectStructure.BLL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, int id)
            : base($"Entity {name} with id ({id}) was not found.")
        {
        }

        public NotFoundException((string, int id) name) : base($"Entity {name} was not found.") { }
    }
}