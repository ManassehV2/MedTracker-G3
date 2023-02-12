using MedAdvisor.DataAccess.MySql.DataContext;
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


        // vaccine seed list
        if (!DbContext.Vaccines.Any()){
            var vaccines = new List<Vaccine>()
            {
                new Vaccine()
                {
                    Name = "addenovirus",
                    Code = "va001"
                },
                new Vaccine()
                {
                    Name = "antherax",
                    Code = "va002"
                },
                new Vaccine()
                {
                    Name = "colera",
                    Code = "va003"
                },
                new Vaccine()
                {
                    Name = "hepitites",
                    Code = "va004"
                },
                new Vaccine()
                {
                    Name = "covid",
                    Code = "va005"
                }

            };
            DbContext.Vaccines.AddRange(vaccines);
            DbContext.SaveChanges();

        }


        // medicine seed data
        if (!DbContext.Medicines.Any())
        {
            var medicines = new List<Medicine>()
            {
                new Medicine()
                {
                    Name = "accetaminophene",
                    Code = "med001"
                },
                new Medicine()
                {
                    Name = "adderl",
                    Code = "med002"
                },
                new Medicine()
                {
                    Name = "amlodepine",
                    Code = "med003"
                },
                new Medicine()
                {
                    Name = "antibiotics",
                    Code = "med004"
                },
                new Medicine()
                {
                    Name = "losarphane",
                    Code = "med005"
                }
            };

            DbContext.Medicines.AddRange(medicines);
            DbContext.SaveChanges();

        }




    }
}
