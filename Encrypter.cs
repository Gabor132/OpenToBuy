using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenToBuy___Admin
{
    class Encrypter
    {
        String final; //sirul de caractere criptat
        Char[] CharOriginal; //vectorul de caracter pentru procesare
        Random n; //variabila random
        public void encypt(String original) //functia primeste sirul de caractere ce trebuie criptat
        {
            CharOriginal = original.ToCharArray(); //transforma sirul original in vector de caractere
            original = "";
            n = new Random(); //declararea variabilei random
            int index, k,index2,p; //variabile pentru criptare
            for (index = 0; index < CharOriginal.Length; index++) //pentru fiecare caracter din vector
            {
                k = n.Next(20)+1; //luam k caractere
                for (index2 = 0; index2 < k; index2++) //pentru fiecare dintre cele k caractere
                {
                    p = n.Next(60) + 65; //se alege un caracter aleatoriu cu codul ASCII intre 65 si 125
                    original = original + (char)p; //se adauga caracterul la sirul final
                }
                original = original + (int)CharOriginal[index]; //se introduce codul ASCII al caracterului dorit
                
            }
            final = original; //final primeste sirul de caractere criptate

        }

        public String getFinal()
        {
            return final; //returneaza sirul de caractere criptate
        }

    }
}
