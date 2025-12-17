using Microsoft.EntityFrameworkCore;
using Miroșnicenco_Eugenia_Lab2.Models;

namespace Miroșnicenco_Eugenia_Lab2.Data
{
	public static class DbInitializer
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new Miroșnicenco_Eugenia_Lab2Context
		   (serviceProvider.GetRequiredService
			<DbContextOptions<Miroșnicenco_Eugenia_Lab2Context>>()))
			{
				if (context.Book.Any())
				{
					return; // BD a fost creata anterior
				}
				/*
				context.Book.AddRange(
				new Book
				{
					Title = "Baltagul",
					Authors = "Mihail Sadoveanu", Price = Decimal.Parse("22") },

				new Book
				{
					Title = "Enigma Otiliei",
					Authors = "George Calinescu", Price = Decimal.Parse("18") },

				new Book
				{
					Title = "Maytrei",
					Authors = "Mircea Eliade", Price = Decimal.Parse("27") }
				);
				*/
				context.Genre.AddRange(
			   new Genre { Name = "Roman" },
			   new Genre { Name = "Nuvela" },
			   new Genre { Name = "Poezie" }
				);
				context.Customer.AddRange(
				new Customer
				{
					Name = "Popescu Marcela",
					Adress = "Str. Plopilor, nr. 24",
					BirthDate = DateTime.Parse("1979-09-01")
				},
				new Customer
				{
					Name = "Mihailescu Cornel",
					Adress = "Str. Bucuresti, nr. 45, ap. 2",BirthDate=DateTime.Parse("1969 - 07 - 08")}
			   
				);

				context.SaveChanges();
			}
		}
	}
}