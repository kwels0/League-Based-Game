using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_w_Inheritance
{
    class Holder
    {
    public class ChampionStats
    {
        public string Name;
        public string Job;
        public string Description;
        public double Hp;
        public int MaxHP;
        public double Dmg;
        public int Spd;
        public int Exp;
        public int Lvl;
        public ChampionStats(string name, string job, string description, double hp, int maxHP, double dmg, int spd)
        {
            this.Name = name;
            this.Job = job;
            this.Description = description;
            this.Hp = hp;
            this.MaxHP = maxHP;
            this.Dmg = dmg;
            this.Spd = spd;
            this.Exp = 0;
            this.Lvl = 1;
        }

    public virtual void CharacterDetails()
    {
        ImageArt(this);
        Thread.Sleep(5);
        delay(@$"
Name: {Name}
Job: {Job}
Description: 
{Description}
Hp: {Hp}
Damage: {Dmg}
Speed: {Spd}
Exp: {Exp}
Level: {Lvl}", 1);
        keyRead();
    }

    public virtual void EnemyDetails()
    {
        delay(@$"
Name: {Name}
Description: 
{Description}
Hp: {Hp}
Damage: {Dmg}
Speed: {Spd}
Exp: {Exp}", 1);
        keyRead();
    }
    public void IncreaseLevel()
        {
            Lvl += 1;
        }
    }
    public class Mordekaiser : ChampionStats
    {
        public int Stamina;
        public Mordekaiser(
            string name = "Mordekaiser the Iron Revenant",
            string job = "Warrior", 
            string description = "Twice slain and thrice born, Mordekaiser is a brutal warlord from a foregone epoch, who uses his necromantic sorcery to bind souls into an eternity of servitude. Few now remain who remember his earlier conquests, or know the true extent of his powers—but there are some ancient souls that do, and they fear the day when he may return to claim dominion over both the living and the dead.", 
            double hp = 645, 
            int maxHP= 645, 
            double dmg = 60, 
            int stamina = 100, 
            int spd = 35)
        : base(name, job, description, hp, maxHP, dmg, spd)
        {
            this.Stamina = stamina;
        }
        public override void CharacterDetails()
        {
            base.CharacterDetails();
            Console.WriteLine("Stamina: " + Stamina);
        }

        public void SkillUse(enemyStats enemy)
        {
            delay(@"
[1] Obliterate
[2] Indestructable
[3] Death's Grasp
[4] Realm of Death",1);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char num = keyInfo.KeyChar;
            switch(num)
            {
                case '1':
                {
                    Obliterate(enemy);
                    return;
                }
                case '2':
                {
                    Indestructible(enemy);
                    return;
                }
                case '3':
                {
                    DeathsGrasp(enemy);
                    return;
                }
                case '4':
                {
                    RealmofDeath(enemy);
                    return;
                }
            }
        }
        public int Obliterate(enemyStats enemy)
        {
            if (Stamina >= 25)
            {
                double damage = Dmg * 0.20;
                enemy.Hp -= damage; 
                int stam = 25;
                Stamina -= stam;
                Console.WriteLine($"You used Obliterate and dealt {damage} damage!");
                return Stamina; 
            }
            else
            {
                delay($"You do not have enough stamina to use Obliterate!",1);
                return Stamina; 
            }
        }

        public void Indestructible(enemyStats enemy)
        {
            if (Stamina >= 25)
            {
                double healAmount = Hp * 0.05;
                Hp += healAmount;
                if (Hp > MaxHP) 
                {
                    Hp = MaxHP;
                }
                Stamina -= 25;
                Console.WriteLine($"You have healed for {healAmount}!");
            }
            else
            {
                delay($"You do not have enough stamina to use Indestructable!", 1);
            } 
        }
        public void DeathsGrasp(enemyStats enemy)
        {
            if (Stamina >= 25)
            {
                //enemyStats.Spd -= 10;
                Stamina -= 25;
                Console.WriteLine("You have slowed down the enemy by 10 spd!");
            }
            else
            {
                delay($"You do not have enough stamina to use Death's Grasp!",1);
            } 
        }
        public void RealmofDeath(enemyStats enemy)
        {
            if (Stamina >= 50)
            {
            Hp += 5;
            Dmg += 5;
            Spd += 5;
            Stamina += 5;
            delay("You have absorbed some of the enemies ChampionStats. Increased current ChampionStats for a round",1);
            }
            else
            {
                delay($"You do not have enough stamina to use Realm of Death!",1);
            }
        }
    }

    public class MordCreate
    {
        public static Mordekaiser CreateMordekaiser()
        {
            return new Mordekaiser();
        }
    }

    public class Jhin : ChampionStats
    {
        public int ArrowCount;
        public int MaxArrows;
        public Jhin(string name, string job, string description, int hp, int maxHP, int dmg, int spd, int arrowCount, int maxArrows)
        : base(name, job, description, hp, maxHP, dmg, spd)
        {
            this.ArrowCount = arrowCount;
            this.MaxArrows = maxArrows;
        }
        public override void CharacterDetails()
        {
            base.CharacterDetails();
            Console.WriteLine("Ammo: " + ArrowCount);
        }
        public void Innate(ChampionStats enemyStats)
        {   
            double damageDealt = this.Dmg * 1;
            enemyStats.Hp -= damageDealt;
            delay($"You used Innate and deals {damageDealt} damage to /!",1);
            delay($"Bullets remaining {ArrowCount}/{MaxArrows}",1);
            ArrowCount -= 1;
        }
        public void DeadlyFlourish(ChampionStats enemyStats)
        {
            double damageDealt = this.Dmg * 1;
            enemyStats.Hp -= damageDealt;
            delay($"You used Innate and deals {damageDealt} damage to /!",1);
            delay($"Bullets remaining {ArrowCount}/{MaxArrows}",1);
            delay("You have stunned the enemy for a round",1);
            ArrowCount -= 1;
        }
        public void CaptiveAudience(ChampionStats enemyStats)
        {
            delay("You have put down a trap",1);
            //if for round increment to deal damage and slow
        }
        public void CurtainCall(ChampionStats enemyStats)
        {
            //calls out method 4 times
            double damageDealt = this.Dmg * 1;
            enemyStats.Hp -= damageDealt;
            delay($"You used Curtain call and deals {damageDealt} damage to /!",1);
            delay($"Bullets remaining {ArrowCount}/{MaxArrows}",1);
            ArrowCount -= 1;
        }
    }

    public class Fiddlesticks : ChampionStats
    {
        public int Mp;
        public Fiddlesticks(string name, string job, string description, int hp, int maxHP, int dmg, int spd, int mp)
        : base(name, job, description, hp, maxHP, dmg, spd)
        {
            this.Mp = mp;
        }
        public override void CharacterDetails()
        {
            base.CharacterDetails();
            Console.WriteLine("Mp: " + Mp);
        }
        public void Terrify(ChampionStats enemyStats)
        {
            double damageDealt = this.Dmg * 1;
            enemyStats.Hp -= damageDealt;
            delay($"You used Curtain call and deals {damageDealt} damage to /!\nYou have feared the enemy! Stunned for a round",1);
        }
        public void BountifulHarvest(ChampionStats enemyStats)
        {
            double heal = this.Hp * 1/8;
            double damageDealt = this.Dmg * 1;
            enemyStats.Hp -= damageDealt;
            delay($"You used Bountiful Harvest and deals {damageDealt} damage to /!\nHealed for {heal}",1);
        }
        public void Reap(ChampionStats enemyStats)
        {   
            double damageDealt = this.Dmg * 1;
            enemyStats.Hp -= damageDealt;
            delay("Reaped",1);
        }
        public void Crowstorm(ChampionStats enemyStats)
        {
            double damageDealt = this.Dmg * 1;
            enemyStats.Hp -= damageDealt;
            delay("Deals damage for 3 rounds",1);
        }
    }

    public class Warwick : ChampionStats
    {
        public Warwick(string name, string job, string description, int hp, int maxHP, int dmg, int spd)
        : base(name, job, description, hp, maxHP, dmg, spd)
        {
        }
        public void JawsOfTheBeast(ChampionStats enemyStats)
        {
            double heal = this.Hp * 1/8;
            double damageDealt = this.Dmg * 1;
            enemyStats.Hp -= damageDealt;
            delay($"You used Obliterate and deals {damageDealt} damage to /!",1);
        }
        public void BloodHunt(ChampionStats enemyStats)
        {
            Spd += 10;
            delay("Increase speed for 10",1);
        }
        public void PrimalHowl(ChampionStats enemyStats)
        {
            delay("Recieve less damage, Stun enemy next round",1);
        }
        public void InfiniteDuress(ChampionStats enemyStats)
        {
            delay("Attacks the enemy mulitple times making the enemy unable to attack for this round",1);
        }
    }

    public class Cho_gath : ChampionStats
    {
        public int SizeStacks;
        public Cho_gath(string name, string job, string description, int hp, int maxHP, int dmg, int spd, int sizeStacks)
        : base(name, job, description, hp, maxHP, dmg, spd)
        {
            this.SizeStacks = sizeStacks;
        }
        public override void CharacterDetails()
        {
            base.CharacterDetails();
            Console.WriteLine("Current Stacks: " + SizeStacks);
        }
        public void Rupture(ChampionStats enemyStats)
        {
            //damg and stun enemy
        }
        public void FeralScream(ChampionStats enemyStats)
        {
            //dmg and stun enemy but unable to move instead for write
        }
        public void VorpalSpikes(ChampionStats enemyStats)
        {
            //attack enemy 3 times
        }
        public void Feast(ChampionStats enemyStats)
        {
            // eat enemy and gain stack if below 40% hp the enemy
        }
    }

    public class enemyStats
    {
        public string Name;
        public string Description;
        public double Hp; 
        public int Dmg; 
        public int Stamina; 
        public int Spd; 
        public int Exp;

        public enemyStats(string name, string description, int hp, int dmg, int stamina, int spd, int exp)
        {
            this.Name = name;
            this.Description = description;
            this.Hp = hp;
            this.Dmg = dmg;
            this.Stamina = stamina;
            this.Spd = spd;
            this.Exp = exp;
        }
    }

    private static void delay(string str, int delay)
    {
        foreach (char c in str)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
        Thread.Sleep(1000);
    }

    public static void keyRead()
    {
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public class Driver
    {
        public static void Main()
        {
            Mordekaiser warrior = new Mordekaiser();

            Jhin archer = new Jhin(
            "Jhin, the Virtuoso",
            "Marksman",
            "Jhin is a meticulous criminal psychopath who believes murder is art. Once an Ionia Crest icon Ionian prisoner, but freed by shadowy elements within Ionia's ruling council, the serial killer now works as their cabal's assassin. Using his gun as his paintbrush, Jhin creates works of artistic brutality, horrifying victims and onlookers. He gains a cruel pleasure from putting on his gruesome theater, making him the ideal choice to send the most powerful of messages. Terror.",
            655,
            655,
            59,
            30,
            4,
            4);  

            Fiddlesticks mage = new Fiddlesticks(
            "Fiddlesticks, the Ancient Fear",
            "Mage",
            "Something has awoken. Something ancient. Something terrible. The ageless horror known as Fiddlesticks stalks the edges of mortal society, drawn to areas thick with paranoia where it feeds upon terrorized victims. Wielding a jagged scythe, the haggard, makeshift creature reaps fear itself, shattering the minds of those unlucky enough to survive in its wake. Beware the sounding of the crow, or the whispering of the shape that appears almost human… Fiddlesticks has returned.",
            650,
            650,
            55,
            34,
            500);  

            Warwick beast = new Warwick(
            "Warwick, the Uncaged Wrath of Zaun",
            "Beast",
            "Warwick is a monster who hunts the gray alleys of Zaun. Transformed by agonizing experiments, his body is fused with an intricate system of chambers and pumps, machinery filling his veins with alchemical rage. Bursting out of the shadows, he preys upon those criminals who terrorize the city’s depths. Warwick is drawn to blood, and driven mad by its scent. None who spill it can escape him.",
            620,
            620,
            65,
            35);

            Cho_gath voidM = new Cho_gath(
            "Cho'gath, the Terror of the Void",
            "Void",
            "From the moment Cho’Gath first emerged into the harsh light of Runeterra’s sun, the beast was driven by the most pure and insatiable hunger. A perfect expression of the Void’s desire to consume all life, Cho’Gath’s complex biology quickly converts matter into new bodily growth—increasing its muscle mass and density, or hardening its outer carapace like organic diamond. When growing larger does not suit the Void-spawn’s needs, it vomits out the excess material as razor-sharp spines, leaving prey skewered and ready to feast upon later.",
            644,
            644,
            69,
            34,
            0);

            wp:
                delay("Welcome to League of Legends! Choose your champion!",1);
                Console.WriteLine(@"
    [1] Mordekaiser
    [2] Jhin
    [3] Fiddlesticks
    [4] Warwick
    [5] Cho'gath");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char charChoose = keyInfo.KeyChar;
                switch (charChoose)
                {
                case '1':
                    warrior.CharacterDetails();
                    if (!Confirmation())
                        goto wp;
                    ShadowIslesRoute();
                    break;

                case '2':
                    archer.CharacterDetails();
                    if (!Confirmation())
                        goto wp;
                    IoniaRoute();
                    break;

                case '3':
                    mage.CharacterDetails();
                    if (!Confirmation())
                        goto wp;
                    BandleCityRoute();
                    break;

                case '4':
                    beast.CharacterDetails();
                    if (!Confirmation())
                        goto wp;
                    ZaunRoute();
                    break;

                case '5':
                    voidM.CharacterDetails();
                    if (!Confirmation())
                        goto wp;
                    VoidRoute();
                    break;

                default:
                    Console.WriteLine("No.");
                    break;
            }
            static bool Confirmation()
            {
                delay(@"
Confirm selected champion?
[1] YES ||| [2] NO", 1);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char num = keyInfo.KeyChar;
                if (num == '2')
                {
                    Console.Clear();
                    return false;
                }
                else
                {
                    Console.Clear();
                    return true;
                }
            }
        }
    }
    public class ShadowIsles
    {
        public class Enemy : enemyStats
        {
            public Enemy(string name, string description, int hp, int dmg, int spd, int stamina)
                : base(name, description, hp, dmg, spd, stamina, 100)
            {
            }
        }

        public class spectralIronhound : Enemy
        {
            public spectralIronhound()
                : base("Spectral Ironhound", "A spectral hound from the Shadow Isles.", 100, 20, 30, 1)
            {
            }
        }

        public class Thousand_Clawed_Deathwinder : Enemy
        {
            public Thousand_Clawed_Deathwinder()
                : base("Thousand-Clawed Deathwinder", "A deadly serpent with a thousand claws.", 150, 40, 40, 1)
            {
            }
        }

        public class Erastin_the_Disgraced : Enemy
        {
            public Erastin_the_Disgraced()
                : base("Erastin the Disgraced", "A fallen knight seeking redemption.", 200, 50, 35, 1)
            {
            }
        }

        public class Commander_Ledros : Enemy
        {
            public Commander_Ledros()
                : base("Commander Ledros", "A fearsome undead commander.", 400, 70, 40, 1)
            {
            }
        }

        public class Viego : Enemy
        {
            public Viego()
                : base("Viego", "The Ruined King, seeking to reclaim his lost queen.", 800, 90, 50, 1)
            {
            }
        }
    }


    public static void ShadowIslesEnemy()
    {
        ShadowIsles.spectralIronhound spectralIronhound = new ShadowIsles.spectralIronhound();
        ShadowIsles.Thousand_Clawed_Deathwinder deathwinder = new ShadowIsles.Thousand_Clawed_Deathwinder();
        ShadowIsles.Erastin_the_Disgraced disgraced = new ShadowIsles.Erastin_the_Disgraced();
        ShadowIsles.Commander_Ledros ledros = new ShadowIsles.Commander_Ledros();
        ShadowIsles.Viego viego = new ShadowIsles.Viego();
    }

    public class Ionia
    {
        public class Sparring_Students : enemyStats
        {
            public Sparring_Students()
            : base("Sparring Student", "A young fighter eager to learn and prove their worth.", 150, 30, 100, 25, 1)
            {
            }
        }
        public class Kinkou_Student : enemyStats
        {
            public Kinkou_Student()
            : base("Kinkou Student", "A disciple of the Kinkou Order, trained in the arts of balance and harmony.", 200, 40, 100, 30, 1)
            {
            }
        }
        public class Sainen_Thousand_Tailed : enemyStats
        {
            public Sainen_Thousand_Tailed()
            : base("Sai'nen Thousand-Tailed", "A fox spirit that roams Ionia.", 850, 95, 85, 80, 1)
            {
            }
        }
        public class Minah_Swiftfoot : enemyStats
        {
            public Minah_Swiftfoot()
            : base("Minah Swiftfoot", "Minah Swiftfoot, the Fleetfeather, is a revered scout and hunter hailing from the Buhru tribe of the Serpentine River in Ionia. With her keen senses and unmatched swiftness, Minah is a master of navigating the dense forests and marshlands of her homeland.", 720, 80, 65, 95, 1)
            {
            }
        }
        public class Shen : enemyStats
        {
            public Shen()
            : base("Viego, the Ruined King", "Once a noble ruler of a prosperous kingdom, Viego's life was tragically altered when he sought forbidden magic to revive his deceased queen. His kingdom fell to ruin, and Viego became consumed by grief and cursed with undeath. Now known as the Ruined King, he roams the Shadow Isles in search of a way to reunite with his lost love.", 800, 90, 70, 85, 1)
            {
            }
        }
    }

    public class BandleCity
    {
        public class PuffcapPup : enemyStats
        {
            public PuffcapPup()
            : base("Puffcap Pup", "Puffcap pups are mischievous creatures native to Bandle City. They are known for their playful antics and their fondness for collecting and planting puffcaps, small explosive mushrooms found throughout the forests of Runeterra.", 50, 20, 10, 60, 1)
            {
            }
        }
        public class Bandle_Commando : enemyStats
        {
            public Bandle_Commando()
            : base("Bandle Commando", "Bandle Commandos are elite yordle soldiers from Bandle City who are skilled in various forms of combat. They are known for their courage, resourcefulness, and unwavering loyalty to their homeland.", 600, 90, 80, 70, 1)
            {
            }
        }
        public class Yordle_Explorer : enemyStats
        {
            public Yordle_Explorer()
            : base("Yordle Explorer", "Yordle explorers are adventurous and curious inhabitants of Bandle City, always seeking out new discoveries and hidden treasures. Armed with their trusty explorer's gear, they fearlessly journey into the unknown, eager to unravel the mysteries of the world.", 80, 30, 15, 70, 1)
            {
            }
        }
        public class YordleSmith : enemyStats
        {
            public YordleSmith()
            : base("Yordle Smith", "Yordle Smiths are skilled craftsmen and artisans from Bandle City who specialize in forging and crafting various weapons and tools for their fellow yordles. They are known for their ingenuity, craftsmanship, and dedication to their craft.", 650, 100, 60, 60, 1)
            {
            }
        }
        public class Teemo : enemyStats
        {
            public Teemo()
            : base("Teemo", "Known as the Swift Scout, Teemo is a yordle with a mischievous personality and a keen sense of strategy. He specializes in guerrilla warfare and is a master of traps and poisons, making him a formidable opponent on the battlefield.", 500, 80, 70, 60, 1)
            {
            }
        }
    }

    public class Void 
    {
        public class Voidling : enemyStats
        {
            public Voidling()
            : base("Voidling", "Voidlings are small, feral creatures spawned from the Void. They are often encountered alongside champions and creatures associated with the Void, serving as their minions or allies in battle.", 300, 50, 40, 70, 1)
            {
            }
        }
        public class VoidAbomination : enemyStats
        {
            public VoidAbomination()
            : base("Void Abomination", "A grotesque and nightmarish creature born from the darkest depths of the Void, its mere presence distorting reality and instilling fear in all who behold it.", 1000, 150, 90, 30, 1)
            {
            }
        }
        public class HiveHerald : enemyStats
        {
            public HiveHerald()
            : base("Hive Herald", "A commanding entity of the Void, adorned with shimmering carapace and surrounded by a legion of lesser voidlings, spreading terror and destruction wherever it roams.", 800, 120, 80, 40, 1)
            {
            }
        }
        public class CamouflagedHorror : enemyStats
        {
            public CamouflagedHorror()
            : base("Camouflaged Horror", "A monstrous entity from the depths of the Void, capable of blending seamlessly into its surroundings, striking fear into the hearts of its prey before unleashing its devastating attacks.", 700, 100, 90, 50, 1)
            {
            }
        }
        public class BelVeth : enemyStats
        {
            public BelVeth()
            : base("Bel'Veth", "A nightmarish empress created from the raw material of an entire devoured city, Bel’Veth is the end of Runeterra itself... and the beginning of a monstrous reality of her own design. Driven by epochs of repurposed history, knowledge, and memories from the world above, she voraciously feeds an ever-expanding need for new experiences and emotions, consuming all that crosses her path. Yet her wants could never be sated by only one world as she turns her hungry eyes toward the Void’s old masters...", 500, 80, 70, 60, 1)
            {
            }
        }
    }

    public class Zaun
    {
        public class ZauniteUrchin : enemyStats
        {
            public ZauniteUrchin()
            : base("Zaunite Urchin", "Zaunite Urchins are street urchins from the alleys of Zaun, surviving through cunning and resourcefulness. Though they may seem harmless at first glance, their agility and street smarts make them dangerous adversaries in a fight.", 300, 40, 35, 80, 1)
            {
            }
        }
        public class ZauniteBruiser : enemyStats
        {
            public ZauniteBruiser()
            : base("Zaunite Bruiser", "Zaunite Bruisers are hired muscle employed by various criminal organizations in Zaun. With their brute strength and ruthless demeanor, they enforce the will of their employers with brutal efficiency.", 600, 90, 70, 50, 1)
            {
            }
        }
        public class ChemPunkPickpocket : enemyStats
        {
            public ChemPunkPickpocket()
            : base("Chem-Punk Pickpocket", "Chem-Punk Pickpockets are skilled thieves operating in the chaotic streets of Zaun. With their nimble fingers and quick reflexes, they excel at snatching valuables and evading capture.", 280, 50, 40, 90, 1)
            {
            }
        }
        public class CamouflagedHorror : enemyStats
        {
            public CamouflagedHorror()
            : base("Camouflaged Horror", "A monstrous entity from the depths of the Void, capable of blending seamlessly into its surroundings, striking fear into the hearts of its prey before unleashing its devastating attacks.", 700, 100, 90, 50, 1)
            {
            }
        }
        public class Vi : enemyStats
        {
            public Vi()
            : base("Vi, the Enforcer", "Vi is a tough and resilient enforcer from Zaun who isn't afraid to use her fists to get the job done. With her powerful gauntlets and no-nonsense attitude, she's a force to be reckoned with on the streets of Zaun.", 800, 120, 90, 50, 1)
            {
            }
        }
    }

    public static void ShadowIslesRoute()
    {   
        Console.WriteLine(@"
 .--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--. 
/ .. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \
\ \/\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ \/ /
 \/ /`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'\/ / 
 / /\  .________.___.__  .______  .______  ._______           ___    / /\ 
/ /\ \ |    ___/:   |  \ :      \ :_ _   \ : .___  \ .___    |   |  / /\ \
\ \/ / |___    \|   :   ||   .   ||   |   || :   |  |:   | /\|   |  \ \/ /
 \/ /  |       /|   .   ||   :   || . |   ||     :  ||   |/  :   |   \/ / 
 / /\  |__:___/ |___|   ||___|   ||. ____/  \_. ___/ |   /       |   / /\ 
/ /\ \    :         |___|    |___| :/         :/     |______/|___|  / /\ \
\ \/ /                             :          :              :      \ \/ /
 \/ /                                                        :       \/ / 
 / /\                                                                / /\ 
/ /\ \ .___ .________.___    ._______.________                      / /\ \
\ \/ / : __||    ___/|   |   : .____/|    ___/                      \ \/ /
 \/ /  | : ||___    \|   |   | : _/\ |___    \                       \/ / 
 / /\  |   ||       /|   |/\ |   /  \|       /                       / /\ 
/ /\ \ |   ||__:___/ |   /  \|_.: __/|__:___/                       / /\ \
\ \/ / |___|   :     |______/   :/      :                           \ \/ /
 \/ /                                                                \/ / 
 / /\.--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--./ /\ 
/ /\ \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \/\ \
\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `' /
 `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--' ");
        delay("The land now known as the Shadow Isles was once a Blessed Isles Crest icon beautiful realm, but it was shattered by a magical cataclysm. Black Mist permanently shrouds the isles and the land itself is tainted, corrupted by malevolent sorcery sorcery. Living beings that stand upon the Shadow Isles slowly have their life-force leeched from them, which, in turn, draws the insatiable, predatory spirits of the dead. Those who perish within the Black Mist are condemned to haunt this melancholy land for eternity. Worse, the power of the Shadow Isles is waxing stronger with every passing year, allowing the shades of undeath to extend their range and reap souls all across Runeterra.",1);
        keyRead();
        Mordekaiser mordekaiser = MordCreate.CreateMordekaiser();
        ShadowIsles.spectralIronhound spectralIronhound = new ShadowIsles.spectralIronhound();
        Console.WriteLine("You encountered an enemy! Prepare for battle!");
        BattleLogic(mordekaiser, spectralIronhound);
        
        theMap.MapBattle();
    }
    public static void IoniaRoute()
    {
        Ionia.Sparring_Students sparring_Students = new Ionia.Sparring_Students();
        Ionia.Kinkou_Student kinkou_Student = new Ionia.Kinkou_Student();
        Ionia.Sainen_Thousand_Tailed sainen_Thousand_Tailed = new Ionia.Sainen_Thousand_Tailed();
        Ionia.Minah_Swiftfoot minah_Swiftfoot = new Ionia.Minah_Swiftfoot();
        Ionia.Shen shen = new Ionia.Shen();
        Console.WriteLine(@"
++----------------------------------++
++----------------------------------++
||.___                 .__          ||
|||   |  ____    ____  |__|_____    ||
|||   | /  _ \  /    \ |  |\__  \   ||
|||   |(  <_> )|   |  \|  | / __ \_ ||
|||___| \____/ |___|  /|__|(____  / ||
||                  \/          \/  ||
++----------------------------------++
++----------------------------------++");
        delay("Ionia, in original Vastayan nomenclature: The First Lands, is a land of unspoiled beauty and natural magic. Its inhabitants, living in scattered settlements across this massive archipelago, are a spiritual people who seek to live in harmony and balance with the world. There are many orders and sects across Ionia, each following their own (often conflicting) paths and ideals. Self-sufficient and isolationist, Ionia has remained largely neutral in the wars that have ravaged Valoran over the centuries - until it was invaded by Noxus Crest icon Noxus. This brutal conflict and occupation has forced Ionia to reassess its place in the world. How it reacts and the future path Ionia will follow is as of yet undetermined, however, animosity against Noxus has led to militarization and vigilantism. Thirst for the dark arts is on the rise.",1);
        keyRead();
        theMap.MapBattle();
    }
    public static void VoidRoute()
    {
        Void.Voidling voidling = new Void.Voidling();
        Void.VoidAbomination voidAbomination = new Void.VoidAbomination();
        Void.HiveHerald hiveHerald = new Void.HiveHerald();
        Void.CamouflagedHorror camouflagedHorror = new Void.CamouflagedHorror();
        Void.BelVeth belVeth = new Void.BelVeth();
        Console.WriteLine(@"
 _____                          _____ 
( ___ )------------------------( ___ )
 |   |                          |   | 
 |   | \ \     /      _)      | |   | 
 |   |  \ \   /  _ \   |   _` | |   | 
 |   |   \ \ /  (   |  |  (   | |   | 
 |   |    \_/  \___/  _| \__,_| |   | 
 |___|                          |___| 
(_____)------------------------(_____)");
        delay("Screaming into existence with the birth of the universe, the Void is a manifestation of the unknowable nothingness that lies beyond. It is a force of insatiable hunger, waiting through the eons until its masters, the mysterious Watchers, mark the final time of undoing. To be a mortal touched by this power is to suffer an agonizing glimpse of eternal unreality, enough to shatter even the strongest mind. Denizens of the Void realm itself are construct-creatures, often of only limited sentience, but tasked with a singular purpose - to usher in total oblivion across Runeterra.",1);
        keyRead();
        theMap.MapBattle();
    }
    public static void ZaunRoute()
    {
        Zaun.ZauniteUrchin zauniteUrchin = new Zaun.ZauniteUrchin();
        Zaun.ZauniteBruiser zauniteBruiser = new Zaun.ZauniteBruiser();
        Zaun.ChemPunkPickpocket chemPunkPickpocket = new Zaun.ChemPunkPickpocket();
        Zaun.CamouflagedHorror camouflagedHorror = new Zaun.CamouflagedHorror(); 
        Zaun.Vi vi = new Zaun.Vi();

        
        Console.WriteLine(@"
__| |________________________| |__
__   ________________________   __
  | |                        | |  
  | | _____                  | |  
  | |/ _  / __ _ _   _ _ __  | |  
  | |\// / / _` | | | | '_ \ | |  
  | | / //\ (_| | |_| | | | || |  
  | |/____/\__,_|\__,_|_| |_|| |  
__| |________________________| |__
__   ________________________   __
  | |                        | |  ");
        delay("Zaun, also known as the City of Iron and Glass, is a large undercity district lying in the deep canyons and valleys threading Piltover Crest icon Piltover. What light reaches below is filtered through fumes leaking from the tangles of corroded pipework and reflected from the stained glass of its industrial architecture. Zaun and Piltover were once united, but are now separate, yet symbiotic societies. Though it exists in perpetual smogged twilight, Zaun thrives, its people vibrant and its culture rich. Piltover's wealth has allowed Zaun to develop in tandem; a dark mirror of the city above. Many of the goods coming to Piltover find their way into Zaun's black markets, and hextech inventors who find the restrictions placed upon them in the city above too restrictive often find their dangerous researches welcomed in Zaun. Unfettered development of volatile technologies and reckless industry has rendered whole swathes of Zaun polluted and dangerous. Streams of toxic runoff stagnate in the city's lower reaches, but even here people find a way to exist and prosper.",1);
        keyRead();
        theMap.MapBattle();
    }
    public static void BandleCityRoute()
    {
        BandleCity.PuffcapPup puffcapPup = new BandleCity.PuffcapPup();
        BandleCity.Bandle_Commando bandle_Commando = new BandleCity.Bandle_Commando();
        BandleCity.Yordle_Explorer yordle_Explorer = new BandleCity.Yordle_Explorer();
        BandleCity.YordleSmith yordleSmith = new BandleCity.YordleSmith();
        BandleCity.Teemo teemo = new BandleCity.Teemo();

        Console.WriteLine(@"
.·:'''''''''''''''''''''''''''''''''''''''''''''''''''''':·.
: : ______                 _ _        _____ _ _          : :
: : | ___ \               | | |      /  __ (_) |         : :
: : | |_/ / __ _ _ __   __| | | ___  | /  \/_| |_ _   _  : :
: : | ___ \/ _` | '_ \ / _` | |/ _ \ | |   | | __| | | | : :
: : | |_/ / (_| | | | | (_| | |  __/ | \__/\ | |_| |_| | : :
: : \____/ \__,_|_| |_|\__,_|_|\___|  \____/_|\__|\__, | : :
: :                                                __/ | : :
: :                                               |___/  : :
'·:......................................................:·'");
        delay("Opinions differ as to where exactly the home of the yordles is to be found, though a handful of mortals claim to have traveled unseen pathways to a land of curious enchantment beyond the material realm. They tell of a place of unfettered magic, where the foolhardy can be led astray by myriad wonders, and end up lost in a dream...\nIn Bandle City, it is said that every sensation is heightened for non-yordles. Colors are brighter. Food and drink intoxicates the senses for years and, once tasted, will never be forgotten. The sunlight is eternally golden, the waters crystal clear, and every harvest brings a fruitful bounty. Perhaps some of these claims are true, or maybe none—for no two taletellers ever seem to agree on what they actually saw.",1);
        keyRead();
        theMap.MapBattle();
    }

class theMap
{
    // Color constants
    const ConsoleColor PlayerColor = ConsoleColor.Black;
    const ConsoleColor EnemyColor1 = ConsoleColor.Green;
    const ConsoleColor EnemyColor2 = ConsoleColor.Blue;
    const ConsoleColor EnemyColor3 = ConsoleColor.Yellow;
    const ConsoleColor EnemyColor4 = ConsoleColor.Magenta;
    const ConsoleColor EnemyColorB = ConsoleColor.Red;
    const ConsoleColor DefaultColor = ConsoleColor.White;

    public static void MapBattle()
    {
        int mapWidth = 20; 
        int mapHeight = 10; 

        char[,] map = new char[mapHeight, mapWidth]; 
        bool[,] visible = new bool[mapHeight, mapWidth]; 
        int[,] enemyPositions = new int[2, 3]; 

        InitializeMap(map, visible, enemyPositions);

        int playerX = 0;
        int playerY = 0;
        map[playerY, playerX] = 'P';

        visible[playerY, playerX] = true;

        DisplayMap(map, visible);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    MovePlayer(map, visible, enemyPositions, ref playerX, ref playerY, 0, -1); 
                    break;
                case ConsoleKey.S:
                    MovePlayer(map, visible, enemyPositions, ref playerX, ref playerY, 0, 1); 
                    break;
                case ConsoleKey.D:
                    MovePlayer(map, visible, enemyPositions, ref playerX, ref playerY, 1, 0); 
                    break;
                case ConsoleKey.A:
                    MovePlayer(map, visible, enemyPositions, ref playerX, ref playerY, -1, 0); 
                    break;
            }
            ClearConsole();

            DisplayMap(map, visible);
        }
    }

    static void ClearConsole()
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, 0);
    }
    static void InitializeMap(char[,] map, bool[,] visible, int[,] enemyPositions)
    {
        Random rand = new Random();

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                visible[y, x] = false;
                map[y, x] = '.';
            }
        }

        for (int i = 0; i < enemyPositions.GetLength(0); i++)
        {
            int enemyX = rand.Next(0, map.GetLength(1));
            int enemyY = rand.Next(0, map.GetLength(0));

            while (map[enemyY, enemyX] != '.')
            {
                enemyX = rand.Next(0, map.GetLength(1));
                enemyY = rand.Next(0, map.GetLength(0));
            }

            map[enemyY, enemyX] = 'E'; 
            enemyPositions[i, 0] = enemyX;
            enemyPositions[i, 1] = enemyY;
        }
    }

    static void DisplayMap(char[,] map, bool[,] visible)
    {
        Console.WriteLine("╔" + new string('═', map.GetLength(1) * 2) + "╗");

        for (int y = 0; y < map.GetLength(0); y++)
        {
            Console.Write("║");

            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (visible[y, x])
                {
                    if (map[y, x] == 'P')
                        Console.ForegroundColor = PlayerColor;
                    else if (map[y, x] == 'E')
                        Console.ForegroundColor = EnemyColor2;

                    Console.Write(map[y, x] + " "); 

                    Console.ForegroundColor = DefaultColor;
                }
                else if (visible[y, x])
                {
                    if (map[y, x] == 'P')
                        Console.ForegroundColor = PlayerColor;
                    else if (map[y, x] == 'E')
                        Console.ForegroundColor = EnemyColor1;

                    Console.Write(map[y, x] + " "); 

                    Console.ForegroundColor = DefaultColor;
                }
                else if (visible[y, x])
                {
                    if (map[y, x] == 'P')
                        Console.ForegroundColor = PlayerColor;
                    else if (map[y, x] == 'E')
                        Console.ForegroundColor = EnemyColor3;

                    Console.Write(map[y, x] + " "); 

                    Console.ForegroundColor = DefaultColor;
                }
                else if (visible[y, x])
                {
                    if (map[y, x] == 'P')
                        Console.ForegroundColor = PlayerColor;
                    else if (map[y, x] == 'E')
                        Console.ForegroundColor = EnemyColor4;

                    Console.Write(map[y, x] + " "); 

                    Console.ForegroundColor = DefaultColor;
                }
                else if (visible[y, x])
                {
                    if (map[y, x] == 'P')
                        Console.ForegroundColor = PlayerColor;
                    else if (map[y, x] == 'E')
                        Console.ForegroundColor = EnemyColorB;

                    Console.Write(map[y, x] + " "); 

                    Console.ForegroundColor = DefaultColor;
                }
                else
                {
                    Console.Write(". "); 
                }
            }

            Console.WriteLine("║");
        }

        Console.WriteLine("╚" + new string('═', map.GetLength(1) * 2) + "╝"); 

        Console.WriteLine("\nUse WASD keys to move (W - up, A - left, S - down, D - right)");
    }

    static void MovePlayer(char[,] map, bool[,] visible, int[,] enemyPositions, ref int playerX, ref int playerY, int dx, int dy)
    {
        int newPlayerX = playerX + dx;
        int newPlayerY = playerY + dy;

        if (newPlayerX >= 0 && newPlayerX < map.GetLength(1) &&
            newPlayerY >= 0 && newPlayerY < map.GetLength(0))
        {
            if (map[newPlayerY, newPlayerX] != 'X')
            {
                map[playerY, playerX] = '.';
                playerX = newPlayerX;
                playerY = newPlayerY;
                MarkVisible(map, visible, playerX, playerY);
                map[playerY, playerX] = 'P'; 
                
                if (map[playerY, playerX] == 'E')
                {
                    int enemyX = enemyPositions[0, 0]; 
                    int enemyY = enemyPositions[0, 1]; 
                    
                    if ((Math.Abs(playerX - enemyX) == 1 && playerY == enemyY) || 
                        (Math.Abs(playerY - enemyY) == 1 && playerX == enemyX))
                    {
                        BattleInitiationR1();
                    }
                }
            }
        }
    }
    static void BattleInitiationR1()
    {
        Mordekaiser mordekaiser = MordCreate.CreateMordekaiser();
        ShadowIsles.spectralIronhound spectralIronhound = new ShadowIsles.spectralIronhound();
        Console.WriteLine("You encountered an enemy! Prepare for battle!");
        //BatlleLogic(mordekaiser, spectralIronhound);
    }


    static void MarkVisible(char[,] map, bool[,] visible, int playerX, int playerY)
    {
        visible[playerY, playerX] = true;
        MarkCellVisible(map, visible, playerX - 1, playerY);
        MarkCellVisible(map, visible, playerX + 1, playerY); 
        MarkCellVisible(map, visible, playerX, playerY - 1);
        MarkCellVisible(map, visible, playerX, playerY + 1);
    }
    static void MarkCellVisible(char[,] map, bool[,] visible, int x, int y)
    {
        if (x >= 0 && x < map.GetLength(1) && y >= 0 && y < map.GetLength(0))
            visible[y, x] = true;
    }
}
    public static void BattleLogic(ChampionStats playerChampionStats, enemyStats enemyStats)
    {
        int round = 1;

        Console.WriteLine($"\n==========\nYou have encountered an enemy {enemyStats.Name}");
        bool playerAlive = true;
        bool enemyAlive = true;

        while (playerAlive && enemyAlive)
        {
            Console.WriteLine($"\n--- Round {round} ---");
            Mordekaiser mordekaiser = MordCreate.CreateMordekaiser();
            Console.WriteLine($"Stamina: {mordekaiser.Stamina}"); 
            if (mordekaiser.Stamina <= 0)
            {
                Console.WriteLine("You do not have enough stamina to take action. Skipping turn...");
            }
            else
            {
                PlayerTurn(playerChampionStats, enemyStats); // Instantiate Mordekaiser
                mordekaiser.SkillUse(enemyStats);
            }

            if (enemyStats.Hp <= 0)
            {
                enemyAlive = false;
                break;
            }

            // Enemy's turn
            EnemyTurn(playerChampionStats, enemyStats);
            if (playerChampionStats.Hp <= 0)
            {
                playerAlive = false;
                break;
            }

            round++;
        }

        if (!playerAlive)
        {
            Console.WriteLine("You Died.");
        }
        else if (!enemyAlive)
        {
            Console.WriteLine($"You defeated the {enemyStats.Name}!");
            int Exp = enemyStats.Exp;
            // Method to gain exp
            Console.WriteLine($"You gained {Exp} experience points!");
            while (playerChampionStats.Exp >= 100)
            {
                Console.Clear();
                // Level up method
            }
        }
    }




        private static void FirstMoveEnemy(ChampionStats ChampionStats, enemyStats enemyStats)
        {
            Console.WriteLine("Enemy attacks first!");
            while (ChampionStats.Hp > 0 && enemyStats.Hp > 0)
            {
                if (ChampionStats.Hp <= 0)
                {
                    return;
                }
                if (enemyStats.Hp <= 0)
                {
                    return;
                }
                else
                {
                    EnemyTurn(ChampionStats, enemyStats);
                    PlayerTurn(ChampionStats, enemyStats);
                }
            }
        }

        private static void FirstMovePlayer(ChampionStats ChampionStats, enemyStats enemyStats)
        {
            Console.WriteLine("You attack first!");
            while (ChampionStats.Hp > 0 && enemyStats.Hp > 0)
            {
                if (ChampionStats.Hp <= 0)
                {
                    return;
                }
                if (enemyStats.Hp <= 0)
                {
                    return;
                }
                else
                {
                    PlayerTurn(ChampionStats, enemyStats);
                    EnemyTurn(ChampionStats, enemyStats);
                }
            }
        }
        private static void EnemyTurn(ChampionStats ChampionStats, enemyStats enemyStats)
        {
            if (ChampionStats.Hp <= 0)
            {
                return;
            }
            if (enemyStats.Hp <= 0)
            {
                return;
            }
            else
            {
            int damage = CalculateDamage(enemyStats.Dmg);
            ChampionStats.Hp -= damage;
            Console.WriteLine($"==========\n{enemyStats.Name} attacked! You received |{damage}| damage.\n==========");
            DisplayHealth(ChampionStats, enemyStats);
            }
        }
        private static void PlayerTurn(ChampionStats ChampionStats, enemyStats enemyStats)
        {
            if (ChampionStats.Hp < 0)
            {
                return;
            }
            
            if (enemyStats.Hp <= 0)
            {
                return;
            }
            else
            {
            //double damage = CalculateDamage(ChampionStats.Dmg);
            //enemyStats.Hp -= damage;
            //WriteLine($"==========\nYou attacked {enemyStats.Name}! Inflicted |{damage}| damage.\n==========");
            DisplayHealth(ChampionStats, enemyStats);
            }
        }
        private static int CalculateDamage(int damage)
        {
            return damage;
        }

        private static void DisplayHealth(ChampionStats ChampionStats, enemyStats enemyStats)
        {
            Console.WriteLine($"Your HP: |{ChampionStats.Hp}| | {enemyStats.Name}'s HP: |{enemyStats.Hp}|");
        }


    
    public static void ImageArt(ChampionStats character)
        {
            switch (character)
            {
                case Mordekaiser mordekaiser:
                    Console.WriteLine(@"
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓░░░░░░░░░░░░▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░▓▓▓░░░░░░░░░░░▒▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓░░░░░░░░░░▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▒▓▓▓▓▓█░░░░░░░░░▓█▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▒░░░░░░░░░▓██▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░███▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓██▓▓▓▓▓█▓░░░░░░░░░████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓█▓▓▓▓▓█▓░░░░░░░░░███▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓█▓▓█████▒░░░░░░░░░████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▓██▓█▓███████░░░░░░░░░▒████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████████████▓█░░░░░░░░░▓█████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████████████▓██░░░░░░░░▓█████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██████████████▓▓██░░░░░░░▓▓███▓█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██▓▓▓███▓▓████▓▓▓██▒░░░░░▓████▓█▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓████████▓▓▓▓▓▓████▓▒░█▓███▓▓█▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓░░▓▓▓▓▓██████▒█████▓█▓████▓▓▓██▓▓▓█████▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓███████▓▓████████▓▓▓████████▓▓▓▓▒███▓████▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░▓▓██████▓▓█▓▓▓▓▓▓███▓▓▓▓█████▓▓██▓█▓▓▓▓█▓▓▒▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░▓▓▓░░░░░░░░░░░░░▒▓░░▒█████████████▓█▒▓▓▓▓▓██▓▓▓▓▓▓█████▓▓▓███▓▓▓▓▓███▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░▒▓▒░░░░▓▓▓▓▓▓░░░░░░░░░░▓██▓████▓████▓▓███▓▓▓▓▓▓▓▓▓█▓▓████▓██▓██▓▓▓██▓▓████▓▓▓▓▓░░▓▓▒▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░▓▓██▓▓░░▓▓█▓▓▓▓▓▓░░░░░░░▒▓████████████▓███▓███▓▓▓▓▓██████████▓▓▓▓▓▓▓█▓░░░░░░░▒░░░▒▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░▓▓▓████▓▓▓▓████▓▓▓▓▓▓▓▒░░░▓███████████████▓▓▓▓▓▓▓▓▓▓███▓████▓▓▓▓▓▓▓▓▓█▓░░░░░░░░░░░▓▓▓█▓▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▒▓▓▓▓██████▓▓▓▓▓▓▓██▓▓▓▓▓▓███████████████████▓▓▓▓▓▓▓▓▓███▓▓▓▓▓████▓▓▓███▓▓▓▒░░░░░░░▓▓▓▓▓▓▓████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓
░░░░░░░▓▓▓▓▓▓██████████▓███████████████████████████▓█▓▓██▓▓▓▓▓▓▓▓██████████▓████████▓████░▓▓▓▓▓▓▓▓▓▓▓▓███▓▒░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▒
░░░░░░▓█▓▓▓▓██████████▓█████████████████████████████▓▓▓███▓▓█████▓█████████▓▓█████▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓███████▓▓▒░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓░
░░░░▓▓█▓▓▓█▓██████████████▓███████████████████████▓▓▓▓▓████▓▓▓▓███▓▓▓▓▓████▓▓█▓▓▓▓▓▓▓▓▓▓▓█▓█████▓▓▓▓▓███▓▓▓▓▓▓█████▓▓███▓▓▓▓▓▓▓▓▓███▓▓▒░
░░░▓▓█████▓█████████████████▓▓███▓██████████████▓▓▓▓▓▓▓▓█████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓█████▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓█████▓██▓▓█████▓▓▓███▓░░
░░▓▓████████████████▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓███████████████▓▓▓▓▓█████▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓██████████████████▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓███▓▓▓██▓▓▓▒▒░░░
░▓▓▓▓▓███████████████▓▓▓▓▓▓▓▓▓████▓▓▓███████████▓▓▓▓▓▓▓██████████▓▓▓▓▓▓████▓████▓▓▓▓▓▓██████████▓▓▓▓▓▓█████▓▓▓▓▓▓▓▓▓▓██▓▓█▓██▓▒░░░░░░░░░
░░▒▓▓▓██▓▓▓▓██████████▓▓▓▓▓▓▒██▓██▓▓██████████▓▓▓▓▓▓▓████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓██▓▓██░░░░░░░░░░░░
░░░░░▓▓▓▓▓▓▓████████▓▓██▓▓▓░░░▓██▓████████████▓▓▓▓▓███▓███████▓▓█▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓███████▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░
░░░░░░░▓▓▓█▓█████████████▒░░▒▓██▓▓█▓██████████▓███████▓██████▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓███████████▓▓▓▓▓▓▓▓▓▓▓███████▓▓▓▓▓███░░░░░░░░░░░░░░
░░░░░░░░▓▓█▓▓▓▓█████████░░░▓███▓▓█▓███████▓███████████▓█████▓▓▓▓█████▓▓▓██▓▓▓▓█▓▓██▓█████▓▓▓███▓▓▓▒▓▓▓▓▓▓▓▒▓█████████████▒░░░░░░░░░░░░░░
░░░░░░░░▓▓██▓█████▓▓▓▓▓░░░█▓██▓▓▓▓█████████▓███████████████▓▓▓▓████▓▓████▓████▓████▓▓▓███▓█████▓▒▓▓▓▓▓▒▒▓▓▓▒▓█████▓▒████▒░░░░░░░░░░░░░░░
░░░░░░░░▓▓██▓█████▓█▓░░░░░█▓▓▓▓▓█▓██████████████████▓▓██████████▓█▓▓▓███████████████▓▓▓▓▓██████▓▓▓█▓▓▓▓▓▓▓▓▓▒▓▓▓█▓░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▓▓██▓██████▓▒░░░░▒▓▓▓▓▓██▓█████████████▓▓███▒░░█████████▓▓▒▓▓█████████████████▓▒▓███████▓▓█▓▓▓▓▓▓▓▓▓▓▓███▓▓░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▓▓▓▓█████▓▓▓▓░░░░▓▓▓▓▓▓█▓▓█████████████▓▒░░░░░░████▓▓▓▓▓▓▒▓█████████▓▓█████████▓▓▓▓▓███▓█▓▓█▓▓▓▓▓▓▓▓▓▓▓▓█▓▓░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▒███████▒▒▓▓▓░░░▓▓▓▓▓▓████████████████░░░░░░░░░██████████▓▓████▓▓████▓██▓██▓███▓▓██████░██▓▓█▓▓▓▓▓▓▓▓▓▓▓█▓▓░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░▓██▒▓█░░░▓▓▓▓░░▓▓▓▓▓████████████████░░░░░░░░░░███▓▓██████▓▓█▓▒▓▓████▓▓████▓▓▓█▓███████░░██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░▓██▓░░░░░▓▓▓▓░▒▓▓▓███████████████▒░░░░░░░░░░░░██▓▓▓██▓▓▓▓███▓▓█████████████▓▓██▓▓████▓░░████▓▓▓▓▓▓▓▓▒▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░█████████▓▓▓▒▓▓▓████████████▓░░░░░░░░░░░░░░░░██▓▓▓▓█▓▓▓▓▓█▓▓████████████████▓▓▓███▓█▓░░░▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░▓████████▓▓▓▓▒▓██████████▒░░░░░░░░░░░░░░▒░░░░██▓▓▓█▓████▓▓▓▓▓███████▓███████▓▓▓▓████▓▓░░░░█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░▒██████████▓▓▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░▒█▓▒░█▓█▓▓█████████████████▓▓▓█████▓▓███████▓█░░░░░▒██▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░██████▓██████░░░░░░░░░░░░░░░░░░░░░░░░░░░██▓▓█▓██▓██████████████████▓█████████████████░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░▒▓▓▓▓███▓░███▓░░░░░░░░░░░░░░░░░░░░░░░░░░████▓███▓████████████████████████████████████░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░▒██▓░░░░░░███▓░░░░░░░░░░░░░░░░░░░░░░░░░▓███████▓████████████████████████▓███████████░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░▒█▓▓░░░░░░███▓░░░░░░░░░░░░░░░░░░░░░░░░████▓██████████████▓██████▓████▓▓█████████████▓░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░▒█▓▓░░░░▓███▓░░░░░░░░░░░░░░░░░░░░░░▒████▓████████████████▓▓▓███▓███▓▓████████▓██████▓░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░▒▓█▓██▓███▓░░░░░░░░░░░░░░░░░░▒▓▒░▒████▓███████▓███████████▓▓▓███▓▓▓██████████▓███████▒░░░░░░░▒██▓▓▓████▒░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░▒▓▓█████▓▒░░░░░░░░░░░░░░░░░░░█▓▓▓███▓███████▓██████████████▓▓▓▓▓▓████████████▓███████▓▒░░░░░░▒██▓▓█████▒░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░▒▓▓▓███▓░░░░░░░░░░░░░░░░░░░░▓██▓█▓▓███████▓████████████████▓▓▓█████████████████████▓▓░░░░░░░░▒█▓███████▓░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███▓▓██████▓▓█████████████████████████████████████████▓░░░░░░░░░▓████████▓░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███▓▓▓██▓███▓█████████████████████████████████████████░░░░░░░██████▓██████░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓████████▓█████████████████████████████████████████████░░░░░░░░░▓████▓█████▓░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███████████████████████████████████████████████████████░░░░░░░░░▒▒▒▓▓▓█████▓░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓████████████████████████████████████████████████████████████████▓▓▓░▒██████▓░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓████████████████████████████████████████████████████████████████▓▓▓▓░█▓░▓██░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒██▒░██████▓█████████████████████████████████████████████████▓▓▓▓▓▓░░░░▓▒░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓▒░▓██████████████████████████████████████████████████████▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███▓▓▓▓▓▓█▓█████████████████████████████████████████████████▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████▓▓▓▓▓▓▓▓▓███████████████████████████████████████████████████▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████▓▓▓▓▓▓▓▓▓▓████████▓░████████████████████▓████████████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███▓▓▓▓▓▓▓▓▓▓███████▓░░▓████████████████░▓█████████████████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███▓▓▓▓▓▓▓▓▓▓████████▓░▓████▓█████████░░░░█████████████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒██▓▓▓▓▓█████████████▓░▒███░░▓██████▓░░░░░█████████████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██▓▓███████████████▒░░░███░░░██████░░░░░░▓███████████████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▓▓██████████████▓░░░░██░░░░▓████▓░░░░░░░███████████████░███▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▓████████████▒░░░░░░░█▓░░░░▒████▓░░░░░░░░██████████████░░▓█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓▓███████████░░░░░░░░░░░░░░░░████░░░░░░░░░▒█████████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓██████████▓░░░░░░░░░░░░░░░░░▒██▓░░░░░░░░░░▓████████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██▓█████████▓░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░███████████▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████████████░░░░░░░░░░░░░░░░░░░░▒▓░░░░░░░░░░░░█████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓█▓███████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█████████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓▓▓███████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█████████████▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███▓▓██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒██████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███▓████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒███▓▓████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓████████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████████████▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒████████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██████████████▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███▓█████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓████████▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒██▓▓███████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒███▓▓██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███▓▓██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███▓▓██████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    break;
                case Jhin jhin:
                Console.WriteLine(@"

░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▒▒▓▓▓░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▒▒░░▒░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░▒▒▒▒░░░░░░▒█▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒░░░▒▒▒░░░░▓▓▒▓▓▓▒▒▒▒▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒░░░▒░▒▒░▒█▒▒▒▒▒▒░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░▒▒▒▒▒░░▒▒░░░░░░░░▒▓█▓▓▒░▒░▒░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒░▒▒░░░░░░░░░░░▓▓▓▓░▒▓▒▒▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░▒▒▒▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░▒▒▒▒▓▓████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▒▒▒▒▒▒▒▒░░░░░░▒▒▒▒▒▒▒▒▒▒▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓███▓▓▒▒▒▒▒▒▒░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▒▒▒▓██████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓██▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒░░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██▓▓▓▓▓▓▓██▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█████████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓█████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓███████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓████████████▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓███████████▓▓███▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓█████████████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓███████████████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██████▓█████████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█████▓░░█████████████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓██▒░░░▒█████████████▓▒▒▒▒▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒█▓▓▓▓▓▒░░░░░██████████████▓▒▒▒▒▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓████▓▓▓░░░▒▓▓▓▓▓███████████▓▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓█▓██▓▓██▓░░░▓▓██▓▓▓████████████▓▒▒▒▓▒▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▓▒▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓█████▓▓▓▓░░░▓▓▓▓▓██████████████▓▓▒▒▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▓░░▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓█████████░░░░░░░▒▓▓█▓███████████▓▓▒▒▒▒▓▓▓▓▓▓▓▒▓▒▒▒▒▒▒▒▓▓▓░░░▒▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓████████▓░░░░░░░░░▒▓██████████████▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▓▓▓░░░░▒▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓██████▓░░░░░░░░░░░░░▓██▓▓██████▓██▓▓▓▒▒▒▒▓▓▓▓▓▓▓▒▓▒▒▒▒▒▒▓▓▓░░░░░░▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▒██▒░░░░░░░░░░░░░░░▒▓▓█████▒░░░░░░░░░░░░░░░▒▓▓▓▓█████▓▓█████▓▓▒▒▒▒▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓░░░░░░░▒▓▓▓▓▓█████▒░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░▒███▒░░░░░░░░░░░░▓▓▓████▓░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▒▓▓▓███▓▓▓▒▒▓▒▓▓▓▓▓▓▓▓▓▒▒▒▓▓▓▓▓░░░░░░░░░▓██████████▒░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░███▓▒▒░░░░░░░░██████▓░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓██████▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░▒█████████▓▒░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░▒███████▓▒░▒▓█████▓░░░░░░░░░░░░░░░░░░░░░░░████▓▓▓▓█████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░▓█████████▓░░░░░░░░░░░░░░▒▓▓░░░
░░░░░░░░░░░░▓██████▓█▓███▓██▒░░░░░░░░░░░░░░░░░░░░░░░▒▓▓███▓██████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░▒██████████▒░░░░▒▒▒▒▒▓▓▓▒░░░░
░░░░░░▓▓██▓████▓██▓███████▓▒░░░░░░░░░░░░░░░░░░░░░░░░▒█████▓█████████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░▓████████████████▓▓▒░░░░░░
░░▒▓▓███▓▓▓███████▓▓▓████▒░░░░░░░░░░░░░░░░░░░░░░░░░░▓████▓████████████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░▓██████████████▓▒░░░░░░░
▒▓▓▓▒▒▒████████▓██▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░▒█▓███▓█████████████████████▓▓▓▓█▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░▓█████████████░░░░░░░░
░▒▓▓████▓▓▓██████▓█▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓███▓███████████████▓█████████▓█▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓███▓░░░░░░░
▓▓▓▒▒░▓███████████▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓███▓██████████████████▓████████▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓███▓░░░░
░░░░░░░░░░░▒▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█████▓█████████████████████████████▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓█▓▓████▓
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓██▓▓▓████████████████████████████▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓█▓▓▓░░░▒▒
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓████████████████████████████▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓█▓▓▓▓▓
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓█▓▓▓▓░▓████████████████████████████▓▓▓██▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▒▒▒▒
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓█▓░░▓██████████████▓███████████▓▓█████▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓█▓▓▓▓░░▓██████████████▓▓█████████▓▓▓▓████▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓█▒░░▓██▓▓▓████████████████████▓██▓▓▓▓█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓█▓▓▓▓░░▒███▓▓▓▓▓████████████████████▓▓▓▓█▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓█▓▓▒░▓███████▓▓█████████████████████▓▓▓█▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█▓▓▓▓▓░░████████████████████████████▓▓██▓▓██▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓░░░░▒███████████████████████▓▓▓▓███▓▓█▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█▓▓▓░░░░░░░███▓█▓█▓█████████████▓▓▓▓▓▓▓▓██▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓░░░░░░▓█████▓▓▓▓█████████████████████▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓█▓▓░░░░░░▓▓▓▓▓▓▓▓█▓▓████▓▓▓███████████▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓░░░░░░░▓███████████████▓▓██████████▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░█▓▓▓▓▓░░░░░░░░▓███████████▓▓█▓▓██████▓▓▓██▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓█▓▓▓▓▓▒░░░░░░▓▓███████████▓▓█▓▓██▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓░░▒▒▓███▓▓▓▓▓▓░░░░░▒▓▓████████████▓▓██▓▓▓▓▓▓▓▓▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓░░▓░▓▓▓▓▓▓▓▓▓▓▓░░░░▓▓███▓▓▓▓▓▓▓▓███▓███▓█▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▒▓░░▓▓▓▓▓▓░░▒▓▓░░░▓██▓▓▓▓▓▓▓▓▓▓▓▓█████▓█▓████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▒░░▒█▓▓▓░░░░░░▒░░░░█▓▓▓▓▓▓▓▓▓▓█▓▓██████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▒░░░▓▓▓▓▒░░░░░░░░░░░░▒▓█▓▓▓▓█▓▓▓█████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓░░░░▓▓▓▓░░░░░░░░░░░░░░░▒████████████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▓░░░░▒▓▓▓▓░░░░░░░░░░░░░░░░▓███████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▓▒░░░░▓▓▓▓░░░░░░░░░░░░░░░░░░████████▓█████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▓░░░░░▓▓▓▒░░░░░░░░░░░░░░░░░░░████████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓░░░░░░▓▓▓░░░░░░░░░░░░░░░░░░░░▒███████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░▒▓▒░░░░░░░░░░░░░░░░░░░░▒█████████▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██▓██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    break;
                case Fiddlesticks fiddlesticks:
                    Console.WriteLine(@"
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▒▓█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓██▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓██▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒░░░░░░▒▓████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓██▓▓▒░░░░▒▓████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒░░▒▓▓███▒░░░░▒█████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▒░░░▓█████▓▒░▒████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██▒░░▒█████▓▒▓████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██▓░░▒█████▒▓████▒░▒░░░░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒░░░░▒██▓░░▒████▓▓████▒░▒▒░░░░░░▒▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒████▓▒▒▒███▓░▒▓█████████░░▒▒░░░▒▓▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒░▓▓▓████████████████████▒░░░▒▒▓▓███▓░░░░▒▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░▒██████████████▒░░▒▓██████▓▓▓▓▓▓██████▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░▒▓█████▓████▓▓██▒▓██████████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▒▒▒░░░░░▒▒▒▒░░░░▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▓▒▒▒▓████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▒▒▓▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▒▒▓▓▒▒▒▒▒██████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▒▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓██▓▓▓██████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓███████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▒▒▓▓▓█▓███████████████▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▓▓▓▓▓▓▓▓▓█████▓▒▒▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▓▓▓▓██████████████▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▒▒██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓███████▓█████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▒▒▒▒▒▒▓▓████▓▒░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▒▒▓▓▒░▒▒░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▒░░░░░▓▓▓▓▓▓█████▓▓▓▓▓▓▓▓██▓▓█▓▓▓▓▓▓▓▓███▓▒▒█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓█▓░░░░░▓█▓▓▓▓█████▓▓▓▓▓▓▓▓▓▓▓▓▓███▓▓▓▓▓▓▓▓▓▒░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▒░░▓█▒░░░▒██▓▓████████▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓░░░░░▓█▓▓▒▓████████████▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████▓██▓▒▒░░░░░░░▓████████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░███████▓▒░░░░░░░░░░░▒▒▓██████████████▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░▓██████▒▒▓█▓███▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██▓█▓▓▓▓▒░░░░░░░░░░░░░░░▒▓██████▓▓█████▒░▒▓▓██▓▒▒▓▓▓▓▓▓▓█▓▓▓▓███▓▓▒░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓████████▓░░░░░░░░░░░░░░▒▓███▓███████████▓▒░▒▓██░░░░░▒▓▓▓▓▓▓▓▓██▓█████▓▓▒▒▒▓███▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓███████▓▒░░░░░░░░░░░░░▒███████████▓████▓▓▓▒▒▒▓█░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▒▒▒▓▓██▓▓████▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓████▓▓▒░░░░░░░░░░░░▒▓████████▓▓▓█████████▓▓▓█▓▒▒░░░░░░░░░░░░░░░░░░░░░░▒▒▓██▓████▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░▒▓██████▓▓▒░░░░░░░░░░░░░▒▓█████████████████████████▓███▓▒░░░░░░░░░░░░░░░░░░░░░░░░▓▓███████▓▓▓▓▒░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░▒▓███████▒░░░░░░░░░░░░░░▓█████████████████████████████████▒░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓██▓▓███▓▓▓▓▒▒▒▒▒░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▒▓██████▓░░░░░░░░░░░░░░░▒████████▓███▓▒▓█████████▓▓▓▓███████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓████▓▓▓▓█▓▓▓▓▒░░░░░░░░░
░░░░░░░░░░░░░░░░░░▓▓▓█████▓░░░░░░░░░░░░░░░░▓████████▓░░░░░░░▒▓███▓▒░░░░░░░▒███████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓██▓▓▓▓▒░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░▓██████▓▒░░░░░░░░░░░░░░░▒▓▒▒█████▓▓▒░░░░░░░░░░░░░░░░░░░░░░░███████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓█▓▓▓▒░░░░░░░░░░░
░░░░░░░░░░░░░░░░▓██████▒░░░░░░░░░░░░░░░░▒▓▒▓████▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░▓███████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██▓▓▓▓▒░░░░░░░░
░░░░░░░░░░░░░░░▓█████▓▒░░░░░░░░░░░░░░░▒▓▒▒▓██▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▒▒░░▓██▓▓▓▓▒░░░░░░
░░░░░░░░░░░░░░▓████▓▒░░░░░░░░░░░░░░░░▒▓▒▓███▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██▓▒▓███▓▓▓▒░░░░
░░░░░░░░░░░░░▒████▓▒░░░░░░░░░░░░░░░▒▓▓▓███▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███████▓▓▓▒░░
░░░░░░░░░░░░░▓███▓▒░░░░░░░░░░░░░░▓███████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓█████▓▓▓░
░░░░░░░░░░░░▒████▓░░░░▓▓▒░░░░░░▒████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒████▓▓
░░░░░░░▒▒░░▒▓███▓░░▓███▓▒▒░▒████████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒██████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓
░░▒▓▓▓▒███▒▓█████▒▒█████████████████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▒███▓▓█████████████▓▓▓▒▒▓▓▓▓▓▓███████▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
██████████▓▒▓██████▓▒▓░░░░░░░░▒███████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
███████████▓████████▓▒░░░░░░░░░░▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
█████████████████▓▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▒░░▓████████▓▒▓▓▒░▒██▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░▒███▓▒▒▒▒▒░░░░░░▒▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███▓▒▓█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██▓▒▒▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▒▒▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    break;
                case Warwick warwick:
                    Console.WriteLine(@"
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▒▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▓██▓▒░░░░░░░░░░░░░░░░▒█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░▒▓██▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓█▓▓▓▓██▓▓▓▓▒▒░░░░░░░░░▒▓███▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▒▒░░░░▒▓▓███▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓█████▓▓▓▓▓▓▓▓▓░░░▒▓███▓█▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓█▓▓▓▓▒▒▒▓▓▓▓▓▓▓▓▒░▒▓████▓█▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▒▒▒▒▒▓▓▓▓▓▒░▒▓▓████▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▒▒▒▒▒▓▓▓▓░▒▓▓▓▓██▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░▒▓▓▓▒▒▒▒▓▓▓▓▒▒▓▓████▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░▓█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▒▒▒▓▓▒▒▓▓▓█████▓▓▓███▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░▒██▓▓▒░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓███▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░▒███▓▓▓▒░░░░░░░░░░░░░░░▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░▒▓▓██▓▓▓▓▒░░░░░░░░░░▒▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓████▓▓▓▓█▓▓▓▓██▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▓▓▓██▓▓▓▓▓▒▒▒░░░▒▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▓▓▓▓▓▓▓▓▓▓▓▓█▓▒▒▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░▓▓▓▓██▓▓▓▓▓▓▓▓▒▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▓▓▓▓█▓▓▓▓▓▓██▓▓▓▓▓▓▓█▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓███▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▓▓▒▒▒▓▓▓▓▓▓████▓▓▓████▓▓▓█▓▓▓▓▓▓▓██▓▓▓█▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▒▒▒▒▒▓▓▓▓███████████▓███▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓███▓▓▓▓▓▒▒▓▓▓██▓▓▓▓▓▓▒▒▓▓▓▓█▓███████████▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓████▓▓▒▒▒▒▒▓█▓▓███▓▓▓▓▓██▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓██▓█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓████████▓▒▓█▓▓▓▓▓▓▓▓▒▓▓▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓█▓▓▓▓███▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓█▓▓███▓▓▓▓█▓▒▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓██▓▓▓▓▓█▓▓████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒██████▓▓▒▒▒▓████▓▓▒▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓████▓▓██▓▓▓████████▓█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▓▓▒▒▓███▓▒▒▒▒▒▓▓████▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████████████████████▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▓██▓████▓▓▓▓▓▓▓▓▒▒▓██▓▒▓▓████████▓▓█████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████████████████████▓▓▓▓▓██▓▓▒░▒▒░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░▒█▓███████▓▓▓▓▓▓▓▓▓▓▓██▓██▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████████████████████▓▓▓▒░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░▒▒▒▒░░▒█▓███████▓▓▓▓▓▓▓▓▓▓██▓▓▓▒▓▒▓▓▓▒▓▓▓▒▒█████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████████████████████████████████▓▓▓▓▓▒▒▒▒░░░░░░░░░░░░░
░░░░░░░░░░░░▒▓▓▓▓▒▒▓███████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▒▒▒▒▒▓▓▓▓▓▒▒▒███▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████████████████████████▓▓▓▒▒▓▓▒░░░░░░░░░░░░
░░░░░░░░░░░▒▓▓▓███▓█████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓█▒▓▓▓▓▓▓▓▓▓▒▒▒█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████████████████████████████████▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░
░░░░░░░░░░▒▓▓████▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒█▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▒░░░▒▓██████████████████████▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░
░░░░░░░░░▒▓▓▓▓████████████████▓▓▓▓▓▓▓▓▓▓▓█▓▒▓▓▓▓▓▓▓▓▓█▓▒▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▒░░░░░░░░▒▒██████████████▓▓▓▓▓▒▓▓█▓▓▓▓▓▓▒░░░░░░░░░
░░░░░░░░▒▓▓▓▓█████████████████▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓░░░░░░░░░░░▓███████████▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▒▒
░░░░░░░▒▓▓▓▓▓█████████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▒▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░▒████████▓▓▓▓▓███▓▓▓▓▓▓▓▓███████████▓▓▓
░░░░░░░▓▓▓▓▓██████████████████▓█▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░▒███████▓███▓▓█████▓▓▓▓▓▓███▓▓▓▒▒▒▒▒▒░
░░░░░░▒▓▓▓█████████████████████▓░░░░░░▒▓▓▓▓▓▓█████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░▒███████████▓▓██▓▓▓▓▓▓▓▓▓███▓▓░░░░░░░
░░░░░░░▒███████████████████████▒░░░░░░░▒▓▓▓▓▓▓▓███████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░▒████████████▓▓▓▓▓▓▓▓▓▓█▓▓██▓▓▒░░░░░░
░░░░░░░░▓▓███▓████████████████▓░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░▒▓██████████▓▓▓▓▓████▓▓▓▓▓▓██▓▒░░░░░░
░░░░░░░▒▓▓██▓▓▓▓▓▓▓██████████▒░░░░░░░░░░░░░▒▒▒▒▓▓▓▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▒░░░░░░░░░░░░░░░░░░░░░▒▓████████▓█████▓▓▓▓▓▓▓▓▓▓█▓▓▒░░░░░
░░░░░░▒▓▓██▓▓▓▓▓▓▓▓▓▓▓███████▓░░░░░░░░░░░░░░░░░░▒▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░▓████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░
░░░░▒▓▓▓▓██▓▓▓▓▓▓▓▓███████▓▓▒░░░░░░░░░░░░░░░░░░░░▓▓▓▓▒▒▓▓▓▓█▓███████▓▓▓▓▓▓█▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓█████▓██████████████▓▓▓▒░░░░
░░░░▓█▓▓▓█▓▓▓▓▓▓▓▓███████▓▓▒░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓███████████████▓▓▓▓▓▓█▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██████████████████▓▓▒░░░░░
▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓███████▓▓▒░░░░░▒█▒░░░░░░░░░░░░░░▒▓▓▓▓███████████████▓▓▓▓▓▓█████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██████▓▓▓▓▓▓█▓▓▓▒░░░░░░
▒▓▓▓▓▓▓███▓▓▓▓▓▓▓▓██████▓▒░░░░░░▒███▓▒░░░░░░▒▓█████▓▓▓███████████████▓▓▓▓██████████▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██████▓▓▓▓▓▓▓▓▓▓▓▒░░░░░
▒▓▓▓▓▓▓█████▓▓▓▓▓█████▓▓▒░░░░░░░▒██████▓▒▒▓███████████████████████████▓▓█████▓██▓▓▓▓███▓▒░░░░░░░░░░░░░░░░░░░░░▒████████████▓▓▓▓▓▓█▒░░░░░
░▒▓▓▓▓▓▓▓██████████▓▓▓▓▒░░░░░░░░▓█████████████████████████████████████████████▓▓██▓██████▓▒░░░░░░░░░░░░░░░░░░▓████████████████▓▓▓█▒░░░░░
░░▓▓▓▓▓▓▓▓▓█████████▒░░░░░░░░░░░▒████████████████████████████████████████████▓▓▓▓█████████▓▒░░░░░░░░░░░░░░░▒▓▓▓████████▓▓██▓█▓▓▓█▓▓░░░░░
░░▒▓▓▓██████████████▒░░░░░░░░░░░░███████████████████████████████████████████▓▓▓▓████████████▒░░░░░░░░░░░░░▒█████████████▓██▓▓▓▓▓▓▓▓▒░░░░
░░▒▓▓▓▓▓▓▓██████████▓▒░░░░░░░░░░░▓██████████████████████████████████████████▓██▓▓███████████▓░░░░░░░░░░░░░▒██████▓▒▒▓██████▓▓█▓▓▓▓▓▓▒░░░
░░▒▓▓▓▓▓▓▓████████████▒░░░░░░░░░▒▓▓██████████████████████████████████████████████████████████▒░░░░░░░░░░░░▒███████▒░▒██████▓███▓▓▓█▓▓▒░░
░▒▓▓▓▓▓▓▓▓██████▓██████▒░░░░░░░▒██▓▓▓██████████████████████████████████████████████████████████▒░░░░░░░░░░▒██████▒░░▒▓████▓▓▓███▓▓██▓▓░░
░▒▓█▓██▓▓██████▒▒██████▓░░░░░░▒██▓▓██▓█████████████████████████████████████████████████████▒░▒▓▒░░░░░░░░░░░▓███▒▒░░░░▒████████████████▓░
░▒████████████▓░░▒███▓▓▒░░░░░░▒████▓▓▓▓██████████████████████████████████████████████████████▒░░░░░░░░░░░░░░▒██░░░░░░░▓███████████████▒░
░▒██▓██████████▓░░▒▓▓▓▒░░░░░░░▒████▓██████████████████████████████████████████████████████████▓▒░░░░░░░░░░░░░░░░░░░░░░▒██████████████▓▒░
░▓██████████████▓▓▓▓▓▓▒░░░░░░░▓█████████████████████████████████████████████████████████████████▒░░░░░░░░░░░░░░░░░░░░░░▒██████████▓▓█▓▓▒
▒▓██▓███████▓▓███▓▓▓▓▓░░░░░░░▓██████████████████████████████████████████████████████████████████▓░░░░░░░░░░░░░░░░░░░░░░░▓█████████▓▓▓█▓▒
▒███████████▓▓▓▒▓▓▓▓▓▒░░░░░░▓██████████████████████████████████████████████████████████████████▓░░░░░░░░░░░░░░░░░░░░░░░▓███████████████▒
▒▓▓███████████████▓▓▒░░░░░░░▓██████████████████████████████████████████████████████████████████▒░░░░░░░░░░░░░░░░░░░░░░▒▓███████████████▒
░▒▓█████████▓▓█▓▓▓▓▓▒░░░░░░░▒▓████████████████▒▓████████████████████████████████████████████████▒░░░░░░░░░░░░░░░░░░░░░▒████████████████▒
░░░▒▓████████▓████▓▒░░░░░░░░░░▒▓███████████▓▒░░░░▒▓████████████████████████▒▒░▒▓████████████████▓▒░░░░░░░░░░░░░░░░░░░░▒▓██████████████▒░
░░░░░▒▒▓▓█████▓▓▓▓▓▒░░░░░░░░▒▓███████████▓▒░░░░░░░░░░░▒▓▓██████████████▓▓▒░░░░░░░░░▒▓████████████▒░░░░░░░░░░░░░░░░░░░░░▒████▓░▒█████▓▒░░
░░░░░░░░▒▓▓▓█████▓▒░░░░░▒▒▒▓███████████▓░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░▒██████████▓░░░░░░░░░░░░░░░░░░░░░▒██▓▒░░░▓███▓░░░░
░░░░░░░░░░▒▒▓▓▓▓▒░░░░▒▓███████████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██████████▒░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░▒██▓▒░░░░░
░░░░░░░░░░░░░░░░░░░▒▓█████████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒██████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░▒███████████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░▓██████████████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░▒▓█▓████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░▒▒░▓█▒▒██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓███████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░▒▓░░▒██▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒██████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    break;
                case Cho_gath choGath:
                    Console.WriteLine(@"
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▓▓▓▓▓█▓▓▓▓▓▓▓▓█▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░▒▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▓░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░▒▒▒▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░
░░░░░░░░░░▓▓▓█▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓░▒▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░▓▓▓▓▓██▓▓▓▓▓░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░
░░░░░░░░░░░░░▓▓▓▓▓███▓▓▒░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓███████████▓▓▓▓████████░░░░░░░░░░░░░
░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓▓███████▓▓█▓█████████████▓░░░░░░░░░░░
░░░░░░░░░░░░░▒██▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓████████▓▓▓▓▒░▒▓▓▓████████▓░░░░░░░░░
░░░░░░░░░░░░░█████▓▓▓▓█▓░░░░░░░░░░░░░░░▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒███▓█████▓░░░░░░░░░░▓█▓███▓▓▓▓▓░░░░░░░░
░░░░░░░░░░░░▓█▓████████▒░░░░░░░░░░░░░░▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒███████▓░░░░░░░░░░░░░░░▓▓████▓▓▓▓░░░░░░
░░░░░░░░░░░▓███▓███████▒░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓███░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓░░░░░
░░░░░░░░░░░█████▓██████▒░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░█▓▓▒░░░░
░░░░░░░░░░▓█████▓██▓▓██▒░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓███▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓░░░
░░░░░░░░░░██████▓▓██▓█▓▒░░░░░░░░░░▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓███▓█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓░░
░░░░░░░░░░███████▓▓█▓▓▓░░░░░░░░░░░░█▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓█▓▓█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓░
░░░░░░░░░░███████▓▓▓▓▓▓░░░░░░░░░░░░░█▓█▓▓▓▓▓▓▓█▓▓▓▓▓▓▓█▓██▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓
░░░░░░░░░░▓██████▓▓▓▓▓▓░░░░░░░░░░░░░▓██▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░▓▒▒▒░▓█████▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓██▓▓█▓████▒░░░░░░░░░░░░░░░░░░▓▓███████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░▓█▓▓▓▓▓▓▓▓▒████▓▓▒▓▓███████▓▓████████▓▓▓▓▓▓▓▓▓▓▓▓▓████████▓▓▓▓▓▓░░░░░░░░░░░░░░░▓▓███████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░▓▓█▓███▓▓▓▓▓░███▓▓▒▓▓██▓▓▓▓█▓▓█████████▓▓▓▓▓▓▓▓▓▓▓▓█▓██▓▓▓██▓▓▓▓▓▓█▓▓▓░░░░░░░░░░▓▓█████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░▓▓▓█▓▓▓█▓▓█▓░▓█▓▓▒▓██▓▓███▒░██████████▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓▓█▓▓███▓▓▓▓▒░░░░▒████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░▓▓▓▓▓▓█▓▓██░░▒█▓▒░░░░░░░░░░░░░▓██████▓▓▓▓▓▓▓▓▓▓▓████▓███▓▓▓███▓▓▓▓██████▓▓▓▓██▓▓████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░▓█▓▓▓▓█▓███▒▓░▓▒░░░░░░░░░░░░░░░▒████▓▓███▓█▓▓▓▓▓██▓█▓▓██▓▓▓▓▓▓▓███████████▓▓█▓▓▓█▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░██▓██████▓▓▓▒░▒░░░░░░░░░░░░░░░░▓███▓▓▓▓▓▓▓▓▓█▓████████████████████████████▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░███████▓▓██▓░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████████████████████░░░▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▓███████████▓▒░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▓▓███████▓▓▓█░░░░▓░░░░░▓█▓▓▓░▒▓▓▓▓▓▓▓▓▓▓▓▓░░░▓▓▓▓▓██▓▓█▓▓▓▓▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░▒▓████████▓▓░░▓▓▓▓▓▓▓▓▓▓██▓▓░░▓▓▓▓▓▓▓▓▓░░▒▓▓▒▓██████▓▓▓▓█▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▓▓▒▒▓███████▓▓▓▓▓▓▓█▓▓▓███░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓█████▓██▓▓█▓██▓▓▓░░░░░░░▓░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓█▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▒▓▓█▓▓▓▓▓▓███▓▓▓▓▓▓▓███▓░░░░░▒░▒▓▓▓▓▓▓▓▒▒▒▒▓▒▓████████▓░░▓████▓▓▓▓▓▓░▓▒░▓▓▓░░░░░░░░░░░░░░░░░▓██▓▓▓▓▓▓▓▓█▓▒░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░▓▓█▓█▓█▓██▓▓▓▓▓█▓█▓▓▓▓▓█▓░░░░░░░░░▒▒░▓▓▓▓█▓████████▒░░░▓▓▓██▓▒▓▓▓▓█▓▓█▓▓▓▓▓░░░░░░░░░░░░▒▓▓███▓▓▓██▓█▓▓▓█▓▒░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░▓▓███▓▓█████████░░░▒▓▒▒▓▓░░░░░▒██▓▓▓▓▓▓▓▓▒░░░░░░░▒▓▓▓▓▓███▓▓█▓▓░░░▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░▓▓▓▓██▓▓▓▓▓░░▒▒▒▒░░░░░░░░░░░░░░░░▓▓▓▓▓▒▓██████▓░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▓▓█▓▓▓▓▓▓█████▓░░░░░░▓▓▓░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░▓▓▓▓▓██▓▓░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓░░░▒█▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓████░░░░░░░░▒▓░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓██▓░░░▒▓▓▓░░░░▒██████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓████▓▓██████▓░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓██▓▓█▓▓▒░▒▓▒▒▒▓████████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░█▓▓██████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓█████████▓█████▓▓██▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓██▓▓▓█▓█████▓▓▓▓██████████████▓▓██▓▓▓▓▓█░░░░░░░░░░░░░░░░░░░░░▒████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓▓▓▓▓▓███▓████████▓████████████████▓▓▓▓▓▓▓▓██▓▓░░░░░░░░░░░░░░░░░░░█████▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓▓▓▓▓▓▓██████████████████████████████▓▓▓███▓▓▓▓▓░░░░░░░░░░░░░░░░░░░▒██▓▓██▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░█▓██▓▓▓██████████████████████████████████████▓▓▓▓▓░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓██████▓████████████████████████████░░░█████▓▓▓█▓░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░▓░▓▓▓▓▓▓▓███▓█▓█████████████████████████▓░░░░░░░███████▓▓▓▓░▒▒░░░░░░░░░░░░░▓▓█▓▓▓▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░█▓▓▓▓▓▓█████░░░▓█████████████████████░░░░░░░░░░░░░░░▓███████▓▓█▓▒░░░░░░░░░░░░░▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░▒▓▓██▓███▓▓▓▓▓▓█▒░░░░▓████████████████████░░░░░░░░░░░░░░░░░░░▒█████▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░███▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▓██████████████████░░░░░░░░░░░▒▓▓▓▓▓████████▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓██▓░░░░░███████████████░░░░░░░░░░░░░▓▓▓▓▓▓█████████▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓████▓█░░░░░░░░███████████░░░░░░░░░░░░░░░░▓██████████▓▓████▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓████░░░░░░░░░░░▓█▓▒░░░░░░░░░░░░░░░░░░░░░▓███░░░░░░▓██████▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓███▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████░░░░░░░░▒███▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░▓▓████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓██████░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓█████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░▓██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓█████████░░░░░░░░░░░░░░░░░░▒▓█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░▓▓█▒░░░░░▓▒░▓███▓███▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓░░▓███████░░▒▓░░█▓▓░░░░▓████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░▓▓████▓░░█▓█▓▓████▓███▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓░░░░░░░░██████▓███▓██████████▓███████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░▓▓▓█▓██████████████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░██████████████████████▓███████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░▓███████████████▓▓██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒███████████████████████▓██████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░▓▓▓██▓▓███████▓█▓████████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒██████████████████████▓▒░░████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░▓▓▓▓██████████▓██▓███████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█████████████░░░░░░░▓▓▓░░░░▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░▓▓██▓░░░░░▒▒▓▓█▓█▓███████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░▓█▓░░░░░░░░░░▓█▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    break;
            }
        }
    }
}