using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //84
        List<C> discounts = new List<C>
        {
            new C { Discount = 10, StoreName = "Store1", ConsumerCode = 123 },
            new C { Discount = 15, StoreName = "Store2", ConsumerCode = 456 },
            new C { Discount = 5, StoreName = "Store1", ConsumerCode = 789 },
            new C { Discount = 20, StoreName = "Store3", ConsumerCode = 789 }
        };

        List<D> prices = new List<D>
        {
            new D { ProductCode = "P1", StoreName = "Store1", Price = 100 },
            new D { ProductCode = "P2", StoreName = "Store2", Price = 200 },
            new D { ProductCode = "P3", StoreName = "Store1", Price = 150 },
            new D { ProductCode = "P4", StoreName = "Store3", Price = 250 }
        };

        List<E> purchases = new List<E>
        {
            new E { ProductCode = "P1", StoreName = "Store1", ConsumerCode = 123 },
            new E { ProductCode = "P1", StoreName = "Store1", ConsumerCode = 789 },
            new E { ProductCode = "P2", StoreName = "Store2", ConsumerCode = 456 },
            new E { ProductCode = "P3", StoreName = "Store1", ConsumerCode = 123 },
            new E { ProductCode = "P4", StoreName = "Store3", ConsumerCode = 789 }
        };
        
        var results = purchases // объединения покупок сo скидками
            .GroupJoin(discounts,
                purchase => new { purchase.StoreName, ProductCode = "" },
                discount => new { discount.StoreName, ProductCode = "" },
                (purchase, purchaseDiscounts) => new
                {
                    purchase,
                    Discounts = purchaseDiscounts.ToList() //преобразование в List для удобства
                }
            )
            //плоский список
            .SelectMany(
                x => x.Discounts.DefaultIfEmpty(),
                (x, pd) => new
                {
                    x.purchase.StoreName,
                    x.purchase.ProductCode,
                    Discount = pd?.Discount ?? 0
                }
            )
            //объединяем результат с ценами по StoreName и ProductCode
            .Join(prices,
                x => new { x.StoreName, x.ProductCode },
                price => new { price.StoreName, price.ProductCode },
                (x, price) => new
                {
                    x.StoreName,
                    x.ProductCode,
                    TotalPriceWithDiscount = price.Price * (1 - (double)x.Discount / 100)
                }
            )
            //группируем результат по StoreName и ProductCode
            .GroupBy(
                x => new { x.StoreName, x.ProductCode },
                (key, group) => new
                {
                    key.StoreName,
                    key.ProductCode,
                    TotalPurchases = group.Count(),
                    TotalPriceWithDiscount = group.Sum(x => x.TotalPriceWithDiscount)
                }
            );
        
        if (results.Any())
        {
            foreach (var result in results.OrderBy(r => r.StoreName).ThenBy(r => r.ProductCode))
            {
                Console.WriteLine($"{result.StoreName} {result.ProductCode} {result.TotalPurchases} {result.TotalPriceWithDiscount}");
            }
        }
        else
        {
            Console.WriteLine("Требуемые данные не найдены");
        }


        Console.WriteLine("----------------");
        
        //91
        
        
        List<A> AList = new List<A>
        {
            new A { Street = "Street1", BirthYear = 1990, ConsumerCode = 1 },
            new A { Street = "Street2", BirthYear = 1985, ConsumerCode = 2 },
            new A { Street = "Street1", BirthYear = 1992, ConsumerCode = 3 }
        };

        List<B> BList = new List<B>
        {
            new B { ProductCode = "P001", Country = "Country1", Category = "Category1" },
            new B { ProductCode = "P002", Country = "Country2", Category = "Category2" },
            new B { ProductCode = "P001", Country = "Country3", Category = "Category1" }
        };

        List<E2> EList = new List<E2>
        {
            new E2 { StoreName = "Store1", ProductCode = "P001", ConsumerCode = 1 },
            new E2 { StoreName = "Store2", ProductCode = "P002", ConsumerCode = 2 },
            new E2 { StoreName = "Store1", ProductCode = "P001", ConsumerCode = 3 }
        };


        var result2 = AList
            .Join(EList, a => a.ConsumerCode, e => e.ConsumerCode, (a, e) => new { a.Street, e.ProductCode }) //соединяет А и В
            .Join(BList, ae => ae.ProductCode, b => b.ProductCode, (ae, b) => new { ae.Street, b.Category, b.Country }) // соединяет В А и Е
            .GroupBy(x => new { x.Street, x.Category }) //группируем результат по Street and Category
            .Select(g => new
            {
                Street = g.Key.Street,
                Category = g.Key.Category,
                CountryCount = g.Select(x => x.Country).Distinct().Count()
            })
            .OrderBy(x => x.Street) // сортировка
            .ThenBy(x => x.Category); // сортировка

        foreach (var item in result2)
        {
            Console.WriteLine($"{item.Street} {item.Category} {item.CountryCount}");
        }

    }
}

class C
{
    public int Discount { get; set; }
    public string StoreName { get; set; }
    public int ConsumerCode { get; set; }
}

//классы для 84 задания
class D
{
    public string ProductCode { get; set; }
    public string StoreName { get; set; }
    public int Price { get; set; }
}

class E
{
    public string ProductCode { get; set; }
    public string StoreName { get; set; }
    public int ConsumerCode { get; set; }
}

// классы для 91 задания

public class A
{
    public string Street { get; set; }
    public int BirthYear { get; set; }
    public int ConsumerCode { get; set; }
}

public class B
{
    public string ProductCode { get; set; }
    public string Country { get; set; }
    public string Category { get; set; }
}

public class E2
{
    public string StoreName { get; set; }
    public string ProductCode { get; set; }
    public int ConsumerCode { get; set; }
}
