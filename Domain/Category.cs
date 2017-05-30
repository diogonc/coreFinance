using System;

namespace Domain
{
    public class Category : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string CategoryType { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }

        public Category(string uuid, string propertyUuid, string name, string categoryType, int priority)
        {
            Uuid = uuid;
            PropertyUuid = propertyUuid;
            Name = name;
            CategoryType = categoryType;
            Priority = priority;
        }

        public Category(string propertyUuid, string name, string categoryType, int priority)
        {
            Uuid = Guid.NewGuid().ToString();
            PropertyUuid = propertyUuid;
            Name = name;
            CategoryType = categoryType;
            Priority = priority;
        }
    }
}
