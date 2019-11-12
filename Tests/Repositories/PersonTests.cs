using CrossCutting.IoC;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests.Repositories
{
	public class  PersonTests
	{
		private ServiceProvider _provider;
		private IPersonRepository _repository;
		private IUnitOfWork _uow;
		private Guid _guid;

		[SetUp]
		public void Setup()
		{
			var services = IocBootStrapper.ConfigureTestServices();

			_provider = services.GetProvider();
			_uow = _provider.GetService<IUnitOfWork>();
			_repository = _provider.GetService<IPersonRepository>();
			var entity = _repository.Add(new  Person { });
			_uow.Commit();
			_guid = entity.Id;
		}

		[Test]
		public void GetOne()
		{
			var entity = _repository.GetOne(_guid);
			Assert.AreEqual(_guid, entity.Id);
		}


		[Test]
		public void Remove()
		{
			var entity = _repository.GetOne(_guid);
			Assert.IsNotNull(entity);
			_repository.Remove(entity);
			_uow.Commit();
			entity = _repository.GetOne(_guid);
			Assert.IsNull(entity);
		}

		[Test]
		public void List()
		{
			var list = _repository.GetAll();
			var count = list.Count();
			Assert.IsTrue(count > 0, $"count = {count}");
			Assert.IsTrue(count == 1, $"count = {count}");
		}

		[Test]
		public void Update()
		{
			var entity = _repository.GetOne(_guid);

            var currentNome = entity.Nome; 
            entity.Nome = "Nome";

            var currentCPF = entity.CPF; 
            entity.CPF = "CPF";

            var currentEmail = entity.Email; 
            entity.Email = "Email";

            var currentTelefone = entity.Telefone; 
            entity.Telefone = "Telefone";

            var currentDataNascimento = entity.DataNascimento; 
            entity.DataNascimento = DateTime.Now;

			var result = _repository.Update(entity);
			Assert.AreEqual(_guid, entity.Id);
			Assert.AreEqual(_guid, result.Id);

            Assert.AreEqual(result.Nome, entity.Nome);
            Assert.AreNotEqual(result.Nome, currentNome);

            Assert.AreEqual(result.CPF, entity.CPF);
            Assert.AreNotEqual(result.CPF, currentCPF);

            Assert.AreEqual(result.Email, entity.Email);
            Assert.AreNotEqual(result.Email, currentEmail);

            Assert.AreEqual(result.Telefone, entity.Telefone);
            Assert.AreNotEqual(result.Telefone, currentTelefone);

            Assert.AreEqual(result.DataNascimento, entity.DataNascimento);
            Assert.AreNotEqual(result.DataNascimento, currentDataNascimento);

		}

		[Test]
		public void Find()
		{
			var entity = _repository.Find(x => x.Id == _guid);
			Assert.IsNotNull(entity);
		}

		[TearDown]
		public void Cleanup()
		{
			_repository.Remove(_guid);      
			_uow.Commit();
		}

	}
}

