using Clients.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clients.Exceptions;
using Clients.Resources;
using Error = Clients.Exceptions.Error;

namespace Clients.Validators
{
	internal class ClientValidator : IClientValidator
	{
		public void ValidateFields(ClientData data)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			DateTime dt;
			if (!DateTime.TryParseExact(data.Dob,
				    "yyyy-MM-dd",
				    CultureInfo.InvariantCulture,
				    DateTimeStyles.None,
				    out dt))
			{
				exceptions.Add(new ValidationException
					{
						Field = Fields.Client_dob,
						Message = Errors.InvalidDateFormat,
						Rule = ValidationRules.ValidateDateFormat
				});
			}

			if (exceptions.Any())
			{
				throw new ValidationError(exceptions);
			}
		}
	}
}
