// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using Infrastructure.Core.SharedKernel;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure.Core.Entities
{
	public partial class Software : Entity
	{
		#region Constructors
		public Software()
        	{
            
        	}
		#endregion
		#region Properties
		public string ProductId { get; set; }
		public string LicenseCode { get; set; }
		public Product Product { get; set; }
                #endregion
		#region Public Methods
		
    		#endregion

	}
}