using System;
namespace PrismApp.Domain
{
	public class Talk
	{
		public string Day { get; private set; }
		public string Title { get; private set; }
		public string Description { get; private set; }
		public DateTime Time { get; private set; }
		public Speaker Speaker { get; private set; }
		public string FormattedDate { get; private set; }

		public Talk(string day, string title, string description,
					DateTime time, Speaker speaker, string formattedDate)
		{
			Day = day;
			Title = title;
			Description = description;
			Time = time;
			Speaker = speaker;
			FormattedDate = formattedDate;
		}
	}
}
