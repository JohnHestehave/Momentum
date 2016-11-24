using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Momentum
{
    public class Momentum
    {
		public void SaveData(string fornavn, string efternavn, string foedselsdato, string mail, string adresse, string postnr, string by, string tlf, string udloebsdato, string aarskorttype, string andet)
		{
			SQLSimplifier sql = new SQLSimplifier();
			sql.Connect("ealdb1.eal.local", "EJL34_DB", "ejl34_usr", "Baz1nga34");
			Dictionary<string, string> data = new Dictionary<string, string>();
			data.Add("Fornavn", adresse);
			data.Add("Efternavn", efternavn);
			data.Add("Foedselsdato", foedselsdato);
			data.Add("Mail", mail);
			data.Add("Adresse", adresse);
			data.Add("Postnr", postnr);
			data.Add("city", by);
			data.Add("Tlf", tlf);
			string today = Convert.ToDateTime(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
			data.Add("IndloestDato", today);
			//data.Add("KoebtDato", koebtdato);
			//data.Add("IndloestDato", indloestdato);
			data.Add("UdloebsDato", udloebsdato);
			data.Add("AarskortType", aarskorttype);
			data.Add("Andet", andet);
			sql.Insert("AarskortMomentum", data);
		}
		public void GetData()
		{
			SqlConnection sql = new SqlConnection("Data Source=ealdb1.eal.local;Initial Catalog=EJL34_DB;User ID=ejl34_usr;Password=Baz1nga34");
			try
			{
				Console.WriteLine("ok");
				SqlCommand cmd = new SqlCommand();
				SqlDataReader reader;
				cmd.CommandText = "SELECT ID, Fornavn, Efternavn, Foedselsdato, Mail, Adresse, Postnr, Tlf, KoebtDato, IndloestDato, UdloebsDato, AarskortType, Andet FROM AarskortMomentum";
				cmd.CommandType = CommandType.Text;
				cmd.Connection = sql;
				sql.Open();
				reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Console.WriteLine("ID: {0}; Fornavn: {1}; Efternavn: {2}; Foedselsdato: {3}; Mail: {4}; Adresse: {5}; Postnr: {6}; Tlf: {7}; KoebtDato: {8}; IndloestDato: {9}; UdloebsDato: {10}; AarskortType: {11}; Andet: {12};"
						, reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetValue(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetString(11), reader.GetString(12));
				}
				sql.Close();

			}
			catch (Exception e)
			{
				Console.WriteLine("error: " + e.Message);
			}
		}
		public void UpdateData(string data, string replace)
		{
			SqlConnection sql = new SqlConnection("Data Source=ealdb1.eal.local;Initial Catalog=EJL34_DB;User ID=ejl34_usr;Password=Baz1nga34");
			SqlCommand cmd = new SqlCommand("UPDATE AarskortMomentum SET '"+ data + "' WHERE '"+replace+"'", sql);
			cmd.ExecuteNonQuery();
		}

		public void DeleteData(string key, string value)
		{
			SqlConnection sql = new SqlConnection("Data Source=ealdb1.eal.local;Initial Catalog=EJL34_DB;User ID=ejl34_usr;Password=Baz1nga34");
			SqlCommand cmd = new SqlCommand("DELETE FROM AarskortMomentum WHERE " + key+ "='"+value+"'", sql);
			cmd.ExecuteNonQuery();
		}
	}
}
