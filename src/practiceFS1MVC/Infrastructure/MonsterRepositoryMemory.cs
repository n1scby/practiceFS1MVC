using ApplicationCore;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class MonsterRepositoryMemory : IMonsterRepository

    {
        private static List<Monster> _monsterList;
        private static int _nextNum = 1;

        public MonsterRepositoryMemory()
        {
           
            
                if (_monsterList == null)
                {
                    _monsterList = new List<Monster>();
                }
            
        }

        public List<Monster> GetMonsterList()
        {
            return _monsterList;
        }
        public Monster GetMonsterByID(int id)
        {
            return _monsterList.Find(m => m.Id == id);

        }

        public void Add(Monster newMonster)
        {
            newMonster.Id = _nextNum++;
            _monsterList.Add(newMonster);
        }

        public void Edit(Monster updateMonster)
        {
            Monster origMonster = GetMonsterByID(updateMonster.Id);
            origMonster.Name = updateMonster.Name;
            origMonster.Color = updateMonster.Color;
            origMonster.NumberOfEyes = updateMonster.NumberOfEyes;

        }

        public void Delete(int Id)
        {
            Monster removeMonster = GetMonsterByID(Id);
            _monsterList.Remove(removeMonster);

        }

       
    }
}
