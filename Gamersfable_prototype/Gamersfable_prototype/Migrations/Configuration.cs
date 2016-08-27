namespace Gamersfable_prototype.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // if the db is empty fill it up with sample data
            // for dev. purposes
            if (context.Users.Any() == false)
            {
                // Users
                CreateUser(context, "admin@gmail.com", "123", "System Administrator");
                CreateUser(context, "pesho@gmail.com", "123", "Peter Ivanov");
                CreateUser(context, "merry@gmail.com", "123", "Maria Petrova");
                CreateUser(context, "geshu@gmail.com", "123", "George Petrov");

                // Roles
                CreateRole(context, "Administrators");
                AddUserToRole(context, "admin@gmail.com", "Administrators");

                // Games
                CreateGame(context, "Diablo III", "A RPG hack n' slash game, where the user takes control over a hero to defy all evil.");
                CreateGame(context, "Starcraft", "Strategy game that supports both single and multiplayer.");
                CreateGame(context, "Dota 2", "The first MOBA type of game, where two teams compete inside an arena.");
                CreateGame(context, "SteamGame", "A famous platform for distributing and selling digital copies of games.");

                // Stories
                CreateStory(
                    context,
                    title: "Hack n' Slashen",
                    body: @"<p> Reaper of Souls is an expansion for Diablo III. It takes place shortly after the events of the original game, and features Malthael, former Archangel of Wisdom turned Angel of Death as its main antagonist.</p><p>In addition to a fifth Act, the expansion introduces the Crusader class, a remake of loot system and further additions to existing class skills. Reaper of Souls also offers greater end-game content, with non-linear gameplay in Adventurer Mode, constantly generated Bounty Missions and randomized dungeons known as Nephalem Rifts, all of which give better chances of tremendous loot.</p><p>Reaper of Souls can be purchased at the Blizzard Store for $39.99 US or $59.99 US for the Digital Deluxe edition, which offers bonus content.</p>",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "merry@gmail.com"
                    );

                CreateStory(
                    context,
                    title: "Strategy at its best",
                    body: @"<p>The StarCraft franchise is a series of real-time strategy (RTS) computer games developed by Blizzard Entertainment. It is similar to Blizzard's previous hit franchise, Warcraft, except that it has a space opera setting rather than a high fantasy setting. StarCraft was the best selling video game of 1998, and was so successful that Blizzard estimated in 2004 that 9.5 million copies had been sold since its release (4.5 million copies in South Korea), making it the third best-selling computer game in history.</p><p>StarCraft is praised for being a benchmark of RTS for its depth, intensity, and balanced races. The main storyline of the series revolves around a war between three galactic species: the protoss (a race of humanoid religious warriors), the zerg (vile insect-like aliens who share a hive mind) and the terrans (initially, descendants of human prisoners from Earth). The sequel, StarCraft II, is a trilogy with each ""chapter"" focusing on one of the three species.</p>",
                    date: new DateTime(2016, 05, 11, 08, 22, 03),
                    authorUsername: "merry@gmail.com"
                    );

                CreateStory(
                    context,
                    title: "The God of all games",
                    body: @"<p>Development of Dota 2 began in 2009 when IceFrog, lead designer of the original Defense of the Ancients mod, was hired by Valve for the same role. Dota 2 was officially released in July 2013, following a Windows-only open beta phase that began two years prior. The game initially used the original Source game engine until it was ported over to Source 2 in 2015, making it the first game to use it. The game also allows for the community to create custom game modes, maps, and cosmetics for the heroes, which are then uploaded to the Steam Workshop. Dota 2 is one of the most actively played games on Steam, with peaks of over a million concurrent players, and was praised by critics for its gameplay, production quality, and faithfulness to its predecessor, despite being criticized for its steep learning curve. The popularity of Dota 2 has led to official merchandise being produced for it, including apparel, accessories, and toys, as well as promotional tie-ins to other games and media.</p>",
                    date: new DateTime(2016, 04, 11, 19, 02, 05),
                    authorUsername: "geshu@gmail.com"
                    );

                CreateStory(
                    context,
                    title: "The God of all games",
                    body: @"<p>Steam is a digital distribution platform developed by Valve Corporation offering digital rights management (DRM), multiplayer gaming and social networking services. Steam provides the user with installation and automatic updating of games on multiple computers, and community features such as friends lists and groups, cloud saving, and in-game voice and chat functionality. The software provides a freely available application programming interface (API) called Steamworks, which developers can use to integrate many of Steam's functions into their products, including networking, matchmaking, in-game achievements, micro-transactions, and support for user-created content through Steam Workshop.</p>It supports a vast genre of games:<ul><li>Strategies</li><li>Action</li><li>Race</li><li>MMO</li></ul><p>Though initially developed for use on Microsoft Windows, versions for OS X and Linux operating systems were later released. Applications whose main functions are chatting and shopping have also been released for iOS, Android and Windows Phone mobile devices. The Steam website also replicates much of the storefront and social network features of the stand-alone application.</p>",
                    date: new DateTime(2016, 02, 18, 22, 14, 38),
                    authorUsername: "pesho@gmail.com"
                    );

                CreateStory(
                    context,
                    title: "Killed Diablo for the first time",
                    body: @"The Diablo Universe involves angels, demons, super humans, giant spiders, world-bearing dragons, an earth that shouldn't rightly exist, necromancy, shape shifting druids, maddened kings, and warring nations: getting lost in it can be easy. This article sums up the very basics of events in chronological order, starting from the very birth of reality and ending with what is known for fact. It also aims to summarize the most important facts that we know of regarding the backstory that will set the base for Diablo III.",
                    date: new DateTime(2016, 06, 30, 17, 36, 52),
                    authorUsername: "merry@gmail.com"
                    );


                context.SaveChanges();
            }
        }

        private void CreateUser(ApplicationDbContext context,
            string email, string password, string fullName)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreateStory(ApplicationDbContext context,
                                 string title,
                                 string body,
                                 DateTime date,
                                 string authorUsername)
        {
            var story = new Story();
            story.Title = title;
            story.Body = body;
            story.Date = date;
            story.Author = context.Users.Where(u => u.UserName == authorUsername).FirstOrDefault();
            context.StoriesLibrary.Add(story);
        }

        private void CreateGame(ApplicationDbContext context,
                                string title,
                                string description)
        {
            var game = new Game();
            game.Title = title;
            game.Description = description;
            context.GameLibrary.Add(game);
        }
    }
}
