using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
    public interface IMonsterRepository
    {
        List<Monster> GetMonsterList();
        Monster GetMonsterByID(int id);
        void Add(Monster newMonster);
        void Edit(Monster updatedMonster);
        void Delete(int id);
    }
}
