using System;

namespace Domain
{
    public class Account : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }

        public Account(string uuid, string propertyUuid, string name, int priority)
        {
            Uuid = uuid;
            PropertyUuid = propertyUuid;
            Name = name;
            Priority = priority;
        }

        public Account(string propertyUuid, string name, int priority)
        {
            Uuid = Guid.NewGuid().ToString();
            PropertyUuid = propertyUuid;
            Name = name;
            Priority = priority;
        }
    }
}
