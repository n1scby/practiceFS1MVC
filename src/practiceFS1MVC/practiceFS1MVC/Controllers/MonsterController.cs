using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MonsterController : Controller
    { 
        private readonly IMonsterRepository _monsterRepo;

        public MonsterController(IMonsterRepository monsterRepo)
        {
            _monsterRepo = monsterRepo;
        }
    
        // GET: Monster
        public ActionResult Index()
        {
            return View(_monsterRepo.GetMonsterList());
        }

        // GET: Monster/Details/5
        public ActionResult Details(int id)
        {
            return View(_monsterRepo.GetMonsterByID(id));
        }

        // GET: Monster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Monster newMonster, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _monsterRepo.Add(newMonster);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                // log the error
                
            }
            return View(newMonster);
        }

        // GET: Monster/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_monsterRepo.GetMonsterByID(id));
        }

        // POST: Monster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Monster updatedMonster, int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _monsterRepo.Edit(updatedMonster);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(updatedMonster);
            }
        }

        // GET: Monster/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_monsterRepo.GetMonsterByID(id));
        }

        // POST: Monster/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Monster deleteMonster, int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _monsterRepo.Delete(deleteMonster);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(deleteMonster);
            }
        }
    }
}