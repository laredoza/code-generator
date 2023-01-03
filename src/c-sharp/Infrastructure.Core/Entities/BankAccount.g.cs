// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using Infrastructure.Core.SharedKernel;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure.Core.Entities
{
	public partial class BankAccount : Entity
	{
		#region Constructors
		public BankAccount()
        	{
            
        	}
		#endregion
		#region Properties
		public string BankAccountId { get; set; }
		public string BankAccountNumber { get; set; }
		public string Balance { get; set; }
		public string CustomerId { get; set; }
		public string Locked { get; set; }
		public Customer Customer { get; set; }
                
                public List<BankTransfers> BankTransferss { get; set; }
		#endregion
		#region Public Methods
		
    		#endregion

	}
}