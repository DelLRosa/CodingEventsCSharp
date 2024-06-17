﻿namespace Coding_Events.Models;

public class Event
{
    public string? Name {get; set;}
    public string? Description { get; set; }

    public EventCategory? Category {get; set;}
    public int CategoryId {get;set;}
    public int Id {get; set;}

    public ICollection<Tag>? Tags { get; set; }

    public Event()
    {
    }
    public Event (string name, string description)
    {
        Name = name;
        Description = description;
        Tags = new List<Tag>();
    }

    public override string? ToString()
    {
        return Name;
    }
       public override bool Equals(object? obj)
   {
      return obj is Event @event && Id == @event.Id;
   }

   public override int GetHashCode()
   {
      return HashCode.Combine(Id);
   }
}
