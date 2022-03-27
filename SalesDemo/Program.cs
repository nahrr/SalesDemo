
namespace Salesdemo
{
    // See https://aka.ms/new-console-template for more information

    public class Program
    {
        private const string filePath = @"C:\Users\Johan\TestFolder\File.txt"; //\Resultat.txt";
        List<SalesPerson> salesPersonList = new();
        List<string> listToFile = new();
        public Program()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Vänligen ange hur många säljare du vill registrera");
            Console.WriteLine("---------------------------------------------------------");
            int numberOfInputs = Convert.ToInt32(Console.ReadLine());
            AddToList(numberOfInputs);
            Console.WriteLine(PrintHeader());
            Console.WriteLine();
            PrintList(salesPersonList);
           
            listToFile.Add($"Added: {DateTime.Now.ToString()}");
            var writeToFile = WriteToFile(listToFile);
            if(writeToFile.Result == true)
            {
                Console.WriteLine("Wrote to file successfully");
            }
            Console.WriteLine("Press any key to close the program");
            Console.ReadLine(); // Just a little hack to keep the console window up
        }

        public void AddToList(int numberOfInputs)
        {
            for (int i = 0; i < numberOfInputs; i++)
            {
                Console.WriteLine("Ange namn:");
                var name = Console.ReadLine();
                Console.WriteLine("Ange personnummer:");
                var ssn = Console.ReadLine();
                Console.WriteLine("Ange distrikt:");
                var district = Console.ReadLine();
                Console.WriteLine("Ange sålda artiklar:");
                var soldArticles = Convert.ToInt32(Console.ReadLine());

                var salesPerson = new SalesPerson
                {
                    Namn = name,
                    persnr = ssn,
                    Distrikt = district,
                    Sålda_artiklar = soldArticles
                };
                salesPersonList.Add(salesPerson);
            }
        }

        public void PrintList(List<SalesPerson> salePersonList)
        {
            using StreamWriter file = new("WriteLines2.txt", append: true);

            var lvlOne = salePersonList.Where(a => a.Sålda_artiklar < 50)
                                       .OrderByDescending(a => a.Sålda_artiklar)
                                       .ToList();
            if (lvlOne.Count > 0)
            {
                foreach (var salesPerson in lvlOne)
                {
                    var tmpLine = $"{salesPerson.Namn} {salesPerson.persnr}  {salesPerson.Distrikt} {salesPerson.Sålda_artiklar}";
                    Console.WriteLine(tmpLine);
                    listToFile.Add(tmpLine);
                }
                var lvlOneHeader = $"{lvlOne.Count} säljare har nått nivå 1: under 50 artiklar";
                Console.WriteLine(lvlOneHeader);
                listToFile.Add(lvlOneHeader);
            }

            var lvlTwo = salePersonList.Where(a => a.Sålda_artiklar > 50 && a.Sålda_artiklar < 100)
                                       .OrderByDescending(a => a.Sålda_artiklar)
                                       .ToList();
            if (lvlTwo.Count > 0)
            {
                foreach (var salesPerson in lvlTwo)
                {
                    var tmpLine = $"{salesPerson.Namn} {salesPerson.persnr}  {salesPerson.Distrikt} {salesPerson.Sålda_artiklar}";
                    Console.WriteLine(tmpLine);
                    listToFile.Add(tmpLine);
                }
                var lvlTwoHeader = $"{lvlTwo.Count} säljare har nått nivå 2: mellan 50-100 artiklar";
                Console.WriteLine(lvlTwoHeader);
                listToFile.Add(lvlTwoHeader);
            }

            var lvlThree = salePersonList.Where(a => a.Sålda_artiklar >= 100 && a.Sålda_artiklar <= 199)
                                         .OrderByDescending(a => a.Sålda_artiklar)
                                         .ToList();
            if (lvlThree.Count > 0)
            {
                foreach (var salesPerson in lvlThree)
                {
                    var tmpLine = $"{salesPerson.Namn} {salesPerson.persnr}  {salesPerson.Distrikt} {salesPerson.Sålda_artiklar}";
                    Console.WriteLine(tmpLine);
                    listToFile.Add(tmpLine);
                }
                var lvlThreeHeader = $"{lvlThree.Count} säljare har nått nivå 3: mellan 100-199 artiklar";
                Console.WriteLine(lvlThreeHeader);
                listToFile.Add(lvlThreeHeader);
            }

            var lvlFour = salePersonList.Where(a => a.Sålda_artiklar > 199)
                                        .OrderByDescending(a => a.Sålda_artiklar)
                                        .ToList();
            if (lvlFour.Count > 0)
            {
                foreach (var salesPerson in lvlFour)
                {
                    var tmpLine = $"{salesPerson.Namn} {salesPerson.persnr}  {salesPerson.Distrikt} {salesPerson.Sålda_artiklar}";
                    Console.WriteLine(tmpLine);
                    listToFile.Add(tmpLine);
                }
                var lvlFourHeader = $"{lvlFour.Count} säljare har nått nivå 4: Över 200 artiklar";
                Console.WriteLine(lvlFourHeader);
                listToFile.Add(lvlFourHeader);
            }
        }
        public static string PrintHeader()
        {
            return "Namn Persnr Distrikt Antal";
        }

        public async Task<bool> WriteToFile(List<string> list)
        {
            try
            {
                await File.WriteAllLinesAsync(filePath, list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }
    }
}