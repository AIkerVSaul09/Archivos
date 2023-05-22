using System;
using System.IO;


class Product
{
    public string Code;
    public string Description;
    public decimal Price;


    public Product(string c, string d, decimal p)
    {
        Code= c;
        Description= d;
        Price=p;
    }
}

class ProductsDB
{
    public static void SaveProducts(List<Product> products)
        {
            StreamWriter textOut= new StreamWriter ( new FileStream(@"C:\Users\LAB-DSC-ITT\Archivos\Productos.txt", FileMode.Create, FileAccess.Write));

            foreach(var product in products)
            {
                textOut.Write(product.Code +"|");
                textOut.Write(product.Description +"|");
                textOut.WriteLine(product.Price);
            }
            textOut.Close();
        }
        public static List<Product> GetProducts()
         {
           List<Product> products= new List<Product>();
           StreamReader textIn= new StreamReader ( new FileStream(@"C:\Users\LAB-DSC-ITT\Archivos\Productos.txt", FileMode.Open, FileAccess.Read));
           while (textIn.Peek() != -1)
           {
              string? row= textIn.ReadLine();
              string[] columns= row.Split('|');
              products.Add(new Product(columns[0], columns[1], decimal.Parse(columns[2])));
           }
           return products;
         }
}




 class Program
{
    private static void Main(string[] args)
    {
        List<Product> product = ProductsDB.GetProducts();
        product.Add(new Product ("123556854", "rojo", 12.8m));
        product.Add(new Product ("000", "rosalia", 00000));
        product.Add(new Product ("4585887", "muñecodeiker", 3));
        product.Add(new Product ("7588547", "celular", 100));
        product.Add(new Product ("1010101", "carlos", 3000));
        product.Add(new Product ("1234567", "gatos de edwin", 1500));
        product.Add(new Product ("1526478", "buerrito de omar", 20));


        //ProductsDB.SaveProducts(product);
        ProductsDB.GetProducts();
       
    }
}
