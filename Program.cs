using System;

namespace TaskJunior2._11
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandCreatureRayOfLight = "1";
            const string CommandMeteorSummoning = "2";
            const string CommandSacrificeASoulForGod = "3";
            const string CommandCreatureDivineShield = "4";

            int healthHero = 100;
            int healthEnemy = 1000;
            int damageEnemy = 30;

            int rayOfLight = 100;
            int meteor = 500;
            int soulForGod = 20;
            int divineShield = 10;
            int triesCount = 3;

            string userInput;

            bool spellMetior = false;

            Console.WriteLine("Вы - единственный герой, который должен спасти этот мир.\n" +
                              "Перед вами Властелин тьмы и на вас лежит ответственнось за всё человечество!\n" +
                              "Вы всю свою жалкую жизнь готовились к этому событию.\n" +
                              "В вашем арсенале есть 4 заклинаня. Используйте их с умом!\n");
            Console.WriteLine($"Ваше здоровье - {healthHero}. Здоровье Властелина тьмы - {healthEnemy}.");

            while (healthHero > 0 && healthEnemy > 0)
            {
                Console.WriteLine("\nВаши заклинания: \n" +
                                 $"{CommandCreatureRayOfLight}. Луч света - Вы создаете Луч света, который наносит {rayOfLight} урона.\n" +
                                 $"{CommandMeteorSummoning}. Метиор - Вы призываете Метеор, который наносит {meteor} урона.\n" +
                                 $"Но для этого заклинания нужно выполнить заклинание 'Душа бога'.\n" +
                                 $"{CommandSacrificeASoulForGod}. Душа бога - Вы приносите в жертву часть своей души, вам нанесется {soulForGod} урона.\n" +
                                 $"{CommandCreatureDivineShield}. Божественный щит - Вы создаете божественный щит и лечите себя {divineShield} здоровья.\nНо у вас в запасе только {triesCount} щита");
                WriteError("\n\n**********БОЙ**********\n");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandCreatureRayOfLight:
                        healthEnemy -= rayOfLight;
                        healthHero -= damageEnemy;

                        Console.WriteLine("По воле божей у вас получилось создать ЛУЧ СВЕТА и направить его на Владыку тьмы.\n" +
                                         $"Вы нанесли {rayOfLight} урона.\n");
                        break;

                    case CommandMeteorSummoning:
                        if (spellMetior == true)
                        {
                            healthEnemy -= meteor;
                            healthHero -= damageEnemy;

                            Console.WriteLine("По воле божей у вас получилось призвать Метеор и направить его на Владыку тьмы.\n" +
                                             $"Вы нанесли метеором - {meteor} урона.\n");
                        }
                        else
                        {
                            Console.WriteLine("Боги не готовы даровать вам метеор. Готовтесь поплатиться за ошибку");
                            healthHero -= damageEnemy;
                        }
                        spellMetior = false;
                        break;

                    case CommandSacrificeASoulForGod:
                        healthHero -= soulForGod;
                        healthHero -= damageEnemy;
                        spellMetior = true;

                        Console.WriteLine("Вы пожертвовали частью вашей души.\n");
                        Console.WriteLine($"Вы теряете {soulForGod} здоровья.\n");
                        break;

                    case CommandCreatureDivineShield:
                        if (triesCount > 0)
                        {
                            triesCount -= 1;
                            Console.WriteLine($"Вы создали божественный щит и восстанавливаете здоровье. Щитов в запасе - {triesCount}.");
                            healthHero += divineShield;
                        }
                        else
                        {
                            Console.WriteLine("Увы но щиты закончились вы пропускаете свой ход.");
                            healthHero -= damageEnemy;
                        }
                        break;

                    default:
                        Console.WriteLine("Владыка тьмы видемо одурманил вас, так как вы пытались сотворить заклинание,\n" +
                                          "которого не знаете.");
                        healthHero -= damageEnemy;
                        break;
                }

                WriteError($"Владыка демонов нанес по вам {damageEnemy} урона.");
                WriteError($"Ваше здоровье - {healthHero}.", ConsoleColor.Green);
                WriteError($"Здоровье Властелина тьмы - {healthEnemy}.", ConsoleColor.DarkBlue);
            }

            if (healthHero <= 0 && healthEnemy <= 0)
            {
                WriteError("Ничья, зато человечество выжило.", ConsoleColor.Yellow);
            }
            else if (healthHero <= 0)
            {
                WriteError("Жалкий герой погиб, все человечество обречено(((");
            }
            else if (healthEnemy <= 0)
            {
                WriteError("Ураа, Великий из всех великих Героев победил жалкого Владыки тьмы.\n Возвысим БАЛТИКУ 7 за его победу!!!", ConsoleColor.Green);
            }
        }

        static void WriteError(string text, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defautColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = defautColor;
        }
    }
}

