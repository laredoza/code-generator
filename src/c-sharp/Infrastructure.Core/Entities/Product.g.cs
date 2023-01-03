// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using Infrastructure.Core.SharedKernel;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure.Core.Entities
{
	public partial class Product : Entity
	{
		#region Constructors
		public Product()
        	{
            
        	}
		#endregion
		#region Properties
		public string ProductId { get; set; }
		public string ProductDescription { get; set; }
		public string UnitPrice { get; set; }
		public string AmountInStock { get; set; }
		
                public Book Book { get; set; }
		
                public List<OrderDetails> OrderDetailss { get; set; }
		
                public Software Software { get; set; }
		#endregion
		#region Public Methods
		
    		#endregion

	}
}