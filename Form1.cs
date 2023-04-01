using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using WorkParser.Back.Services;
using System.Collections.Generic;
using WorkParser.Entity;
using System.Threading.Tasks;
using WorkParser.DataBase;

namespace WorkParser
{
    public partial class Form1 : Form
    {
       /// <summary>
       /// Виведення тексту
       /// </summary>
        private void Show(string text)
        {
            richTextBox1.AppendText(text + "\n");
        }
        private List<Vacancy> VacancyList = new List<Vacancy>();
        private List<Vacancy> temp = new List<Vacancy>();
        public Form1() { InitializeComponent();}

        private void Log_Enter(object sender, EventArgs e) { }


        /// <summary>
        /// Вивод інформації про поле
        /// </summary>

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Log.Text = $"Log [{richTextBox1.Lines.Count()}]";
        }

        /// <summary>
        /// Запустить парсер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void Start_Click(object sender, EventArgs e)
        {
            for (int j = 1; j < 28; j++)
            {
                string responce = WorkUa.GetPage("https://www.work.ua/jobs-it-it/?page="+j);
                 VacancyList.AddRange(WorkUa.ParsPage(responce));

                for (int i = 0; i < VacancyList.Count; i++)
                {
                    Show($"{VacancyList[i].Position}  {VacancyList[i].Salary}  {VacancyList[i].Company} {VacancyList[i].Details}");
                }
            }
            // Збеження в базу данних та сортування
            using (VacancyDbContext db = new VacancyDbContext())
            {
                var vac = new Vacancy();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                foreach (var model in VacancyList)
                {
                    if (model.Details.Contains("Неповна зайнятість"))
                    {
                        temp.AddRange(WorkUa.Add(model));
                    }
                    else
                    {
                        db.Vacances.AddRange(model);
                    }
                }
                foreach (var model in temp)
                {
                    db.Vacances.AddRange(model);
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Остановить парсер
        /// </summary>

        private void Form1_Load(object sender, EventArgs e) {}

        //Метод відбору вакансій з неповиним робочим днем
        private void Sort_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            using (VacancyDbContext db = new VacancyDbContext())
            {
                var vacancy = db.Vacances.ToList();
                
                foreach (Vacancy u in vacancy)
                {
                    if(u.Details.Contains("Неповна зайнятість"))
                    {
                        Show($"{u.Id} -- {u.Position} -- {u.Salary} -- {u.Company} -- {u.Details}");

                    }
                }
            }
        }
    }
}