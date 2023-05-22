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
            StreamWriter textOut=
            new StreamWriter ( new FileStream(@"C:\Users\LAB-DSC-ITT\Archivos\Productos.txt", FileMode.Create, FileAccess.Write));


            foreach(var product in products)
            {
                textOut.Write(product.Code +"|");
                textOut.Write(product.Description +"|");
                textOut.WriteLine(product.Price);
            }
            textOut.Close();
        }
}




 class Program
{
    private static void Main(string[] args)
    {
        List<Product> product = new List<Product>();
        product.Add(new Product ("123556854", "rojo", 125));
        product.Add(new Product ("000", "rosalia", 00000));
        product.Add(new Product ("4585887", "muñecodeiker", 3));
        product.Add(new Product ("7588547", "celular", 100));
        product.Add(new Product ("1010101", "chamarra de carlos", 3000));
        product.Add(new Product ("1234567", "gatos de edwin", 1500));
        product.Add(new Product ("1526478", "buerrito de omar", 20));


        ProductsDB.SaveProducts(product);
       
    }
}
