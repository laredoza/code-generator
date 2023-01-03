// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using Infrastructure.Core.SharedKernel;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure.Core.Entities
{
	public partial class OrderDetails : Entity
	{
		#region Constructors
		public OrderDetails()
        	{
            
        	}
		#endregion
		#region Properties
		public string OrderDetailsId { get; set; }
		public string OrderId { get; set; }
		public string ProductId { get; set; }
		public string UnitPrice { get; set; }
		public string Amount { get; set; }
		public string Discount { get; set; }
		public Order Order { get; set; }
                public Product Product { get; set; }
                #endregion
		#region Public Methods
		
    		#endregion

	}
}