using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int total_starting_units = 10;
    public static int total_a_units = 0;
    public static int total_b_units = 0;
    public static int total_c_units = 0;
    public Text total_starting_units_txt;
    public Text total_a_unit_txt;
    public Text total_b_unit_txt;
    public Text total_c_unit_txt;


    public static Image a_image;
    public static Image b_image;
    public static Image c_image;

    public void Start()
    {
        update_unit_txt("a");
        update_unit_txt("b");
        update_unit_txt("c");
    }

    public void add_unit(string unit_type)
    {
        if(total_starting_units > 0)
        {
            switch (unit_type)
            {
                case "a":
                    total_a_units++;
                    total_starting_units--;
                    break;
                case "b":
                    total_b_units++;
                    total_starting_units--;
                    break;
                case "c":
                    total_c_units++;
                    total_starting_units--;
                    break;
                default:
                    // code block
                    break;
            }
        }
        update_unit_txt(unit_type);
    }

    public void subtract_unit(string unit_type)
    {
        switch (unit_type)
        {
            case "a":
                if(total_a_units > 0)
                {
                    total_a_units--;
                    total_starting_units++;
                }
                break;
            case "b":
                if (total_b_units > 0)
                {
                    total_b_units--;
                    total_starting_units++;
                }
                break;
            case "c":
                if (total_c_units > 0)
                {
                    total_c_units--;
                    total_starting_units++;
                }
                break;
            default:
                // code block
                break;
        }
        update_unit_txt(unit_type);
    }

    private void update_unit_txt(string unit_type)
    {
        switch (unit_type)
        {
            case "a":
                total_a_unit_txt.text = total_a_units.ToString();
                break;
            case "b":
                total_b_unit_txt.text = total_b_units.ToString();
                break;
            case "c":
                total_c_unit_txt.text = total_c_units.ToString();
                break;
            default:
                // code block
                break;
        }
        total_starting_units_txt.text = total_starting_units.ToString();
    }
}
