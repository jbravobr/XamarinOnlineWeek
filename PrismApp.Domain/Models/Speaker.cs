namespace PrismApp.Domain
{
	public class Speaker
	{
		public string FullName { get; private set; }
		public string Assignment { get; private set; }
		public string Photo { get; private set; }
		public string Name_Assignment => $"{FullName} - {Assignment}";
		
		public Speaker(string fullName, string assigment, string photo)
		{
			FullName = fullName;
			Assignment = assigment;
			Photo = photo;
		}
	}
}