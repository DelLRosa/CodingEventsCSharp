﻿namespace Coding_Events.Models;

public class Event
{
    public string? Name {get; set;}
    public string? Description { get; set; }
    public int Id {get; set;}

    public Event()
    {
    }
    public Event (string name, string description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
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
