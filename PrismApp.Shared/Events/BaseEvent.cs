using Prism.Events;

namespace PrismApp.Shared
{
	public class BaseEvent : PubSubEvent<string>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PrismApp.Shared.BaseEvent"/> class.
		/// </summary>
		public BaseEvent()
		{
		}
	}
}
