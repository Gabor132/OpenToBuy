using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Product
{
    string name; //numele produsului
    float price; //pretul produsului
    int quantity; //cantitatea produsului
    string desc; //stringul ce descrie intreg produsul
    String category = ""; //categoria produsului

	public Product(string n) //primeste numele
	{
        name = n; //seteaza numele
        desc = n; //seteaza descrierea doar cu numele
	}
    //set//
    public void setDetails(float p, int c) //seteaza detaliile
    {
        price = p;
        quantity = c;
        String s2 = " units ";
        if (quantity == 1)
        {
            s2 = " unit";
        }
        desc = name + " - " + price + " $ " + " - " + quantity + s2 + " - " + category;
    }
    public void setCategory(String c) //seteaza categoria
    {
        category = c;
        setDetails(price, quantity);
    }
    //get//
    public string getDesc() //returneaza descrierea
    {
        return desc;
    }
    public float getPrice() //returneaza pretul
    {
        return price;
    }
    public int getQuantity() //returneaza cantitatea
    {
        return quantity;
    }
    public String getName() //retuneaza numele
    {
        return name;
    }
    public String getCategory() //returneaza categoria
    {
        return category;
    }
}
