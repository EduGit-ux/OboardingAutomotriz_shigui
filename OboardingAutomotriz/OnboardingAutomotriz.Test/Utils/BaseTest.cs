
using Microsoft.EntityFrameworkCore;
using OboardingAutomotriz.Infraestructure.Context;

namespace OnboardingAutomotriz.Test.Utils
{
    public class BaseTest
    {
        protected BBDDOnboardingContext ConstruirContext(string baseDatos)
        {
            var dbBase = new DbContextOptionsBuilder<BBDDOnboardingContext>().UseInMemoryDatabase(baseDatos).Options;
            var dbContext = new BBDDOnboardingContext(dbBase);
            return dbContext;
        }
    }
}
