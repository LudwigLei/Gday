using System.ServiceModel;
using System.Runtime.Serialization;

namespace Gday
{
	[ServiceContract(Name = "GdayService")]
	public interface IService
	{
		[OperationContract]
		Event[] GetEvents(Date date);

		[OperationContract]
		Event GetEvent(int id);

		[OperationContract]
		void LikeEvent(int id);
	}

	[DataContract]
	public class Event
	{
		[DataMember(IsRequired = true)]
		public int Id { get; set; }

		[DataMember(IsRequired = true)]
		public string Name { get; set; }

		[DataMember(IsRequired = true)]
		public string Description { get; set; }

		[DataMember(IsRequired = true)]
		public Date Date { get; set; }
	}

	[DataContract]
	public class Date
	{
		[DataMember(IsRequired = true)]
		public int Day { get; set; }
		
		[DataMember(IsRequired = true)]
		public int Month { get; set; }

		[DataMember]
		public int? Year { get; set; }
	}
}
