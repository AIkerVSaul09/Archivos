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
           textIn.Close();
           return products;
         }

           public static void SaveProductsBin(List<Product> products)
         {
           FileStream fs= new FileStream("archivos.bin", FileMode.Create, FileAccess.Write);
           BinaryWriter binOut= new BinaryWriter(fs);

           foreach(Product product in products)
            {
             binOut.Write(product.Code +"|");
             binOut.Write(product.Description +"|");
             binOut.Write(product.Price);
            }
            binOut.Close();
         }

         public static List<Product> GetProductsBin()
         { 
           FileStream fs= new FileStream("archivos.bin", FileMode.Open, FileAccess.Read);

           BinaryReader binIn= new BinaryReader(fs);

           while (binIn.PeekChar()!= -1)
           {
              string code = binIn.ReadString();
              string description = binIn.ReadString();
             // ProductsDB.Add(code, description, decimal.Parse(binIn.ReadString()));
           }
           binIn.Close();
           return GetProducts();

         }
}




 class Program
{
    private static void Main(string[] args)
    {
        List<Product> product = ProductsDB.GetProductsBin();
        foreach (Product product2 in product)
        {
            Console.WriteLine(product2);
        }
       // product.Add(new Product ("123556854", "rojo", 12.8m));
        //product.Add(new Product ("000", "rosalia", 00000));
        //product.Add(new Product ("4585887", "muñecodeiker", 3));
        //product.Add(new Product ("7588547", "celular", 100));
        //product.Add(new Product ("1010101", "carlos", 3000));
        //product.Add(new Product ("1234567", "gatos de edwin", 1500));
        //product.Add(new Product ("1526478", "buerrito de omar", 20));

        //ProductsDB.SaveProducts(product);
        //ProductsDB.GetProductsBin();
       
    }
}
  