using System.Collections.Generic;
using Rock_Senai.Models;

namespace Rock_Senai
{
    public interface Imusico
    {
       
        void Create(Musico m);
        
        List<Musico> ReadAll();
        
        void Update(Musico m);
        
        void Delete(int id);   
    }
}