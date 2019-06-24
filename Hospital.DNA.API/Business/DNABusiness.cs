using Hospital.DNA.API.Interface;
using Hospital.DNA.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DNA.API.Business
{
    public class DNABusiness : IDNABusiness
    {
        public IList<string> AnalisaDNA(DnaVM dnaCompleto)
        {
            var retornoAnalise = new List<string>();

            for (int i = 0; i < dnaCompleto.trechoDna.Count(); i++)
            {
                retornoAnalise.Add(AnalisadorTrechoDNA(dnaCompleto.trechoDna[i], dnaCompleto.trechoVirus[i]));
            }

            return retornoAnalise;
        }

        private string AnalisadorTrechoDNA(string dna, string virus)
        {
            var retornoAnalise = "";

            for (int i = 0; i <= dna.Length; i++)
            {
                if (i + virus.Count() <= dna.Length)
                {
                    var trechoAnalisado = dna.Substring(i, virus.Count());
                    var matchCount = 0;
                    for (int j = 0; j < trechoAnalisado.Length; j++)
                    {
                        if (trechoAnalisado[j] == virus[j])
                        {
                            matchCount++;
                        }
                    }

                    if (virus.Count() - matchCount <= 1)
                    {
                        retornoAnalise += i;
                    }
                }
            }

            if (String.IsNullOrEmpty(retornoAnalise))
            {
                retornoAnalise = "No Match!";
            }

            return retornoAnalise;
        }
    }
}
