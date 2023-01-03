// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using Infrastructure.Core.SharedKernel;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure.Core.Entities
{
	public partial class Country : Entity
	{
		#region Constructors
		public Country()
        	{
            
        	}
		#endregion
		#region Properties
		public string CountryId { get; set; }
		public string CountryName { get; set; }
		
                public List<Customer> Customers { get; set; }
		#endregion
		#region Public Methods
		
    		#endregion

	}
}