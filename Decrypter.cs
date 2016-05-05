using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenToBuy___Admin
{
    class Decrypter
    {
        String final = ""; //sirul de caractere decriptat
        String[] source = new String[1000]; //sirul de caractere ce trebuie decriptat
        Char[] CharOriginal; //vectorul de caractere necesar
        int index,i; //variabile necesare
        Boolean sol = false; //ajuta sa citeasca un numar intreg, nu pe cifre
        public void decrypt(String original) //primeste sirul ce trebuie decriptat
        {
            CharOriginal = original.ToCharArray(); //transforma in vector de caractere
            original = ""; //resetarea variabilelor
            final = "";
            for (index = 0; index < CharOriginal.Length; index++) //parcurge fiecare caracter al vectorului
            {
                if (!(CharOriginal[index] >= 'A' && CharOriginal[index] <= '}')) //daca este un numar sau este '*' sau '#'
                {
                    original = original + CharOriginal[index]; //se adauga la sirul de prelucrat
                    if (!sol)
                        sol = true; 
                }
                else
                    if (sol) //daca era numar sau simbol
                    {
                        original = original + " "; //adaugam spatiu dupa numar sau simbol
                        sol = false;
                    }
            }
            source = original.Split(' '); //despartim sirul intr-un vector de siruri in functie de ' '
            for (index = 0; index < source.Length; index++) //parcurgem tot vectorul de siruri
            {
                if (source[index] != "") //se prelucreaza doar sirurile nenule
                {
                    original = source[index];
                    i = Int32.Parse(original); //se transforma in numar codul ASCII
                    final = final + (char)i; //se adauga caracterul cu acel cod ASCII la sirul decriptat
                }
            }
        }

        public String getFinal()
        {
            return final; //returneaza sirul decriptat
        }
    }
}
