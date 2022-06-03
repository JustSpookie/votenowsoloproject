using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.DummyDAL
{
    public class DummyKandidaatDAL
    {
        List<KandidaatDTO> kandidaatDTOs;

        public bool UpdateKandidaat(KandidaatDTO kandidaatDTO)
        {
            bool found = false;
            foreach(KandidaatDTO kandidaat in kandidaatDTOs)
            {
                if(kandidaat.KandidaatID == kandidaatDTO.KandidaatID)
                {
                    kandidaat.KandidaatNaam = kandidaatDTO.KandidaatNaam;
                    found = true;
                }
            }

            return found;
        }
        public KandidaatDTO GetKandidaat(int kandidaatID)
        {
            bool found = false;
            foreach(KandidaatDTO kandidaat in kandidaatDTOs)
            {
                if(kandidaat.KandidaatID == kandidaatID)
                {
                    return kandidaat;
                    found = true;
                }
            }
            return null;
            
        }
        public List<KandidaatDTO> GetKandidaten()
        {
            return kandidaatDTOs;
        }
        public List<KandidaatDTO> GetKandidatenFromVerkiezing(int verkiezingID)
        {
            return null;
        }
        public bool AddKandidaat(KandidaatDTO kandidaatDTO)
        {
            kandidaatDTOs.Add(kandidaatDTO);
            return true;
        }
        public bool DeleteKandidaat(KandidaatDTO kandidaatDTO)
        {
            int locatie;
            int lengt = kandidaatDTOs.Count;
            for (int i = 0; i < kandidaatDTOs.Count; i++)
            {
                if(kandidaatDTOs[i] == kandidaatDTO)
                {
                    kandidaatDTOs.RemoveAt(i);
                }
            }
            if(lengt-1 == kandidaatDTOs.Count)
            {
                return true;
            }
            else { return false; }
        }
    }
}
