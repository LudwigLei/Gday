using FluentNHibernate.Mapping;

namespace Gday.Data
{
	public class EventMap : ClassMap<Domain.Event>
	{
		public EventMap()
		{
			Table("Event");
			Id(m => m.Id)
				.GeneratedBy.Identity();
			Map(m => m.Name);
			Map(m => m.Description);
			Map(m => m.Rank);
			Component(m => m.Date);
		}
	}

	public class DateMap : ComponentMap<Domain.Date>
	{
		public DateMap()
		{
			Map(m => m.Day);
			Map(m => m.Month);
			Map(m => m.Year).Nullable();
		}
	}
}