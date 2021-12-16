using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_Ankh_Mork.DB.Entity;

namespace Web_Ankh_Mork.DB
{
    public class MyContextInitializer : DropCreateDatabaseAlways<AnkhMorokContext>
    {
        protected override void Seed(AnkhMorokContext context)
        {
            //Assasins
            IList<Assasin> setUpAssasins = new List<Assasin>();

            setUpAssasins.Add(new Assasin() { Name = "Killer Bob", HighestReward = 15, IsOcupied = false, LowestReward = 5 });
            setUpAssasins.Add(new Assasin() { Name = "Killer Drake", HighestReward = 20, IsOcupied = false, LowestReward = 10 });
            setUpAssasins.Add(new Assasin() { Name = "Killer Lucy", HighestReward = 17, IsOcupied = true, LowestReward = 9 });
            setUpAssasins.Add(new Assasin() { Name = "Killer Armin", HighestReward = 11, IsOcupied = false, LowestReward = 2 });
            setUpAssasins.Add(new Assasin() { Name = "Killer Tom", HighestReward = 15, IsOcupied = true, LowestReward = 8 });
            setUpAssasins.Add(new Assasin() { Name = "Killer Viski", HighestReward = 21, IsOcupied = false, LowestReward = 9 });
            setUpAssasins.Add(new Assasin() { Name = "Killer Vodka", HighestReward = 13, IsOcupied = true, LowestReward = 4 });
            setUpAssasins.Add(new Assasin() { Name = "Killer Ben", HighestReward = 17, IsOcupied = false, LowestReward = 5 });

            context.Assasins.AddRange(setUpAssasins);

            //Fools
            IList<Fool> setUpFools = new List<Fool>();

            setUpFools.Add(new Fool() { Name = "Bob", FoolType = "Muggins", Salary = 0.5, Replic = "Let's get some money!" });
            setUpFools.Add(new Fool() { Name = "Kartoha", FoolType = "Gull", Salary = 1, Replic = "Hi friend! Wanna get money?" });
            setUpFools.Add(new Fool() { Name = "Vilka", FoolType = "Dupe", Salary = 2, Replic = "Let's work together?" });
            setUpFools.Add(new Fool() { Name = "Armin", FoolType = "Butt", Salary = 3, Replic = "Let's get some money!" });
            setUpFools.Add(new Fool() { Name = "Tom", FoolType = "Fool", Salary = 5, Replic = "Will u help me?" });
            setUpFools.Add(new Fool() { Name = "Gemor", FoolType = "Tomfool", Salary = 6, Replic = "Hi friend! Wanna get money?" });
            setUpFools.Add(new Fool() { Name = "Spat", FoolType = "StupidFool", Salary = 7, Replic = "Let's work together?" });
            setUpFools.Add(new Fool() { Name = "Ben", FoolType = "ArchFool", Salary = 8, Replic = "Will u help me?" });
            setUpFools.Add(new Fool() { Name = "PaSha", FoolType = "CompleteFool", Salary = 10, Replic = "I can pay you, will you work?" });

            context.Fools.AddRange(setUpFools);

            //Beggars
            IList<Beggar> setUpBeggars = new List<Beggar>();

            setUpBeggars.Add(new Beggar() { Name = "Krack", AmountOfMoney = 3, BeggarType = "Twitchers", Replic = "Wanna money!" });
            setUpBeggars.Add(new Beggar() { Name = "Pil", AmountOfMoney = 2, BeggarType = "Droolers", Replic = "Wanna money!" });
            setUpBeggars.Add(new Beggar() { Name = "Bub", AmountOfMoney = 1, BeggarType = "Dribblers", Replic = "Wanna money!" });
            setUpBeggars.Add(new Beggar() { Name = "Bomj", AmountOfMoney = 1, BeggarType = "Mumblers", Replic = "Wanna money!" });
            setUpBeggars.Add(new Beggar() { Name = "Yanik", AmountOfMoney = 0.9, BeggarType = "Mutterers", Replic = "Wanna money!" });
            setUpBeggars.Add(new Beggar() { Name = "Sakura", AmountOfMoney = 0.8, BeggarType = "WalkingAlongShouters", Replic = "Bless me with money" });
            setUpBeggars.Add(new Beggar() { Name = "Dimka", AmountOfMoney = 0.6, BeggarType = "DemandersofaChip", Replic = "Hmmm i see your pocket" });
            setUpBeggars.Add(new Beggar() { Name = "Egorik", AmountOfMoney = 0.5, BeggarType = "CallOtherPeopleJimmy", Replic = "Wanna money!" });
            setUpBeggars.Add(new Beggar() { Name = "Bolshe", AmountOfMoney = 0.08, BeggarType = "NeedAMeal", Replic = "Give me gizza!" });
            setUpBeggars.Add(new Beggar() { Name = "Loki", AmountOfMoney = 0.02, BeggarType = "NeedATea", Replic = "I'm loki!" });
            setUpBeggars.Add(new Beggar() { Name = "Buhoi", AmountOfMoney = 0, BeggarType = "NeedABeer", Replic = "Beer or live?" });

            context.Beggars.AddRange(setUpBeggars);

            //Thief
            context.Thiefs.Add(new Thief() { Name = "Bojenka", Fee = 10 });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}