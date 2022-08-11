﻿using Testing.Models;

namespace MVC_Proj.Models;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int CategoryID { get; set; }
    public bool OnSale { get; set; }
    public int StockLevel { get; set; }

    public IEnumerable<Category> Categories { get; set; }
}
