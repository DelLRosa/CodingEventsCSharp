namespace Coding_Events;

public class EventData
{
    static private Dictionary<int,Event> Events = new Dictionary<int, Event>();

    public static IEnumerable<Event> GetAll()
    {
        return Events.Values;
    }

     public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

         // Remove
        public static void Remove(int id)
        {
            Events.Remove(id);
        }

         // GetById
        public static Event GetById(int id)
        {
            return Events[id];
        }
}
