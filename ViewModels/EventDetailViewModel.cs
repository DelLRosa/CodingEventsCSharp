using System;
using System.Collections.Generic;
using Coding_Events.Models;

namespace Coding_Events.ViewModels
{
   public class EventDetailViewModel
   {
      public int EventId { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public string ContactEmail { get; set; }
      public string CategoryName { get; set; }
      public string TagText {get;set;}

      public EventDetailViewModel(Event theEvent)
         {
         EventId = theEvent.Id;
         Name = theEvent.Name;
         Description = theEvent.Description;
         CategoryName = theEvent.Category.Name;
         
         TagText = "";
         
                List<Tag> evtTags = theEvent.Tags.ToList();
                for (var i = 0; i < evtTags.Count; i++)
                {
                    TagText += ("#" + evtTags[i].Name);
                    if (i < evtTags.Count - 1)
                    {
                        TagText += ", ";
                    }
                }
            }
            
      }
   }
