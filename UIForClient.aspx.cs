using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

namespace Taxes
{
    public partial class UIForClient : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            string month = string.Empty;
            LinkList<Person> people = new LinkList<Person>();
            LinkList<Tax> taxes = new LinkList<Tax>();
            LinkList<Person> filteredPeople = new LinkList<Person>();
            LinkList<Tax> filteredTaxes = new LinkList<Tax>();

            InOutUtils.ReadPeople(FileUpload1.PostedFile.InputStream, people);
            InOutUtils.ReadTax(FileUpload2.PostedFile.InputStream, taxes);
            TaskUtils allPeople = new TaskUtils(people);
            if (File.Exists(Server.MapPath("~/Required_Data/Rez.txt")))
                File.Delete(Server.MapPath("~/Required_Data/Rez.txt"));

            InOutUtils.PrintPeople<Person>(Server.MapPath("~/Required_Data/Rez.txt"), people, "Primary citizens' data");
            InOutUtils.PrintTax<Tax>(Server.MapPath("~/Required_Data/Rez.txt"), taxes, "Primary taxes' data");
            InsertCitizenData(people, Table1);
            InsertTaxData(taxes, Table2);

            if (people.Count() > 0 && taxes.Count() > 0)
            {

                filteredTaxes = allPeople.AllTheCheapestTaxes(ref month, taxes);
                InOutUtils.PrintTax<Tax>(Server.MapPath("~/Required_Data/Rez.txt"), filteredTaxes, month);
                Label5.Text = $"The cheapest month was {month.ToLower()}";
                InsertTaxData(filteredTaxes, Table3);


                double allTaxSum = allPeople.FindAllTaxSum(taxes);
                File.AppendAllText(Server.MapPath("~/Required_Data/Rez.txt"), $"The sum of all taxes was: {allTaxSum}\n\r");
                Label6.Text = $"The sum of all the paid taxes from all citizens: {allTaxSum}";

                filteredPeople = allPeople.AddWhoPaidLessThanAverage(taxes);
                filteredPeople.Sort();
                InOutUtils.PrintFiltered(Server.MapPath("~/Required_Data/Rez.txt"), filteredPeople, "People who paid less than the average in a year");
                InsertFilteredData(filteredPeople, Table4);

                allPeople.RemoveWhoDidntPayAtRequired(TextBox1.Text, TextBox2.Text, taxes);
                people.Sort();
                InOutUtils.PrintPeople<Person>(Server.MapPath("~/Required_Data/Rez.txt"), people, "Filtered citizens' data");
                InsertCitizenData(people, Table5);

            }
            else
            {
                File.AppendAllText(Server.MapPath("~/Required_Data/Rez.txt"), "One of the files was lacking information so it's imposible to do the required calculations");
                Label3.Text = "One of the files was lacking information so it's imposible to do the required calculations";
                Label4.Text = string.Empty;
                Table1.Rows.Clear();
                Table4.Rows.Clear();
            }
        }
    }
}