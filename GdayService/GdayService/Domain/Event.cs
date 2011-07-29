namespace Gday.Domain
{
	public class Event
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual Date Date { get; set; }
		public virtual int Rank { get; set; }
	}
}