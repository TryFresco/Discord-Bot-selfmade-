//Dateiname         Commands.cs
//Datum             25.02.2020
//Ersteller         Robin
//Version           1.0
//Änderungen        keine
//Beschreibung      Hier sind alle Commands, die im Dicord-Chat eingegeben werden können. 


using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Linq;
using System.Threading.Tasks;
using Discord;

namespace DiscordBot1.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {


        //Einfache Operatoren anwenden


        [Command("Rechnen")]
        public async Task Rechner(string was, double zahl1, double zahl2)
        {
            string wasC = "";
            string user = Context.Message.Author.Username;
            double Resultat = 0;

            switch (was)
            {
                case "Addieren":

                    Resultat = zahl1 + zahl2;
                    wasC = "addiert";

                    break;

                case "Subtrahieren":

                    Resultat = zahl1 - zahl2;
                    wasC = "subtrahiert";

                    break;

                case "Multiplizieren":

                    Resultat = zahl1 * zahl2;
                    wasC = "multipliziert";

                    break;

                case "Dividieren":

                    Resultat = zahl1 / zahl2;
                    wasC = "dividiert";

                    break;
            }

            await Context.Channel.SendMessageAsync("Das Resultat ist " + Resultat);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" hat gerade " + zahl1 + " und " + zahl2 + " " + wasC + ".");
            Console.ForegroundColor = ConsoleColor.White;
        }


        //mit Phytagoras rechnen


        [Command("Phytagoras")]
        public async Task Phytagoras(string Seiten, double Seite1, double Seite2)
        {
            string user = Context.Message.Author.Username;

            switch (Seiten)
            {
                case "ab":

                    double Seite1q = Seite1 * Seite1;
                    double Seite2q = Seite2 * Seite2;
                    double Quadrat = Seite1q + Seite2q;
                    double Ende = Math.Sqrt(Quadrat);
                    await Context.Channel.SendMessageAsync("Das Resultat ist " + Ende);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Der User ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(user);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" hat gerade Phytagoras mit den Seiten a und b angewendet");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                    

                case "ac":
                    double Seite1q2 = Seite1 * Seite1;
                    double Seite2q2 = Seite2 * Seite2;
                    double Quadrat2 = Seite2q2 - Seite1q2;
                    double Ende2 = Math.Sqrt(Quadrat2);
                    await Context.Channel.SendMessageAsync("Das Resultat ist " + Ende2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Der User ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(user);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" hat gerade Phytagoras mit den Seiten a und c angewendet");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "bc":
                    double Seite1q3 = Seite1 * Seite1;
                    double Seite2q3 = Seite2 * Seite2;
                    double Quadrat3 = Seite2q3 - Seite1q3;
                    double Ende3 = Math.Sqrt(Quadrat3);
                    await Context.Channel.SendMessageAsync("Das Resultat ist " + Ende3);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Der User ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(user);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" hat gerade Phytagoras mit den Seiten b und c angewendet");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
            }
        }


        //Die Fläche eines Rechtecks berechnen


        [Command("Fläche Rechteck")]
        public async Task Rechteck(double SeiteR1, double SeiteR2)
        {
            string user = Context.Message.Author.Username;
            double Fläche = SeiteR1 * SeiteR2;
            await Context.Channel.SendMessageAsync("Das Resultat ist " + Fläche);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" hat gerade die Fläche eines Rechtecks mit den Seitenlängen " + SeiteR1 + " und" + SeiteR2 + "ausgerechnet");
            Console.ForegroundColor = ConsoleColor.White;
        }


        //Hilfe und Commandliste


        [Command("Help")]
        public async Task HelpCommands()
        {
            string user = Context.Message.Author.Username ;
            await Context.Channel.SendMessageAsync("Beep. Ich rechne Ihnen alles aus, was Sie wollen. Sie müssen es mir nur richtig sagen. \r\n Dazu müssen Sie nur die richtigen Commands eingeben. \r\n Wenn Sie einen Überblick über alle Commands haben wollen, so geben Sie einfach [Command List] ein.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ist gerade hilflos.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        [Command("Command List")]
        public async Task CommandList()
        {

            string user = Context.Message.Author.Username;

            await Context.Channel.SendMessageAsync("Addieren/Subtrahieren/Multiplizieren/Dividieren: [Rechnen] + [<Operation>] + [<Zahl1>] + [<Zahl2>] \r\n");
            await Context.Channel.SendMessageAsync("Phytagoras: [Phytagoras] + [<Seitennamen, die eingegeben werden.(z.B. [ab])>] + [<Seite1>] + [<Seite2>] \r\n");
            await Context.Channel.SendMessageAsync("Fläche Rechteck: [Fläche Rechteck] + [<Seite1>] + [<Seite2>]");
            await Context.Channel.SendMessageAsync("Kreisumfang/Kreisfläche: [Was soll berechnet werden] + [<Radius>]");
            await Context.Channel.SendMessageAsync("Sektorfläche: [Sektorfläche] + [<Radius>] + [<Grad>] \nTemperaturumrechner: [c/f] + [to] + [f/c] + [<anzahl Grad>]");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" hat gerade Commands nachgeschaut");
            Console.ForegroundColor = ConsoleColor.White;

        }


        //Alles, was mit Pi zu tun hat


        [Command("Kreisumfang")]
        public async Task Kreisumfang(double radius)
        {

            string user = Context.Message.Author.Username;

            double kreisumfang = 2 * radius * Math.PI;
            await Context.Channel.SendMessageAsync("Das Resultat ist " + kreisumfang);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" hat gerade den Kreisumfang von " + radius + " berechnet.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        [Command("Kreisfläche")]
        public async Task Kreisfläche(double radius)
        {

            string user = Context.Message.Author.Username;

            double kreisfläche = radius * radius * Math.PI;
            await Context.Channel.SendMessageAsync("Das Resultat ist " + kreisfläche);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" hat gerade die Kreisfläche von " + radius + " berechnet.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        [Command("Sektorfläche")]
        public async Task Sektorfläche(double radius, double grad)
        {

            string user = Context.Message.Author.Username;

            double Sektorfläche = radius * radius * Math.PI / 360 * grad;
            await Context.Channel.SendMessageAsync("Das Resultat ist " + Sektorfläche);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" hat gerade die Sektorfläche von r = " + radius + " und " + grad + "°" + " berechnet.");
            Console.ForegroundColor = ConsoleColor.White;
        }


        //Temperatur umrechnen


        [Command("C to F")]
        public async Task Farrenheit(double celsius)
        {

            string user = Context.Message.Author.Username;

            double farrenheit = celsius * 1.8 + 32;
            await Context.Channel.SendMessageAsync(celsius + "° Celsius sind " + farrenheit + "° Fahrenheit.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" hat gerade " + celsius + "° C" + " zu Farrenheit umgerechnet");
            Console.ForegroundColor = ConsoleColor.White;
        }

        [Command("F to C")]
        public async Task Celsius(double farrenheit)
        {

            string user = Context.Message.Author.Username;

            double celsius = (farrenheit - 32) / 1.8;
            await Context.Channel.SendMessageAsync(farrenheit + "° Fahrenheit sind " + celsius + "° Celsius.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Der User ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" hat gerade " + farrenheit + "° F" + "zu Celsius umgerechnet");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
