using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Menu : MonoBehaviour
{
    Dictionary<string, List<string>> boba_recipes =
        new Dictionary<string, List<string>>();

    List<string> topping_list =
        new List<string>();

    void Start()
    {
        // Initialize drinks
        boba_recipes.Add("Assam Black Tea", new List<string> { "Black", "None", "None", "100%" });
        boba_recipes.Add("Classic Milk Tea", new List<string> { "Black", "Creamer", "None", "100%" });

        boba_recipes.Add("Jasmine Green Tea", new List<string> { "Jasmine", "None", "None", "100%" });
        boba_recipes.Add("Jasmine Milk Tea", new List<string> { "Jasmine", "Creamer", "None", "100%" });

        boba_recipes.Add("Oolong Tea", new List<string> { "Oolong", "None", "None", "100%" });
        boba_recipes.Add("Oolong Milk Tea", new List<string> { "Oolong", "Creamer", "None", "100%" });

        boba_recipes.Add("Honey Black Tea", new List<string> { "Black", "None", "Honey", "0%" });
        boba_recipes.Add("Honey Green Tea", new List<string> { "Jasmine", "None", "Honey", "0%" });
        boba_recipes.Add("Honey Oolong Tea", new List<string> { "Oolong", "None", "Honey", "0%" });
        boba_recipes.Add("Honey Black Milk Tea", new List<string> { "Black", "Creamer", "Honey", "0%" });
        boba_recipes.Add("Honey Green Milk Tea", new List<string> { "Jasmine", "Creamer", "Honey", "0%" });
        boba_recipes.Add("Honey Oolong Milk Tea", new List<string> { "Oolong", "Creamer", "Honey", "0%" });

        boba_recipes.Add("Lychee Black Tea", new List<string> { "Black", "None", "Lychee", "50%" });
        boba_recipes.Add("Lychee Green Tea", new List<string> { "Jasmine", "None", "Lychee", "50%" });
        boba_recipes.Add("Lychee Oolong Tea", new List<string> { "Oolong", "None", "Lychee", "50%" });
        boba_recipes.Add("Lychee Black Milk Tea", new List<string> { "Black", "Creamer", "Lychee", "50%" });
        boba_recipes.Add("Lychee Green Milk Tea", new List<string> { "Jasmine", "Creamer", "Lychee", "50%" });
        boba_recipes.Add("Lychee Oolong Milk Tea", new List<string> { "Oolong", "Creamer", "Lychee", "50%" });

        boba_recipes.Add("Strawberry Black Tea", new List<string> { "Black", "None", "Strawberry", "50%" });
        boba_recipes.Add("Strawberry Green Tea", new List<string> { "Jasmine", "None", "Strawberry", "50%" });
        boba_recipes.Add("Strawberry Oolong Tea", new List<string> { "Oolong", "None", "Strawberry", "50%" });
        boba_recipes.Add("Strawberry Black Milk Tea", new List<string> { "Black", "Creamer", "Strawberry", "50%" });
        boba_recipes.Add("Strawberry Green Milk Tea", new List<string> { "Jasmine", "Creamer", "Strawberry", "50%" });
        boba_recipes.Add("Strawberry Milk Tea", new List<string> { "Oolong", "Creamer", "Strawberry", "50%" });

        boba_recipes.Add("Peach Black Tea", new List<string> { "Black", "None", "Peach", "50%" });
        boba_recipes.Add("Peach Green Tea", new List<string> { "Jasmine", "None", "Peach", "50%" });
        boba_recipes.Add("Peach Oolong Tea", new List<string> { "Oolong", "None", "Peach", "50%" });
        boba_recipes.Add("Peach Black Milk Tea", new List<string> { "Black", "Creamer", "Peach", "50%" });
        boba_recipes.Add("Peach Green Milk Tea", new List<string> { "Jasmine", "Creamer", "Peach", "50%" });
        boba_recipes.Add("Peach Milk Tea", new List<string> { "Oolong", "Creamer", "Peach", "50%" });

        boba_recipes.Add("Mango Black Tea", new List<string> { "Black", "None", "Mango", "50%" });
        boba_recipes.Add("Mango Green Tea", new List<string> { "Jasmine", "None", "Mango", "50%" });
        boba_recipes.Add("Mango Oolong Tea", new List<string> { "Oolong", "None", "Mango", "50%" });
        boba_recipes.Add("Mango Black Milk Tea", new List<string> { "Black", "Creamer", "Mango", "50%" });
        boba_recipes.Add("Mango Green Milk Tea", new List<string> { "Jasmine", "Creamer", "Mango", "50%" });
        boba_recipes.Add("Mango Oolong Milk Tea", new List<string> { "Oolong", "Creamer", "Mango", "50%" });

        boba_recipes.Add("Passionfruit Black Tea", new List<string> { "Black", "None", "Passionfruit", "50%" });
        boba_recipes.Add("Passionfruit Green Tea", new List<string> { "Jasmine", "None", "Passionfruit", "50%" });
        boba_recipes.Add("Passionfruit Oolong Tea", new List<string> { "Oolong", "None", "Passionfruit", "50%" });
        boba_recipes.Add("Passionfruit Black Milk Tea", new List<string> { "Black", "Creamer", "Passionfruit", "50%" });
        boba_recipes.Add("Passionfruit Green Milk Tea", new List<string> { "Jasmine", "Creamer", "Passionfruit", "50%" });
        boba_recipes.Add("Passionfruit Oolong Milk Tea", new List<string> { "Oolong", "Creamer", "Passionfruit", "50%" });

        boba_recipes.Add("Winter Melon Tea", new List<string> { "Water", "None", "Winter Melon", "0%" });
        boba_recipes.Add("Winter Melon Green Tea", new List<string> { "Jasmine", "None", "Winter Melon", "0%" });
        boba_recipes.Add("Winter Melon Oolong Tea", new List<string> { "Oolong", "None", "Winter Melon", "0%" });
        boba_recipes.Add("Winter Melon Black Milk Tea", new List<string> { "Black", "Creamer", "Winter Melon", "0%" });
        boba_recipes.Add("Winter Melon Green Milk Tea", new List<string> { "Jasmine", "Creamer", "Winter Melon", "0%" });
        boba_recipes.Add("Winter Melon Oolong Milk Tea", new List<string> { "Oolong", "Creamer", "Winter Melon", "0%" });

        boba_recipes.Add("Grapefruit Black Tea", new List<string> { "Black", "None", "Grapefruit", "50%" });
        boba_recipes.Add("Grapefruit Green Tea", new List<string> { "Jasmine", "None", "Grapefruit", "50%" });

        boba_recipes.Add("Pineapple Black Tea", new List<string> { "Black", "None", "Pineapple", "50%" });
        boba_recipes.Add("Pineapple Green Tea", new List<string> { "Jasmine", "None", "Pineapple", "50%" });

        boba_recipes.Add("Taro Milk Tea", new List<string> { "Water", "Taro", "None", "100%" });
        boba_recipes.Add("Thai Milk Tea", new List<string> { "Black", "Thai", "None", "25%" });
        boba_recipes.Add("Vanilla Milk Tea", new List<string> { "Water", "Creamer", "Vanilla", "0%" });
        boba_recipes.Add("Chocolate Milk Tea", new List<string> { "Water", "Chocolate", "None", "100%" });
        boba_recipes.Add("Caramel Milk Tea", new List<string> { "Black", "Creamer", "Caramel", "0%" });


        // Initialize toppings
        topping_list.Add("Boba");
        topping_list.Add("Aloe Vera");
        topping_list.Add("Pudding");
        topping_list.Add("Strawberry Popping Boba");
        topping_list.Add("Mango Popping Boba");
        topping_list.Add("Passionfruit Popping Boba");
        topping_list.Add("Lychee Popping Boba");
        topping_list.Add("Herbal Jelly");
        topping_list.Add("Rainbow Jelly");
        topping_list.Add("Strawberry Jelly");
        topping_list.Add("Lychee Jelly");
        topping_list.Add("Coconut Jelly");
        topping_list.Add("Coffee Jelly");
        topping_list.Add("Green Apple Jelly");
    }

    (string name, List<string> recipe) GetOrder()
    {
        // Choose random name from list of recipes on the menu
        List<string> all_recipes = boba_recipes.Keys.ToList();
        string random_name = all_recipes[Random.Range(0, all_recipes.Count)];

        // Get recipe for the order
        List<string> order = boba_recipes[random_name];

        // Add random topping(s) to the order
        // 0 - Boba | 1 - Random | 2 - Boba, Random | 3 - No Topping
        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            order.Add("Boba");
        }
        else if (rand == 1)
        {
            order.Add(topping_list[Random.Range(0, topping_list.Count)]);
        }
        else if (rand == 2)
        {
            order.Add("Boba");
            order.Add(topping_list[Random.Range(0, topping_list.Count)]);
        }

        return (random_name, order);
    }
}
