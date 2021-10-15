using System.Collections.Generic;

namespace SignumExplorer.Data
{
    public class CountryInfo
    {

        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public int TotalCases { get; set; } = 0;
        public int TotalDeaths { get; set; } = 0;
        public float DeathPercentage => (this.TotalDeaths * 100) / this.TotalCases;

        public List<CountryInfo> GetCountryInfos()
        {
            var countryInfos = new List<CountryInfo>
            {
                new CountryInfo() { Id = 1, Name = "USA", TotalCases = 123871, TotalDeaths = 23422 },
                new CountryInfo() { Id = 2, Name = "Italy", TotalCases = 12352871, TotalDeaths = 5332342 },
                new CountryInfo() { Id = 2, Name = "China", TotalCases = 125874521, TotalDeaths = 19222342 },
                new CountryInfo() { Id = 2, Name = "Germany", TotalCases = 122381, TotalDeaths = 22342 },
                new CountryInfo() { Id = 2, Name = "France", TotalCases = 4587221, TotalDeaths = 1212342 },
                new CountryInfo() { Id = 2, Name = "Russion", TotalCases = 823871, TotalDeaths = 235422 }
            };

            return countryInfos;
        }

    }
}
