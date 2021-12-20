using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ankh_Mork.BL.Game;
using Web_Ankh_Mork.BL.Game.Guid;
using Web_Ankh_Mork.BL.NPCsType;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.Controllers
{
    public class GameController : Controller
    {
        private Game _game;
        private GameViewModel _gameModel; 

        // GET: Game
        public ActionResult Start()
        {
            _game = new Game();
            _gameModel = new GameViewModel();
            _gameModel.AppearModel = new AppearModel();
            _gameModel.answerModel = new AnswerModel();
            _gameModel.answerModel.Alive = true;
            _gameModel.answerModel.PlayerMoney = 100;

            _game.ContinueGame(_gameModel);

            Session["Game"] = _gameModel;
            var gModel = Session["Game"] as GameViewModel;

            return View("Starts",gModel);
        }

        public ActionResult Starts()
        {
            return View(Session["Game"] as GameViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept(GameViewModel gameModel)
        {
            _game = new Game();
            _game.ResultOfChoise(gameModel);
            if (gameModel.answerModel.Alive)
            {
                _game.Accept(gameModel);
                Session["Game"] = gameModel;
                return RedirectToAction("Starts");
            }
            
            GuildOfThiefs.ResetThefts();
            return View("End", gameModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Skip(GameViewModel gameModel)
        {
            _game = new Game();
            if (gameModel.AppearModel.NpcRole == NPC.Assasin
                || gameModel.AppearModel.NpcRole == NPC.Beggar
                || gameModel.AppearModel.NpcRole == NPC.Thief)
            {
                GuildOfThiefs.ResetThefts();
                return View("End", gameModel);
            }

            _game.Skip(gameModel);
            if (gameModel.answerModel.Alive)
            {
                Session["Game"] = gameModel;
                return RedirectToAction("Starts");
            }

            GuildOfThiefs.ResetThefts();
            return View("End", gameModel);
        }

    }
}
