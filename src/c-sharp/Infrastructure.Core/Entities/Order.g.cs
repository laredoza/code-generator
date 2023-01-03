// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using Infrastructure.Core.SharedKernel;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure.Core.Entities
{
	public partial class Order : Entity
	{
		#region Constructors
		public Order()
        	{
            
        	}
		#endregion
		#region Properties
		public string OrderId { get; set; }
		public string CustomerId { get; set; }
		public string OrderDate { get; set; }
		public string DeliveryDate { get; set; }
		public string ShippingName { get; set; }
		public string ShippingAddress { get; set; }
		public string ShippingCity { get; set; }
		public string ShippingZip { get; set; }
		public Customer Customer { get; set; }
                
                public List<OrderDetails> OrderDetailss { get; set; }
		#endregion
		#region Public Methods
		
    		#endregion

	}
}