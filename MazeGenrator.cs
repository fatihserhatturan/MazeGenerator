using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace MazeGenrator
{
    public partial class MazeGenrator : Form
    {
        public MazeGenrator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            singletoon singleton = singletoon.GetInstance();

            List<System.Windows.Forms.TextBox> textboxs = new List<TextBox>();
            

            int c = 0;
            int b = 0;


            string inc = textBox1.Text.ToString();
            string dec = textBox2.Text.ToString();
            int counter = Convert.ToInt32(inc) + 4;
            int counter2 = Convert.ToInt32(dec) + 4;
            singleton.textboxes = new System.Windows.Forms.TextBox[counter, counter2];

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter2; j++)
                {

                    TextBox newtext = new TextBox();
                    newtext.Location = new System.Drawing.Point(22 + (25 * c), 22 + (20 * b));
                    newtext.Size = new System.Drawing.Size(25, 25);
                    this.Controls.Add(newtext);
                   textboxs.Add(newtext);
                    singleton.textboxes[i, j] = newtext;
                    c++;
                }
                c = 0;
                b++;
            }
            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter2; j++)
                {

                    if (i % 2 == 0) { singleton.textboxes[i, j].BackColor = Color.Black; }
                    if (j % 2 == 0) { singleton.textboxes[i, j].BackColor = Color.Black; }
                    if (singleton.textboxes[i, j].BackColor != Color.Black) { singleton.textboxes[i, j].BackColor = Color.White; }
                    if (i == 0 || i == 1 || i == counter - 1 || i == counter - 2) { singleton.textboxes[i, j].BackColor = Color.Turquoise; }
                    if (j % counter2 == 0 || j % counter2 == 1 || j % counter2 == counter2 - 1 || j % counter2 == counter2 - 2) { singleton.textboxes[i, j].BackColor = Color.Turquoise; }
                }
            }

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter2; j++)
                {
                    if (singleton.textboxes[i, j].BackColor == Color.White) { singleton.counterBosluk++; }
                }
            }


            Random rnd = new Random();
            int counterBisque = 0;
            while (true)
            {

                int Random = rnd.Next(0, 4);

                if (singleton.counterBosluk == counterBisque) { break; }

                if (Random == 0)
                {
                    if (singleton.textboxes[singleton.i, singleton.j + 2].BackColor == Color.White || singleton.textboxes[singleton.i, singleton.j + 2].BackColor == Color.Bisque)
                    {
                        if (singleton.textboxes[singleton.i, singleton.j + 2].BackColor == Color.White)
                        {
                            singleton.textboxes[singleton.i, singleton.j + 1].BackColor = Color.Bisque;
                            singleton.textboxes[singleton.i, singleton.j + 2].BackColor = Color.Bisque;
                            singleton.j = singleton.j + 2; counterBisque++;
                        }
                        else { singleton.j = singleton.j + 2; }

                    }

                }
                if (Random == 1)
                {
                    if (singleton.textboxes[singleton.i, singleton.j - 2].BackColor == Color.White || singleton.textboxes[singleton.i, singleton.j - 2].BackColor == Color.Bisque)
                    {
                        if (singleton.textboxes[singleton.i, singleton.j - 2].BackColor == Color.White)
                        {
                            singleton.textboxes[singleton.i, singleton.j - 1].BackColor = Color.Bisque;
                            singleton.textboxes[singleton.i, singleton.j - 2].BackColor = Color.Bisque;
                            singleton.j = singleton.j - 2; counterBisque++;
                        }
                        else { singleton.j = singleton.j - 2; }

                    }

                }
                if (Random == 2)
                {
                    if (singleton.textboxes[singleton.i - 2, singleton.j].BackColor == Color.White || singleton.textboxes[singleton.i - 2, singleton.j].BackColor == Color.Bisque)
                    {
                        if (singleton.textboxes[singleton.i - 2, singleton.j].BackColor == Color.White)
                        {
                            singleton.textboxes[singleton.i - 1, singleton.j].BackColor = Color.Bisque;
                            singleton.textboxes[singleton.i - 2, singleton.j].BackColor = Color.Bisque;
                            singleton.i = singleton.i - 2; counterBisque++;
                        }
                        else { singleton.i = singleton.i - 2; }

                    }

                }
                if (Random == 3)
                {
                    if (singleton.textboxes[singleton.i + 2, singleton.j].BackColor == Color.White || singleton.textboxes[singleton.i + 2, singleton.j].BackColor == Color.Bisque)
                    {
                        if (singleton.textboxes[singleton.i + 2, singleton.j].BackColor == Color.White)
                        {
                            singleton.textboxes[singleton.i + 1, singleton.j].BackColor = Color.Bisque;
                            singleton.textboxes[singleton.i + 2, singleton.j].BackColor = Color.Bisque;
                            singleton.i = singleton.i + 2; counterBisque++;
                        }
                        else { singleton.i = singleton.i + 2; }

                    }
                }
            }

            Stack<TextBox> dügüm = new Stack<TextBox>();
            singleton.textboxes[counter - 4, counter2 - 4].BackColor = Color.Tomato;
            singleton.textboxes[3, 3].BackColor = Color.Violet;
            Random rnd2 = new Random();
            int sayyac = 0;
            int tutucu1 = 0, tutucu2 = 0, counter3 = 0;
            while (true)
            {


                for (int i = 0; i < counter; i++)
                {
                    for (int j = 0; j < counter2; j++)
                    {
                        if (singleton.textboxes[i, j].BackColor == Color.Tomato) { tutucu1 = i; tutucu2 = j; }
                    }
                }

                if (singleton.textboxes[tutucu1, tutucu2 + 1].BackColor == Color.Bisque || singleton.textboxes[tutucu1, tutucu2 + 1].BackColor == Color.Violet) { counter3++; }
                if (singleton.textboxes[tutucu1, tutucu2 - 1].BackColor == Color.Bisque || singleton.textboxes[tutucu1, tutucu2 - 1].BackColor == Color.Violet) { counter3++; }
                if (singleton.textboxes[tutucu1 - 1, tutucu2].BackColor == Color.Bisque || singleton.textboxes[tutucu1 - 1, tutucu2].BackColor == Color.Violet) { counter3++; }
                if (singleton.textboxes[tutucu1 + 1, tutucu2].BackColor == Color.Bisque || singleton.textboxes[tutucu1 + 1, tutucu2].BackColor == Color.Violet) { counter3++; }

                if (counter3 == 2)
                {
                    singleton.textboxes[tutucu1, tutucu2].BackColor = Color.Cyan;

                    dügüm.Push(singleton.textboxes[tutucu1, tutucu2]);

                }

                if (counter3 == 0)
                {
                    singleton.textboxes[tutucu1, tutucu2].BackColor = Color.Brown;
                    TextBox text;
                    text = dügüm.Pop();
                    sayyac++;
                    for (int i = 0; i < counter; i++)
                    {
                        for (int j = 0; j < counter2; j++)
                        {
                            if (singleton.textboxes[i, j] == text) { tutucu1 = i; tutucu2 = j; }
                        }
                    }
                }
                counter3 = 0;
                int Random = rnd2.Next(0, 4);
                //if (sayyac % 2 == 0) { MessageBox.Show(""); } 

                if (Random == 0)
                {
                    if (singleton.textboxes[tutucu1, tutucu2 + 1].BackColor == Color.Bisque || singleton.textboxes[tutucu1, tutucu2 + 1].BackColor == Color.Violet)
                    {
                        if (singleton.textboxes[tutucu1, tutucu2 + 1].BackColor == Color.Violet) { break; }
                        singleton.textboxes[tutucu1, tutucu2].BackColor = Color.Brown;
                        singleton.textboxes[tutucu1, tutucu2 + 1].BackColor = Color.Tomato;

                    }
                }
                if (Random == 1)
                {
                    if (singleton.textboxes[tutucu1, tutucu2 - 1].BackColor == Color.Violet || singleton.textboxes[tutucu1, tutucu2 - 1].BackColor == Color.Bisque)
                    {
                        if (singleton.textboxes[tutucu1, tutucu2 - 1].BackColor == Color.Violet) { break; }
                        singleton.textboxes[tutucu1, tutucu2].BackColor = Color.Brown;
                        singleton.textboxes[tutucu1, tutucu2 - 1].BackColor = Color.Tomato;

                    }
                }
                if (Random == 2)
                {
                    if (singleton.textboxes[tutucu1 - 1, tutucu2].BackColor == Color.Violet || singleton.textboxes[tutucu1 - 1, tutucu2].BackColor == Color.Bisque)
                    {
                        if (singleton.textboxes[tutucu1 - 1, tutucu2].BackColor == Color.Violet) { break; }
                        singleton.textboxes[tutucu1, tutucu2].BackColor = Color.Brown;
                        singleton.textboxes[tutucu1 - 1, tutucu2].BackColor = Color.Tomato;

                    }
                }
                if (Random == 3)
                {
                    if (singleton.textboxes[tutucu1 + 1, tutucu2].BackColor == Color.Bisque || singleton.textboxes[tutucu1 + 1, tutucu2].BackColor == Color.Violet)
                    {
                        if (singleton.textboxes[tutucu1 + 1, tutucu2].BackColor == Color.Violet) { break; }
                        singleton.textboxes[tutucu1, tutucu2].BackColor = Color.Brown;
                        singleton.textboxes[tutucu1 + 1, tutucu2].BackColor = Color.Tomato;

                    }

                }

            }

            Console.WriteLine(sayyac);
        }
    }
}
