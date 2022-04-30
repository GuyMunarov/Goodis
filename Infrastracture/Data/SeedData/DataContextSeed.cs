using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastracture.Data.SeedData
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.BpTypes.Any())
                {
                    var bptData =
                        File.ReadAllText("../Infrastracture/Data/SeedData/bptypes.json");

                    var bpTypes = JsonSerializer.Deserialize<List<BpType>>(bptData);
                    foreach (var item in bpTypes)
                    {
                        context.BpTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.BusinessPartners.Any())
                {
                    var bpData =
                        File.ReadAllText("../Infrastracture/Data/SeedData/businesspartners.json");
                    var bpTypes = await context.BpTypes.ToListAsync();
                    var businessPartners = JsonSerializer.Deserialize<List<BusinessPartner>>(bpData);

                    foreach (var item in bpTypes)
                    {
                        var matchingPartners = businessPartners.Where(x => x.BpType.TypeCode == item.TypeCode).ToList();
                        item.BusinessPartners = matchingPartners;
                    }

                     await context.SaveChangesAsync();
                    
                }

                if (!context.Items.Any())
                {
                    var itemsData =
                        File.ReadAllText("../Infrastracture/Data/SeedData/items.json");

                    var items = JsonSerializer.Deserialize<List<Item>>(itemsData);
                    foreach (var item in items)
                    {
                        context.Items.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Users.Any())
                {
                    var usersData =
                        File.ReadAllText("../Infrastracture/Data/SeedData/users.json");

                    var users = JsonSerializer.Deserialize<List<AppUser>>(usersData);
                    foreach (var item in users)
                    {
                        context.Users.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex, "exception while seeding");
            }
        }
    }
}