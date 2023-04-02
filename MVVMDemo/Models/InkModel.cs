using System;
namespace MVVMDemo.Models
{
	public class InkModel
	{
		public Guid  InkId { get; set; }
		public string InkName { get; set; }
		public string BrandName { get; set; }
		public DateTime TStamp { get; set; }
		public bool Status { get; set; }
	}
}

