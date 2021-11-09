using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_20211109
{
    public class Banka
    {
        public string jmeno;
        public float zustatek;
        public string cisloUctu;
        public int max = 200000;
        public int maxVyberZaTyden = 1000;
        public int maxPlatba = 5000;


        public Banka(string jmeno, float aktualniZustatek, string cisloUctu)
        {
            this.jmeno = jmeno;
            this.zustatek = aktualniZustatek;
            this.cisloUctu = cisloUctu;
        }
        public void Vklad(float vklad)
        {
            if (vklad + zustatek <= max)
            {
                zustatek += vklad;
                MessageBox.Show("Vložil jsi: " + vklad.ToString());
            }
            else if (vklad + zustatek >= max)
            {
                MessageBox.Show("Nejde vložit víc než je váš limit");
                MessageBox.Show("Váš limit: " + max);
            }
        }
        public void Vypis()
        {
            MessageBox.Show("Číslo účtu: " + cisloUctu + Environment.NewLine + "Aktuální zůstatek: " + zustatek + Environment.NewLine + "Týdenní limit: " + maxVyberZaTyden + Environment.NewLine + "Platební limit: " + maxPlatba);
        }

        public void Vyber(float vyber)
        {

            if (vyber - zustatek <= 0 && vyber <= maxVyberZaTyden)
            {
                zustatek -= vyber;
                MessageBox.Show("Vybral jsi: " + vyber.ToString());
            }
            else
            {
                MessageBox.Show("Nepodařilo se vybrat, překročil jsi svůj limit");
            }
        }
        public void Navyseni(int navyseni)
        {
            if (navyseni > maxVyberZaTyden)
            {
                maxVyberZaTyden = navyseni;
                MessageBox.Show("Vyběr se navýšil: " + maxVyberZaTyden);
            }
            if (navyseni < maxVyberZaTyden)
            {
                maxVyberZaTyden = navyseni;
                MessageBox.Show("Vyběr se zmenšil: " + maxVyberZaTyden);
            }
        }
        public void NavyseniPlatby(int navyseni)
        {
            if (navyseni > maxPlatba)
            {
                maxPlatba = navyseni;
                MessageBox.Show("Navýšili jste platební limit na: " + maxPlatba);
            }
            if (navyseni < maxPlatba)
            {
                maxPlatba = navyseni;
                MessageBox.Show("Zmenšili jste platební limit na: " + maxPlatba);
            }
        }
        public void Platba (float platba, string cisloUctu)
        {
            if (platba - zustatek <= 0 && platba <= maxPlatba)
            {
                zustatek -= platba;
                MessageBox.Show("Transakce byla provedena na číslo učtu: " + cisloUctu + " s částkou:" + platba);
                MessageBox.Show("Aktualní zůstatek na účtě: " + zustatek);
            }
            else if (platba - zustatek > 0)
            {
                MessageBox.Show("Nemáte dostatek peněz na provedení transakce");
            }
            else
            {
                MessageBox.Show("Nepodařilo se akci dokončit, došlo k překročení platebního limitu");
            }
        }
    }
}
