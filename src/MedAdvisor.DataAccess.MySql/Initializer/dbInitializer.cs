﻿using MedAdvisor.DataAccess.MySql.DataContext;
using MedAdvisor.Models;

public class DataSeeder
{
	public AppDbContext DbContext;
	public DataSeeder(AppDbContext dbContext)
	{
		this.DbContext = dbContext;
	}

	public void Seed()
	{

		if (!DbContext.Allergies.Any())
		{
			// allergy seed list 
			var allergies = new List<Allergy>()
			{
				new Allergy()
				{
					Name = "milk",
					Code = "al001"
				},
                new Allergy()
                {
                    Name = "egg",
                    Code = "al002"
                },
                new Allergy()
                {
                    Name = "peanut",
                    Code = "al003"
                },
                new Allergy()
                {
                    Name = "dairy",
                    Code = "al004"
                },
                new Allergy()
                {
                    Name = "seesam",
                    Code = "al005"
                }
            };
           
            DbContext.Allergies.AddRange(allergies);
            DbContext.SaveChanges();

        }

}



    }
}
