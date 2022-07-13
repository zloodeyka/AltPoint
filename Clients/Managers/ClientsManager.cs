

using Clients.Converters;
using Clients.Entities;
using Clients.Exceptions;
using Clients.Validators;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Clients.Managers
{
	internal class ClientsManager : IClientsManager
	{
		public ClientsManager(ClientsContext context,
			IClientValidator validator,
			IClientConverter converter)
		{
			_context = context;
			_validator = validator;
			_converter = converter;
		}

		public Guid Create(ClientData data)
		{
			var client = _converter.Convert(data);

			if (client.LivingAddress != null)
			{
				client.LivingAddress.Id = Guid.NewGuid();
				_context.Addresses.Add(client.LivingAddress);
				client.LivingAddressId = client.LivingAddress.Id;
			}

			if (client.RegAddress != null)
			{
				client.RegAddress.Id = Guid.NewGuid();
				_context.Addresses.Add(client.RegAddress);
				client.RegAddressId = client.RegAddress.Id;
			}

			client.Id = Guid.NewGuid();
			
			var now = DateTime.UtcNow;

			if (client.Children != null)
			{
				foreach (var child in client.Children)
				{
					child.Id = Guid.NewGuid();
					child.ClientId = client.Id;
					child.CreatedAt = now;
					child.UpdatedAt = now;
				}
				_context.Children.AddRange(client.Children);
			}

			if (client.Documents != null)
			{
				foreach (var document in client.Documents)
				{
					document.Id = Guid.NewGuid();
					document.CreatedAt = now;
					document.UpdatedAt = now;
				}
				_context.Documents.AddRange(client.Documents);
			}

			if (client.Communications != null)
			{
				foreach (var communication in client.Communications)
				{
					communication.Id = Guid.NewGuid();
					communication.ClientId = client.Id;
					communication.CreatedAt = now;
					communication.UpdatedAt = now;
				}
				_context.Communications.AddRange(client.Communications);
			}

			if (client.Jobs != null)
			{
				foreach (var job in client.Jobs)
				{
					job.Id = Guid.NewGuid();
					job.ClientId = client.Id;
					job.CreatedAt = now;
					job.UpdatedAt = now;

					if (job.FactAddress != null)
					{
						job.FactAddress.Id = Guid.NewGuid();
						job.FactAddressId = job.FactAddress.Id;
						_context.Addresses.Add(job.FactAddress);
					}

					if (job.JurAddress != null)
					{
						job.JurAddress.Id = Guid.NewGuid();
						job.JurAddressId = job.JurAddress.Id;
						_context.Addresses.Add(job.JurAddress);
					}
				}
				_context.Jobs.AddRange(client.Jobs);
			}

			if (client.Passport != null)
			{
				client.Passport.Id = Guid.NewGuid();
				client.Passport.ClientId = client.Id;

				_context.Passports.Add(client.Passport);
			}

			return client.Id;

		}

		public void Delete(Guid clientId)
		{
			var client = _context.Clients
				.Include(x=> x.Passport)
				.Include(x=> x.Children)
				.Include(x=> x.Communications)
				.Include(x=> x.Documents)
				.Include(x=> x.LivingAddress)
				.Include(x => x.RegAddress)
				.FirstOrDefault(x => x.Id == clientId);

			client.IsDeleted = true;
			_context.Clients.Update(client);

			if (client.Passport != null)
			{
				client.Passport.IsDeleted = true;
				_context.Passports.Update(client.Passport);
			}

			if (client.Children != null)
			{
				foreach (var child in client.Children)
				{
					child.IsDeleted = true;
				}
				_context.Children.UpdateRange(client.Children);
			}

			if (client.Communications != null)
			{
				foreach (var communication in client.Communications)
				{
					communication.IsDeleted = true;
				}
				_context.Communications.UpdateRange(client.Communications);
			}

			if (client.Documents != null)
			{
				foreach (var document in client.Documents)
				{
					document.IsDeleted = true;
				}
				_context.Documents.UpdateRange(client.Documents);
			}

			if (client.LivingAddress != null)
			{
				client.LivingAddress.IsDeleted = true;
				_context.Addresses.UpdateRange(client.LivingAddress);
			}

			if (client.RegAddress != null)
			{
				client.RegAddress.IsDeleted = true;
				_context.Addresses.UpdateRange(client.RegAddress);
			}

			if (client.SpouseId.HasValue)
			{
				Delete(client.SpouseId.Value);
			}
		}

		public ClientData Get(Guid id)
		{
			var client = _context.Clients.Where(x => !x.IsDeleted && x.Id == id)
				.Select(_converter.Convert())
				.SingleOrDefault();

			if (client == null)
			{
				throw new EntityNotFoundError();
			}

			if (client.SpouseId.HasValue)
			{
				client.Spouse = Get(client.SpouseId.Value);
			}

			return client;
		}

		public IQueryable<ClientData> GetList()
		{
			return _context.Clients.Where(x => !x.IsDeleted)
				.Select(_converter.Convert());
		}

		public void Update(Guid clientId, ClientData data)
		{
			var oldClient = _context.Clients
				.Include(x => x.Passport)
				.Include(x => x.Children)
				.Include(x => x.Communications)
				.Include(x => x.Documents)
				.Include(x => x.LivingAddress)
				.Include(x => x.RegAddress)
				.FirstOrDefault(x => x.Id == clientId);

			var client = _converter.Convert(data);
			var now = DateTime.Now;
			client.CreatedAt = oldClient.CreatedAt;
			client.UpdatedAt = now;




		}

		private readonly ClientsContext _context;
		private readonly IClientValidator _validator;
		private readonly IClientConverter _converter;
	}
}
