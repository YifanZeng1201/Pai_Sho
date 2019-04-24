using System;

public class Tile
{
    public int mobility, owner;
    string color;

    public Tile(int val, int owner, string color)
    {
        this.mobility = val;
        this.owner = owner;
        this.color = color;
    }

    public bool checkHarmony(Tile other)
    {
        if (this.color == "red")
        {
            if (this.mobility == 4)
            {
                if (other.color == "red")
                {
                    if (other.mobility == 4) return false;
                    else return true;
                }
                else return false;
            }
            else if (this.mobility == 3)
            {
                if (other.color == "white")
                {
                    if (other.mobility == 5) return true;
                    else return false;
                }
                else
                {
                    if (other.mobility == 4) return true;
                    else return false;
                }
            }
            else
            {
                if (other.color == "white")
                {
                    if (other.mobility == 3) return true;
                    else return false;
                }
                else
                {
                    if (other.mobility == 4) return true;
                    else return false;
                }
            }
        }
        else
        {
            if (this.mobility == 4)
            {
                if (other.color == "white")
                {
                    if (other.mobility == 4) return false;
                    else return true;
                }
                else return false;
            }
            else if (this.mobility == 3)
            {
                if (other.color == "red")
                {
                    if (other.mobility == 5) return true;
                    else return false;
                }
                else
                {
                    if (other.mobility == 4) return true;
                    else return false;
                }
            }
            else
            {
                if (other.color == "red")
                {
                    if (other.mobility == 3) return true;
                    else return false;
                }
                else
                {
                    if (other.mobility == 4) return true;
                    else return false;
                }
            }
        }
    }
}

