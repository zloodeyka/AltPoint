using Clients.Entities;
using DataAccess.Entities;
using System.Globalization;
using System.Linq.Expressions;

namespace Clients.Converters
{
	internal class ClientConverter : IClientConverter
	{
		public Expression<Func<Client, ClientData>> Convert()
		{
			return entity => new ClientData
			{
				Id = entity.Id,
				Name = entity.Name,
				Surname = entity.Surname,
				Patronymic = entity.Patronymic,
				Dob = entity.Dob.GetValueOrDefault().ToString("yyyy-MM-dd"),
				TypeEducation = entity.TypeEducation,
				CurWorkExp = entity.CurWorkExp,
				MonIncome = entity.MonIncome,
				MonExpenses = entity.MonExpenses,
				CreatedAt = entity.CreatedAt,
				UpdatedAt = entity.UpdatedAt,
				SpouseId = entity.SpouseId,
				Children = entity.Children.Select(x => new ChildData{
					Id = x.Id,
					Name = x.Name,
					Surname = x.Surname,
					Patronymic = x.Patronymic,
					Dob = x.Dob
				}).ToList(),
				DocumentIds = entity.Documents.Select(x => x.DocumentId).ToList(),
				Communications = entity.Communications.Select(x => new CommunicationData
				{
					Id = x.Id,
					Type = x.Type,
					Value = x.Value
				}).ToList(),
				Jobs = entity.Jobs.Select(x => new JobData
				{
					Id = x.Id,
					Type = x.Type,
					DateEmp = x.DateEmp,
					DateDismissal = x.DateDismissal,
					MonIncome = x.MonIncome,
					Tin = x.Tin,
					PhoneNumber = x.PhoneNumber,
					FactAddress = Convert(x.FactAddress),
					JurAddress = Convert(x.JurAddress)
				}).ToList(),
				Passport = entity.Passport != null ? new PassportData
				{
					Id = entity.Passport.Id,
					Series = entity.Passport.Series,
					Number = entity.Passport.Number,
					Giver = entity.Passport.Giver,
					DateIssues = entity.Passport.DateIssues
				} : null,
				LivingAddress = Convert(entity.LivingAddress),
				RegAddress = Convert(entity.RegAddress)
				};
		}

		public Client Convert(ClientData data)
		{
			DateTime clientDob;
			var clientHasDob = DateTime.TryParseExact(data.Dob,
				"yyyy-MM-dd",
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out clientDob);

			return new Client
			{
				Id = data.Id,
				Name = data.Name,
				Surname = data.Surname,
				Patronymic = data.Patronymic,
				Dob = clientHasDob ? clientDob.Date : null,
				TypeEducation = data.TypeEducation,
				CurWorkExp = data.CurWorkExp,
				MonIncome = data.MonIncome,
				MonExpenses = data.MonExpenses,
				Children = data.Children?.Select(x=> new Child
				{
					Id = x.Id,
					Name = x.Name,
					Surname = x.Surname,
					Patronymic = x.Patronymic,
					Dob = x.Dob
				}).ToList(),
				Documents = data.DocumentIds?.Select(x=> new Document
				{
					DocumentId = x
				}).ToList(),
				Communications = data.Communications?.Select(x=> new Communication
				{
					Id = x.Id,
					Type = x.Type,
					Value = x.Value
				}).ToList(),
				Jobs = data.Jobs?.Select(x=> new Job
				{
					Id = x.Id,
					Type = x.Type,
					DateEmp = x.DateEmp,
					DateDismissal = x.DateDismissal,
					MonIncome = x.MonIncome,
					Tin = x.Tin,
					PhoneNumber = x.PhoneNumber,
					FactAddress = Convert(x.FactAddress),
					JurAddress = Convert(x.JurAddress)
				}).ToList(),
				Passport = data.Passport!=null ? new Passport
				{
					Id = data.Passport.Id,
					Series = data.Passport.Series,
					Number = data.Passport.Number,
					Giver = data.Passport.Giver,
					DateIssues = data.Passport.DateIssues
				} : null,
				LivingAddress = Convert(data.LivingAddress),
				RegAddress = Convert(data.RegAddress)
			};
		}

		private Address Convert(AddressData? data)
		{
			if (data == null)
			{
				return null;
			}

			return new Address
			{
				Id = data.Id,
				ZipCode = data.ZipCode,
				Country = data.Country,
				Region = data.Region,
				City = data.City,
				Street = data.Street,
				House = data.House,
				Apartment = data.Apartment
			};
		}

		private AddressData Convert(Address? data)
		{
			if (data == null)
			{
				return null;
			}

			return new AddressData
			{
				Id = data.Id,
				ZipCode = data.ZipCode,
				Country = data.Country,
				Region = data.Region,
				City = data.City,
				Street = data.Street,
				House = data.House,
				Apartment = data.Apartment
			};
		}
	}
}
