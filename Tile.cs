/* Author: Andrew Crapitto
 * Updated: 5/04/2019
 */

// Changelog: 5/13/2019: Added i and j parameters to keep track of location on board, added getID() so that the special ID won't have to be public
using System;

public class Tile
{

    static char ROCK = 'r';
    static char WHEEL = 'w';
    static char KNOTWEED = 'k';
    static char BOAT = 'b';
    static char LOTUS = 'l';
    static char ORCHID = 'o';
    static char BASIC = 'f';
    static char NULL = 'n';

    static char RED = 'R';
    static char WHITE = 'W';

    public int mobility, owner, i, j;
    public string color;
    bool junction, exists, flower;
    char specid;

    // Initializer for a special tile
    public Tile(int val, int owner, string color, char spec)
    {
        this.exists = true;
        this.junction = false;
        this.flower = false;
        this.mobility = val;
        this.owner = owner;
        this.color = color;
        this.specid = spec;
        this.i = -1;
        this.j = -1;
    }

    // Initializer for a basic flower tile
    public Tile(int val, int owner, string color)
    {
        this.exists = true;
        this.junction = false;
        this.flower = true;
        this.mobility = val;
        this.owner = owner;
        this.color = color;
        this.specid = BASIC;
        this.i = -1;
        this.j = -1;
    }

    // Initializer for a null space
    public Tile()
    {
        this.exists = false;
        this.junction = false;
        this.flower = false;
        this.mobility = 0;
        this.owner = 0;
        this.color = null;
        this.specid = NULL;
        
    }

    public bool inHarmony(Tile other)
    {
        if (this.owner == other.owner)
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
        else return false;
        
    }

    public bool isJunction()
    {
        return this.junction;
    }

    public bool isFlower()
    {
        return flower;
    }

    public char getID()
    {
        return this.specid;
    }
}

