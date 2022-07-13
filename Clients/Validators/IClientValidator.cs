using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clients.Entities;

namespace Clients.Validators
{
	public interface IClientValidator
	{
		public void ValidateFields(ClientData data);
	}
}
